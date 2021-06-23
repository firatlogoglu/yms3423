using NTierProject.MODEL.Entities;
using System.Collections.Generic;

namespace NTierProject.WebUI.Areas.Admin.Models
{
    public class ProductSubcategoryVM
    {
        public Product Product { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}