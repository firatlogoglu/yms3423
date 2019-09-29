using NtierProject.SERVICE.Option;
using NTierProject.COMMON.MyTools;
using NTierProject.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierProject.WebUI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ProductService ProductService = new ProductService();
        SubCategoryService subCategory = new SubCategoryService();

        public ActionResult Index()
        {
            var products = ProductService.GetActive().OrderByDescending(x => x.CreatedDate).ToList();
            return View(products);
        }

        public ActionResult Create()
        {

            return View(subCategory.GetActive());
        }

        [HttpPost]
        public ActionResult Create(Product model, HttpPostedFileBase ImagePath)
        {
            model.ID = Guid.NewGuid();
            model.ImagePath = ImageUploader.UploadSingleImage("~/Uploads", ImagePath);
            ProductService.Add(model);
            return RedirectToAction("Index");
        }

        //Todo: Update Action
        public ActionResult Update(Guid id)
        {
            ViewBag.SubCategories = subCategory.GetAll();
            return View(ProductService.GetById(id));
        }

        [HttpPost]
        public ActionResult Update(Product model,HttpPostedFileBase ImagePath,Guid SubCategoryID)
        {
            ViewBag.SubCategories = subCategory.GetAll();
            model.SubCategory = subCategory.GetById(SubCategoryID);
            model.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/Users/", ImagePath);
            ProductService.Update(model);
            return View("Index");
        }

        //Todo: Delete Action

        public ActionResult Delete(Guid id)
        {
            var deleted=ProductService.GetById(id);
            ProductService.Remove(deleted);
            return View("Index");
        }


    }
}