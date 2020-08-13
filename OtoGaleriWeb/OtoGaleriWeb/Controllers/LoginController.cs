using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Entities;

namespace OtoGaleriWeb.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private GaleriDBEntities _db = new GaleriDBEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(User user)
        {
            var login = _db.Users.Where(x => x.UserName == user.UserName && x.UserPassword == user.UserPassword).FirstOrDefault();

            if (login == null)
            {
                ViewBag.Error = "Geçersiz kullanıcı adı veya şifre girdiniz ...";
                return RedirectToAction("Index","User");
            }
            else
            {
                Session.Add("ActiveUser",login.FullName);
                FormsAuthentication.SetAuthCookie(login.UserName,false);
                return RedirectToAction("Index", "Admin");
            }

        }

        public ActionResult LogOut()
        {
            //Session.Remove("ActiveUser");
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "User");
        }
    }
}