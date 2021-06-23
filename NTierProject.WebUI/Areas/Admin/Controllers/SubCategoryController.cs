using NtierProject.SERVICE.Option;
using NTierProject.MODEL.Entities;
using NTierProject.WebUI.Areas.Admin.Models;
using System;
using System.Net;
using System.Web.Mvc;

namespace NTierProject.WebUI.Areas.Admin.Controllers
{
    public class SubCategoryController : Controller
    {
        SubCategoryService sub = new SubCategoryService();
        CategoryService category = new CategoryService();
        public ActionResult Index()
        {
            return View(sub.GetActive());
        }

        public ActionResult Add()
        {
            ViewBag.CategoryID = new SelectList(category.GetActive(), "ID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Add(SubCategory data)
        {
            data.ID = Guid.NewGuid();
            sub.Add(data);

            return RedirectToAction("Index");
        }
        public ActionResult Update(Guid id)//Bilgisayar
        {
            SubCategoryVM model = new SubCategoryVM();
            model.SubCategory = sub.GetById(id);
            model.Categories = category.GetActive();
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(SubCategory model)
        {
            sub.Update(model);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubCategory subCategory = sub.GetById(id);
            if (subCategory == null)
            {
                return HttpNotFound();
            }
            return View(subCategory);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            SubCategory subCategory = sub.GetById(id);
            sub.Remove(subCategory);

            return RedirectToAction("Index");
        }
    }
}