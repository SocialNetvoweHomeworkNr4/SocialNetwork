using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNetwork.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name ="E-mail")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your e-mail")]
        public string Email { get; set; }

        [Display(Name = "Parole")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }

    }
}