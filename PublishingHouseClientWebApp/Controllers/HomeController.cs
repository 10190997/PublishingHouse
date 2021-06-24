using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibraryPublishingHouse;
using PublishingHouseClientWebApp.ViewModel;

namespace PublishingHouseClientWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            ViewBag.Message = "Регистрация";

            return View();
        }

        public ActionResult SignIn()
        {
            ViewBag.Message = "Авторизация";

            return View();
        }

        public ActionResult ShowPublications()
        {
            var table = new PublicationViewModel
            {
                Publications = DB.db.Publications.ToList()
            };
            return View(table);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(User user)
        {
            Authentificator.Register(user.EmailAddress, user.Password, user.Login, user.LastName, user.FirstName);
            return RedirectToAction("SignIn");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(User user)
        {
            if (Authentificator.Authorize(user.Login, user.Password, user) == "OK")
            {
                return RedirectToAction("ShowPublications");
            }
            return RedirectToAction("Index");
        }
    }
}