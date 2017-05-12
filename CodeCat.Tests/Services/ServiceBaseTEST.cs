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
    public class ServiceBaseTest
    {
       /* private ServiceBase _service;

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
                projectID = 1,
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

            //ProjectModel table
            var p1 = new ProjectModel
            {
                ID = 1,
                name = "gandalf",
                creatorUserID = "mellon"
            };
            mockDb.ProjectModel.Add(p1);

            var p2 = new ProjectModel
            {
                ID = 2,
                name = "gimli",
                creatorUserID = "jon"
            };
            mockDb.ProjectModel.Add(p2);

            var p3 = new ProjectModel
            {
                ID = 3,
                name = "frodo",
                creatorUserID = "mellon"
            };
            mockDb.ProjectModel.Add(p3);

            _service = new ServiceBase(mockDb);
        }

        [TestMethod]
        public void getProject3()
        {
            // Arrange:
            int projID = 3;
            string name = "frodo";
            string wrongName = "gimli";

            // ACT:

            var result = _service.getProjectByID(3);

            // Assert:

            Assert.AreEqual(name, result.name);
            Assert.AreNotEqual(wrongName, result.name);

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
        public void getProjectFromDoc4()
        {
            // Arrange:
            int docID = 4;

            // ACT:

            //Returns the projectID of the project that contains the document
            var result = _service.getProjectByDocumentID(docID);

            // Assert:

            //The projectID of document 4 is 1
            Assert.AreEqual(1, result);

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
            var result = _service.getProjectByDocumentID(docID);

            // Assert:
        }*/

    }
}
