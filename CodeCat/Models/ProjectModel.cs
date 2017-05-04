using System;
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
        [Required(ErrorMessage = "You must enter a name for the project!")]
        public string name { get; set; }

        [ForeignKey("User")] //veit ekki hvort þetta sé rétt
        public int creatorUserID { get; set; }
    }
}