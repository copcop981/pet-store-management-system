﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using PetStoreManagement.BLL;
using PetStoreManagement.DTO;

namespace PetStoreManagement
{
    public partial class CashForm : Form
    {
        CashBLL cashBLL = new CashBLL();
        string title = "Pet Store Management System";

        MainForm mainForm;

        public CashForm(MainForm mainF)
        {
            InitializeComponent();

            mainForm = mainF;
            getTransNo();
            loadCashTempDataList();
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
            //btnCash.Enabled = true;
        }
        
        private void btnCash_Click(object sender, EventArgs e)
        {
            List<InvoiceDTO> ds = new List<InvoiceDTO>();

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


                    // GET CUSTOMER ID BY CUSTOMER NAME

                    //int customerId = -1;
                    //string customerName = gridCash.Rows[i].Cells[7].Value.ToString();
                    //cn.Open();
                    //cm = new SqlCommand("select Cid from dbo.Customer where Cname = N'" + customerName + "'", cn);
                    //SqlDataReader rd = cm.ExecuteReader();
                    //if (rd.Read())
                    //    customerId = (int)rd[0];
                    //rd.Close();
                    //cn.Close();
                    string customerName = gridCash.Rows[i].Cells[7].Value.ToString();
                    int customerId = cashBLL.getCusIdByCusName(customerName);

                    // INSERT NEW TO dbo.Cash

                    //cn.Open();
                    //cm = new SqlCommand("insert dbo.Cash values (@TransNo, @Pid, @Pname, @Quantity, @Price, @Total, @Cid, @Cashier)", cn);
                    //cm.Parameters.Add("@TransNo", SqlDbType.VarChar).Value = lblTransNo.Text;
                    //cm.Parameters.Add("@Pid", SqlDbType.VarChar).Value = gridCash.Rows[i].Cells[2].Value;
                    //cm.Parameters.Add("@Pname", SqlDbType.NVarChar).Value = gridCash.Rows[i].Cells[3].Value;
                    //cm.Parameters.Add("@Quantity", SqlDbType.Int).Value = (int)gridCash.Rows[i].Cells[4].Value;
                    //cm.Parameters.Add("@Price", SqlDbType.Int).Value = (int)gridCash.Rows[i].Cells[5].Value;
                    //cm.Parameters.Add("@Total", SqlDbType.Int).Value = (int)gridCash.Rows[i].Cells[4].Value * (int)gridCash.Rows[i].Cells[5].Value;
                    //cm.Parameters.Add("@Cid", SqlDbType.Int).Value = customerId;
                    //cm.Parameters.Add("@Cashier", SqlDbType.VarChar).Value = mainForm.lblUsername.Text;
                    //cm.ExecuteNonQuery();
                    //cn.Close();
                    string transNo = lblTransNo.Text;
                    string pId = gridCash.Rows[i].Cells[2].Value.ToString();
                    string pName = gridCash.Rows[i].Cells[3].Value.ToString();
                    int quantity = (int)gridCash.Rows[i].Cells[4].Value;
                    int price = (int)gridCash.Rows[i].Cells[5].Value;
                    int total = (int)gridCash.Rows[i].Cells[4].Value * (int)gridCash.Rows[i].Cells[5].Value;
                    int cId = customerId;
                    string cashier = mainForm.lblUsername.Text;
                    cashBLL.addNewCash(transNo, pId, pName, quantity, price, total, cId, cashier);

                    // UPDATE THE CURRENT QUANTITY OF THE PRODUCT AFTER PURCHASE
                    cashBLL.updateProductQuantity(quantity, int.Parse(pId));

                    // PRINT INVOICE
                    InvoiceDTO iv = new InvoiceDTO();
                    iv.CashId = (int)gridCash.Rows[i].Cells[1].Value;
                    iv.Pid = gridCash.Rows[i].Cells[2].Value.ToString();
                    iv.Pname = gridCash.Rows[i].Cells[3].Value.ToString();
                    iv.Pquantity = (int)gridCash.Rows[i].Cells[4].Value;
                    iv.Pprice = (int)gridCash.Rows[i].Cells[5].Value;
                    iv.Total = (int)gridCash.Rows[i].Cells[4].Value * (int)gridCash.Rows[i].Cells[5].Value;
                    iv.Cname = gridCash.Rows[i].Cells[7].Value.ToString();
                    iv.Cashier = gridCash.Rows[i].Cells[8].Value.ToString();

                    ds.Add(iv);
                }

                // CONFIRM TO PRINT INVOICE
                DialogResult dlR2 = MessageBox.Show("Would you like to print an invoice?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlR2 == DialogResult.Yes)
                {
                    InvoiceForm f = new InvoiceForm(ds, lblTotal.Text);
                    f.ShowDialog();
                }
            }
            
            if (gridCash.Rows.Count == 0)
            {
                btnAddCustomer.Visible = false;
                btnCash.Enabled = false;
            }
            else
            {
                btnAddCustomer.Visible = true;
                btnCash.Enabled = true;
            }

            lblTotal.Text = 0 + ".00đ";
            gridCash.Rows.Clear();
            //btnInvoice.Enabled = false;
            mainForm.loadDailySale();
            loadCashTempDataList();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            
        }

        private void btnInvoice_MouseHover(object sender, EventArgs e)
        {
            //toolTip1.SetToolTip(btnInvoice, "Print Invoice");
        }

        private void gridCash_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = gridCash.Columns[e.ColumnIndex].Name;
            if(colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to Delete This Cash?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    // CANCEL CASH

                    //cn.Open();
                    //cm = new SqlCommand($"delete from dbo.TemporaryData where CashId = {gridCash.Rows[e.RowIndex].Cells[1].Value}", cn);
                    //cm.ExecuteNonQuery();
                    //cn.Close();
                    cashBLL.deleteCash((int)gridCash.Rows[e.RowIndex].Cells[1].Value);
                    MessageBox.Show("Cash has been Successfully Deleted!", title);
                }
                
            }
            else if(colName == "Increase")
            {
                // INCREASE THE NUMBER OF PRODUCTS

                //cn.Open();
                //cm = new SqlCommand("update dbo.TemporaryData set Quantity = Quantity + 1 where CashId = " + gridCash.Rows[e.RowIndex].Cells[1].Value, cn);
                //cm.ExecuteNonQuery();
                //cn.Close();
                cashBLL.increaseProductsNumber((int)gridCash.Rows[e.RowIndex].Cells[1].Value);
            }
            else if(colName == "Decrease")
            {
                // DECREASE THE NUMBER OF PRODUCTS

                if ((int)gridCash.Rows[e.RowIndex].Cells[4].Value == 1)
                {
                    MessageBox.Show("Quantity should not be less than 1", title);
                    return;
                }
                //cn.Open();
                //cm = new SqlCommand("update dbo.TemporaryData set Quantity = Quantity - 1 where CashId = " + gridCash.Rows[e.RowIndex].Cells[1].Value, cn);
                //cm.ExecuteNonQuery();
                //cn.Close();
                cashBLL.decreaseProductsNumber((int)gridCash.Rows[e.RowIndex].Cells[1].Value);
            }
            loadCashTempDataList();
        }

        #region Method
        public void getTransNo()
        {
            try
            {
                //string sDate = DateTime.Now.ToString("yyyyMMdd");
                //int count;
                //string transNo;

                //cn.Open();
                //cm = new SqlCommand($"select top 1 TransactionNo from dbo.TemporaryData where TransactionNo like '%{sDate}%' order by CashId desc", cn);
                //rd = cm.ExecuteReader();
                //rd.Read();

                //if (rd.HasRows)
                //{
                //    transNo = rd[0].ToString();
                //    count = int.Parse(transNo.Substring(8, 4));
                //    lblTransNo.Text = sDate + (count + 1);
                //}
                //else
                //{
                //    transNo = sDate + "1001";
                //    lblTransNo.Text = transNo;
                //}
                //rd.Close();
                //cn.Close();

                string sDate = DateTime.Now.ToString("yyyyMMdd");
                int count;
                string transNo = "";

                List<TemporaryDataDTO> list = cashBLL.getTransNo(sDate);
                foreach (TemporaryDataDTO tempData in list)
                {
                    transNo = tempData.TransNo;
                    count = int.Parse(transNo.Substring(8, 4));
                    lblTransNo.Text = sDate + (count + 1);
                }
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
                //cm = new SqlCommand("SELECT CashId, Pid, Pname, Quantity, Price, Total, c.Cname, Cashier " +
                //                    "FROM dbo.TemporaryData AS cash LEFT JOIN dbo.Customer c ON cash.Cid = c.Cid " +
                //                    $"WHERE TransactionNo LIKE '%{lblTransNo.Text}%'", cn);
                //cn.Open();
                //rd = cm.ExecuteReader();
                //while (rd.Read())
                //{
                //    i++;
                //    int CashId = (int)rd[0];
                //    //string transNo = rd[1].ToString();
                //    string Pid = rd[1].ToString();
                //    string Pname = rd[2].ToString();
                //    int quantity = (int)rd[3];
                //    int price = (int)rd[4];
                //    int total = (int)rd[5];
                //    string customerName = rd[6].ToString();
                //    string cashier = rd[7].ToString();

                //    gridCash.Rows.Add(i, CashId, Pid, Pname, quantity, price, total, customerName, cashier);
                //    totalPayment += total;
                //}
                //rd.Close();
                //cn.Close();

                int i = 0;
                int totalPayment = 0;
                gridCash.Rows.Clear();

                List<MiddleTemporaryDataDTO> middleTempDataList = cashBLL.getCashTempDataList(lblTransNo.Text);
                foreach(MiddleTemporaryDataDTO middleTempData in middleTempDataList)
                {
                    i++;
                    int cashId = middleTempData.CashId;
                    //string transNo = rd[1].ToString();
                    string pId = middleTempData.Pid;
                    string pName = middleTempData.Pname;
                    int quantity = middleTempData.Quantity;
                    int price = middleTempData.Price;
                    int total = quantity * price;
                    string customerName = middleTempData.Cname;
                    string cashier = middleTempData.Cashier;

                    gridCash.Rows.Add(i, cashId, pId, pName, quantity, price, total, customerName, cashier);
                    totalPayment += total;
                }

                lblTotal.Text = totalPayment + "";
                lblTotal.Text = string.Format("{0:#,##0.00}đ", double.Parse(lblTotal.Text));
                if (gridCash.Rows.Count == 0)
                {
                    btnAddCustomer.Visible = false;
                    btnCash.Enabled = false;
                    //btnInvoice.Enabled = false;
                    picBoxNoItemsFound.Visible = true;
                }
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
