using BusinessLogic.Providers;
using BusinessLogic.Services;
using System.Linq;
using System.Web.Mvc;
using BusinessLogic.Models;

using System.Text.RegularExpressions;
using SocialNetwork.ViewModels.Profile;
using System;
using System.Globalization;
using BusinessLogic.Helpers;

namespace Website.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private IUserService userService;
        private CustomMembershipProvider provider;


        public ProfileController(IUserService userService)
        {
            this.userService = userService;
            provider = new CustomMembershipProvider();
        }
        public ActionResult Index()
        {
            var profInfoModel = new ProfileInfoViewModel();
            int id = provider.GetUserId();

            if (id != 0)
            {
                var user = userService.GetById(id);

                profInfoModel.BirthDate = user.DateOfBirth.HasValue ? user.DateOfBirth.Value.ToShortDateString() : null;
                profInfoModel.Firstname = user.FirstName;
                profInfoModel.Lastname = user.LastName;
                profInfoModel.Phone = user.PhoneNumber;
                profInfoModel.Interests = user.Interests;
                profInfoModel.Information = user.About;
                profInfoModel.Avatar = user.Avatar;

                return View(profInfoModel);
            }

            return View();
        }

        [HttpPost]
        public ActionResult editProfile(string name, string value)
        {
            if (string.IsNullOrEmpty(name) == false && string.IsNullOrEmpty(value) == false)
            {
                int userId = provider.GetUserId();

                if (userId > 0)
                {

                    var user = userService.GetById(userId);
                    var field = user.GetType().GetProperty(name);

                    if (((name == "Age") || (name == "PhoneNumber")) && Regex.IsMatch(value, @"^\d+$"))
                    {
                        int val = int.Parse(value);
                        field.SetValue(user, val, null);
                    }
                    else if (name == "DateOfBirth")
                    {
                        var tmp = DateTime.Parse(value);
                        field.SetValue(user, tmp, null);
                    }
                    else
                    {
                        field.SetValue(user, value, null);
                    }
                    
                    userService.Update(user);

                    return Json(new { success = true, message = "Profile information updated successfully!" }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(new { success = false, message = "User not found!" }, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return Json(new { success = false, message = "Field can't be empty" }, JsonRequestBehavior.AllowGet);
            }

            }

        [HttpPost]
        public ActionResult UploadAvatar()
        {

            var userId = provider.GetUserId();
            var user = userService.GetById(userId);

           
            try
            {
                var userImage = Request.Files[0];

                string fileName = string.Format("{0}{1}.{2}", "avatar-",Guid.NewGuid().ToString(), userImage.ContentType.Split('/')[1]);

                string fullPath = HttpContext.Server.MapPath(string.Format("{0}{1}","~/Images/Avatars/", fileName));

                if (string.IsNullOrEmpty(user.Avatar) == false)
                {
                    string existingImagePath = HttpContext.Server.MapPath(string.Format("{0}{1}", "~/Images/Avatars/", user.Avatar));
                    FileHelper.DeleteImage(existingImagePath);
                }

                FileHelper.SaveStreamToFile(fullPath, userImage.InputStream);

                user.Avatar = fileName;
                userService.Update(user);

                return Json(true);

            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }
    }
}