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
using AutoMapper;
using SocialNetwork.ViewModels;
using System.Collections.Generic;

namespace Website.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private IUserService userService;
        private CustomMembershipProvider provider;
        private IInvitationService invitationService;


        public ProfileController(IUserService userService, IInvitationService invitationService)
        {
            this.userService = userService;
            this.invitationService = invitationService;
            provider = new CustomMembershipProvider();
        }

        [Authorize]
        public ActionResult Index()
        {
            int id = provider.GetUserId();

            var profileModel = new ProfileViewModel();

            var profInfoModel = new ProfileInfoViewModel();
            var invitationsList = new InvitationsListModel();
           

            if (id != 0)
            {
                var myInvites = invitationService.GetMyInvites(id);
                var invitationsByMe = invitationService.GetInvitesByMe(id);

                var invitedByMe = userService.GetInvitedUsers(invitationsByMe);
                var invitesToMe = userService.GetInvitedUsers(myInvites);

                  invitationsList.InvitationsByMe = Mapper.Map<List<User>, List<ProfileInvitationsViewModel>>(invitedByMe);
                  invitationsList.MyInvitations = Mapper.Map<List<User>, List<ProfileInvitationsViewModel>>(invitesToMe);

                var user = userService.GetById(id);
                
                profInfoModel.BirthDate = user.DateOfBirth.HasValue ? user.DateOfBirth.Value.ToShortDateString() : null;
                profInfoModel.Firstname = user.FirstName;
                profInfoModel.Lastname = user.LastName;
                profInfoModel.Phone = user.PhoneNumber;
                profInfoModel.Interests = user.Interests;
                profInfoModel.Information = user.About;
                profInfoModel.Avatar = user.Avatar;

                profileModel.ProfileInfoViewModel = profInfoModel;
                profileModel.InvitationsListModel = invitationsList;

                return View(profileModel);
            }

            return View();
        }

        [HttpPost]
        [Authorize]
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
        [Authorize]
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

        public ActionResult ViewProfile(int id)
        {

            if (id <= 0)
            {
                return View("NotExistingUser");
            }

            try
            {
                var user = userService.GetById(id);

                if(user != null)
                {
                  var model =  Mapper.Map<User, ProfileInfoViewModel>(user);

                  return View(model);
                }

            }
            catch(Exception ex)
            {
                return View("NotExistingUser");
            }

            return View("NotExistingUser");
        }

        public ActionResult AcceptDeclineInvite(int id, bool act)
        {

            int myId = provider.GetUserId();

            invitationService.AcceptDeclineInvite(id, myId, act);

            return Json(true);
        }


    }
}