using CodeCat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeCat.TestClasses
{
    //lists of projects, documents and users to test with before database is used
    public class testClass
    {
        List<ProjectModel> projects = new List<ProjectModel>();

        ProjectModel project1 = new ProjectModel
        {
            ID = 0,
            name = "Project 1",
            creatorUserID = 1
        };

        ProjectModel project2 = new ProjectModel
        {
            ID = 1,
            name = "Project 2",
            creatorUserID = 1
        };

        ProjectModel project3 = new ProjectModel
        {
            ID = 2,
            name = "Project 3",
            creatorUserID = 1
        };
    }
}