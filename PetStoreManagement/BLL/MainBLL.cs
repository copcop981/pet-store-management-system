using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStoreManagement.DAL;

namespace PetStoreManagement.BLL
{
    internal class MainBLL
    {
        MainDAL mainDAL = new MainDAL();

        internal int getDailySale(string sDate)
        {
            return mainDAL.getDailySale(sDate);
        }
    }
}
