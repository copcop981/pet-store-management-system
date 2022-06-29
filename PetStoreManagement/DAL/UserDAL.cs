using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStoreManagement.DTO;
using System.Data;
using System.Data.SqlClient;

namespace PetStoreManagement.DAL
{
    internal class UserDAL
    {
        DbConnect dbConn = new DbConnect();
        SqlConnection conn = new SqlConnection();
        
        internal List<UserDTO> getAllUser(string search)
        {
            conn = new SqlConnection(dbConn.connection());
            List<UserDTO> userList = new List<UserDTO>();

            SqlCommand command = new SqlCommand("select * from dbo.Userr where concat(name, address, phone, role, birth) like '%" + search + "%'", conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                UserDTO user = new UserDTO();
                user.Id = (int)reader[0];
                user.Name = reader[1].ToString();
                user.Address = reader[2].ToString();
                user.Phone = reader[3].ToString();
                user.Role = reader[4].ToString();
                user.Birth = (DateTime)reader[5];
                user.Password = reader[6].ToString();

                userList.Add(user);
            }
            reader.Close();
            conn.Close();

            return userList;
        }

        internal int addNewUser(string name, string address, string phone, string role, DateTime birth, string password)
        {
            conn = new SqlConnection(dbConn.connection());
            SqlCommand command = new SqlCommand("insert dbo.Userr(name, address, phone, role, birth, password) values(@name, @address, @phone, @role, @birth, @password)", conn);
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            command.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@role", SqlDbType.NVarChar).Value = role;
            command.Parameters.Add("@birth", SqlDbType.Date).Value = birth;
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        internal int updateUser(string name, string address, string phone, string role, DateTime birth, string password, int id)
        {
            conn = new SqlConnection(dbConn.connection());
            SqlCommand command = new SqlCommand("update dbo.Userr set name = @name, address = @address, phone = @phone, role =  @role, birth = @birth, password = @password where id = @id", conn);
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            command.Parameters.Add("@address", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@role", SqlDbType.NVarChar).Value = role;
            command.Parameters.Add("@birth", SqlDbType.Date).Value = birth;
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        internal int deleteUser(int id)
        {
            conn = new SqlConnection(dbConn.connection());
            SqlCommand command = new SqlCommand("delete from dbo.Userr where id = " + id, conn);
            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }
    }
}
