using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierProject.MODEL.Entities
{
    public class TestList
    {
        public static List<Product> Products = new List<Product>()
        {
            new Product{ID= new Guid(), UnitPrice=50, ProductName="Boron", ImagePath=""},
            new Product{ID= new Guid(), UnitPrice=25, ProductName="Mouse4", ImagePath=""},
            new Product{ID = new Guid(), UnitPrice=30, ProductName="Klavye", ImagePath=""},
            new Product{ID=new Guid(), UnitPrice=60, ProductName="Monitör", ImagePath=""}
        };

        
    }
}
