﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeCat.Models;

namespace CodeCat.Models.ViewModels
{
    public class DashboardViewModel
    {
        public List<ProjectModel> projects { get; set; }

        public ProjectModel currProject { get; set; }
    }
}