using Project.BLL.RepositoryPattern.ConcreteRepository;
using Project.BLL.RepositoryPattern.RepositoryBase;
using Project.MODEL.Entities;
using ProjectVIEWMODEL.VMs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIEWMODEL.VMRepository
{
    public  class CategoryVMRepository:BaseRepository<CategoryVM>
    {

        public CategoryVMRepository()
        {
            cr_repo = new CategoryRepository();
        }
        public override List<CategoryVM> SelectActives()
        {
            return db.Categories.Where(x => x.Status != Project.MODEL.Enums.DataStatus.Deleted).Select(x => new CategoryVM
            {
                ID = x.ID,
                CategoryName = x.CategoryName,
                Description=x.Description
            }).ToList();
        }

        CategoryRepository cr_repo;
        public List<CategoryVM> Add(Category item)
        {
            cr_repo.Add(item);
            return SelectActives();
        }
    }
}
