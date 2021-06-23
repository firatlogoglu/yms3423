using System.Web.Mvc;

namespace NTierProject.WebUI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}