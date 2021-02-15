using Project.BLL.RepositoryPattern.RepositoryBase;
using Project.BLL.SingletonPattern;
using Project.DAL.Context;
using ProjectVIEWMODEL.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIEWMODEL.VMRepository
{
    public class AppUserDetailVMRepository : BaseRepository<AppUserDetailVM>
    {
       
        public override List<AppUserDetailVM> SelectActives()
        {
            return db.AppUserDetails.Where(x => x.Status != Project.MODEL.Enums.DataStatus.Deleted).Select(x => new AppUserDetailVM
            {
                ID = x.ID,
                FirstName = x.FirstName,
                LastName = x.LastName,


            }).ToList();
        }
    }
}
