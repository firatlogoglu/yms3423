using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NtierProject.SERVICE.Option;
using NTierProject.MODEL.Context;
using NTierProject.MODEL.Entities;

namespace NTierProject.WebUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService db = new CategoryService();

        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(db.GetAll());
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                category.ID = Guid.NewGuid();
                db.Add(category);
                db.Save();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Category category)
        {
            if (ModelState.IsValid)
            {
                db.Update(category);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.GetById(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Category category = db.GetById(id);
            db.Remove(category);
            db.Save();
            return RedirectToAction("Index");
        }

     
    }
}
