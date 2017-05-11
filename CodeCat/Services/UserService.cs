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
        public UserService(IAppDataContext context) : base(context)
        {
            // db = context ?? new ApplicationDbContext();
        }

        public void share(string email, int projectID)
        {
            ApplicationUser user = _db.Users.FirstOrDefault(x => x.Email == email);
            var link = new UserProjectModel
            {
                UserID = user.Id,
                ProjectID = projectID
            };

            _db.UserProjectModel.Add(link);
            _db.SaveChanges();

        }

        public List<ApplicationUser> getUsersSharingADocument(int projID)
        {
            var result = from user in _db.Users
                         join con in _db.UserProjectModel
                         on user.Id equals con.UserID
                         where con.ProjectID == projID
                         select user;
            List<ApplicationUser> users = result.ToList();

            return users;
        }
    }
}