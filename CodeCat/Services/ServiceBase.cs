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
            /*This is a work in process
             * var result = from projects in _db.ProjectModel
                         join users in _db.Users
                         on projects.users equals users.Id
                         where users.id == userID
                         select projects;*/
          
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

        //Might want to rename this properly
        //Is supposed to retrieve all documents contained in a single project and return them
        public List<DocumentModel> getProjectFromDB(int projectID)
        {
            /*This is a work in process
             * var result = from docs in _db.DocumendModel
                         join project in _db.ProjectModel
                         on docs.projects.ID equals project.ID
                         where docs.projects.ID == projectID
                         select docs;
                            

            List<DocumentModel> documents = new List<DocumentModel>();
            documents = result.ToList();*/

            return null;
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

        public bool linkUserToProjectInDB(string email)
        {

            ApplicationUser user = _db.Users.FirstOrDefault(x => x.Email == email);
            //Todo: link the user to the project in the database.
            return true;
        }

    }
}