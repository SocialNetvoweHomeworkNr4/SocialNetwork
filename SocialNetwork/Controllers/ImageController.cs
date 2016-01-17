using AutoMapper;
using BusinessLogic.Helpers;
using BusinessLogic.Models;
using BusinessLogic.Services;
using SocialNetwork.Helpers;
using SocialNetwork.ViewModels;
using SocialNetwork.ViewModels.Image;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SocialNetwork.Controllers
{
    public class ImageController : Controller
    {
        private IUserImageService userImageService;
        private IUserImageCommentService userImageCommentService;
        private IUserService userService;

        public ImageController(IUserImageService userImageService, IUserImageCommentService userImageCommentService, IUserService userService)
        {
            this.userImageService = userImageService;
            this.userImageCommentService = userImageCommentService;
            this.userService = userService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var userId = HttpContextHelper.CurrentUser.UserID;

            var images = userImageService.GetMany(s => s.UserID == userId).ToList();

            var imagesView = Mapper.Map<List<UserImage>, List <UserImageViewModel>>(images);

            var model = new UserImagesViewModel();
            model.UserId = userId;
            model.Images = imagesView;

            return View(model);
        }

        [HttpPost]
        public ActionResult UploadFiles()
        {
            var userId = HttpContextHelper.CurrentUser.UserID;

            try
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    string fileName = string.Format("{0}.{1}", Guid.NewGuid().ToString(), file.ContentType.Split('/')[1]);

                    string fullPath = HttpContext.Server.MapPath(string.Format("~/Images/{0}", fileName));

                    FileHelper.SaveStreamToFile(fullPath, file.InputStream);

                    var userImageViewModel = new UserImageViewModel()
                    {
                        UserID = userId,
                        FileName = fileName,
                        Comment = string.Empty, 
                        Date = DateTime.Now.ToString()
                    };

                    userImageService.Add(Mapper.Map<UserImageViewModel, UserImage>(userImageViewModel));
                }


                return Json(true);

            }
            catch (Exception e)
            {
                return Json(false);
            }
        }

        [HttpPost]
        public ActionResult Edit(int imageId)
        {
            var image = userImageService.Get(s => s.ImageID == imageId);

            var model = new UserImageViewModel();

            if (image != null)
            {
                model = Mapper.Map<UserImage, UserImageViewModel>(image);
            }

            return Json(new { model }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(int imageId, string comment)
        {
            try
            {
                var userId = HttpContextHelper.CurrentUser.UserID;

                var image = userImageService.Get(s => s.UserID == userId && s.ImageID == imageId);

                image.Comment = comment;

                userImageService.Update(image);

                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            } 
        }

        [HttpPost]
        public ActionResult Add(int imageId, string text)
        {
            try
            {
                var userId = HttpContextHelper.CurrentUser.UserID;

                var date = DateTime.Now;

                UserImageComment comment = new UserImageComment();
                comment.AuthorID = userId;
                comment.Date = date;
                comment.ImageID = imageId;
                comment.Text = text;
                userImageCommentService.Add(comment);

                var name = UserHelper.FullName(userService.GetById(userId));

                return Json(new { success = true, text = text, date = date.ToString(DateHelper.Format), name = name }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult UserImages(int id)
        {
            var images = userImageService.GetMany(s => s.UserID == id).ToList();

            var imagesView = Mapper.Map<List<UserImage>, List<UserImageViewModel>>(images);

            var model = new UserImagesViewModel();
            model.UserId = id;
            model.Images = imagesView;
            model.FullName = UserHelper.FullName(userService.GetById(id));

            return View(model);
        }
    }
}