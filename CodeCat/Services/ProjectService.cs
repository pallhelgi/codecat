using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeCat.Models;
using CodeCat.Services;

namespace CodeCat.Services
{
    public class ProjectService : ServiceBase
    {
        public ProjectModel project;

        public List<ProjectModel> getAllProjects()
        {
            return base.getAllProjects();
        }

        public bool getProject(int projectID)
        {
            return false;
        }

        public bool addProject(int creatorUserID, ProjectModel project)
        {
            return false;
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