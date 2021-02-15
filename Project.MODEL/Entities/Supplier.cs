using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
   public class Supplier:BaseEntity
    {
        public Supplier()
        {
            Products = new List<Product>();
        }
        public string CompanyName { get; set; }

        public string Contact { get; set; }

        //Relational Properties

        // 1 supplier n urun
        // 1  urun    1 Supplier

        public virtual List<Product> Products { get; set; }


    }
}
