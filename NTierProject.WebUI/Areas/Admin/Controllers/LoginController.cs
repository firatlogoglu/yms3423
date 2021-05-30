using NTierProject.MODEL.Context;
using NTierProject.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierProject.WebUI.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login

        public ActionResult Login()
        {
            return View();
        }
        ProjectContext db = new ProjectContext();

        [HttpPost]
        public ActionResult Login(AppUser kullanici)
        {
            if(kullanici != null)
            {
                using (ProjectContext context = new ProjectContext())
                {
                    var user = context.Users.FirstOrDefault(x => x.UserName == kullanici.UserName && x.Password == kullanici.Password);



                    return RedirectToAction("Index", "Home");


                }
            }
            else
            {
                return View();
            }        
        }
    }
}