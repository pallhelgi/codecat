using CodeCat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace CodeCat.Services
{
    public class ServiceBase
    {
        public ProjectModel getProjectByID(int id)
        {
            return null;
        }

        public bool addProject(int creatorID, ProjectModel project)
        {
            return false;
        }

        public DocumendModel getDocumentByID(int documentID)
        {
            return null;
        }

        public bool addDocument(DocumendModel document)
        {
            return false;
        }

        public UserModel getuserByID(int userID)
        {
            return null;
        }

        public bool addUser(UserModel user)
        {
            return false;
        }
    }
}