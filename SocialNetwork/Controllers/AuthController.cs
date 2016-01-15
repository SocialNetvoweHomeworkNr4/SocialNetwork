using SocialNetwork.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SocialNetwork.Controllers
{
    public class AuthController : Controller
    {
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
                if (Membership.ValidateUser(model.Email, model.Password))
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
        public ActionResult Register(RegisterViewModel model)
        {

            return View();
        }
    }
}