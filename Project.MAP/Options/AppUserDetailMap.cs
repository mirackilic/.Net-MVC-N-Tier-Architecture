using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
   public class AppUserDetailMap:BaseMap<AppUserDetail>
    {
        public AppUserDetailMap()
        {
            ToTable("Kullanıcı Profilleri");
            Property(x => x.FirstName).IsRequired().HasColumnName("İsim").HasMaxLength(50);

            Property(x => x.LastName).IsRequired().HasColumnName("Soyisim").HasMaxLength(50);

            Property(x => x.Address).IsOptional().HasColumnName("İkamet Adresi").HasMaxLength(300);

            Property(x => x.BirthDate).IsOptional().HasColumnName("Dogum Tarihi");

            


        }

    }
}
