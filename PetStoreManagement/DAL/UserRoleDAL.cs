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
    internal class UserRoleDAL
    {
        DbConnect dbConn = new DbConnect();
        SqlConnection conn = new SqlConnection();

        internal List<UserRoleDTO> getAllUserRole()
        {
            conn = new SqlConnection(dbConn.connection());
            List<UserRoleDTO> urList = new List<UserRoleDTO>();

            SqlCommand command = new SqlCommand("select * from dbo.UserRole", conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                UserRoleDTO ur = new UserRoleDTO();
                ur.Id= (int)reader[0];
                ur.UserRole = reader[1].ToString();

                urList.Add(ur);
            }
            reader.Close();
            conn.Close();
            return urList;
        }

        internal List<UserDTO> getUserByUserRole(string role)
        {
            conn = new SqlConnection(dbConn.connection());
            List<UserDTO> userList = new List<UserDTO>();

            //SqlCommand command = new SqlCommand("select * from dbo.Userr where role = N'" + role + "'", conn);
            SqlCommand command = new SqlCommand($"select * from dbo.Userr where role = N'{role}'", conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                UserDTO userr = new UserDTO();
                userr.Id = (int)reader[0];
                userr.Name = (string)reader[1];
                userr.Address = (string)reader[2];
                userr.Phone = (string)reader[3];
                userr.Role = (string)reader[4];
                userr.Birth = (DateTime)reader[5];
                userr.Password = (string)reader[6];

                userList.Add(userr);
            }
            reader.Close();
            conn.Close();
            return userList;
        }
    }
}
