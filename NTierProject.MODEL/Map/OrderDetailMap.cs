using NTierProject.CORE.Map;
using NTierProject.MODEL.Entities;

namespace NTierProject.MODEL.Map
{
    public class OrderDetailMap : CoreMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("dbo.OrderDetails");

            Property(x => x.UnitPrice).IsOptional();
            Property(x => x.Quantity).IsOptional();
        }
    }
}