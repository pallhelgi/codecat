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

            _service = new UserService(mockDb);
        }

     /*   [TestMethod]
        public void shareWithMellon()
        {
            // Arrange:
            string email = "mellon@mellon.com";
            string fakeEmail = "nina@nina.com";

            int projID = 2;

            // ACT:

            var result = _service.share(email, projID);
            var result2 = _service.share(fakeEmail, projID);

            // Assert:

            Assert.AreEqual(true, result);

            //there is no user with the email "nina@nina.com"
            Assert.AreEqual(false, result2);
        }*/
    }
}
