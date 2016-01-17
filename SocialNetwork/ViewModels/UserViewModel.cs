using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.ViewModels
{
    public class UserViewModel
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte Gender { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Interests { get; set; }
        public string About { get; set; }
        public string Avatar { get; set; }
        public string Password { get; set; }
    }
}