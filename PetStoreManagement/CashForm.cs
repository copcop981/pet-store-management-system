using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PetStoreManagement
{
    public partial class CashForm : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader rd;
        DbConnect dbcon = new DbConnect();
        string title = "Pet Store Management System";

        MainForm mainForm;

        public CashForm(MainForm mainF)
        {
            InitializeComponent();

            cn = new SqlConnection(dbcon.connection());
            mainForm = mainF;
            getTransNo();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            CashProduct cpForm = new CashProduct(this);
            cpForm.uName = mainForm.lblUsername.Text;
            cpForm.ShowDialog();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            CashCustomer ccForm = new CashCustomer(this);
            ccForm.ShowDialog();
            btnCash.Enabled = true;
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            DialogResult dlR = MessageBox.Show("Are you sure you want to Cash This Product?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dlR == DialogResult.Yes)
            {
                getTransNo();
                for (int i = 0; i < gridCash.Rows.Count; i++)
                {
                    //cn.Open();
                    //cm = new SqlCommand("update dbo.Product set Pquantity = Pquantity - " + (int)gridCash.Rows[i].Cells[4].Value + " where Pid = " + (int)gridCash.Rows[i].Cells[1].Value, cn);
                    //cm.ExecuteNonQuery();
                    //cn.Close();

                    int customerId = -1;
                    string customerName = gridCash.Rows[i].Cells[7].Value.ToString();
                    cn.Open();
                    cm = new SqlCommand("select Cid from dbo.Customer where Cname = N'" + customerName + "'", cn);
                    SqlDataReader rd = cm.ExecuteReader();
                    if (rd.Read())
                        customerId = (int)rd[0];
                    rd.Close();
                    cn.Close();

                    cn.Open();
                    cm = new SqlCommand("insert dbo.Cash values (@TransNo, @Pid, @Pname, @Quantity, @Price, @Total, @Cid, @Cashier)", cn);
                    cm.Parameters.Add("@TransNo", SqlDbType.VarChar).Value = lblTransNo.Text;
                    cm.Parameters.Add("@Pid", SqlDbType.VarChar).Value = gridCash.Rows[i].Cells[2].Value;
                    cm.Parameters.Add("@Pname", SqlDbType.NVarChar).Value = gridCash.Rows[i].Cells[3].Value;
                    cm.Parameters.Add("@Quantity", SqlDbType.Int).Value = (int)gridCash.Rows[i].Cells[4].Value;
                    cm.Parameters.Add("@Price", SqlDbType.Int).Value = (int)gridCash.Rows[i].Cells[5].Value;
                    cm.Parameters.Add("@Total", SqlDbType.Int).Value = (int)gridCash.Rows[i].Cells[4].Value * (int)gridCash.Rows[i].Cells[5].Value;
                    cm.Parameters.Add("@Cid", SqlDbType.Int).Value = customerId;
                    cm.Parameters.Add("@Cashier", SqlDbType.VarChar).Value = mainForm.lblUsername.Text;
                    cm.ExecuteNonQuery();
                    cn.Close();
                }
            }
            lblTotal.Text = 0 + "đ";
            btnCash.Enabled = false;
            btnAddCustomer.Visible = false;
            gridCash.Rows.Clear();
            mainForm.loadDailySale();
        }

        private void gridCash_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = gridCash.Columns[e.ColumnIndex].Name;
            if(colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to Delete This Cash?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand($"delete from dbo.Cash where CashId = {gridCash.Rows[e.RowIndex].Cells[1].Value}", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Cash has been Successfully Deleted!", title);
                }
            }
            else if(colName == "Increase")
            {
                cn.Open();
                cm = new SqlCommand("update dbo.TemporaryData set Quantity = Quantity + 1 where CashId = " + gridCash.Rows[e.RowIndex].Cells[1].Value, cn);
                cm.ExecuteNonQuery();
                cn.Close();
            }
            else if(colName == "Decrease")
            {
                if((int)gridCash.Rows[e.RowIndex].Cells[4].Value == 1)
                {
                    MessageBox.Show("Quantity should not be less than 1", title);
                    return;
                }

                cn.Open();
                cm = new SqlCommand("update dbo.TemporaryData set Quantity = Quantity - 1 where CashId = " + gridCash.Rows[e.RowIndex].Cells[1].Value, cn);
                cm.ExecuteNonQuery();
                cn.Close();
            }
            loadCashTempDataList();
        }

        #region Method
        public void getTransNo()
        {
            try
            {
                string sDate = DateTime.Now.ToString("yyyyMMdd");
                int count;
                string transNo;

                cn.Open();
                cm = new SqlCommand($"select top 1 TransactionNo from dbo.TemporaryData where TransactionNo like '%{sDate}%' order by CashId desc", cn);
                rd = cm.ExecuteReader();
                rd.Read();

                if (rd.HasRows)
                {
                    transNo = rd[0].ToString();
                    count = int.Parse(transNo.Substring(8, 4));
                    lblTransNo.Text = sDate + (count + 1);
                }
                else
                {
                    transNo = sDate + "1001";
                    lblTransNo.Text = transNo;
                }
                rd.Close();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        public void loadCashTempDataList()
        {
            try
            {
                int i = 0;
                int totalPayment = 0;
                gridCash.Rows.Clear();

                cm = new SqlCommand("SELECT CashId, Pid, Pname, Quantity, Price, Total, c.Cname, Cashier " +
                                    "FROM dbo.TemporaryData AS cash LEFT JOIN dbo.Customer c ON cash.Cid = c.Cid " +
                                    $"WHERE TransactionNo LIKE '%{lblTransNo.Text}%'", cn);
                cn.Open();
                rd = cm.ExecuteReader();
                while (rd.Read())
                {
                    i++;
                    int CashId = (int)rd[0];
                    //string transNo = rd[1].ToString();
                    string Pid = rd[1].ToString();
                    string Pname = rd[2].ToString();
                    int quantity = (int)rd[3];
                    int price = (int)rd[4];
                    int total = (int)rd[5];
                    string customerName = rd[6].ToString();
                    string cashier = rd[7].ToString();

                    gridCash.Rows.Add(i, CashId, Pid, Pname, quantity, price, total, customerName, cashier);
                    totalPayment += total;
                }
                rd.Close();
                cn.Close();
                lblTotal.Text = totalPayment + "đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }
        #endregion
    }
}
