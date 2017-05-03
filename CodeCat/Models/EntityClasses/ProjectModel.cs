using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeCat.Models
{
    public class ProjectModel
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int creatorUserID { get; set; }
    }
}