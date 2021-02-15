using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    //Controller/Action

    //Area/Controller/Action

        //AdminSpecial

        //Admin/Home/Index

        //Admin/Index


    public class Order : BaseEntity
    {
        public string ShippedAddress { get; set; }

        public DateTime? RequiredDate { get; set; }

        public int? AppUserID { get; set; }



        //Relational Properties with APpUser(one-to-many) and with OrderDetail(many to many)

        public virtual AppUser AppUser { get; set; }

        //AppUser zaten icerisinde AppUser tipinde bir nesneyi alıp arka planda bunu field'a atan bir property'dir. O halde neden acıkca ID'yi yazmam tavsiye ediliyor. (ipucu:CodeFirst'in sundugu özgürlükle)
        public virtual List<OrderDetail> OrderDetails { get; set; }


    }
}
