using System.Web.Mvc;
using BusinessLogic.Services;

namespace SocialNetwork.Controllers
{
    public class HomeController : Controller
    {
        IWeapon weapon;

        public HomeController(IWeapon weapon)
        {
            this.weapon = weapon;
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}