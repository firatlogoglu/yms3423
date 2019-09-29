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
            appUser.Add(model);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(Guid Id)
        {
            return View(appUser.GetById(Id));
        }

        [HttpPost]
        public ActionResult Edit(AppUser model, HttpPostedFileBase ImagePath)
        {
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
    }
}