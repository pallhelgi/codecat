using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CodeCat.Models
{
    public class UserProjectModel
    {
        [Key]
        public int ID { get; set; }

        public string userID { get; set; }

        public int projectID { get; set; }
    }
}