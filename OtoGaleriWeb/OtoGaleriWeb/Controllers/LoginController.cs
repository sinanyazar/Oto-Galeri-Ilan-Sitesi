using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;

namespace OtoGaleriWeb.Controllers
{
    public class LoginController : Controller
    {
        private GaleriDBEntities _db = new GaleriDBEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LoginControl(User user)
        {
            var login = _db.Users.Where(x => x.UserName == user.UserName && x.UserPassword == user.UserPassword).FirstOrDefault();

            if (login == null)
            {
                return HttpNotFound();
            }
            else
            {
                return RedirectToAction("Index", "Admin");
            }

        }
    }
}