using NtierProject.SERVICE.Option;
using System;
using System.Web.Mvc;

namespace NTierProject.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService cat;
        public CategoryController()
        {
            cat = new CategoryService();
        }

        public ActionResult Index()
        {
            try
            {
                return View(cat.GetActive());
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}