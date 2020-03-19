using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;

namespace OtoGaleriWeb.Controllers
{
    public class HomeController : Controller
    {
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

        private GaleriDBEntities db = new GaleriDBEntities();

        public ActionResult Deneme()
        {
            ViewBag.Message = "Deneme Sayfam";

            return View();
        }

        public ActionResult Deneme2()
        {
            ViewBag.Message = "Deneme2 Sayfam";

            var list = db.Gears.ToList();

            return View(list);
        }
        
    }
}