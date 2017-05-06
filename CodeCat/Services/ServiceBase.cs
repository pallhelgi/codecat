﻿using CodeCat.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



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

        public List<ProjectModel> getAllProjectsFromDB()
        {
            return _db.ProjectModel.ToList();
        }

        /*public ProjectModel getProjectByID(int projectID)
        {
            ProjectModel project = _db.ProjectModel.Where(x => x.ID == projectID).SingleOrDefault();
            if(project != null)
            {
                ProjectModel model = new ProjectModel();
                model.ID = project.ID;
            }

            return null;
        }*/

        public List<ProjectModel> getUserProjectsFromDB(string username)
        {

            ApplicationUser user = _db.Users.FirstOrDefault(x => x.Email == username);
            return _db.ProjectModel.Where(x => x.creatorUserID == user.Id).ToList();
        }

        public bool addProjectToDB(ProjectModel project)
        {
            _db.ProjectModel.Add(project);
            _db.SaveChanges();

            

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

        public string getProjectCreatorByID(string username)
        {
            //return _db.AspNetUsers.FirstOrDefault(x => x.Email == model.Email);

             ApplicationUser user = _db.Users.FirstOrDefault(x => x.Email == username);

            return user.Id;

            //return _db.Users.FirstOrDefault(x => x.Email == Users.Identity.Email);
        }

        public bool addUser(UserModel user)
        {
            _db.UserModel.Add(user);
            _db.SaveChanges();
            
            return false;
        }
    }
}