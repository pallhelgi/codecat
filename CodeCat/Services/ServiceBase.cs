using CodeCat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CodeCat.Services
{
    public class ServiceBase
    {
        //Connecting the serviceBase to the appDbContext class which speaks to the database(sql)
        public ApplicationDbContext _db; //= new ApplicationDbContext();

        public ServiceBase()
        {
            _db = new ApplicationDbContext();
        }

        public List<ProjectModel> getAllProjectsFromDb()
        {
            return _db.ProjectModel.ToList();
        }

        public ProjectModel getProjectByID(int id)
        {
            return null;
        }

        public bool addProject(int creatorID, ProjectModel project)
        {
           // _db.ProjectModel.Add(project);
            //_db.SaveChanges();

            //MUNA AD BREYTA SVO THETTA SE EKKI ALLTAF TRUE
            return true;
        }

        public DocumentModel getDocumentByID(int documentID)
        {
            return null;
        }

        public bool addDocument(DocumentModel document)
        {
            return false;
        }

        public UserModel getuserByID(int userID)
        {
            return null;
        }

        public bool addUser(UserModel user)
        {
            _db.UserModel.Add(user);
            _db.SaveChanges();
            
            return false;
        }
    }
}