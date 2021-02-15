using Projec.TOOLS.MyTools;
using Project.BLL.RepositoryPattern.ConcreteRepository;
using Project.DAL.Context;
using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class HomeController : Controller
    {
        //Todo:Dikkat edin mail gönderme sınıfı etkisiz hale getirilmiştir. Sizin eklediginiz üyeyi aktif etmeniz gerekir.

        // GET: Home
        public ActionResult Login()
        {
            AppUser girecekOlan = CheckCookie();
            if (girecekOlan == null) return View();
           

            return View(girecekOlan);
        }


        [HttpPost]
        //asagıdaki ikinci parametrenin name attribute'unun front enddeki tagimizle aynı olmasına dikkat ediniz.
        public ActionResult Login(AppUser item, string Hatirla)
        {
            if (apUser_repository.Any(x => x.UserName == item.UserName && x.Role == MODEL.Enums.Role.Admin && x.Status != MODEL.Enums.DataStatus.Deleted))
            {
                //Hashlenmiş bir passwordu girilen sade password ile karsılayabilmek icin MVC'nin VerifyHashedPassword metodunu kullanabilirsiniz. Bu metot size bool sonuc döndürür.

                AppUser girisYapan = apUser_repository.Default(x => x.UserName == item.UserName && x.Role == MODEL.Enums.Role.Admin);

                bool sonuc = Crypto.VerifyHashedPassword(girisYapan.Password, item.Password);

                if (sonuc)
                {
                    HatirlaKontrol(item, Hatirla);

                    Session["admin"] = girisYapan;

                    return RedirectToAction("CategoryList", "Category", new { area = "AdminSpecial" });
                }


            }
            else if (apUser_repository.Any(x => x.UserName == item.UserName && x.Role == MODEL.Enums.Role.Member))
            {
                AppUser girisYapanUye = apUser_repository.Default(x => x.UserName == item.UserName);

                bool sonuc = Crypto.VerifyHashedPassword(girisYapanUye.Password, item.Password);

                if (sonuc)
                {
                    HatirlaKontrol(item, Hatirla);
                    Session["member"] = girisYapanUye;
                    return RedirectToAction("ShoppingList","Member"); //burası eskiden Index'ti biz ShoppingList'e cektik.
                }
                //Area/Controller/Action


                //Controller/Action
                //Member/Index
            }



            return View();
        }

        AppUserRepository apUser_repository = new AppUserRepository();

        AppUserDetailRepository apDetail_repository = new AppUserDetailRepository();


        //Url'de Action'dan sonraki slashtan sonra gönderecegimiz verinin direkt Action'in parametresine gidebilmesi icin Action'in parametresinin isminin sablonda Action slashindan sonra belirlenen isim olması gerekir.


        #region BeniHatirla


        private void HatirlaKontrol(AppUser item, string Hatirla)
        {
            //Burada kullanıcı cookie'de var mı bu kontrol edilecek

            if (Hatirla == "true")
            {
                HttpCookie girisIsim = new HttpCookie("userName"); //Cookie olusturduk
                girisIsim.Expires = DateTime.Now.AddMinutes(5);
                girisIsim.Value = item.UserName;
                //Cookie eklemek icin Response'lara bir ekleme yapmalıyız

                Response.Cookies.Add(girisIsim);

                HttpCookie girisSifre = new HttpCookie("password");
                girisSifre.Expires = DateTime.Now.AddMinutes(5);
                girisSifre.Value = item.Password;
                Response.Cookies.Add(girisSifre);
            }
        }




        //Cookie client side bir durum yönetimidir.
        //Cookie'de saklanan bir degeri yakalayabilmek icin Request property'sini kullanırız.

        private AppUser CheckCookie()
        {
            string userName = string.Empty, password = string.Empty;

            AppUser cookiedeSaklanan = null;


            if (Request.Cookies["userName"] != null && Request.Cookies["password"] != null)
            {
                userName = Request.Cookies["userName"].Value;
                password = Request.Cookies["password"].Value;
            }

            //Client Side validation icin bu kontrole cok gerek yok
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                cookiedeSaklanan = new AppUser
                {
                    UserName = userName,
                    Password = password
                };
            }
            return cookiedeSaklanan;

        }


        #endregion





        public ActionResult Register(Guid? id)
        {

            //Home/Register/asdasd-asdasd-asdasd-asdasdasd
            if (id != null)
            {

                if (apUser_repository.Any(x => x.ActivationCode == id))
                {
                    AppUser aktifedilecek = Session["register"] as AppUser;
                    aktifedilecek.IsActive = true;

                    apUser_repository.Update(aktifedilecek); //yapmayı unutmayın yoksa kullanıcı pasif olarak kalır.
                    //Burada kullanıcı baska bir action'a login gibi bir action'a da yönlendirilebilir. Tabii o zaman TempData kullanmanız gerekir.

                    TempData["Tebrikler"] = "Tebrikler basarılı bir sekilde hesabınız aktif olmustur";


                }
                else
                {
                    //Kişi özellikle 3th party uygulamalarla girmeye calısıyorsa ve guid göndermeyi basarmıssa veritabanında engellenecek
                    ViewBag.KullaniciYok = "Kullanıcı olarak giriş yapmadınız";
                }

            }
            else if (Session["register"] != null && id == null)
            {
                if ((Session["register"] as AppUser).IsActive == false)
                {
                    ViewBag.AktifDegil = "Hesabınızı aktif etmemişsiniz";
                }
            }

            return View();
        }

        [HttpPost]

        public ActionResult Register([Bind(Prefix = "Item1")] AppUser item1, [Bind(Prefix = "Item2")] AppUserDetail item2)
        {
            if (apUser_repository.Any(x => x.UserName == item1.UserName))
            {
                ViewBag.ZatenVar = "Böyle bir kullanıcı zaten kayıtlıdır";
                return View();
            }

            //Kullanıcı basarılı bir şekilde register işlemini tamamladıysa ona mail gönder

            string gonderilecekMesaj = "Tebrikler hesabınız olusturulmustur. Hesabınızı aktif etmek icin http://localhost:60181/Home/Register/" + item1.ActivationCode + " linkine tıklayabilirsiniz.";

            #region MailGondermeIslemi
            //göndericinin mail adresi sifresini buradaki gibi bos bırakmayın
            //MailSender.Send(item1.Email, password: "", body: gonderilecekMesaj, subject: "Hosgeldiniz!");
            #endregion

            item1.Password = Crypto.HashPassword(item1.Password); //sifreyi hashledik
            apUser_repository.Add(item1);
            item2.ID = item1.ID;

            Session["register"] = apUser_repository.GetByID(item1.ID); //Kullanıcı register oldugu anda onun icin bir session actık.
            apDetail_repository.Add(item2);
            return RedirectToAction("RegisterOk");
        }


        public ActionResult RegisterOk()
        {
            return View();
        }










    }
}