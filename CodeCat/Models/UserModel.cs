using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeCat.Models
{
    public class UserModel
    {
        int ID { get; set; }
        string userName { get; set; }
        string password { get; set; }
        string email { get; set; }
        string fullName { get; set; }
    }
}