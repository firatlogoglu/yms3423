using NtierProject.SERVICE.Option;
using NTierProject.COMMON.MyTools;
using NTierProject.MODEL.Entities;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierProject.WebUI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ProductService productService;
        SubCategoryService subCategory;
        public ProductController()
        {
            productService = new ProductService();
            subCategory = new SubCategoryService();
        }

        public ActionResult Index()
        {
            var products = productService.GetActive().OrderByDescending(x => x.CreatedDate).ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            ViewBag.SubCategoryID = new SelectList(subCategory.GetActive(), "ID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase ImagePath)
        {
            if (ModelState.IsValid)
            {
                product.ID = Guid.NewGuid();

                if (product.UnitsInStock <= 0)
                {
                    product.Status = CORE.Enums.Status.Deleted;
                    product.UnitsInStock = 0;
                    TempData["Error"] = product.ProductName + " isimli ürün, stoktaki ürün miktrı 0 veya negatif sayı olduğundan dolayı otomatik olarak stok miktarı 0 ve ürünü satıştan kaldırıldı. ";
                }

                //TODO: Yol ayarlanacak
                product.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", ImagePath);
                productService.Add(product);

                return RedirectToAction("Index");
            }

            ViewBag.SubCategoryID = new SelectList(subCategory.GetActive(), "ID", "Name", product.SubCategoryID);
            return View(product);
        }

        public ActionResult Update(Guid id)
        {
            Product product = productService.GetById(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            ViewBag.SubCategoryID = new SelectList(subCategory.GetActive(), "ID", "Name", product.SubCategoryID);
            return View(product);
        }

        [HttpPost]
        public ActionResult Update(Product product, HttpPostedFileBase ImagePath)
        {
            if (ImagePath != null)
            {
                product.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/", ImagePath);
                productService.Update(product);

                return RedirectToAction("Index");
            }
            else
            {
                product.ImagePath = productService.GetById(product.ID).ImagePath;
                productService.Update(product);

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(Guid id)
        {
            return View(productService.GetById(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            productService.Remove(productService.GetById(id));
            return RedirectToAction("Index");
        }
    }
}