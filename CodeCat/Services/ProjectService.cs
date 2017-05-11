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
    public class ProjectService
    {
        ApplicationDbContext _db;

        public ProjectService()
        {
            _db = new ApplicationDbContext();
        }

        public ProjectModel project;

        //Returns all the projects a user has access to both which he created and others shared with him

        /*public ProjectService(IAppDataContext context) : base(context)
        {
            // db = context ?? new ApplicationDbContext();
        }*/

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

        //Filters project by name(ascending and descending), newest/oldest project
        //
        public List<ProjectModel> getProjectFiltered(string userName, int option)
        {
            ApplicationUser user = _db.Users.FirstOrDefault(x => x.Email == userName);

            List<ProjectModel> list = getAllProjects(userName);

            switch(option)
            {
                case 1: //By project name ascending
                    var ascending = from lis in list
                                 orderby lis.name ascending
                                 select lis;

                    return ascending.ToList();
                    
                case 2: //By project name descending
                    var descending = from lis in list
                                 orderby lis.name descending
                                 select lis;

                    return descending.ToList();
                    
                case 3: //By newest
                    var newest = from lis in list
                                     orderby lis.ID descending
                                     select lis;

                    return newest.ToList();
                    
                case 4: //By oldest
                    var oldest = from lis in list
                                 orderby lis.ID ascending
                                 select lis;

                    return oldest.ToList();

                case 5: //By creator
                    var creator = from lis in list
                                 orderby lis.creatorUserID != user.Id
                                 select lis;

                    return creator.ToList();

                case 6: //By share
                    var share = from lis in list
                                  orderby lis.creatorUserID == user.Id
                                  select lis;

                    return share.ToList();
                default:
                    Console.WriteLine("Default case");
                    break;
            }

            return list;
        }

        //Returns all the documents within a project
        public List<DocumentModel> getProject(int projectID)
        {
            var result = from docs in _db.DocumentModel
                         where docs.projectID == projectID
                         select docs;

            List<DocumentModel> documents = result.ToList();
            documents.Reverse();

            return documents;
        }

        //Gets a list of projects created by a specific user
        public List<ProjectModel> getUserProjects(string username)
        {
            ApplicationUser user = _db.Users.FirstOrDefault(x => x.Email == username);
            return _db.ProjectModel.Where(x => x.creatorUserID == user.Id).ToList();
        }

        //Adds a projects to the database
        public void addProject(ProjectModel project, string username)
        {
            project.creatorUserID = getProjectCreatorByID(username);

            _db.ProjectModel.Add(project);
            _db.SaveChanges();
        }

        //Returns projects creator id
        public string getProjectCreatorByID(string username)
        {
            ApplicationUser user = _db.Users.FirstOrDefault(x => x.Email == username);

            return user.Id;
        }

        //Deletes a projects, including all documents within it
        //and all connections to users in the connection table
        public void deleteProject(int projectID)
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