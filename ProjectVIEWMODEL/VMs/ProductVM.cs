using Project.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectVIEWMODEL.VMs
{
    public class ProductVM:PictureSpecific
    {
        public string ProductName { get; set; }

        public short? UnitsInStock { get; set; }

        public decimal? UnitPrice { get; set; }


    }
}
