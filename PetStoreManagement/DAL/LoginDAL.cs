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
    internal class LoginDAL
    {
        DbConnect dbConn = new DbConnect();
        SqlConnection conn = new SqlConnection();

        internal bool checkLogin(string _username, string _password)
        {
            conn = new SqlConnection(dbConn.connection());

            DataTable data = new DataTable();

            conn.Open();
            SqlCommand command = new SqlCommand("select * from dbo.Userr where name = '" + _username + "' and password = '" + _password + "'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(data);
            conn.Close();

            return data.Rows.Count > 0;
        }

        internal List<LoginDTO> getNameAndRole(string name, string pass)
        {
            conn = new SqlConnection(dbConn.connection());

            List<LoginDTO> list = new List<LoginDTO>();

            SqlCommand command = new SqlCommand("select name, role from dbo.Userr where name = @name and password = @password", conn);
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = pass;

            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                LoginDTO login = new LoginDTO();
                login.Name = (string)reader[0];
                login.Role = (string)reader[1];

                list.Add(login);
            }
            reader.Close();
            conn.Close();
            return list;
        }
    }
}
