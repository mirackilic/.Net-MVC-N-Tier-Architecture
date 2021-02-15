using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class OrderDetail : BaseEntity
    {

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public short Quantity { get; set; }

        public decimal? TotalPrice { get; set; }


        //Relational Properties (many to many with Product and Order)

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
