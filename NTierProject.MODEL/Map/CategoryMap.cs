using NTierProject.CORE.Map;
using NTierProject.MODEL.Entities;

namespace NTierProject.MODEL.Map
{
    public class CategoryMap:CoreMap<Category>
    {
        public CategoryMap()
        {
            ToTable("dbo.Categories");

            HasMany(x => x.SubCategories)
                .WithRequired(x => x.Category)
                .HasForeignKey(x => x.CategoryID);

        }
    }
}
