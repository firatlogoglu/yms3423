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
    public class AppUserController : Controller
    {
        AppUserService appUser = new AppUserService();
        public ActionResult Index()
        {
            return View(appUser.GetActive().OrderByDescending(x => x.CreatedDate).ToList());
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

            appUser.Add(model);
            MailSender.Send(model.Email, "Sayın " + model.Name + " " + model.SurName + "," + "\n" + "İsteğiniz üzerine satıcı hesabınız açılmıştır." + "\n" + "Şifreniz: " + model.Password + "\n" + "\n" + "Giriş yaptıktan sonra lütfen şifrenizi değiştiriniz!", "Sitemize Hoşgeldiniz");
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid Id)
        {
            return View(appUser.GetById(Id));
        }

        [HttpPost]
        public ActionResult Edit(AppUser model, HttpPostedFileBase ImagePath)
        {
            //TODO: Mail adresi değiştirildiğinde eski mail adresine "Mail adresiniz değiştirildi." şeklinde mail atılacak.

            if (ImagePath != null)
            {
                model.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/Users/", ImagePath);
                appUser.Update(model);
            }
            else
            {
                model.ImagePath = appUser.GetById(model.ID).ImagePath;
                appUser.Update(model);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid Id)
        {
            return View(appUser.GetById(Id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid Id)
        {
            appUser.Remove(appUser.GetById(Id));
            appUser.Save();
            return RedirectToAction("Index");
        }

        public ActionResult ResetPassword(Guid id)
        {
            AppUser user = appUser.GetById(id);
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
            AppUser user = appUser.GetById(id);
            user.Password = user.ConfirmPassword = Guid.NewGuid().ToString();

            //TODO: Session veya cookie tanımlandığında değiştirenin id veya mail adresi ModifiedBy'a verilecek.
            //user.ModifiedBy = Email;
            appUser.Update(user);

            MailSender.Send(user.Email, "Sayın " + user.Name + " " + user.SurName + "," + "\n" + "İsteğiniz üzerine şifreniz sıfırlandı." + "\n" + "Yeni Şifreniz: " + user.Password + "\n" + "\n" + "Giriş yaptıktan sonra lütfen şifrenizi değiştiriniz!", "Şifreniz sıfırlandı");
            return RedirectToAction("Index");
        }
    }
}