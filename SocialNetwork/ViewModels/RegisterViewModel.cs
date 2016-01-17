using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNetwork.ViewModels
{
    public class RegisterViewModel
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your name")]
        [Display(Name = "Name")]
        public string Firstname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your surname")]
        [Display(Name = "Surname")]
        public string Lastname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your e-mail")]
        [Display(Name ="E-mail")]
        public string Email { get; set; }

        [Display(Name = "Gender")]
        public bool Gender { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your password")]
        [Display(Name = "Password")]
        [MinLength(length:5,ErrorMessage = "Password must contain at least 5 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false,ErrorMessage = "Please repeat your password")]
        [Display(Name = "Repeat password")]
        [Compare("Password", ErrorMessage = "Password must match")]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }


    }
}