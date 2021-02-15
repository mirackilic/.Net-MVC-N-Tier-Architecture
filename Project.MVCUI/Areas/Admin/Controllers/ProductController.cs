using Project.BLL.RepositoryPattern.ConcreteRepository;
using Project.MODEL.Entities;
using Project.TOOLS.MyTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository pro_repo = new ProductRepository();
        CategoryRepository cat_repo = new CategoryRepository();


        public ActionResult ProductList()
        {
            return View(pro_repo.SelectActives());
        }


        public ActionResult AddProduct()
        {
            return View(Tuple.Create(new Product(),cat_repo.SelectActives()));
        }


        [HttpPost]
        public ActionResult AddProduct([Bind(Prefix ="Item1")]Product item,HttpPostedFileBase resim)
        {

            item.ImagePath = ImageUploader.UploadImage("~/Pictures",resim);
            pro_repo.Add(item);
            return RedirectToAction("ProductList");
        }


        public ActionResult ProductDetail(int id)
        {
            return View(pro_repo.GetByID(id));

        }





    }
}