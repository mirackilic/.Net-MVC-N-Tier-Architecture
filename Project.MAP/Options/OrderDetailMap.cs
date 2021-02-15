using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class OrderDetailMap:BaseMap<OrderDetail>
    {
        public OrderDetailMap()
        {
            ToTable("Satıslar");

            Ignore(x => x.ID);

            HasKey(x => new { x.OrderID, x.ProductID });

            Property(x => x.Quantity).HasColumnName("Miktar").IsOptional();

            Property(x => x.TotalPrice).HasColumnName("Toplam Fiyat").IsOptional();

            Property(x => x.OrderID).HasColumnName("SiparisID");

            Property(x => x.ProductID).HasColumnName("ÜrünID");
        }
    }
}
