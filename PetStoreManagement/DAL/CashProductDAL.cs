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
    internal class CashProductDAL
    {
        DbConnect dbConn = new DbConnect();
        SqlConnection conn = new SqlConnection();

        internal List<ProductDTO> getAllProduct(string search)
        {
            conn = new SqlConnection(dbConn.connection());
            List<ProductDTO> productList = new List<ProductDTO>();

            SqlCommand command = new SqlCommand("select * from dbo.Product where concat(Pname, Ptype, Pcategory) like '%" + search + "%'", conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ProductDTO product = new ProductDTO();
                product.Pid = (int)reader[0];
                product.Pname = reader[1].ToString();
                product.Ptype = reader[2].ToString();
                product.Pcategory = reader[3].ToString();
                product.Pquantity = (int)reader[4];
                product.Pprice = (int)reader[5];

                productList.Add(product);
            }

            reader.Close();
            conn.Close();

            return productList;
        }

        internal int submitTemporaryData(string transNo, string pId, string pName, int quantity, int price, string cashier)
        {
            conn = new SqlConnection(dbConn.connection());

            SqlCommand command = new SqlCommand("insert dbo.TemporaryData (TransactionNo, Pid, Pname, Quantity, Price, Cashier) values (@TransactionNo, @Pid, @Pname, @Quantity, @Price, @Cashier)", conn);
            command.Parameters.Add("@TransactionNo", SqlDbType.VarChar).Value = transNo;
            command.Parameters.Add("@Pid", SqlDbType.VarChar).Value = pId;
            command.Parameters.Add("@Pname", SqlDbType.NVarChar).Value = pName;
            command.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
            command.Parameters.Add("@Price", SqlDbType.Int).Value = price;
            //cm.Parameters.Add("@Total", SqlDbType.Int).Value = (int)row.Cells[5].Value * (int)row.Cells[6].Value;
            command.Parameters.Add("@Cashier", SqlDbType.VarChar).Value = cashier;

            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }
    }
}
