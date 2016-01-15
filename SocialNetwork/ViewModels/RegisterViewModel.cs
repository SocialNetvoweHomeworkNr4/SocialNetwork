﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNetwork.ViewModels
{
    public class RegisterViewModel
    {

        public int UserId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Lūdzu ievadiet e-pasta adresi")]
        [Display(Name ="E-pasta adrese")]
        public string Email { get; set; }

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