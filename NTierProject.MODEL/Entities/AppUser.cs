using NTierProject.CORE.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace NTierProject.MODEL.Entities
{
    public class AppUser:CoreEntity
    {
        public AppUser()
        {
            isActive = false;
            ActivationCode = Guid.NewGuid();
        }
        public string Name { get; set; }
        public string SurName { get; set; }
        [Required(ErrorMessage ="Kullanıcı Adı zorunlu!")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Şifre girilmesi zorunlu")]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Şifreler uyumlu değil!")]
        [NotMapped]
        public string ConfirmPassword { get; set; }
        [Required,EmailAddress(ErrorMessage ="Lütfen geçerli bir email adresi giriniz.")]
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string ImagePath { get; set; }
        public Role? Role { get; set; }
        public DateTime? BirthDate { get; set; }

        public Guid ActivationCode { get; set; }
        public bool isActive { get; set; }
        //Mapping
        public List<Order> Orders { get; set; }

    }

    public enum Role
    {
        Banned=0,
        Member=1,
        Admin=2
    }

}
