using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeCat.Models
{
    public class ProjectModel
    {
        public int ID { get; set; }
        [Display(Name = "Project name")]
        [Required(ErrorMessage = "You must enter a name for the project!")]
        public string name { get; set; }
        public int creatorUserID { get; set; }
    }
}