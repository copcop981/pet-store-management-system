using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PetStoreManagement.DAL
{
    public class DataProvider
    {
        public static SqlConnection conn = null;
        public static string connStr = "Data Source=.\\sqlexpress;Initial Catalog=QuanLyCuaHangPet;Integrated Security=True";

        private static void openConnection()
        {
            if (conn == null)
                conn = new SqlConnection(connStr);

            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }

        public static object executeScalar(string query, object[] parameters = null)
        {
            object data = 0;
            openConnection();

            SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.Text;
            command.CommandText = query;
            command.Connection = conn;

            if (parameters != null)
            {
                string[] paramList = query.Split(' ');

                int i = 0;
                foreach (string item in paramList)
                {
                    if (item.Contains("@"))
                    {
                        command.Parameters.AddWithValue(item, parameters[i]);
                        i++;
                    }
                }
            }
            data = command.ExecuteScalar();
            return data;
        }

        public static SqlDataReader executeReader(string query, object[] parameters = null)
        {
            openConnection();

            SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.Text;
            command.CommandText = query;
            command.Connection = conn;

            if (parameters != null)
            {
                string[] paramList = query.Split(' ');

                int i = 0;
                foreach (string item in paramList)
                {
                    if (item.Contains("@"))
                    {
                        command.Parameters.AddWithValue(item, parameters[i]);
                        i++;
                    }
                }
            }
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public static int executeNonQuery(string query, object[] parameters = null)
        {
            int result = 0;
            openConnection();

            SqlCommand command = new SqlCommand();
            //command.CommandType = CommandType.Text;
            command.CommandText = query;
            command.Connection = conn;

            if (parameters != null)
            {
                string[] paramList = query.Split(' ');

                int i = 0;
                foreach (string item in paramList)
                {
                    if (item.Contains("@"))
                    {
                        command.Parameters.AddWithValue(item, parameters[i]);
                        i++;
                    }
                }
            }
            result = command.ExecuteNonQuery();
            return result;
        }
    }
}
