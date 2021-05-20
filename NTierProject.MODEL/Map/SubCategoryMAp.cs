using NTierProject.CORE.Map;
using NTierProject.MODEL.Entities;

namespace NTierProject.MODEL.Map
{
   public class SubCategoryMap:CoreMap<SubCategory>
    {
        public SubCategoryMap()
        {
            ToTable("dbo.SubCategories");


            HasMany(x => x.Products)
                .WithRequired(x => x.SubCategory)
                .HasForeignKey(x => x.SubCategoryID);
        }
    }
}
