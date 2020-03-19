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
    public class BrandController : Controller
    {
        private GaleriDBEntities _db = new GaleriDBEntities();
        private BrandService _brdService = new BrandService();

        // GET: Brand
        public ActionResult Index()
        {
            var list = _brdService.GetList().OrderBy(x => x.BrandName);

            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Brand brd)
        {
            if (ModelState.IsValid)
            {
                _brdService.Insert(brd);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Update(int id)
        {
            Brand brand = _brdService.GetById(id);

            if (brand == null)
            {
                return HttpNotFound();
            }

            return View(brand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Brand brd)
        {
            if (ModelState.IsValid)
            {
                _brdService.Update(brd);
                return RedirectToAction("Index");
            }

            return View();
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            else
            {
                var brd = _db.Brands.Find(id);
                _db.Brands.Remove(brd);
                _db.SaveChanges();
                //_brdService.Delete(brd);
                return RedirectToAction("Index");
            }
        }
    }
}