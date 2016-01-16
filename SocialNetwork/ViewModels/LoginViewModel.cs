using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNetwork.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name ="E-pasts")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ievadiet e-pasta adresi")]
        public string Email { get; set; }

        [Display(Name = "Parole")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ievadiet paroli")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Atcerēties mani")]
        public bool RememberMe { get; set; }

    }
}