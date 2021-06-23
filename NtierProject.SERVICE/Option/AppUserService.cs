using NtierProject.SERVICE.Base;
using NTierProject.COMMON.MyTools;
using NTierProject.MODEL.Entities;
using System.Web;

namespace NtierProject.SERVICE.Option
{
    public class AppUserService : BaseService<AppUser>
    {
        public bool CheckCredentials(string _username, string _password)
        {
            return Any(x => x.UserName == _username && x.Password == _password);
        }

        public bool CheckEmail(string _email)
        {
            return Any(x => x.Email == _email);
        }

        public bool CheckAgainEmailAddres(AppUser appUser, out string errorMsg, out AppUser appUserOut, out string cEmailMsg)
        {
            errorMsg = null;
            appUserOut = appUser;
            cEmailMsg = null;

            if (appUser.Email != GetById(appUser.ID).Email)
            {
                if (CheckEmail(appUser.Email))
                {
                    errorMsg = appUser.Email + " e-posta adresi, kayıtlarımızda mevcut.";
                    appUser.ImagePath = GetById(appUser.ID).ImagePath;
                    appUserOut = appUser;
                    return true;
                }
                cEmailMsg = "E-posta adresiniz, isteğiniz üzerine, " + appUser.Email + " şeklinde değiştirilmiştir: ";
                return false;
            }
            return false;
        }

        public void CheckImageFullEmpty(AppUser appUser, HttpPostedFileBase ImagePath, string cEmailMsg)
        {
            string subject = "Hesap Değişikliği";
            string cEmail = GetById(appUser.ID).Email;
            //
            string body1 = "Sayın " + appUser.Name + " " + appUser.SurName + "," + "\n" + "İsteğiniz üzerine müşteri hesabınız değiştirilmiştir." + "\n" + "Bu hesap değiştirme işlemi, isteğiniz üzerine yapılmıştır.";
            string body2 = "Sayın " + appUser.Name + " " + appUser.SurName + "," + "\n" + "İsteğiniz üzerine müşteri hesabınız değiştirilmiştir." + "\n" + cEmailMsg + "\n" + "Bu hesap değiştirme işlemi, isteğiniz üzerine yapılmıştır.";
            //

            if (ImagePath != null)
            {
                appUser.ImagePath = ImageUploader.UploadSingleImage("~/Uploads/Image/Users/", ImagePath);
            }
            else
            {
                appUser.ImagePath = GetById(appUser.ID).ImagePath;
            }

            Update(appUser);
            if (cEmailMsg == null)
            {
                MailSender.Send(appUser.Email, body1, subject);
            }
            else
            {
                MailSender.Send(cEmail, body2, subject);
                MailSender.Send(appUser.Email, body2, subject);
            }
        }

    }
}