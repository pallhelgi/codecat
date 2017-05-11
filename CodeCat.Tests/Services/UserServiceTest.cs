using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodeCat.Services;

namespace CodeCat.Tests.Services
{

    [TestClass]
    public class UserServiceTest
    {
        private UserService _service;

        [TestInitialize]
        public void Initializer()
        {
            //LAGA, A EKKI AD VERA NULL
            _service = new UserService(null);
        }

        [TestMethod]
        public void shareWithMellon()
        {
            // Arrange:

            // ACT:

            // Assert:
        }
    }
}
