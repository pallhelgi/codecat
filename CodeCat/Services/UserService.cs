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
        public IAppDataContext _db;

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
                UserID = user.Id,
                ProjectID = projectID
            };

            _db.UserProjectModel.Add(link);
            _db.SaveChanges();

        }

        //retursn a list of usres who are part of a specfic project
        public List<ApplicationUser> getUsersSharingADocument(int projID)
        {
            var result = from u in _db.Users
                         join con in _db.UserProjectModel
                         on u.Id equals con.UserID
                         where con.ProjectID == projID
                         select u;

            var resultOwner = from u in _db.Users
                              join proj in _db.ProjectModel
                              on u.Id equals proj.creatorUserID
                              where proj.ID == projID
                              select u;

            List<ApplicationUser> users = result.ToList();
            ApplicationUser user = resultOwner.ToList().FirstOrDefault();

            users.Add(user);

            return users;
        }

        //Returns a list of users
        public List<ApplicationUser> getUsers()
        {
            return _db.Users.ToList();
        }
    }
}