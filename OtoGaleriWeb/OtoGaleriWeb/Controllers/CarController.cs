using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using FactoryLayer.Services;

namespace OtoGaleriWeb.Controllers
{
    public class CarController : Controller
    {
        private GaleriDBEntities _db = new GaleriDBEntities();
        private CarService _carService = new CarService();

        // GET: Car
        public ActionResult Index()
        {
            var list = _carService.GetList();

            return View(list);
        }

        [HttpPost]
        public ActionResult GetModels(int brandId)
        {
            var models = _db.Models.Where(x => x.BrandId == brandId).ToList();

            List<SelectListItem> itemList = (from item in models
                                         select new SelectListItem
                                         {
                                             Value = item.ModelId.ToString(),
                                             Text = item.ModelName
                                         }).ToList();

            return Json(itemList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Create()
        {
            ViewBag.BrandList = new SelectList(_db.Brands, "BrandId", "BrandName");
            ViewBag.FuelList = new SelectList(_db.Fuels, "FuelId", "FuelName");
            ViewBag.GearList = new SelectList(_db.Gears, "GearId", "GearName");
            ViewBag.ColorList = new SelectList(_db.Colors, "ColorId", "ColorName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car car, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string imageName = System.IO.Path.GetFileName(file.FileName);
                string imageAdress = Server.MapPath("~/Resources/" + imageName);
                file.SaveAs(imageAdress);

                car.Picture1 = imageName;
            }

            if (ModelState.IsValid)
            {
                _carService.Insert(car);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Update(int id)
        {
            Car car = _carService.GetById(id);

            ViewBag.BrandList = new SelectList(_db.Brands, "BrandId", "BrandName");
            ViewBag.ModelList = new SelectList(_db.Models.Where(x => x.BrandId == car.Model.BrandId), "ModelId","ModelName");
            ViewBag.FuelList = new SelectList(_db.Fuels, "FuelId", "FuelName");
            ViewBag.GearList = new SelectList(_db.Gears, "GearId", "GearName");
            ViewBag.ColorList = new SelectList(_db.Colors, "ColorId", "ColorName");

            if (car == null)
            {
                return HttpNotFound();
            }

            return View(car);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Car car, HttpPostedFileBase file)
        {
            if (file != null)
            {
                string imageName = System.IO.Path.GetFileName(file.FileName);
                string imageAdress = Server.MapPath("~/Resources/" + imageName);
                file.SaveAs(imageAdress);

                car.Picture1 = imageName;
            }

            if (ModelState.IsValid)
            {
                _carService.Update(car);
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
                var car = _db.Cars.Find(id);
                _db.Cars.Remove(car);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}