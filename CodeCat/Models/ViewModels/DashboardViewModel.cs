using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CodeCat.Models;
using CodeCat.TestClasses;

namespace CodeCat.Models.ViewModels
{
    public class DashboardViewModel
    {
        public List<ProjectModel> projects { get; set; }
    }
}