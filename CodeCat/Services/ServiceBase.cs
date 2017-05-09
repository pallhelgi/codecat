using CodeCat.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeCat.TestClasses;



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


        //gets a list of projects connected to a specific user
        public List<ProjectModel> getAllProjectsFromDB(string userName)
        {
            //ApplicationUser user = _db.Users.FirstOrDefault(x => x.Email == "pallhelgi@gmail.com");
            //string userID = "1"; //test for now should be in funciton
            //This is a work in process

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
            //return _db.ProjectModel.ToList();

            /*Trying to make a cleaner code, didn't return in the order I wanted
             * var resultUnion = result.Union(_db.ProjectModel.Where(x => x.creatorUserID == user.Id)).ToList();
            return resultUnion;*/

            return lis;
        }

        public ProjectModel getProjectByID(int projectID)
        {
          
            return _db.ProjectModel.FirstOrDefault(x => x.ID == projectID);
        }

        //gets a list of projects created by a specific user
        public List<ProjectModel> getUserProjectsFromDB(string username)
        {

            ApplicationUser user = _db.Users.FirstOrDefault(x => x.Email == username);
            return _db.ProjectModel.Where(x => x.creatorUserID == user.Id).ToList();
        }

        //adds a project to database
        public bool addProjectToDB(ProjectModel project)
        {
            _db.ProjectModel.Add(project);
            _db.SaveChanges();

            //MUNA AD BREYTA SVO THETTA SE EKKI ALLTAF TRUE
            return true;
        }

        public bool saveDocumentToDB(int documentID, string content)
        {
            var replace = from doc in _db.DocumentModel
                          where doc.ID == documentID
                          select doc;

            foreach(DocumentModel doc in replace)
            {
                doc.content = content;
            }

            _db.SaveChanges();

            return true;
        }

        //Deletes a single document from database
        public bool deleteDocumentFromDB(int documentID)
        {
            var delete = from doc in _db.DocumentModel
                         where doc.ID == documentID
                         select doc;

            var item = delete.ToList().First();
            _db.DocumentModel.Remove(item);
            

            return true;
        }

        public bool deleteProjectFromDB(int projectID)
        {
            var deleteDocuments = from documents in _db.DocumentModel
                                  where documents.projectID == projectID
                                  select documents;

            var docs = deleteDocuments.ToList();

            foreach(DocumentModel doc in docs)
            {
                _db.DocumentModel.Remove(doc);
            }

            var deleteProject = from projects in _db.ProjectModel
                                where projects.ID == projectID
                                select projects;

            var project = deleteProject.ToList().First();
            _db.ProjectModel.Remove(project);

            return true;
        }

        //Might want to rename this properly
        //Is supposed to retrieve all documents contained in a single project and return them
        public List<DocumentModel> getProjectFromDB(int projectID)
        {
            //This is a work in process
            var result = from docs in _db.DocumentModel
                         where docs.projectID == projectID
                         select docs;

            List<DocumentModel> documents = result.ToList();

            return documents;
        }

        public DocumentModel getDocumentByID(int documentID)
        {
            return _db.DocumentModel.FirstOrDefault(x => x.ID == documentID);
        }

        //adds a doccument to database
        public bool addDocumentToDB(DocumentModel document)
        {
            _db.DocumentModel.Add(document);
            _db.SaveChanges();

            return true;
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

        //shares the project with another user
        public bool shareToDB(string email, int projectID)
        {
            ApplicationUser user = _db.Users.FirstOrDefault(x => x.Email == email);

            var link = new UserProjectModel
            {
                UserID = user.Id,
                ProjectID = projectID
            };

            _db.UserProjectModel.Add(link);
            _db.SaveChanges();

            return true;
        }

        //Links the user to a project
        public bool linkUserToProjectInDB(string email)
        {
            ApplicationUser user = _db.Users.FirstOrDefault(x => x.Email == email);
            //Todo: link the user to the project in the database.
            return true;
        }

    }
}