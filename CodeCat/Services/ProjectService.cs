using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using CodeCat.DAL;
using CodeCat.Models;
using CodeCat.Services;



namespace CodeCat.Services
{
    public class ProjectService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        public ProjectModel project;

        public List<ProjectModel> getAllProjects()
        {
            return _db.ProjectModel.ToList();

        }

        public bool getProject(int projectID)
        {
            return false;
        }

        public bool addProject(ProjectModel project)
        {
          /*  ProjectModel newProject = new ProjectModel();
            newProject.creatorUserID = 1;
            newProject.ID = 5;
            newProject.name = "Bla";*/

            _db.ProjectModel.Add(project);
            _db.SaveChanges();

            return true;
          
            //return _db.ProjectModel.Add(project);
        }

        public UserModel getProjectCreator(int projectID)
        {
            return null;
        }

        public bool share(int userID)
        {
            return false;
        }
    }
}