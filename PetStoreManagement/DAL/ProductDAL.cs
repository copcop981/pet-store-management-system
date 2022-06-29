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
    internal class ProductDAL
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

        internal int addNewProduct(string pName, string pType, string pCategory, int pQuantity, int pPrice)
        {
            conn = new SqlConnection(dbConn.connection());
            SqlCommand command = new SqlCommand("insert dbo.Product(Pname, Ptype, Pcategory, Pquantity, Pprice) values(@Pname, @Ptype, @Pcategory, @Pquantity, @Pprice)", conn);
            command.Parameters.Add("@Pname", SqlDbType.NVarChar).Value = pName;
            command.Parameters.Add("@Ptype", SqlDbType.NVarChar).Value = pType;
            command.Parameters.Add("@Pcategory", SqlDbType.NVarChar).Value = pCategory;
            command.Parameters.Add("@Pquantity", SqlDbType.Int).Value = pQuantity;
            command.Parameters.Add("@Pprice", SqlDbType.Int).Value = pPrice;

            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        internal int updateProduct(string pName, string pType, string pCategory, int pQuantity, int pPrice, int pId)
        {
            conn = new SqlConnection(dbConn.connection());
            SqlCommand command = new SqlCommand("update dbo.Product set Pname = @Pname, Ptype = @Ptype, Pcategory = @Pcategory, Pquantity =  @Pquantity, Pprice = @Pprice where Pid = @Pid", conn);
            command.Parameters.Add("@Pname", SqlDbType.NVarChar).Value = pName;
            command.Parameters.Add("@Ptype", SqlDbType.NVarChar).Value = pType;
            command.Parameters.Add("@Pcategory", SqlDbType.VarChar).Value = pCategory;
            command.Parameters.Add("@Pquantity", SqlDbType.Int).Value = pQuantity;
            command.Parameters.Add("@Pprice", SqlDbType.Int).Value = pPrice;
            command.Parameters.Add("@Pid", SqlDbType.Int).Value = pId;

            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        internal int deleteProduct(int pId)
        {
            conn = new SqlConnection(dbConn.connection());
            SqlCommand command = new SqlCommand("delete from dbo.Product where Pid = " + pId, conn);
            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }
    }
}
