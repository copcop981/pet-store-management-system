using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PetStoreManagement
{
    internal class DbConnect
    {
        internal SqlConnection cn = new SqlConnection();
        internal SqlCommand cm = new SqlCommand();
        private string con;

        public string connection()
        {
            con = "Data Source=.\\sqlexpress;Initial Catalog=QuanLyCuaHangPet;Integrated Security=True";
            return con;
        }
    }
}
