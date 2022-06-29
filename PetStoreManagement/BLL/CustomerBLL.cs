using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStoreManagement.DAL;
using PetStoreManagement.DTO;

namespace PetStoreManagement.BLL
{
    class CustomerBLL
    {
        CustomerDAL cusDAL = new CustomerDAL();

        internal List<CustomerDTO> getAllCustomer(string search)
        {
            return cusDAL.getAllCustomer(search);
        }

        internal int addNewCustomer(string cName, string cAddress, string cPhone)
        {
            return cusDAL.addNewCustomer(cName, cAddress, cPhone);
        }

        internal int updateCustomer(string cName, string cAddress, string cPhone, int cId)
        {
            return cusDAL.updateCustomer(cName, cAddress, cPhone, cId);
        }

        internal int deleteCustomer(int cId)
        {
            return cusDAL.deleteCustomer(cId);
        }
    }
}
