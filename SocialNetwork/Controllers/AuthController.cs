﻿using BusinessLogic.Models;
using BusinessLogic.Providers;
using BusinessLogic.Services;
using SocialNetwork.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace SocialNetwork.Controllers
{
    public class AuthController : Controller
    {

        private IUserService userService;
        private CustomMembershipProvider provider;
        public AuthController(IUserService userService)
        {
            this.userService = userService;
            provider = new CustomMembershipProvider();
        }

        // GET: Auth
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (provider.ValidateUser(model.Email, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Email, true);
                    return RedirectToAction("Index", "Profile");
                }
                else
                {
                    ModelState.AddModelError("", "Nepareiza epasta adrese vai parole");
                    return View("Login", model);
                }
            }
            return View("Login", model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(RegisterViewModel user)
        {
                if (ModelState.IsValid)
                {
                    var model = new User();

                    model.FirstName = user.Firstname;
                    model.LastName = user.Lastname;
                    model.Email = user.Email;
                    model.Password = Crypto.HashPassword(user.Password);

                    userService.Add(model);

                    return RedirectToAction("Login", "Auth");
                }

            return View("Register", user);
        }
    }
}