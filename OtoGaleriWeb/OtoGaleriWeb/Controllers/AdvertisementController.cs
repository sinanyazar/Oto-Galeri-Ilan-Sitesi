using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities;
using FactoryLayer.Services;

namespace OtoGaleriWeb.Controllers
{
    public class AdvertisementController : Controller
    {
        private GaleriDBEntities _db = new GaleriDBEntities();
        private AdvertisementService _advService = new AdvertisementService();

        // GET: Advertisement
        public ActionResult Index()
        {
            var advList = _advService.GetList();

            return View(advList);
        }

        public ActionResult Create()
        {
            ViewBag.CarList = new SelectList(_db.Cars, "CarId", "CarId");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Advertisement adv)
        {
            if (ModelState.IsValid)
            {
                _advService.Insert(adv);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Update(int id)
        {
            ViewBag.CarList = new SelectList(_db.Cars, "CarId", "CarId");
            Advertisement advertisement = _advService.GetById(id);

            if(advertisement == null)
            {
                return HttpNotFound();
            }

            return View(advertisement);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Advertisement adv)
        {
            if (ModelState.IsValid)
            {
                _advService.Update(adv);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Delete(Advertisement adv)
        {
            _advService.Delete(adv);
            return RedirectToAction("Index");
        }
    }
}