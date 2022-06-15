using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreManagement.DTO
{
    public class UserDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string role { get; set; }
        public DateTime birth { get; set; }
        public string password { get; set; }
    }
}
