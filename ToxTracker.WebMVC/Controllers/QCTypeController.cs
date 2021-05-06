using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToxTracker.Models.QCTypeModels;
using ToxTracker.Services;

namespace ToxTracker.WebMVC.Controllers
{
    [Authorize]
    public class QCTypeController : Controller
    {
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new QCTypeService(userId);
            var model = service.GetAllQCTypes();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QCTypeCreate model, int analyteId)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateQCTypeService();

            if (service.CreateQCType(model, analyteId))
            {
                TempData["SaveResult"] = "QC successfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "QC could not be created.");
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var svc = CreateQCTypeService();
            var model = svc.GetQCTypeById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateQCTypeService();
            var detail = service.GetQCTypeById(id);
            var model =
                new QCTypeEdit
                {
                    Id = detail.Id,
                    Level = detail.Level,
                    Concentration = detail.Concentration,
                    Unit = detail.Unit,
                    AnalyteId = detail.AnalyteId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, QCTypeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateQCTypeService();
            if (service.UpdateQCType(model))
            {
                TempData["SaveResult"] = "QC successfully saved.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The QC could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateQCTypeService();
            var model = svc.GetQCTypeById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateQCTypeService();
            service.DeleteQCType(id);

            TempData["SaveResult"] = "QC deleted.";
            return RedirectToAction("Index");
        }

        private QCTypeService CreateQCTypeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new QCTypeService(userId);
            return service;
        }
    }
}