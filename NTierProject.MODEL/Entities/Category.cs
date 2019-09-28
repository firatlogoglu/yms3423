using NTierProject.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierProject.MODEL.Entities
{
    public class Category:CoreEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        //Mapping
        public virtual List<SubCategory> SubCategories { get; set; }

    }
}
