using NTierProject.CORE.Map;
using NTierProject.MODEL.Entities;
namespace NTierProject.MODEL.Map
{
    public class OrderMap:CoreMap<Order>
    {
        public OrderMap()
        {
            ToTable("dbo.Orders");

            HasRequired(x => x.AppUser)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.AppUserID);
        }
    }
}
