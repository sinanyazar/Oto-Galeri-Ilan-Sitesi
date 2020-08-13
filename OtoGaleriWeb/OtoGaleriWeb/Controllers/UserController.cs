using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using FactoryLayer.Services;

namespace OtoGaleriWeb.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private GaleriDBEntities _db = new GaleriDBEntities();

        // GET: User

        public ActionResult Index()
        {
            AdvertisementService advService = new AdvertisementService();

            var list = advService.GetList().Where(x => x.State == true);

            ViewBag.BrandList = new SelectList(_db.Brands, "BrandId", "BrandName");
            ViewBag.ModelList = new SelectList(_db.Models, "ModelId", "ModelName");

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
            return Json(itemList,JsonRequestBehavior.AllowGet);
        }

        public ActionResult Filter(int? model,int? txtMinYear, int? txtMaxYear, bool? radioNew, int? txtMinPrice, int? txtMaxPrice, int? txtMinKm, int? txtMaxKm, int?[] chkGear, int?[] chkFuel, int?[] chkColor)
        {
            ViewBag.BrandList = new SelectList(_db.Brands, "BrandId", "BrandName");

            var list = _db.Advertisements.ToList();

            #region Filtre
            if (model != null)
            {
                list = list.Where(x => x.Car.Model.ModelId == model).ToList();
            }
            if (txtMinYear != null)
            {
                list = list.Where(x => x.Car.Year.Value.Year >= txtMinYear).ToList();
            }
            if (txtMaxYear != null)
            {
                list = list.Where(x => x.Car.Year.Value.Year <= txtMaxYear).ToList();
            }
            if (txtMinPrice != null)
            {
                list = list.Where(x => x.Car.Price >= txtMinPrice).ToList();
            }
            if (txtMaxPrice != null)
            {
                list = list.Where(x => x.Car.Price <= txtMaxPrice).ToList();
            }
            if (txtMinKm != null)
            {
                list = list.Where(x => x.Car.KM >= txtMinKm).ToList();
            }
            if (txtMaxKm != null)
            {
                list = list.Where(x => x.Car.KM <= txtMaxKm).ToList();
            }
            if (chkGear != null)
            {
                list = list.Where(x => chkGear.Contains(x.Car.Gear.GearId)).ToList();
            }
            if (chkFuel != null)
            {
                list = list.Where(x => chkFuel.Contains(x.Car.Fuel.FuelId)).ToList();
            }
            if (chkColor != null)
            {
                list = list.Where(x => chkColor.Contains(x.Car.Color.ColorId)).ToList();
            }
            if (radioNew != null)
            {
                list = list.Where(x => x.Car.State == radioNew.Value).ToList();
            }
            #endregion

            return View("Index", list);
        }

        public ActionResult Detail(int id)
        {
            AdvertisementService advertisementService = new AdvertisementService();
            var dty = advertisementService.GetById(id);

            return View("Detail", dty);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}