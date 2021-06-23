using NtierProject.SERVICE.Option;
using NTierProject.MODEL.Entities;
using System.Web.Mvc;

namespace NTierProject.WebUI.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AppUser kullanici)
        {
            if (kullanici.UserName != null && kullanici.Password != null)
            {
                AppUserService appUserService = new AppUserService();
                if (appUserService.CheckCredentials(kullanici.UserName, kullanici.Password))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Error"] = "Kullanıcı adı veya şifre yanlış.";
                    return View();
                }
            }
            else
            {
                TempData["Error"] = "Kullanıcı adı veya şifre boş olamaz.";
                return View();
            }
        }
    }
}