using NtierProject.SERVICE.Option;
using System;
using System.Web.Mvc;

namespace NTierProject.WebUI.Controllers
{
    public class ProductController : Controller
    {
        ProductService ps;
        public ProductController()
        {
            ps = new ProductService();
        }

        public ActionResult Index()
        {
            try
            {
                return View(ps.GetActive());
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}