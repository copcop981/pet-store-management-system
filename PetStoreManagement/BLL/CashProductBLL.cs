using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStoreManagement.DAL;
using PetStoreManagement.DTO;

namespace PetStoreManagement.BLL
{
    internal class CashProductBLL
    {
        CashProductDAL cashProductDAL = new CashProductDAL();

        internal List<ProductDTO> getAllProduct(string search)
        {
            return cashProductDAL.getAllProduct(search);
        }

        internal int submitTemporaryData(string transNo, string pId, string pName, int quantity, int price, string cashier)
        {
            return cashProductDAL.submitTemporaryData(transNo, pId, pName, quantity, price, cashier);
        }
    }
}
