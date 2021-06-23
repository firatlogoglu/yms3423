using NTierProject.CORE.Entity;
using System.ComponentModel.DataAnnotations;

namespace NTierProject.MODEL.Entities
{
    public class OrderDetail : CoreEntity
    {
        public Product Product { get; set; }
        public Order Orders { get; set; }

        [Required(ErrorMessage = "Lütfen ürünün birim fiyatını girin"), Display(Name = "Birim Fiyatı")]
        public decimal UnitPrice { get; set; }

        [Required(ErrorMessage = "Lütfen miktarı girin"), Display(Name = "Miktar")]
        public short? Quantity { get; set; }
    }
}