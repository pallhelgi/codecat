﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void deleteDocument4()
        {
            // Arrange:
            const int id = 4;

            // ACT:

            _service.deleteDocument(id);
            var result = _service.getDocumentByID(4);
            var result1 = _service.getDocumentByID(1);

            // Assert:

            Assert.AreEqual(null, result);
            Assert.AreEqual("doc1", result1.name);

        }

    }
}
