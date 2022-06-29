using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStoreManagement.DAL;
using PetStoreManagement.DTO;

namespace PetStoreManagement.BLL
{
    internal class CashCustomerBLL
    {
        CashCustomerDAL cashCusDAL = new CashCustomerDAL();

        internal List<CustomerDTO> getAllCustomer(string search)
        {
            return cashCusDAL.getAllCustomer(search);
        }

        internal int submitChoiceCustomer(int cId, string transNo)
        {
            return cashCusDAL.submitChoiceCustomer(cId, transNo);
        }
    }
}
