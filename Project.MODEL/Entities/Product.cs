using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
   public class Product:PictureSpecific
    {
        public string ProductName { get; set; }

        public short UnitsInStock { get; set; }

        public decimal? UnitPrice { get; set; }

        public int? CategoryID { get; set; }


        public int? SupplierID { get; set; }
        //Relational one to many with Category


        public virtual Category Category { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }

        public virtual Supplier Supplier { get; set; }





    }
}
