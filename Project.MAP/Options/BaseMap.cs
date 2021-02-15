using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Options
{
   public abstract class BaseMap<T>:EntityTypeConfiguration<T> where T:BaseEntity
    {
        public BaseMap()
        {

            Property(x => x.Status).HasColumnName("Veri Durumu");

            Property(x => x.CreatedDate).HasColumnName("Olusturma Tarihi").HasColumnType("datetime2").IsOptional();

            Property(x => x.ModifiedDate).HasColumnName("Güncelleme Tarihi").HasColumnType("datetime2").IsOptional();

            Property(x => x.ModifiedBy).HasColumnName("Güncelleyen").HasMaxLength(60);

            Property(x => x.CreatedBy).HasColumnName("Olusturan").HasMaxLength(60);

        }

       




    }
}
