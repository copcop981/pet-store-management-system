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
    internal class CashDAL
    {
        DbConnect dbConn = new DbConnect();
        SqlConnection conn = new SqlConnection();

        internal List<TemporaryDataDTO> getTransNo(string sDate)
        {
            //string transNo = "";
            //int count = 0;

            conn = new SqlConnection(dbConn.connection());
            List<TemporaryDataDTO> list = new List<TemporaryDataDTO>();

            conn.Open();
            SqlCommand command = new SqlCommand($"select top 1 TransactionNo from dbo.TemporaryData where TransactionNo like '%" + sDate + "%' order by CashId desc", conn);
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                TemporaryDataDTO tempData = new TemporaryDataDTO();
                tempData.TransNo = reader[0].ToString();

                list.Add(tempData);
            }
            else
            {
                TemporaryDataDTO tempData = new TemporaryDataDTO();
                tempData.TransNo = sDate + "1001";

                list.Add(tempData);
            }
            reader.Close();
            conn.Close();

            return list;
        }

        internal int getCusIdByCusName(string customerName)
        {
            conn = new SqlConnection(dbConn.connection());
            int customerId = -1;
            conn.Open();
            SqlCommand command = new SqlCommand("select Cid from dbo.Customer where Cname = N'" + customerName + "'", conn);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
                customerId = (int)reader[0];
            reader.Close();
            conn.Close();
            return customerId;
        }

        internal int addNewCash(string transNo, string pId, string pName, int quantity, int price, int total, int cId, string cashier)
        {
            conn = new SqlConnection(dbConn.connection());
            
            SqlCommand command = new SqlCommand("insert dbo.Cash values (@TransNo, @Pid, @Pname, @Quantity, @Price, @Total, @Cid, @Cashier)", conn);
            command.Parameters.Add("@TransNo", SqlDbType.VarChar).Value = transNo;
            command.Parameters.Add("@Pid", SqlDbType.VarChar).Value = pId;
            command.Parameters.Add("@Pname", SqlDbType.NVarChar).Value = pName;
            command.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;
            command.Parameters.Add("@Price", SqlDbType.Int).Value = price;
            command.Parameters.Add("@Total", SqlDbType.Int).Value = total;
            command.Parameters.Add("@Cid", SqlDbType.Int).Value = cId;
            command.Parameters.Add("@Cashier", SqlDbType.VarChar).Value = cashier;

            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        internal int deleteCash(int cashId)
        {
            conn = new SqlConnection(dbConn.connection());
            conn.Open();
            SqlCommand command = new SqlCommand("delete from dbo.TemporaryData where CashId = " + cashId, conn);
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        internal int increaseProductsNumber(int cashId)
        {
            conn = new SqlConnection(dbConn.connection());
            conn.Open();
            SqlCommand command = new SqlCommand("update dbo.TemporaryData set Quantity = Quantity + 1 where CashId = " + cashId, conn);
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        internal int decreaseProductsNumber(int cashId)
        {
            conn = new SqlConnection(dbConn.connection());
            conn.Open();
            SqlCommand command = new SqlCommand("update dbo.TemporaryData set Quantity = Quantity - 1 where CashId = " + cashId, conn);
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }

        internal List<MiddleTemporaryDataDTO> getCashTempDataList(string transNo)
        {
            //SqlCommand command = new SqlCommand("exec dbo.loadCashTempDataList @TransNo, @Pid, @Pname, @Quantity", conn);
            //command.Parameters.Add("@TransNo", SqlDbType.VarChar).Value = transNo;
            //command.Parameters.Add("@Pid", SqlDbType.VarChar).Value = pId;
            //command.Parameters.Add("@Pname", SqlDbType.NVarChar).Value = pName;
            //command.Parameters.Add("@Quantity", SqlDbType.Int).Value = quantity;

            List<MiddleTemporaryDataDTO> middleTempDataList = new List<MiddleTemporaryDataDTO>();
            conn = new SqlConnection(dbConn.connection());
            SqlCommand command = new SqlCommand("SELECT CashId, Pid, Pname, Quantity, Price, Total, c.Cname, Cashier " +
                                    "FROM dbo.TemporaryData AS cash LEFT JOIN dbo.Customer c ON cash.Cid = c.Cid " +
                                    "WHERE TransactionNo LIKE '%" + transNo + "%'", conn);

            conn.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                MiddleTemporaryDataDTO middleTempData = new MiddleTemporaryDataDTO();
                middleTempData.CashId = (int)reader[0];
                //string transNo = rd[1].ToString();
                middleTempData.Pid = reader[1].ToString();
                middleTempData.Pname = reader[2].ToString();
                middleTempData.Quantity = (int)reader[3];
                middleTempData.Price = (int)reader[4];
                middleTempData.Total = (int)reader[5];
                middleTempData.Cname = reader[6].ToString();
                middleTempData.Cashier = reader[7].ToString();

                middleTempDataList.Add(middleTempData);
            }
            reader.Close();
            conn.Close();

            return middleTempDataList;
        }

        internal int updateProductQuantity(int quantity, int pId)
        {
            conn = new SqlConnection(dbConn.connection());

            SqlCommand command = new SqlCommand("update dbo.Product set Pquantity = Pquantity - @quantity where Pid = @pId", conn);
            command.Parameters.Add("@quantity", SqlDbType.Int).Value = quantity;
            command.Parameters.Add("@pId", SqlDbType.Int).Value = pId;

            conn.Open();
            int result = command.ExecuteNonQuery();
            conn.Close();
            return result;
        }
    }
}
