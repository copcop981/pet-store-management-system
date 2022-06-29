using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStoreManagement.DAL;
using PetStoreManagement.DTO;

namespace PetStoreManagement.BLL
{
    internal class LoginBLL
    {
        LoginDAL loginDAL = new LoginDAL();

        internal bool checkLogin(string _username, string _password)
        {
            return loginDAL.checkLogin(_username, _password);
        }

        internal List<LoginDTO> getNameAndRole(string name, string pass)
        {
            return loginDAL.getNameAndRole(name, pass);
        }
    }
}
