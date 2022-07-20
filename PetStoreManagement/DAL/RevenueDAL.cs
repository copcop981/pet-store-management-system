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
    internal class RevenueDAL
    {
        DbConnect dbConn = new DbConnect();
        SqlConnection conn = new SqlConnection();

        internal int storeRevenue(DateTime dateTime, string transNo, string pName, int quantity, int price, int total, string payer)
        {
            conn = new SqlConnection(dbConn.connection());
            SqlCommand command = new SqlCommand("insert dbo.Revenue values (@Date_Time, @Trans_No, @Pname, @Quantity, @Price, @Total, @Payer)", conn);
            command.Parameters.Add("@Date_Time", SqlDbType.DateTime).Value = dateTime;
            command.Parameters.Add("@Trans_No", SqlDbType.VarChar).Value = transNo;
            command.Parameters.Add("@Pname", SqlDbType.NVarChar).Value = pName;
            command.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
            command.Parameters.Add("@Price", SqlDbType.Int).Value = price;
            command.Parameters.Add("@Total", SqlDbType.Int).Value = total;
            command.Parameters.Add("@Payer", SqlDbType.VarChar).Value = payer;

            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        internal List<RevenueDTO> getAllRevenue()
        {
            conn = new SqlConnection(dbConn.connection());
            List<RevenueDTO> revenueList = new List<RevenueDTO>();

            SqlCommand command = new SqlCommand("select * from dbo.Revenue", conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                RevenueDTO revenue = new RevenueDTO();
                revenue.Id = (int)reader[0];
                revenue.Date_Time = (DateTime)reader[1];
                revenue.Transaction_No = (string)reader[2];
                revenue.Product_Name = (string)reader[3];
                revenue.Quantity = (int)reader[4];
                revenue.Price = (int)reader[5];
                revenue.Total = (int)reader[6];
                revenue.Payer = (string)reader[7];

                revenueList.Add(revenue);
            }

            reader.Close();
            conn.Close();

            return revenueList;
        }
    }
}
