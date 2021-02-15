using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class OrderMap:BaseMap<Order>
    {
        public OrderMap()
        {
            ToTable("Siparişler");

            Property(x => x.ShippedAddress).HasColumnName("Gönderim Adresi").HasMaxLength(300).IsRequired();

            Property(x => x.RequiredDate).IsOptional().HasColumnName("Son Teslim Tarihi");

            Property(x => x.AppUserID).HasColumnName("KullanıcıID").IsOptional();
        }
    }
}
