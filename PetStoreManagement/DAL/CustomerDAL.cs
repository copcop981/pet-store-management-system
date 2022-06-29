using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using PetStoreManagement.DTO;

namespace PetStoreManagement.DAL
{
    internal class CustomerDAL
    {
        DbConnect dbConn = new DbConnect();
        SqlConnection conn = new SqlConnection();

        internal List<CustomerDTO> getAllCustomer(string search)
        {
            conn = new SqlConnection(dbConn.connection());
            List<CustomerDTO> cusList = new List<CustomerDTO>();

            SqlCommand command = new SqlCommand("select * from dbo.Customer where concat(Cname, Caddress, Cphone) like '%" + search + "%'", conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                CustomerDTO cus = new CustomerDTO();
                cus.Cid = (int)reader[0];
                cus.Cname = (string)reader[1];
                cus.Caddress = (string)reader[2];
                cus.Cphone = (string)reader[3];

                cusList.Add(cus);
            }
            reader.Close();
            conn.Close();

            return cusList;
        }

        internal int addNewCustomer(string cName, string cAddress, string cPhone)
        {
            conn = new SqlConnection(dbConn.connection());
            SqlCommand command = new SqlCommand("insert dbo.Customer (Cname, Caddress, Cphone) values(@Cname, @Caddress, @Cphone)", conn);
            command.Parameters.Add("@Cname", SqlDbType.NVarChar).Value = cName;
            command.Parameters.Add("@Caddress", SqlDbType.NVarChar).Value = cAddress;
            command.Parameters.Add("@Cphone", SqlDbType.VarChar).Value = cPhone;

            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        internal int updateCustomer(string cName, string cAddress, string cPhone, int cId)
        {
            conn = new SqlConnection(dbConn.connection());
            SqlCommand command = new SqlCommand("update dbo.Customer set Cname = @Cname, Caddress = @Caddress, Cphone = @Cphone where Cid = @Cid", conn);
            command.Parameters.Add("@Cname", SqlDbType.NVarChar).Value = cName;
            command.Parameters.Add("@Caddress", SqlDbType.NVarChar).Value = cAddress;
            command.Parameters.Add("@Cphone", SqlDbType.VarChar).Value = cPhone;
            command.Parameters.Add("@Cid", SqlDbType.Int).Value = cId;

            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        internal int deleteCustomer(int cId)
        {
            conn = new SqlConnection(dbConn.connection());
            SqlCommand command = new SqlCommand("delete from dbo.Customer where Cid = " + cId, conn);
            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }
    }
}
