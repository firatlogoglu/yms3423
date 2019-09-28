
using NTierProject.CORE.Map;
using NTierProject.MODEL.Entities;

namespace NTierProject.MODEL.Map
{
    public class ProductMap:CoreMap<Product>
    {
        public ProductMap()
        {
            ToTable("dbo.Products");

        }
    }
}
