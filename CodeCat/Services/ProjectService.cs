using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using CodeCat.DAL;
using CodeCat.Models;
using CodeCat.Services;
using Microsoft.AspNet.Identity;



namespace CodeCat.Services
{
    public class ProjectService : ServiceBase
    {
        //private ApplicationDbContext _db = new ApplicationDbContext();
        public ProjectModel project;

        public List<ProjectModel> getAllProjects()
        {
            // return _db.ProjectModel.ToList();
            return getAllProjectsFromDB();

        }

        public List<ProjectModel> getUserProjects(string username)
        {
            return getUserProjectsFromDB(username);
        }

        public bool addProject(ProjectModel project, string username)
        {
            // _db.ProjectModel.Add(project);
            //_db.SaveChanges();

            project.creatorUserID = getProjectCreatorByID(username);

            addProjectToDB(project);


            return true;
          
            //return _db.ProjectModel.Add(project);
        }

        public string getProjectCreatorID()
        {
            return getProjectCreatorID();
        }

        public bool share(int userID)
        {
            return false;
        }
    }
}