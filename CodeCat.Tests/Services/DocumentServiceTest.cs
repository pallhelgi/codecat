using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCat.Services;
using CodeCat.Tests;
using CodeCat.Models;

namespace CodeCat.Tests.Services
{

    [TestClass]
    public class DocumentServiceTest
    {
        private DocumentService _service;

        [TestInitialize]
        public void Initializer()
        {
            var mockDb = new MockDatabase();

            //DocumentModel table
            var f1 = new DocumentModel
            {
                ID = 1,
                content = "Lorem ipsum Doc1",
                name = "doc1",
                projectID = 1,
                type = 0
            };
            mockDb.DocumentModel.Add(f1);

            var f2 = new DocumentModel
            {
                ID = 2,
                content = "Lorem ipsum Doc2",
                name = "doc2",
                projectID = 2,
                type = 0
            };
            mockDb.DocumentModel.Add(f2);

            var f3 = new DocumentModel
            {
                ID = 4,
                content = "Lorem ipsum Doc3",
                name = "This name is taken!",
                projectID = 3,
                type = 0
            };
            mockDb.DocumentModel.Add(f3);

            //Users table

            var u1 = new ApplicationUser
            {
                Id = "mellon",
                Email = "mellon@mellon.com"

            };
            mockDb.Users.Add(u1);

            var u2 = new ApplicationUser
            {
                Id = "jon",
                Email = "jon@jon.com"
            };
            mockDb.Users.Add(u2);

            var u3 = new ApplicationUser
            {
                Id = "stina",
                Email = "stina@stina.com"

            };
            mockDb.Users.Add(u3);

            //UserProject table

            var UP1 = new UserProjectModel
            {
                ID = 1,
                UserID = "mellon",
                ProjectID = 1
            };
            mockDb.UserProjectModel.Add(UP1);

            var UP2 = new UserProjectModel
            {
                ID = 2,
                UserID = "stina",
                ProjectID = 2
            };
            mockDb.UserProjectModel.Add(UP2);

            _service = new DocumentService(mockDb);
        }

        [TestMethod]
        public void saveDocument1()
        {
            // Arrange:
            int docID = 1;
            string content = "I'm updated!";

            // ACT:

            _service.saveDocument(docID, content);
            var result = _service.getDocumentByID(docID);

            // Assert:

            Assert.AreEqual(content, result.content);

        }

        [TestMethod]
        public void addDocument()
        {
            // Arrange:
            DocumentModel doc = new DocumentModel
            {
                ID = 10,
                name = "I'm new!",
                projectID = 3
            };

            DocumentModel doc2 = new DocumentModel
            {
                ID = 11,
                name = "This name is taken!",
                projectID = 3
            };

            // ACT:

            var result = _service.addDocument(doc);
            var result2 = _service.addDocument(doc2); 

            // Assert:

            Assert.AreEqual(true, result);
            Assert.AreEqual(false, result2);

        }


        [TestMethod]
        [ExpectedException(typeof(Exception), "That document id is invalid")]
        public void deleteDocument1()
        {
            // Arrange:
            const int id = 1;

            // ACT:

            _service.deleteDocument(id);

            //If the document no longer exists, getDocumentByID should throw an
            //exception
            var result = _service.getDocumentByID(id);

            // Assert:

        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void deleteDocument6()
        {
            // Arrange:
            const int id = 6;

            // ACT:

            //Document 6 does not exists, and therefore an exception should be thrown
            _service.deleteDocument(id);

            // Assert:

        }

        [TestMethod]
        public void getProjectFromDoc4()
        {
            // Arrange:
            int docID = 4;

            // ACT:

            //Returns the projectID of the project that contains the document
            var result = _service.getProjectIDByDocumentID(docID);

            // Assert:

            //The projectID of document 4 is 1
            Assert.AreEqual(3, result);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "That document id is invalid")]
        public void getProjectFromDoc3()
        {
            // Arrange:

            //There is no document with the id 3
            int docID = 3;

            // ACT:

            //Returns the projectID of the project that contains the document
            var result = _service.getProjectIDByDocumentID(docID);

            // Assert:
        }

        [TestMethod]
        public void getDocument2()
        {
            // Arrange:
            int docID = 2;
            string content = "Lorem ipsum Doc2";

            // ACT:

            var result = _service.getDocumentByID(docID);

            // Assert:

            Assert.AreEqual(content, result.content);

        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "That document id is invalid")]
        public void getDocument10()
        {
            // Arrange:
            int docID = 10;
          //  string content = "Lorem ipsum Doc2";

            // ACT:

            var result = _service.getDocumentByID(docID);

            // Assert:

        }

    }
}
