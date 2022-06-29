using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreManagement.DTO
{
    internal class UserDTO
    {
        internal int Id { get; set; }
        internal string Name { get; set; }
        internal string Address { get; set; }
        internal string Phone { get; set; }
        internal string Role { get; set; }
        internal DateTime Birth { get; set; }
        internal string Password { get; set; }
    }
}
