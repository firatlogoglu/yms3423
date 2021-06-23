using NtierProject.SERVICE.Option;
using NTierProject.MODEL.Entities;
using System;
using System.Net;
using System.Web.Mvc;

namespace NTierProject.WebUI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService db = new CategoryService();

        public ActionResult Index()
        {
            return View(db.GetAll());
        }

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

                return RedirectToAction("Index");
            }

            return View(category);
        }

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
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Update(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Category category = db.GetById(id);
            db.Remove(category);
            return RedirectToAction("Index");
        }
    }
}