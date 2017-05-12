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
        private IAppDataContext _db;

        public UserService(IAppDataContext context)
        {
            _db = context ?? new ApplicationDbContext();
        }

        //Sharing a project with another user
        public void share(string email, int projectID)
        {
            ApplicationUser user = _db.Users.FirstOrDefault(x => x.Email == email);
            var link = new UserProjectModel
            {
                userID = user.Id,
                projectID = projectID
            };

            List<UserProjectModel> links = _db.UserProjectModel.ToList();

            foreach(var l in links)
            {
                if(l.projectID == link.projectID && l.userID == link.userID)
                {
                    return;
                }
            }
            _db.UserProjectModel.Add(link);
            _db.SaveChanges();

        }

        //retursn a list of usres who are part of a specfic project
        public List<ApplicationUser> getUsersSharingADocument(int projID)
        {
            var result = from u in _db.Users
                         join con in _db.UserProjectModel
                         on u.Id equals con.userID
                         where con.projectID == projID
                         select u;

            List<ApplicationUser> users = result.ToList();

            return users;
        }

        //Returns a list of users
        public List<ApplicationUser> getUsers()
        {
            return _db.Users.ToList();
        }
    }
}