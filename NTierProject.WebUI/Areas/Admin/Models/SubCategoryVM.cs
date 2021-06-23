using NTierProject.MODEL.Entities;
using System.Collections.Generic;

namespace NTierProject.WebUI.Areas.Admin.Models
{
    public class SubCategoryVM
    {
        public List<Category> Categories { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}