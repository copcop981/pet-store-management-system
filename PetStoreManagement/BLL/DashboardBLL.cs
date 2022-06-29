using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStoreManagement.DAL;

namespace PetStoreManagement.BLL
{
    internal class DashboardBLL
    {
        DashboardDAL dashboardDAL = new DashboardDAL();

        internal int countPet(string petCategory)
        {
            return dashboardDAL.countPet(petCategory);
        }
    }
}
