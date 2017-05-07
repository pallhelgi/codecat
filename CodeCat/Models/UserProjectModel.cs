using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeCat.Models
{
    public class UserProjectModel
    {
       // [ForeignKey("UserID")]
        public string UserID { get; set; }

       // [ForeignKey("ProjectID")]
        public int ProjectID { get; set; }
    }
}