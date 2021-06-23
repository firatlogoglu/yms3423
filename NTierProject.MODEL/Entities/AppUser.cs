using NTierProject.CORE.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace NTierProject.MODEL.Entities
{
    public class AppUser : CoreEntity
    {
        public AppUser()
        {
            isActive = false;
            ActivationCode = Guid.NewGuid();
        }

        [Display(Name = "İsim")]
        public string Name { get; set; }

        [Display(Name = "Soy İsim")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı zorunlu!"), Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Şifre girilmesi zorunlu"), Display(Name = "Şifre")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Şifreler uyumlu değil!"), Display(Name = "Şifreyi Tekrar Girin")]
        //[NotMapped]
        public string ConfirmPassword { get; set; }

        [Required, EmailAddress(ErrorMessage = "Lütfen geçerli bir email adresi giriniz."), Display(Name = "E-posta Adresi")]
        public string Email { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Telefon No")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Lütfen bir görsel seçin"), Display(Name = "Görsel")]
        public string ImagePath { get; set; }

        [Display(Name = "Yetki")]
        public Role? Role { get; set; }

        [Display(Name = "Doğum Tarihi")]
        public DateTime? BirthDate { get; set; }

        public Guid ActivationCode { get; set; }
        public bool isActive { get; set; }

        //Mapping
        public List<Order> Orders { get; set; }
    }

    public enum Role
    {
        Banned = 0,
        Member = 1,
        Admin = 2
    }
}