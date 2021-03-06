﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeCat.Models;
using System.Web.Mvc;

namespace CodeCat.Models.ViewModels
{
    public class ProjectViewModel
    {
        public List<DocumentModel> documents;

        public ProjectModel project;

        public SideBarViewModel sidebar;

        public string userEmail { get; set; }

        public string projectName { get; set; }
    }
}