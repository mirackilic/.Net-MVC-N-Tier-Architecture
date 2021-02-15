using Project.BLL.RepositoryPattern.ConcreteRepository;
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
    public class APIAppUserController : ApiController
    {


        AppUserVMRepository ap_repository = new AppUserVMRepository();

        [HttpGet]
        public List<AppUserVM> GetAppUsers()
        {

            return ap_repository.SelectActives();



            
        }



    }
}
