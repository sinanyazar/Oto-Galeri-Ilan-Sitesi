using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using FactoryLayer.Services;

namespace OtoGaleriWeb.Controllers
{
    public class EmployeeController : Controller
    {
        private GaleriDBEntities _db = new GaleriDBEntities();
        private UserService _userService = new UserService();

        // GET: Employee
        public ActionResult Index()
        {
            var list = _userService.GetList();

            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _userService.Insert(user);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Update(int id)
        {
            User user = _userService.GetById(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(User user)
        {
            if (ModelState.IsValid)
            {
                _userService.Update(user);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int id)
        {
            User user = _userService.GetById(id);

            if (user == null)
            {
                return HttpNotFound();
            }
            else
            {
                _userService.Delete(user);
                return RedirectToAction("Index");
            }
        }
    }
}