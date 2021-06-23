using NtierProject.SERVICE.Option;
using NTierProject.COMMON.MyTools;
using NTierProject.MODEL.Entities;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierProject.WebUI.Areas.Admin.Controllers
{
    public class AppUserController : Controller
    {
        AppUserService appUserService = new AppUserService();
        public ActionResult Index()
        {
            return View(appUserService.GetActive().OrderByDescending(x => x.CreatedDate).ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AppUser model, HttpPostedFileBase ImagePath)
        {
            model.ID = Guid.NewGuid();
            model.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/Users/", ImagePath);
            model.Password = model.ConfirmPassword = Guid.NewGuid().ToString();
            model.isActive = true;

            appUserService.Add(model);
            MailSender.Send(model.Email, "Sayın " + model.Name + " " + model.SurName + "," + "\n" + "İsteğiniz üzerine hesabınız açılmıştır." + "\n" + "Şifreniz: " + model.Password + "\n" + "\n" + "Giriş yaptıktan sonra lütfen şifrenizi değiştiriniz!", "Sitemize Hoşgeldiniz");
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid Id)
        {
            return View(appUserService.GetById(Id));
        }

        [HttpPost]
        public ActionResult Edit(AppUser appUser, HttpPostedFileBase ImagePath)
        {
            string cEmailMsg = null;

            if (appUserService.CheckAgainEmailAddres(appUser, out string msgMail, out AppUser appMailUserout, out cEmailMsg))
            {
                TempData["Error"] = msgMail;
                return View(appMailUserout);
            }

            appUserService.CheckImageFullEmpty(appUser, ImagePath, cEmailMsg);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid Id)
        {
            return View(appUserService.GetById(Id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid Id)
        {
            appUserService.Remove(appUserService.GetById(Id));
            return RedirectToAction("Index");
        }

        public ActionResult ResetPassword(Guid id)
        {
            AppUser user = appUserService.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("ResetPassword")]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPasswordConfirmed(Guid id)
        {
            AppUser user = appUserService.GetById(id);
            user.Password = user.ConfirmPassword = Guid.NewGuid().ToString();

            //TODO: Session veya cookie tanımlandığında değiştirenin id veya mail adresi ModifiedBy'a verilecek.
            //user.ModifiedBy = Email;
            appUserService.Update(user);

            MailSender.Send(user.Email, "Sayın " + user.Name + " " + user.SurName + "," + "\n" + "İsteğiniz üzerine şifreniz sıfırlandı." + "\n" + "Yeni Şifreniz: " + user.Password + "\n" + "\n" + "Giriş yaptıktan sonra lütfen şifrenizi değiştiriniz!", "Şifreniz sıfırlandı");
            return RedirectToAction("Index");
        }
    }
}