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
        [DataType(DataType.Password)]
        public string password { get; set; }

        [Display(Name = "Confirm password")]
        //[Required(ErrorMessage = "You must enter a password!")]
        [Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        [DataType(DataType.Password)]
        public string confirmPassword { get; set; }

        [EmailAddress(ErrorMessage ="Please enter a valid email address!")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "You must enter an email!")]
        public string email { get; set; }

        [Display(Name = "Full name")]
        public string fullName { get; set; }
    }
}