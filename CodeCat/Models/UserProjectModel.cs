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

       // [ForeignKey("UserID")]
        public string UserID { get; set; }

       // [ForeignKey("ProjectID")]
        public int ProjectID { get; set; }
    }
}