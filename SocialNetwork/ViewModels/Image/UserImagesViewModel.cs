using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.ViewModels.Image
{
    public class UserImagesViewModel
    {
        public int UserId { get; set; }
        public List<UserImageViewModel> Images { get; set; }
    }
}