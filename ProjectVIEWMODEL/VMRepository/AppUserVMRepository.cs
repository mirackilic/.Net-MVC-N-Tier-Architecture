using Project.BLL.RepositoryPattern.RepositoryBase;
using Project.BLL.SingletonPattern;
using Project.DAL.Context;
using Project.MODEL.Entities;
using ProjectVIEWMODEL.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIEWMODEL.VMRepository
{
   public class AppUserVMRepository:BaseRepository<AppUserVM>
    {
      
        public override List<AppUserVM> SelectActives()
        {
            return db.AppUsers.Select(x => new AppUserVM
            {
                ID = x.ID,
                UserName = x.UserName,
                Password = x.Password
            }).ToList();
        }
    }
}
