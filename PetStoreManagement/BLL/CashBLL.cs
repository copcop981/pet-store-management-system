using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStoreManagement.DAL;
using PetStoreManagement.DTO;

namespace PetStoreManagement.BLL
{
    internal class CashBLL
    {
        CashDAL cashDAL = new CashDAL();

        internal List<TemporaryDataDTO> getTransNo(string sDate)
        {
            return cashDAL.getTransNo(sDate);
        }

        internal int getCusIdByCusName(string customerName)
        {
            return cashDAL.getCusIdByCusName(customerName);
        }

        internal int addNewCash(string transNo, string pId, string pName, int quantity, int price, int total, int cId, string cashier)
        {
            return cashDAL.addNewCash(transNo, pId, pName, quantity, price, total, cId, cashier);
        }

        internal int deleteCash(int cashId)
        {
            return cashDAL.deleteCash(cashId);
        }

        internal int increaseProductsNumber(int cashId)
        {
            return cashDAL.increaseProductsNumber(cashId);
        }

        internal int decreaseProductsNumber(int cashId)
        {
            return cashDAL.decreaseProductsNumber(cashId);
        }

        internal List<MiddleTemporaryDataDTO> getCashTempDataList(string transNo)
        {
            return cashDAL.getCashTempDataList(transNo);
        }

        internal int updateProductQuantity(int quantity, int pId)
        {
            return cashDAL.updateProductQuantity(quantity, pId);
        }
    }
}
