using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToxTracker.Models.StockModels;
using ToxTracker.Services;

namespace ToxTracker.WebMVC.Controllers
{
    [Authorize]
    public class StockController : Controller
    {
        // GET: Stock
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StockService(userId);
            var model = service.GetAllStocks();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StockCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateStockService();

            if (service.CreateStock(model))
            {
                TempData["SaveResult"] = "Stock successfully created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Stock could not be created.");
            return View(model);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var svc = CreateStockService();
            var model = svc.GetStockById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateStockService();
            var detail = service.GetStockById(id);
            var model =
                new StockEdit
                {
                    Id = detail.Id,
                    Assay = detail.Assay,
                    LotNumber = detail.LotNumber,
                    Type = detail.Type,
                    IsApproved = detail.IsApproved,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, StockEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.Id != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateStockService();
            if (service.UpdateStock(model))
            {
                TempData["SaveResult"] = "Stock successfully saved.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The stock could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateStockService();
            var model = svc.GetStockById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateStockService();
            service.DeleteStock(id);

            TempData["SaveResult"] = "Stock deleted.";
            return RedirectToAction("Index");
        }

        private StockService CreateStockService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new StockService(userId);
            return service;
        }
    }
}