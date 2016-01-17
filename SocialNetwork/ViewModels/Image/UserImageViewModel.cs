using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.ViewModels.Image
{
    public class UserImageViewModel
    {
        public int ImageID { get; set; }
        public int UserID { get; set; }
        public string FileName { get; set; }
        public string Comment { get; set; }
        public string Date { get; set; }
        public IList<ImageCommentViewModel> Comments { get; set;}
    }
}