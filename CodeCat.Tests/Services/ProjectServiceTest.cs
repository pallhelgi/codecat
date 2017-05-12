using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCat.Services;
using CodeCat.Tests;
using CodeCat.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CodeCat.Tests.Services
{

    [TestClass]
    public class ProjectServiceTest
    {
        private ProjectService _service;

        [TestInitialize]
        public void Initializer()
        {
            var mockDb = new MockDatabase();

            //DocumentModel table
            var f1 = new DocumentModel
            {
                ID = 1,
                content = "Lorem ipsum",
                name = "doc1",
                projectID = 1,
                type = 0     
            };
            mockDb.DocumentModel.Add(f1);

            var f2 = new DocumentModel
            {
                ID = 2,
                content = "Lorem ipsum",
                name = "doc2",
                projectID = 2,
                type = 0
            };
            mockDb.DocumentModel.Add(f2);

            var f3 = new DocumentModel
            {
                ID = 4,
                content = "Lorem ipsum",
                name = "doc3",
                projectID = 1,
                type = 0
            };
            mockDb.DocumentModel.Add(f3);

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
                userID = "mellon",
                projectID = 1
            };
            mockDb.UserProjectModel.Add(UP1);

            var UP2 = new UserProjectModel
            {
                ID = 2,
                userID = "stina",
                projectID = 2
            };
            mockDb.UserProjectModel.Add(UP2);

            var UP3 = new UserProjectModel
            {
                ID = 3,
                userID = "mellon",
                projectID = 2
            };
            mockDb.UserProjectModel.Add(UP3);


            _service = new ProjectService(mockDb);
        }


        [TestMethod]
        public void getAllProjectsForMellon()
        {
            // Arrange:

            const string username = "mellon@mellon.com";

            // ACT:

            var result = _service.getAllProjects(username);

            // Assert:

            //There are two documents in the MockDB with the projectID '1'.
            Assert.AreEqual(2, result.Count);
            //Assert.AreEqual("doc3", result[1].name);
        }

        [TestMethod]
        public void getProjectForProjectID1()
        {
            // Arrange:

            const int projID = 1;

            // ACT:

            var result = _service.getProject(projID);

            // Assert:

            //There are two documents in the MockDB with the projectID '1'.
            Assert.AreEqual(2, result.Count);

            foreach(var proj in result)
            {
                Assert.AreEqual(1, proj.projectID);
            }
        }

        [TestMethod]
        public void filterProjectsByNameDescending()
        {
            // Arrange:
            //2 is the "sort by name descending" id
            const int id = 2;
            const string username = "mellon@mellon.com";

            // ACT:

            var result = _service.getProjectFiltered(username, id);

            // Assert:

            Assert.AreEqual(2, result.Count);

            Assert.AreEqual("gandalf", result[1].name);
        }

        [TestMethod]
        public void filterProjectsByOldest()
        {
            // Arrange:
            //4 is the "sort by name descending" id
            const int id = 4;
            const string username = "mellon@mellon.com";

            // ACT:

            var result = _service.getProjectFiltered(username, id);

            // Assert:

            Assert.AreEqual(2, result.Count);

            Assert.AreEqual("gimli", result[1].name);
        }


        [TestMethod]
        public void getUserProjectsForMellon()
        {
            // Arrange:

            const string username = "mellon@mellon.com";

            // ACT:

            var result = _service.getUserProjects(username);

            // Assert:

            //There are two documents in the MockDB with the projectID '1'.
            Assert.AreEqual(2, result.Count);
            //The second projectID should be 3 (see var p3)
            Assert.AreEqual(3, result[1].ID);
        }


        [TestMethod]
        public void getProjectCreatorMellon()
        {
            // Arrange:

            const string username1 = "mellon@mellon.com";
            const string username2 = "stina@stina.com";

            // ACT:

            var result1 = _service.getProjectCreatorByID(username1);
            var result2 = _service.getProjectCreatorByID(username2);

            // Assert:

            Assert.AreEqual("mellon", result1);
            Assert.AreEqual("stina", result2);
        }

        [TestMethod]
        public void deleteProject1()
        {
            // Arrange:

            const int projID = 1;

            // ACT:

            _service.deleteProject(projID);
            //mellon is the creator of project1
            var deleted = _service.getUserProjects("mellon@mellon.com");

            // Assert:

            //Mellon previously had two projects, and should therefore
            //now have only one
            Assert.AreEqual(1, deleted.Count);
        }

        [TestMethod]
        public void getProjectByID1()
        {
            // Arrange:

            const int projID = 1;

            // ACT:

            var result = _service.getProjectById(projID);
            //mellon is the creator of project1

            // Assert:

            Assert.AreEqual("gandalf", result.name);
        }

    }
}
