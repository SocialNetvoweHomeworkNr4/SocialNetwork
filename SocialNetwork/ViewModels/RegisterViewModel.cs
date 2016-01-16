using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNetwork.ViewModels
{
    public class RegisterViewModel
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Lūdzu ievadiet savu vārdu")]
        [Display(Name = "Vārds")]
        public string Firstname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Lūdzu ievadiet savu uzvārdu")]
        [Display(Name = "Uzvārds")]
        public string Lastname { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Lūdzu ievadiet e-pasta adresi")]
        [Display(Name ="E-pasts")]
        public string Email { get; set; }

        [Display(Name = "Dzimums")]
        public bool Gender { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Lūdzu ievadiet paroli")]
        [Display(Name = "Parole")]
        [MinLength(length:5,ErrorMessage = "Parolei jābūt vismaz 5 simbolu garai")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false,ErrorMessage = "Lūdzu atkārtojiet paroli")]
        [Display(Name = "Atkārtojiet paroli")]
        [Compare("Password", ErrorMessage = "Parolēm ir jāsakrīt")]
        [DataType(DataType.Password)]
        public string RepeatPassword { get; set; }


    }
}