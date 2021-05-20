using NTierProject.CORE.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierProject.CORE.Map
{
    //EntityTypeConfiguration tipini eklemek için package manager console'a 
    //install-package entityframework yazıp paketi yüklememiz gerekmektedir.
    public class CoreMap<T>:EntityTypeConfiguration<T> where T:CoreEntity
    {
        public CoreMap()
        {
            Property(x => x.Status).HasColumnName("Status").IsOptional();
            Property(x => x.CreatedDate).HasColumnName("CreatedDate").IsOptional();
        }
    }
}


