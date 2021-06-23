using NTierProject.CORE.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NTierProject.MODEL.Entities
{
    public class Order : CoreEntity
    {
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }

        [Display(Name = "Kullanıcı ID")]
        public Guid AppUserID { get; set; }

        public virtual AppUser AppUser { get; set; }

        [Display(Name = "Onaylandı mı?")]
        public bool Confirmed { get; set; }

        //Mapping

        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}