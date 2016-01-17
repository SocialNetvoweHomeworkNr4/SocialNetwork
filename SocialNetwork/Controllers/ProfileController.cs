using BusinessLogic.Providers;
using BusinessLogic.Services;
using System.Linq;
using System.Web.Mvc;
using BusinessLogic.Models;

using System.Text.RegularExpressions;
using SocialNetwork.ViewModels.Profile;
using System;
using System.Globalization;

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
        // GET: Profile
        public ActionResult Index()
        {
            var profInfoModel = new ProfileInfoViewModel();
            int id = provider.GetUserId();

            if (id != 0)
            {
                            
                var user = userService.GetById(id);
                
                profInfoModel.BirthDate = user.DateOfBirth.Value.ToShortDateString();
                profInfoModel.Firstname = user.FirstName;
                profInfoModel.Lastname = user.LastName;
                profInfoModel.Phone = user.PhoneNumber;
                profInfoModel.Interests = user.Interests;
                profInfoModel.Information = user.About;
                profInfoModel.ImagePath = user.Avatar;

            }
            return View(profInfoModel);
        }

        [HttpPost]
        public ActionResult editProfile(string name, string value)
        {
            if(string.IsNullOrEmpty(name) == false && string.IsNullOrEmpty(value) == false)
            {
                int userId = provider.GetUserId();

                if(userId > 0)
                {

                    var user = userService.GetById(userId);
                    var field =  user.GetType().GetProperty(name);

                    if (((name == "Age") || (name == "PhoneNumber")) && Regex.IsMatch(value, @"^\d+$"))
                    {
                        int val = int.Parse(value);
                        field.SetValue(user, val, null);
                    }
                    else if(name == "DateOfBirth")
                    {
                        var tmp = DateTime.Parse(value);
                        field.SetValue(user, tmp, null);
                    }
                    else
                    {
                        field.SetValue(user, value, null);
                    }
                    
                    userService.Update(user);

                    return Json( new {success = true, message = "Profila infomācija atjaunota veiksmīgi!" }, JsonRequestBehavior.AllowGet);

                }
                else
                {
                    return Json(new { success = false, message = "Lietotājs nav atrasts" }, JsonRequestBehavior.AllowGet);
                }

            }
            else
            {
                return Json(new { success = false, message = "Lauks nevar būt tukšs" }, JsonRequestBehavior.AllowGet);
            }

        }
    }
}