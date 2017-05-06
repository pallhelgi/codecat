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
        public ApplicationDbContext _db;

        public ServiceBase()
        {
            _db = new ApplicationDbContext();
        }

        public List<ProjectModel> getAllProjects()
        {
            return _db.ProjectModel.ToList();
        }

        public ProjectModel getProjectByID(int projectID)
        {
            ProjectModel project = _db.ProjectModel.Where(x => x.ID == projectID).SingleOrDefault();
            if(project != null)
            {
                ProjectModel model = new ProjectModel();
                model.ID = project.ID;
            }

            return null;
        }

        public bool addProject(int creatorID, ProjectModel project)
        {
            return false;
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