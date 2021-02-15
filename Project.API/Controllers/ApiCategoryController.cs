using Project.MODEL.Entities;
using ProjectVIEWMODEL.VMRepository;
using ProjectVIEWMODEL.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.API.Controllers
{
    public class ApiCategoryController : ApiController
    {

        //Ödeviniz bu tarz Vm entegrasyonu
        CategoryVMRepository crvm_repo = new CategoryVMRepository();


        [HttpPost]
        public List<CategoryVM> AddCategory(Category item)
        {
         return   crvm_repo.Add(item);

        }

    }
}
