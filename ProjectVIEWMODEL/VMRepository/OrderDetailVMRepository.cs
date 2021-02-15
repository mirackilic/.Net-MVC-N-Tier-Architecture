using Project.BLL.RepositoryPattern.RepositoryBase;
using ProjectVIEWMODEL.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIEWMODEL.VMRepository
{
   public class OrderDetailVMRepository:BaseRepository<OrderDetailVM>
    {
        public override List<OrderDetailVM> SelectActives()
        {
            return db.OrderDetails.Where(x => x.Status != Project.MODEL.Enums.DataStatus.Deleted).Select(x => new OrderDetailVM
            {
                OrderID = x.OrderID,
                ProductID = x.ProductID
            }).ToList();
        }
    }
}
