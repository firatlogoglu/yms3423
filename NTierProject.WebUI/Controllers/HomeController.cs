using NtierProject.SERVICE.Option;
using NTierProject.COMMON.MyTools;
using NTierProject.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierProject.WebUI.Controllers
{
    public class HomeController : Controller
    {
        AppUserService appUser;
        public HomeController()
        {
            appUser = new AppUserService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(AppUser model, HttpPostedFileBase ImagePath)
        {

            if (ModelState.IsValid)
            {
                if (appUser.Any(x => x.UserName == model.UserName))
                {
                    ViewBag.ExistsUser = "Üye adı daha önce alınmış";
                    return View();
                }
                else if (appUser.Any(x => x.Email == model.Email))
                {
                    ViewBag.ExistsEmail = "Email daha önce kayıt edilmiş.";
                    return View();
                }
                else
                {
                    //Todo: Aktivasyon action tanımla.
                    model.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/Users/", ImagePath);
                    model.ID = Guid.NewGuid();
                    appUser.Add(model);
                    string sendMessage = "Tebrikler hesabınız oluşturuldu. Hesabınızı Aktive etmek için http://localhost:50247/Home/Aktivasyon/"+model.ActivationCode;

                    string _subject = $"Hoşgeldin {model.UserName}";

                    MailSender.Send(model.Email, sendMessage, _subject);

                    return View("RegisterOk");
                }
            }
            else
            {
                return View();
            }

            
            
        }

        public ActionResult RegisterOk()
        {
            return View();
        }

        
        public ActionResult Aktivasyon(Guid id)
        {
            if (appUser.Any(x => x.ActivationCode == id))
            {
                AppUser aktiveEdilecek = appUser.GetByDefault(x => x.ActivationCode == id);
                aktiveEdilecek.isActive = true;
                appUser.Update(aktiveEdilecek);

            }
            return View();
        }


    }
}