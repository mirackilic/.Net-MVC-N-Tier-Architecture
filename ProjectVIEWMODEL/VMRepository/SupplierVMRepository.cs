using Project.BLL.RepositoryPattern.RepositoryBase;
using ProjectVIEWMODEL.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIEWMODEL.VMRepository
{
   public class SupplierVMRepository:BaseRepository<SupplierVM>
    {
        public override List<SupplierVM> SelectActives()
        {
            return db.Suppliers.Where(x => x.Status != Project.MODEL.Enums.DataStatus.Deleted).Select(x => new SupplierVM
            {
                CompanyName = x.CompanyName
            }).ToList();
        }
    }
}
