using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.Helpers
{
    public static class UserHelper
    {
        public static string FullName(User user)
        {
            return string.Format("{0} {1}", user.FirstName, user.LastName);
        }
    }
}