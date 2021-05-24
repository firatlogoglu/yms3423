using NtierProject.SERVICE.Option;
using NTierProject.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace NTierProject.WebUI.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        OrderService db = new OrderService();
        public ActionResult Index()
        {
            return View(db.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                order.ID = Guid.NewGuid();
                db.Add(order);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        public ActionResult Update(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.GetById(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Order order)
        {
            if (ModelState.IsValid)
            {
                order.ID = Guid.NewGuid();
                db.Update(order);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.GetById(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Order order = db.GetById(id);
            db.Remove(order);
            db.Save();
            return RedirectToAction("Index");
        }
    }
}