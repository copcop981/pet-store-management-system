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
    public partial class CashCustomer : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader rd;
        DbConnect dbcon = new DbConnect();
        public string uName;
        string title = "Pet Store Management System";

        CashForm cashForm;

        bool drag = false;
        Point startPoint = new Point(0, 0);

        public CashCustomer(CashForm cash)
        {
            InitializeComponent();

            cn = new SqlConnection(dbcon.connection());
            loadCustomerList();
            cashForm = cash;

            Panel[] panelList = { panel1, panel2 };
            for (int i = 0; i < panelList.Length; i++)
            {
                panelList[i].MouseUp += CashCustomer_MouseUp;
                panelList[i].MouseMove += CashCustomer_MouseMove;
                panelList[i].MouseDown += CashCustomer_MouseDown;
            }
        }

        private void CashCustomer_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void CashCustomer_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void CashCustomer_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void gridCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = gridCustomer.Columns[e.ColumnIndex].Name;
            if (colName == "Choice")
            {
                cn.Open();
                cm = new SqlCommand("update dbo.TemporaryData set Cid = " + gridCustomer.Rows[e.RowIndex].Cells[1].Value + " where TransactionNo = '" + cashForm.lblTransNo.Text + "'", cn);
                cm.ExecuteNonQuery();
                cn.Close();
                cashForm.loadCashTempDataList();
                cashForm.btnCash.Enabled = true;
                Dispose();
            }
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            loadCustomerList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        #region Method
        public void loadCustomerList()
        {
            try
            {
                int i = 0;
                gridCustomer.Rows.Clear();

                cm = new SqlCommand($"select Cid, Cname, Cphone from dbo.Customer where Cname like '%{txbSearch.Text}%'", cn);
                cn.Open();
                rd = cm.ExecuteReader();
                while (rd.Read())
                {
                    i++;
                    int id = (int)rd[0];
                    string name = rd[1].ToString();
                    string phone = rd[2].ToString();

                    gridCustomer.Rows.Add(i, id, name, phone);
                }
                rd.Close();
                cn.Close();
                if (gridCustomer.Rows.Count == 0)
                    picBoxNoItemsFound.Visible = true;
                else
                    picBoxNoItemsFound.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }
        #endregion
    }
}
