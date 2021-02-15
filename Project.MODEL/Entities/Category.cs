using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MODEL.Entities
{
    public class Category : BaseEntity
    {
        //Bir kategorinin Product ile ilişkisi vardır ve bu ilişki Bire cok ilişkidir. Yani her Kategorinin bos olsa bile bir Product koleksiyonu vardır. Eger burada Constructor'da Category'nin List<Product> tipindeki property'sinin icerisine bir nesne vermezsek dısarıda vermek zorunda kalırız. Eger vermezseniz nullreferenceexception hatası alırsınız.
        public Category()
        {
            Products = new List<Product>();
        }


        public string CategoryName { get; set; }

        public string Description { get; set; }

        //Relational Properties one to many with Product

        public virtual List<Product> Products { get; set; }



    }
}
