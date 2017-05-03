using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeCat.Models
{
    public class UserModel
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Username")]
        [Required(ErrorMessage = "You must enter a username!")]
        public string username { get; set; }
        [Display(Name = "Password")]
        [Required(ErrorMessage = "You must enter a password!")]
        public string password { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "You must enter an email!")]
        public string email { get; set; }
        [Display(Name = "Full name")]
        public string fullName { get; set; }
    }
}