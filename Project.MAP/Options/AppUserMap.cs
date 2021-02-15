using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
    public class AppUserMap:BaseMap<AppUser>
    {
        public AppUserMap()
        {

            ToTable("Kullanıcılar");
            Property(x => x.UserName).HasColumnName("Kullanıcı İsmi").IsRequired().HasMaxLength(70);

            Property(x => x.Password).HasColumnName("Şifre").HasMaxLength(200).IsRequired();

            HasOptional(x => x.AppUserDetail).WithRequired(x => x.AppUser);

            Ignore(x => x.RePassword);

            Property(x => x.ActivationCode).HasColumnName("Aktivasyon Kodu");

            Property(x => x.Role).HasColumnName("Rolü");

            Property(x => x.IsBanned).HasColumnName("Yasaklımı");

            Property(x => x.IsActive).HasColumnName("Hesap Aktifmi");

            Property(x => x.Email).IsRequired().HasMaxLength(200).HasColumnName("E-Posta");

            Property(x => x.UserIP).HasColumnName("Bilgisayar IP").HasMaxLength(50);

            Property(x => x.UserIdentity).HasColumnName("Bilgisayar ismi").HasMaxLength(50);
        }
    }
}
