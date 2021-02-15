using Project.BLL.RepositoryPattern.RepositoryBase;
using ProjectVIEWMODEL.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIEWMODEL.VMRepository
{
   public class OrderVMRepository:BaseRepository<OrderVM>
    {
        public override List<OrderVM> SelectActives()
        {
            return db.Orders.Where(x => x.Status != Project.MODEL.Enums.DataStatus.Deleted).Select(x => new OrderVM
            {
                ShippedAddress = x.ShippedAddress
            }).ToList();
        }
    }
}
