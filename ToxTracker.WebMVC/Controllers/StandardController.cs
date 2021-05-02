using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToxTracker.Models.StandardModels;
using ToxTracker.Services;

namespace ToxTracker.WebMVC.Controllers
{
    [Authorize]
    public class StandardController : Controller
    {
        // GET: Standard
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StandardService(userId);
            var model = service.GetAllStandards();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StandardCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateStandardService();

            if (service.CreateStandard(model))
            {
                TempData["SaveResult"] = "Standard successfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Standard could not be created.");
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var svc = CreateStandardService();
            var model = svc.GetStandardById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateStandardService();
            var detail = service.GetStandardById(id);
            var model =
                new StandardEdit
                {
                    Id = detail.Id,
                    Name = detail.Name,
                    Concentration = detail.Concentration,
                    Unit = detail.Unit,
                    IsDeuterated = detail.IsDeuterated,
                    LotNumber = detail.LotNumber,
                    CatNumber = detail.CatNumber,
                    RecDate = detail.RecDate,
                    OpenDate = detail.OpenDate,
                    ExpireDate = detail.ExpireDate
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StandardEdit model)
        {
            if(!ModelState.IsValid) return View(model);

            if(model.Id != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateStandardService();
            if (service.UpdateStandard(model))
            {
                TempData["SaveResult"] = "Standard successfully saved.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The standard could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateStandardService();
            var model = svc.GetStandardById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateStandardService();
            service.DeleteStandard(id);

            TempData["SaveResult"] = "Standard deleted.";
            return RedirectToAction("Index");
        }

        private StandardService CreateStandardService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StandardService(userId);
            return service;
        }
    }
}