using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.MVCUI.Models.MyEntities
{
    public class Cart
    {
        //Sepetten ürün cıkar,sepete ürün ekle, güncelleyi

        //List<CartItem> List.Remove(sepetUrunu.ID) List bir key barındırmadıgından dolayı ilgili id'yi alsa o id'ye sahip bir key belirlenemeyeecginden istediginiz ürünü silme işlemini yapamaz.

        //Dictionary<int,CartItem>  Dictionary.Remove(int)

        //Bir koleksiyondan o koleksiyonun elemanına özel bir key kesiminden silme yapmak istedigimiz durumlarda Dictionary oldukca rahat bir yapıdır.

        Dictionary<int, CartItem> _sepetim = new Dictionary<int, CartItem>();

        public List<CartItem> Sepetim
        {
            get
            {
                return _sepetim.Values.ToList();
            }
        }

        //BU metodumuz kendi icerisinde bir kontrol yaparak calısacak. Eger kullanıcı daha önce bir ürünü secmişs onun adedini arttıracak secmemişse ekleyecek...
        public void SepeteEkle(CartItem item)
        {
            if (_sepetim.ContainsKey(item.ID))
            {
                _sepetim[item.ID].Amount += 1;
                return;
            }
            _sepetim.Add(item.ID,item);
        }


        public void SepettenSil(int id)
        {
            if (_sepetim[id].Amount>1)
            {
                _sepetim[id].Amount -= 1;
                return;
            }
           
            _sepetim.Remove(id);
        }

        //Sepet güncelleme ödev!! (Sadece amount'ın güncellenebilmesini istiyorum)
    }
}