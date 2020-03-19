using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using FactoryLayer.Services;

namespace OtoGaleriWeb.Controllers
{
    public class ModelController : Controller
    {
        private GaleriDBEntities _db = new GaleriDBEntities();
        private ModelService _mdlService = new ModelService();

        // GET: Model
        public ActionResult Index()
        {
            var list = _mdlService.GetList().OrderBy(x => x.Brand.BrandName);

            return View(list);
        }

        public ActionResult Create()
        {
            ViewBag.BrandList = new SelectList(_db.Brands,"BrandId","BrandName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Model mdl)
        {
            if (ModelState.IsValid)
            {
                _mdlService.Insert(mdl);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Update(int id)
        {
            Model model = _mdlService.GetById(id);

            ViewBag.BrandList = new SelectList(_db.Brands, "BrandId", "BrandName");

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Model mdl)
        {
            if (ModelState.IsValid)
            {
                _mdlService.Update(mdl);
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
                var mdl = _db.Models.Find(id);
                _db.Models.Remove(mdl);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}