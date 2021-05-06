using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToxTracker.Models.AnalyteModels;
using ToxTracker.Services;

namespace ToxTracker.WebMVC.Controllers
{
    [Authorize]
    public class AnalyteController : Controller
    {
        // GET: Analyte
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AnalyteService(userId);
            var model = service.GetAllAnalytes();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnalyteCreate model, int standardId, int stockId)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateAnalyteService();

            if (service.CreateAnalyte(model, standardId, stockId))
            {
                TempData["SaveResult"] = "Analyte successfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Analyte could not be created.");
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var svc = CreateAnalyteService();
            var model = svc.GetAnalyteById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateAnalyteService();
            var detail = service.GetAnalyteById(id);
            var model =
                new AnalyteEdit
                {
                    Id = detail.Id,
                    StandardId = detail.StandardId,
                    StockId = detail.StockId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AnalyteEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateAnalyteService();
            if (service.UpdateAnalyte(model))
            {
                TempData["SaveResult"] = "Analyte successfully saved.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The Analyte could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateAnalyteService();
            var model = svc.GetAnalyteById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateAnalyteService();
            service.DeleteAnalyte(id);

            TempData["SaveResult"] = "Analyte deleted.";
            return RedirectToAction("Index");
        }

        private AnalyteService CreateAnalyteService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new AnalyteService(userId);
            return service;
        }
    }
}