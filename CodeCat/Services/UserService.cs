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
        //public readonly IAppDataContext db;

        public UserService(IAppDataContext context) : base(context)
        {
           // db = context ?? new ApplicationDbContext();
        }

        //  ServiceBase baas = new ServiceBase();
        public UserModel user;

        public bool share(string email, int projectID)
        {
            ApplicationUser user = _db.Users.FirstOrDefault(x => x.Email == email);

            if(user != null)
            {
                var link = new UserProjectModel
                {
                    UserID = user.Id,
                    ProjectID = projectID
                };

                _db.UserProjectModel.Add(link);
                _db.SaveChanges();

                return true;
            }

            return false;

        }

        public List<ApplicationUser> getUsersSharingADocument(DocumentModel document)
        {
            var result = from user in _db.Users
                         join con in _db.UserProjectModel
                         on user.Id equals con.UserID
                         where con.ProjectID == document.projectID
                         select user;

            return result.ToList();
        }
    }
}