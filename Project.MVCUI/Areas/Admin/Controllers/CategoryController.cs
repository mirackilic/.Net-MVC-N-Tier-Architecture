using Project.BLL.RepositoryPattern.ConcreteRepository;
using Project.MODEL.Entities;
using Project.MVCUI.AuthenticationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Areas.Admin.Controllers
{
    //[AdminAuthentication]
    public class CategoryController : Controller
    {
        CategoryRepository cat_repo = new CategoryRepository();
        // GET: Admin/Category
        public ActionResult CategoryList()
        {
            return View(cat_repo.SelectActives());
        }


        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category item)
        {
            cat_repo.Add(item);
            return RedirectToAction("CategoryList");
        }



        public ActionResult UpdateCategory(int id)
        {
            return View(cat_repo.GetByID(id));
        }

        [HttpPost]

        public ActionResult UpdateCategory(Category item)
        {
            cat_repo.Update(item);
            return RedirectToAction("CategoryList");
        }


        public ActionResult DeleteCategory(int id)
        {
            cat_repo.Delete(cat_repo.GetByID(id));
            return RedirectToAction("CategoryList");
        }








    }
}