using NTierProject.CORE.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NTierProject.MODEL.Entities
{
    public class Category : CoreEntity
    {
        [Required(ErrorMessage = "Lütfen bir isim girin"), Display(Name = "Kategori Adı")]
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        public string Description { get; set; }

        //Mapping
        public virtual List<SubCategory> SubCategories { get; set; }
    }
}