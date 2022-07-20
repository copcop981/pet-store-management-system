using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreManagement.DTO
{
    internal class RevenueDTO
    {
        internal int Id { get; set; }
        internal DateTime Date_Time { get; set; }
        internal string Transaction_No { get; set; }
        internal string Product_Name { get; set; }
        internal int Quantity { get; set; }
        internal int Price { get; set; }
        internal int Total { get; set; }
        internal string Payer { get; set; }
    }
}
