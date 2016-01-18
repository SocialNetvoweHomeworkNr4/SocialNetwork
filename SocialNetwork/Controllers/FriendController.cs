using AutoMapper;
using BusinessLogic.Models;
using BusinessLogic.Providers;
using BusinessLogic.Services;
using PagedList;
using SocialNetwork.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.Controllers
{
    public class FriendController : Controller
    {
        int pageSize = 20;
        int pageNumber = 1;
        IFriendService friendService;
        IUserService userService;
        IInvitationService invitationService;

        private CustomMembershipProvider provider;

        public FriendController(IFriendService friendService, IUserService userService, IInvitationService invitationService)
        {
            this.friendService = friendService;
            this.userService = userService;
            this.invitationService = invitationService;
            this.provider = new CustomMembershipProvider();
        }

        // GET: Friend
        [Authorize]
        public ActionResult Index(int? page)
        {
            int userId = provider.GetUserId();
            IQueryable<User> users = userService.GetUsersByUserIDs(userId);

            var allUsers = Mapper.Map<IList<User>, IList<UserViewModel>>(users.ToList());

            pageNumber = (page ?? 1);

            return View(allUsers.ToPagedList(pageNumber, pageSize));
        }

        [Authorize]
        public ActionResult Discover(int? page)
        {
            var allUsers = Mapper.Map<IList<User>, IList<UserViewModel>>(userService.GetAll().OrderBy(u => u.FirstName).ToList());

            //dont show yourself
            allUsers = allUsers.Where(r => r.UserID != provider.GetUserId()).ToList();

            //dont show friends
            var friendsIds = friendService.GetFriendIDsByUserId(provider.GetUserId());

            if(friendsIds.Count() == 0)
                allUsers = allUsers.Where(r => friendsIds.Any(u => u != r.UserID) == false).ToList();
            else
                allUsers = allUsers.Where(r => friendsIds.Any(u => u != r.UserID) == true).ToList();
            //dont show invited users
            var t = invitationService.GetInvitationIDsByUserId(provider.GetUserId());

            ViewBag.invitationIds = t.ToList();

           // allUsers = allUsers.Where(r => !invitationIds.Contains(r.UserID)).ToList();

            pageNumber = (page ?? 1);

            return View(allUsers.ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        [Authorize]
        public ActionResult FilterPeople(string firstName, string lastName, string gender, int? page)
        { 
            var allUsers = Mapper.Map<IList<User>, IList<UserViewModel>>(userService.GetAll().ToList());

            if (!String.IsNullOrEmpty(firstName))
                allUsers = allUsers.Where(u => u.FirstName.Contains(firstName)).ToList();

            if (!String.IsNullOrEmpty(lastName))
                allUsers = allUsers.Where(u => u.LastName.Contains(lastName)).ToList();

            if (!String.IsNullOrEmpty(gender))
                allUsers = allUsers.Where(u => u.Gender.ToString() == gender).ToList();

            pageNumber = (page ?? 1);

            return PartialView("~/Views/Friend/_SearchResults.cshtml", allUsers.OrderBy(u => u.FirstName).ToPagedList(pageNumber, pageSize));
        }

        [Authorize]
        public ActionResult RemoveFriend(int userId)
        {
            User user = userService.GetById(userId);

            return PartialView("~/Views/Friend/Modals/RemoveFriendModal.cshtml", user);
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddFriend(int userId)
        {
            User user = userService.GetById(userId);

            var result = invitationService.InviteUser(provider.GetUserId(), userId);

            return Json(new { result = result }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RemoveFriendAccept(int userId, int? page)
        {
            int currentUserId = provider.GetUserId();

            friendService.DeleteFriend(currentUserId, userId);

            IQueryable<User> users = userService.GetUsersByUserIDs(currentUserId);

            var allUsers = Mapper.Map<IList<User>, IList<UserViewModel>>(users.ToList());
            pageNumber = (page ?? 1);

            return PartialView("~/Views/Friend/_SearchResults.cshtml", allUsers.ToPagedList(pageNumber, pageSize));
        }
    }
}