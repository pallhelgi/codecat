using CodeCat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeCat.Services;

namespace CodeCat.Services
{
    public class UserService : ServiceBase
    {
        //  ServiceBase baas = new ServiceBase();
        public UserModel user;

        public bool share(string email, int projectID)
        {
            ApplicationUser user = _db.Users.FirstOrDefault(x => x.Email == email);

            var link = new UserProjectModel
            {
                UserID = user.Id,
                ProjectID = projectID
            };

            _db.UserProjectModel.Add(link);
            _db.SaveChanges();

            return true;
        }
    }
}