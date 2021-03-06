﻿using NTierProject.CORE.Entity;
using System;
using System.Collections.Generic;

namespace NTierProject.MODEL.Entities
{
    public class Order:CoreEntity
    {
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
        public Guid AppUserID { get; set; }
        public virtual AppUser AppUser{ get; set; }
        public bool Confirmed { get; set; }

        //Mapping

        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}