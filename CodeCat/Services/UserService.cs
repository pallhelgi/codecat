using CodeCat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeCat.Services;

namespace CodeCat.Services
{
    public class UserService
    {
        ServiceBase baas = new ServiceBase();
        public UserModel user;

        public bool getUser(int userID)
        {
            return false;
        }

        public List<UserModel> listUsers(int projectID)
        {
            return null;
        }

        public bool addUser(UserModel user)
        {       
            baas.addUser(user);
            return false;
        }
    }
}