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
        public void Seed()
        {

            List<ProjectModel> projects = new List<ProjectModel>();

            ProjectModel project1 = new ProjectModel
            {
                ID = 0,
                name = "Project 1",
                creatorUserID = 1
            };

            projects.Add(project1);

            ProjectModel project2 = new ProjectModel
            {
                ID = 1,
                name = "Project 2",
                creatorUserID = 1
            };

            projects.Add(project2);

            ProjectModel project3 = new ProjectModel
            {
                ID = 2,
                name = "Project 3",
                creatorUserID = 1
            };

            projects.Add(project3);

            List<UserModel> users = new List<UserModel>();

            UserModel user1 = new UserModel
            {
                ID = 0,
                userName = "iceHot1",
                email = "bjarnib@n1.is",
                fullName = "Bjarni",
                password = "123456789"
            };

            users.Add(user1);

            UserModel user2 = new UserModel
            {
                ID = 1,
                userName = "Meowzer",
                email = "pallhelgi@ru.is",
                fullName = "Pall",
                password = "123456789"
            };

            users.Add(user2);

            UserModel user3 = new UserModel
            {
                ID = 2,
                userName = "Ziggs",
                email = "waldorf@ru.is",
                fullName = "Siggi",
                password = "123456789"
            };

            users.Add(user3);

            List<DocumendModel> documents = new List<DocumendModel>();

            DocumendModel doc1 = new DocumendModel
            {
                ID = 0,
                name = "doc1",
                content = "There once was a little boy name Paul, and he was all alone in the whole wide cosmos, which...",
            };

            documents.Add(doc1);

            DocumendModel doc2 = new DocumendModel
            {
                ID = 1,
                name = "doc2",
                content = "In a galaxy far, far away, a boy found out his father was the dark lord of the sith and a mass murdered..."
            };

            documents.Add(doc2);

            DocumendModel doc3 = new DocumendModel
            {
                ID = 2,
                name = "doc3",
                content = "You're a Lizzard Harrrry! Haggy said with a frown. What a sad fate that is...",
            };

            documents.Add(doc3);

        }
    }
}