using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class  AppUserDetail:BaseEntity
    {
        [Required(ErrorMessage ="Lütfen isminizi giriniz"),MaxLength(30,ErrorMessage ="Maksimum 30 karakter girebilirsiniz")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lütfen soyisminizi giriniz"), MaxLength(30, ErrorMessage = "Maksimum 30 karakter girebilirsiniz")]
        public string LastName { get; set; }

        public string Address { get; set; }

        public DateTime BirthDate { get; set; }



        //Relational Properties

        //one-to one with AppUser

        public virtual AppUser AppUser { get; set; }


    }
}
