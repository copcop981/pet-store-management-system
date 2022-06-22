using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreManagement.DTO
{
    public class InvoiceDTO
    {
        public int CashId { get; set; }
        public string Pid { get; set; }
        public string Pname { get; set; }
        public int Pquantity { get; set; }
        public int Pprice { get; set; }
        public int Total { get; set; }
        public string Cname { get; set; }
        public string Cashier { get; set; }
    }
}
