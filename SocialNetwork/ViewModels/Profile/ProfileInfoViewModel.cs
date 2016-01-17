using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialNetwork.ViewModels.Profile
{
    public class ProfileInfoViewModel
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name = "Name")]
        public string Firstname { get; set; }

        [Display(Name = "Surname")]
        public string Lastname { get; set; }

        [Display(Name = "Birth date")]
        public string BirthDate { get; set; }

        [Display(Name = "Phone number")]
        public string Phone { get; set; }

        [Display(Name = "Interests")]
        public string Interests { get; set; }

        [Display(Name = "About")]
        public string Information { get; set; }

        [Display(Name = "Profile image")]
        public string ImagePath { get; set; }
        
    }
}