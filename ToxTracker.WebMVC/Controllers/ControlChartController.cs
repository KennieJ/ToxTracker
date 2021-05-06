using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToxTracker.Models.ControlChartModels;
using ToxTracker.Services;

namespace ToxTracker.WebMVC.Controllers
{
    [Authorize]
    public class ControlChartController : Controller
    {
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ControlChartService(userId);
            var model = service.GetAllControls();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ControlCreate model, int qcId)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateControlService();

            if (service.CreateControl(model, qcId))
            {
                TempData["SaveResult"] = "Control successfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Control could not be created.");
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var svc = CreateControlService();
            var model = svc.GetControlById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateControlService();
            var detail = service.GetControlById(id);
            var model =
                new ControlEdit
                {
                    Id = detail.Id,
                    QuantValue = detail.QuantValue,
                    RunDate = detail.RunDate,
                    BatchName = detail.BatchName,
                    QCId = detail.QCId
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ControlEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateControlService();
            if (service.UpdateControl(model))
            {
                TempData["SaveResult"] = "Control successfully saved.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The control could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateControlService();
            var model = svc.GetControlById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateControlService();
            service.DeleteControl(id);

            TempData["SaveResult"] = "Control deleted.";
            return RedirectToAction("Index");
        }

        private ControlChartService CreateControlService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ControlChartService(userId);
            return service;
        }
    }
}