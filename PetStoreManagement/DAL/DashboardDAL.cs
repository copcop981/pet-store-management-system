using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PetStoreManagement.DAL
{
    internal class DashboardDAL
    {
        DbConnect dbConn = new DbConnect();
        SqlConnection conn = new SqlConnection();

        internal int countPet(string petCategory)
        {
            conn = new SqlConnection(dbConn.connection());
            conn.Open();
            SqlCommand command = new SqlCommand("select isnull(sum(Pquantity), 0) from dbo.Product where Pcategory = N'" + petCategory + "'", conn);
            int result = (int)command.ExecuteScalar();
            conn.Close();
            return result;
        }
    }
}
