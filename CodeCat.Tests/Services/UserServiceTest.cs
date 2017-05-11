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
    public class UserServiceTest
    {
        private UserService _service;

        [TestInitialize]
        public void Initializer()
        {
            var mockDb = new MockDatabase();

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

            _service = new UserService(mockDb);
        }

        [TestMethod]
        public void shareWithMellon()
        {
            // Arrange:
            string email = "mellon@mellon.com";
            int projID = 2;

            // ACT:

            var result = _service.share(email, projID);

            // Assert:

            Assert.AreEqual(true, result);
        }
    }
}
