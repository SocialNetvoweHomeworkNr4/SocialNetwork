using BusinessLogic.Models;
using BusinessLogic.Services;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.Controllers
{
    public class FriendController : Controller
    {
        IFriendService friendService;
        IUserService userService;

        public FriendController(IFriendService friendService, IUserService userService)
        {
            this.friendService = friendService;
            this.userService = userService;
        }

        // GET: Friend
        public ActionResult Index(int? page)
        {
            List<User> users = userService.GetAll().ToList();

            int pageSize = 20;
            int pageNumber = (page ?? 1);

            return View(users.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult RemoveFriend(int userId)
        {
            User user = userService.GetById(userId);

            return PartialView("~/Views/Friend/Modals/RemoveFriendModal.cshtml", user);
        }
    }
}