using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeCat.Models
{
    public class ProjectModel
    {
        int ID { get; set; }
        string name { get; set; }
        int creatorUserID { get; set; }
    }
}