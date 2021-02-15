using Project.BLL.RepositoryPattern.RepositoryBase;
using Project.BLL.RepositoryPattern.RepositoryInterface;
using ProjectVIEWMODEL.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIEWMODEL.VMRepository
{
    public class ProductVMRepository : BaseRepository<ProductVM>
    {
       
        public override List<ProductVM> SelectActives()
        {
          return  db.Products.Where(x => x.Status != Project.MODEL.Enums.DataStatus.Deleted).Select(x =>
                   new ProductVM
                   {
                       ID = x.ID,
                       ProductName = x.ProductName
                   }).ToList();
        }
    }
}
