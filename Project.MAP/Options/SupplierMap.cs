using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class SupplierMap : BaseMap<Supplier>
    {
        public SupplierMap()
        {
            ToTable("Tedarikçiler");
            Property(x => x.CompanyName).HasColumnName("Şirket İsmi").HasMaxLength(100).IsRequired();

            Property(x => x.Contact).HasColumnName("Yetkili").HasMaxLength(30);
        }
    }
}
