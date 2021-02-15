using ProjectVIEWMODEL.VMRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Project.API.Controllers
{
    public class APIAppUserDetailController : ApiController
    {
        AppUserDetailVMRepository apr_repository = new AppUserDetailVMRepository();
    }
}
