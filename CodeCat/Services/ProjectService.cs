using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeCat.Models;
using CodeCat.Services;
using Microsoft.AspNet.Identity;



namespace CodeCat.Services
{
    public class ProjectService : ServiceBase
    {
        public ProjectModel project;

        public ProjectService(IAppDataContext context) : base(context)
        {
            // db = context ?? new ApplicationDbContext();
        }

        //Returns all the projects a user has access to
        public List<ProjectModel> getAllProjects(string userName)
        {
            ApplicationUser user = _db.Users.FirstOrDefault(x => x.Email == userName);
            var result = from proj in _db.ProjectModel
                         join con in _db.UserProjectModel
                         on proj.ID equals con.ProjectID
                         where con.UserID == user.Id
                         select proj;

            List<ProjectModel> lis = new List<ProjectModel>();
            List<ProjectModel> lis2 = new List<ProjectModel>();

            lis = _db.ProjectModel.Where(x => x.creatorUserID == user.Id).ToList();
            lis2 = result.ToList();

            lis2.ForEach(l => lis.Add(l));

            return lis;
        }

        //Returns all the documents within a project
        public List<DocumentModel> getProject(int projectID)
        {
            var result = from docs in _db.DocumentModel
                         where docs.projectID == projectID
                         select docs;

            List<DocumentModel> documents = result.ToList();

            return documents;
        }

        //Gets a list of projects created by a specific user
        public List<ProjectModel> getUserProjects(string username)
        {
            ApplicationUser user = _db.Users.FirstOrDefault(x => x.Email == username);
            return _db.ProjectModel.Where(x => x.creatorUserID == user.Id).ToList();
        }

        //Adds a projects to the database
        public bool addProject(ProjectModel project, string username)
        {
            project.creatorUserID = getProjectCreatorByID(username);

            _db.ProjectModel.Add(project);
            _db.SaveChanges();

            return true;
        }

        //Returns projects creator id
        public string getProjectCreatorByID(string username)
        {
            ApplicationUser user = _db.Users.FirstOrDefault(x => x.Email == username);

            return user.Id;
        }

        //Deletes a projects, including all documents within it
        //and all connections to users in the connection table
        public bool deleteProject(int projectID)
        {
            var deleteDocuments = from documents in _db.DocumentModel
                                  where documents.projectID == projectID
                                  select documents;

            var docs = deleteDocuments.ToList();

            foreach (DocumentModel doc in docs)
            {
                _db.DocumentModel.Remove(doc);
            }

            var deleteConnection = from proj in _db.UserProjectModel
                                   where proj.ProjectID == projectID
                                   select proj;

            var connection = deleteConnection.ToList();

            foreach (UserProjectModel con in connection)
            {
                _db.UserProjectModel.Remove(con);
            }

            _db.SaveChanges();

            var deleteProject = from proj in _db.ProjectModel
                                where proj.ID == projectID
                                select proj;

            var projects = deleteProject.ToList();

            foreach (ProjectModel project in projects)
            {
                _db.ProjectModel.Remove(project);
            }

            _db.SaveChanges();

            return true;
        }

        //Returns a projects based on it's ID
        //This function also exists in serviceBase,
        //is currently being used by UserController directly to serviceBase
        public ProjectModel getProjectById(int projectID)
        {
            return _db.ProjectModel.FirstOrDefault(x => x.ID == projectID);
        }
    }
}