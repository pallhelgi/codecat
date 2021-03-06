﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeCat.Models
{
    public class ProjectModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Project name")]
        [Required(ErrorMessage = "You must enter a name for the project!"), MaxLength(20, ErrorMessage = "Project name must be less than 20 characters long")]
        public string name { get; set; }
        
        public string creatorUserID { get; set; }
    }
}