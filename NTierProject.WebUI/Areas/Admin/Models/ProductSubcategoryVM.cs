using NTierProject.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NTierProject.WebUI.Areas.Admin.Models
{
    public class ProductSubcategoryVM
    {
     
        public Product Product { get; set; }
        public List<SubCategory> SubCategories{ get; set; }
    }
}