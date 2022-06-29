using System;using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreManagement.DTO
{
    internal class ProductDTO
    {
        internal int Pid { get; set; }
        internal string Pname { get; set; }
        internal string Ptype { get; set; }
        internal string Pcategory { get; set; }
        internal int Pquantity { get; set; }
        internal int Pprice { get; set; }
    }
}
