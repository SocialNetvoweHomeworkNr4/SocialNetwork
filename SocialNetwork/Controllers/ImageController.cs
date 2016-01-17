using AutoMapper;
using BusinessLogic.Helpers;
using BusinessLogic.Models;
using BusinessLogic.Services;
using SocialNetwork.ViewModels;
using SocialNetwork.ViewModels.Image;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.Controllers
{
    public class ImageController : Controller
    {
        private IUserImageService userImageService;

        public ImageController(IUserImageService userImageService)
        {
            this.userImageService = userImageService;
        }

        [HttpGet]
        public ActionResult Index(int id)
        {


            var images = userImageService.GetMany(s => s.UserID == id).ToList();

            var imagesView = Mapper.Map<List<UserImage>, List <UserImageViewModel>>(images);

            var model = new UserImagesViewModel();
            model.UserId = id;
            model.Images = imagesView;

            return View(model);
        }

        [HttpPost]
        public ActionResult UploadFiles(int userId)
        {
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
        public ActionResult Edit(int id, int imageId)
        {
            var image = userImageService.Get(s => s.UserID == id && s.ImageID == imageId);

            var model = new UserImageViewModel();

            if (image != null)
            {
                model = Mapper.Map<UserImage, UserImageViewModel>(image);
            }

            return Json(new { model }, JsonRequestBehavior.AllowGet);
        }
    }
}