using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PetStoreManagement.DAL
{
    internal class MainDAL
    {
        DbConnect dbConn = new DbConnect();
        SqlConnection conn = new SqlConnection();

        internal int getDailySale(string sDate)
        {
            conn = new SqlConnection(dbConn.connection());
            conn.Open();
            SqlCommand command = new SqlCommand("select isnull(sum(Total), 0) from dbo.Cash where TransactionNo LIKE '%" + sDate + "%'", conn);
            int result = (int)command.ExecuteScalar();
            conn.Close();
            return result;
        }

        internal int cleanJunkData()
        {
            conn = new SqlConnection(dbConn.connection());
            conn.Open();
            SqlCommand command = new SqlCommand("delete dbo.TemporaryData", conn);
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }
    }
}
