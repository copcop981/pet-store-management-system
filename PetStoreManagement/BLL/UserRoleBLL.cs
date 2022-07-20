using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStoreManagement.DAL;
using PetStoreManagement.DTO;

namespace PetStoreManagement.BLL
{
    internal class UserRoleBLL
    {
        UserRoleDAL urDAL = new UserRoleDAL();

        internal List<UserRoleDTO> getAllUserRole()
        {
            return urDAL.getAllUserRole();
        }

        internal List<UserDTO> getUserByUserRole(string role)
        {
            return urDAL.getUserByUserRole(role);
        }
    }
}
