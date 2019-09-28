using NtierProject.SERVICE.Option;
using NTierProject.MODEL.Entities;
using NTierProject.WebUI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            return View(category.GetActive());
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
            var deleted = sub.GetById(id);
            sub.Remove(deleted);
            return RedirectToAction("Index");
        }
    }
}