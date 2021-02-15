using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public abstract class PictureSpecific : BaseEntity
    {
        //Burada DataAnnotation kullanmamızın sebebi sadece bu property'nin sadece belli classlarda olması ve dolayısıyla sadece onlarda map'lenmek istenmesidir. Biz eger BaseEntity'e ImagePath olarak bir property verirsek bu sınıfı acmak zorunda kalmayız ancak bütün sınıflara da ImagePath vermiş oluruz. Bu demektir ki istemedigimiz sınıflar icin bu property'i ignore etmemiz gerekir. Bu da pek hos bir durum olmaz. O yüzden eger DataAnnotation kullanmasaydık bu sınıfın ayarlamasını ayrı bir map'te yapmak zorundaydık. Bu sefer de PictureMap'in ya BaseMap'ten bagımsız olarak EntityTypeConfiguration'dan miras alması gerekecek(ki bu demektir ki BaseMap'teki tüm görevleri burada bastan yazacagız-kod tekrarı) veya BaseMap'ten miras alıp BaseMap'in generic olarak devam etmesini saglayacak ki PictureSpecific olan Product ve AppUser'a miras verdiginde nereye gidecegini bilebilsin(ki bu da Performans olarak sistemi asırı sekilde yorar)



        //Sütun ismi dosya yolu olsun maksimum uzunlugu da nvarchar olsun.
        [Column("Dosya Yolu"), MaxLength(1000)]
        public string ImagePath { get; set; }

    }
}
