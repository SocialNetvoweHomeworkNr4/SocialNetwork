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

        [Display(Name = "Vārds")]
        public string Firstname { get; set; }

        [Display(Name = "Uzvārds")]
        public string Lastname { get; set; }

        [Display(Name = "Dzimšanas datums")]
        public string BirthDate { get; set; }

        [Display(Name = "Telefona nr.")]
        public string Phone { get; set; }

        [Display(Name = "Intereses")]
        public string Interests { get; set; }

        [Display(Name = "Cita informācija")]
        public string Information { get; set; }

        [Display(Name = "Profila attēls")]
        public string ImagePath { get; set; }
        
    }
}