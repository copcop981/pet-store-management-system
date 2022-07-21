using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStoreManagement.DAL;
using PetStoreManagement.DTO;

namespace PetStoreManagement.BLL
{
    internal class RevenueBLL
    {
        RevenueDAL revenueDAL = new RevenueDAL();

        internal int storeRevenue(DateTime dateTime, string transNo, string pName, int quantity, int price, int total, string payer)
        {
            return revenueDAL.storeRevenue(dateTime, transNo, pName, quantity, price, total, payer);
        }

        internal List<RevenueDTO> getAllRevenue()
        {
            return revenueDAL.getAllRevenue();
        }

        internal List<RevenueDTO> filterRevenueByDate(string startDay, string endDay)
        {
            return revenueDAL.filterRevenueByDate(startDay, endDay);
        }

        internal List<RevenueDTO> filterProductByDate(string year, string month, string day, string search)
        {
            return revenueDAL.filterProductByDate(year, month, day, search);
        }
    }
}
