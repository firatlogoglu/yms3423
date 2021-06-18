using NtierProject.SERVICE.Option;
using System;
using System.Web.Mvc;

namespace NTierProject.WebUI.Controllers
{
    public class SubCategoryController : Controller
    {

        SubCategoryService subcat;
        public SubCategoryController()
        {
            subcat = new SubCategoryService();
        }

        public ActionResult Index()
        {
            try
            {
                return View(subcat.GetActive());
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}