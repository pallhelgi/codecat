﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using CodeCat.DAL;
using CodeCat.Models;
using CodeCat.Services;



namespace CodeCat.Services
{
    public class ProjectService : ServiceBase
    {
        public ProjectModel project;

        public List<ProjectModel> getAllProjects()
        {
            return getAllProjectsFromDb();
        }

        public bool getProject(int projectID)
        {
            return false;
        }

        public bool addProject(ProjectModel project)
        {
           // if (ModelState.IsValid)
            //{
                ProjectModel newProject = new ProjectModel();
                newProject.ID = 5;
                newProject.name = project.name;

                _db.ProjectModel.Add(newProject);
                _db.SaveChanges();
                return true;
            //}
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