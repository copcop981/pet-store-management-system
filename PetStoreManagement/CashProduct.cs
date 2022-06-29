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
using PetStoreManagement.BLL;
using PetStoreManagement.DTO;

namespace PetStoreManagement
{
    public partial class CashProduct : Form
    {
        //SqlConnection cn = new SqlConnection();
        //SqlCommand cm = new SqlCommand();
        //SqlDataReader rd;
        //DbConnect dbcon = new DbConnect();

        CashProductBLL cashProductBLL = new CashProductBLL();
        public string uName;
        string title = "Pet Store Management System";

        CashForm cashForm;

        bool drag = false;
        Point startPoint = new Point(0, 0);

        public CashProduct(CashForm cash)
        {
            InitializeComponent();

            //cn = new SqlConnection(dbcon.connection());
            loadProductList();
            cashForm = cash;
            AcceptButton = btnSubmit;

            Panel[] panelList = { panel1, panel2 };
            for(int i = 0; i < panelList.Length; i++)
            {
                panelList[i].MouseUp += CashProduct_MouseUp;
                panelList[i].MouseMove += CashProduct_MouseMove;
                panelList[i].MouseDown += CashProduct_MouseDown;
            }

            Load += CashProduct_Load;
        }

        private void CashProduct_Load(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row1 in cashForm.gridCash.Rows)
            //foreach (DataGridViewRow row2 in gridProduct.Rows)

            for (int i = 0; i < cashForm.gridCash.Rows.Count; i++)
            {
                string pName = cashForm.gridCash.Rows[i].Cells[3].Value.ToString();

                for (int j = 0; j < gridProduct.Rows.Count; j++)
                {
                    if (gridProduct.Rows[j].Cells[2].Value.ToString() == pName)
                    {
                        gridProduct.Rows[j].Visible = false; // C1
                        //gridProduct.Rows.Remove(gridProduct.Rows[j]); // C2
                        //gridProduct.Rows.RemoveAt(j); // C3
                    }
                    //else
                    //    gridProduct.Rows[j].Visible = true;
                }
            }
        }

        private void CashProduct_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void CashProduct_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void CashProduct_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            loadProductList();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in gridProduct.Rows)
            {
                bool chkBox = Convert.ToBoolean(row.Cells["Select"].Value);
                if (chkBox)
                {
                    try
                    {
                        //cm = new SqlCommand("insert dbo.TemporaryData (TransactionNo, Pid, Pname, Quantity, Price, Cashier) values (@TransactionNo, @Pid, @Pname, @Quantity, @Price, @Cashier)", cn);
                        //cm.Parameters.Add("@TransactionNo", SqlDbType.VarChar).Value = cashForm.lblTransNo.Text;
                        //cm.Parameters.Add("@Pid", SqlDbType.VarChar).Value = row.Cells[1].Value;
                        //cm.Parameters.Add("@Pname", SqlDbType.NVarChar).Value = row.Cells[2].Value;
                        //cm.Parameters.Add("@Quantity", SqlDbType.Int).Value = (int)row.Cells[5].Value;
                        //cm.Parameters.Add("@Price", SqlDbType.Int).Value = (int)row.Cells[6].Value;
                        ////cm.Parameters.Add("@Total", SqlDbType.Int).Value = (int)row.Cells[5].Value * (int)row.Cells[6].Value;
                        //cm.Parameters.Add("@Cashier", SqlDbType.VarChar).Value = uName;

                        //cn.Open();
                        //cm.ExecuteNonQuery();
                        //cn.Close();

                        string transNo = cashForm.lblTransNo.Text;
                        string pId = row.Cells[1].Value.ToString();
                        string pName = row.Cells[2].Value.ToString();
                        //int quantity = (int)row.Cells[5].Value;
                        int quantity = 1;
                        int price = (int)row.Cells[6].Value;
                        string cashier = uName;

                        TemporaryDataDTO tempData = new TemporaryDataDTO();
                        tempData.TransNo = transNo;
                        tempData.Pid = pId;
                        tempData.Pname = pName;
                        tempData.Quantity = quantity;
                        tempData.Price = price;
                        tempData.Cashier = cashier;

                        cashProductBLL.submitTemporaryData(transNo, pId, pName, quantity, price, cashier);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, title);
                    }
                }
            }
            Dispose();
            cashForm.loadCashTempDataList();

            if (cashForm.gridCash.Rows.Count == 0)
                cashForm.btnAddCustomer.Visible = false;
            else
                cashForm.btnAddCustomer.Visible = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        #region Method
        public void loadProductList()
        {
            //cm = new SqlCommand($"select * from dbo.Product where concat(Pname, Ptype, Pcategory) like '%{txbSearch.Text}%' and Pquantity > 0", cn);
            //cn.Open();
            //rd = cm.ExecuteReader();
            //while (rd.Read())
            //{
            //    i++;
            //    string Pid = rd[0].ToString();
            //    string Pname = rd[1].ToString();
            //    string Ptype = rd[2].ToString();
            //    string Pcategory = rd[3].ToString();
            //    int Pquantity = (int)rd[4];
            //    int Pprice = (int)rd[5];

            //    gridProduct.Rows.Add(i, Pid, Pname, Ptype, Pcategory, Pquantity, Pprice);
            //}
            //rd.Close();
            //cn.Close();

            int i = 0;
            gridProduct.Rows.Clear();

            List<ProductDTO> productList = cashProductBLL.getAllProduct(txbSearch.Text);
            foreach(ProductDTO product in productList)
            {
                i++;
                int pId = product.Pid;
                string pName = product.Pname;
                string pType = product.Ptype;
                string pCategory = product.Pcategory;
                int pQuantity = product.Pquantity;
                int pPrice = product.Pprice;

                gridProduct.Rows.Add(i, pId, pName, pType, pCategory, pQuantity, pPrice);
            }

            if (gridProduct.Rows.Count == 0)
                picBoxNoItemsFound.Visible = true;
            else
                picBoxNoItemsFound.Visible = false;
        }
        #endregion
    }
}
