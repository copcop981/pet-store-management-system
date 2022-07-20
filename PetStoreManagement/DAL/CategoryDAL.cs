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
    internal class CategoryDAL
    {
        DbConnect dbConn = new DbConnect();
        SqlConnection conn = new SqlConnection();

        internal List<CategoryDTO> getAllCategory()
        {
            conn = new SqlConnection(dbConn.connection());
            List<CategoryDTO> cateList = new List<CategoryDTO>();
            SqlCommand command = new SqlCommand("select * from dbo.Category", conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                CategoryDTO cate = new CategoryDTO();
                cate.Id = (int)reader[0];
                cate.Name = (string)reader[1];

                cateList.Add(cate);
            }
            reader.Close();
            conn.Close();
            return cateList;
        }

        internal List<ProductDTO> getProductByCategory(string cate)
        {
            conn = new SqlConnection(dbConn.connection());
            List<ProductDTO> productList = new List<ProductDTO>();
            SqlCommand command = new SqlCommand("select * from dbo.Product where Pcategory = N'" + cate + "'", conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ProductDTO product = new ProductDTO();
                product.Pid = (int)reader[0];
                product.Pname = (string)reader[1];
                product.Ptype = (string)reader[2];
                product.Pcategory = (string)reader[3];
                product.Pquantity = (int)reader[4];
                product.Pprice = (int)reader[5];

                productList.Add(product);
            }
            reader.Close();
            conn.Close();
            return productList;
        }
    }
}
