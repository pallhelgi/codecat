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

        List<UserModel> users = new List<UserModel>();

        UserModel user1 = new UserModel
        {
            ID = 0,
            userName = "iceHot1",
            email = "bjarnib@n1.is",
            fullName = "Bjarni",
            password = "123456789"
        };

        UserModel user2 = new UserModel
        {
            ID = 1,
            userName = "Meowzer",
            email = "pallhelgi@ru.is",
            fullName = "Pall",
            password = "123456789"
        };

        UserModel user3 = new UserModel
        {
            ID = 2,
            userName = "Ziggs",
            email = "waldorf@ru.is",
            fullName = "Siggi",
            password = "123456789"
        };
    }
}