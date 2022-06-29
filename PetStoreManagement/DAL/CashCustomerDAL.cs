using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using PetStoreManagement.DTO;

namespace PetStoreManagement.DAL
{
    internal class CashCustomerDAL
    {
        DbConnect dbConn = new DbConnect();
        SqlConnection conn = new SqlConnection();

        internal List<CustomerDTO> getAllCustomer(string search)
        {
            conn = new SqlConnection(dbConn.connection());
            List<CustomerDTO> cusList = new List<CustomerDTO>();

            SqlCommand command = new SqlCommand($"select Cid, Cname, Cphone from dbo.Customer where Cname like '%" + search + "%'", conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                CustomerDTO cus = new CustomerDTO();
                cus.Cid = (int)reader[0];
                cus.Cname = reader[1].ToString();
                cus.Cphone = reader[2].ToString();

                cusList.Add(cus);
            }
            reader.Close();
            conn.Close();
            return cusList;
        }

        internal int submitChoiceCustomer(int cId, string transNo)
        {
            conn = new SqlConnection(dbConn.connection());
            conn.Open();
            SqlCommand command = new SqlCommand("update dbo.TemporaryData set Cid = " + cId + " where TransactionNo = '" + transNo + "'", conn);
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }
    }
}
