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

        public bool getProject(int projectID)
        {
            return false;
        }

        public bool addProject(ProjectModel project)
        {
            // _db.ProjectModel.Add(project);
            //_db.SaveChanges();

            addProjectToDB(project);

            return true;
          
            //return _db.ProjectModel.Add(project);
        }

        public string getProjectCreatorID()
        {
            //return _db.AspNetUsers.FirstOrDefault(x => x.Email == model.Email);
            return getProjectCreatorID();
        }

        public bool share(int userID)
        {
            return false;
        }
    }
}