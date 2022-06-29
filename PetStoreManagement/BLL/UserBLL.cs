using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStoreManagement.DAL;
using PetStoreManagement.DTO;

namespace PetStoreManagement.BLL
{
    internal class UserBLL
    {
        UserDAL userDAL = new UserDAL();

        internal List<UserDTO> getAllUser(string search)
        {
            return userDAL.getAllUser(search);
        }

        internal int addNewUser(string name, string address, string phone, string role, DateTime birth, string password)
        {
            return userDAL.addNewUser(name, address, phone, role, birth, password);
        }

        internal int updateUser(string name, string address, string phone, string role, DateTime birth, string password, int id)
        {
            return userDAL.updateUser(name, address, phone, role, birth, password, id);
        }

        internal int deleteUser(int id)
        {
            return userDAL.deleteUser(id);
        }
    }
}
