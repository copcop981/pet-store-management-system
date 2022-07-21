using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PetStoreManagement.BLL;
using PetStoreManagement.DTO;

namespace PetStoreManagement
{
    public partial class RevenueForm : Form
    {
        RevenueBLL revenueBLL = new RevenueBLL();
        public RevenueForm()
        {
            InitializeComponent();
            loadRevenue();

            btnFilter.MouseHover += BtnFilter_MouseHover;
            btnRefresh.MouseHover += BtnRefresh_MouseHover;

            btnFilter.Click += BtnFilter_Click;
            btnRefresh.Click += BtnRefresh_Click;

            //txbSearch.TextChanged += TxbSearch_TextChanged;
        }

        //private void TxbSearch_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string search = txbSearch.Text;
        //        string year = dtpkFilter.Value.Year.ToString();

        //        string month = "";
        //        if (dtpkFilter.Value.Month < 10)
        //            month = "0" + dtpkFilter.Value.Month;
        //        else
        //            month = dtpkFilter.Value.Month.ToString();

        //        string day = "";
        //        if (dtpkFilter.Value.Day < 10)
        //            day = "0" + dtpkFilter.Value.Day;
        //        else
        //            day = dtpkFilter.Value.Day.ToString();

        //        List<RevenueDTO> revenueList = revenueBLL.filterProductByDate(year, month, day, search);

        //        int i = 0;
        //        gridRevenue.Rows.Clear();

        //        foreach (RevenueDTO revenue in revenueList)
        //        {
        //            i++;
        //            int id = revenue.Id;
        //            DateTime dateTime = revenue.Date_Time;
        //            string transNo = revenue.Transaction_No;
        //            string pName = revenue.Product_Name;
        //            int quantity = revenue.Quantity;
        //            int price = revenue.Price;
        //            int total = quantity * price;
        //            string payer = revenue.Payer;

        //            gridRevenue.Rows.Add(i, "", "", dateTime.ToString("dd-MM-yyyy HH:mm:ss"), transNo, pName, quantity, price, total, payer);
        //        }

        //        if (gridRevenue.Rows.Count == 0)
        //            picBoxNoItemsFound.Visible = true;
        //        else
        //            picBoxNoItemsFound.Visible = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                //string year = dtpkFilter.Value.Year.ToString();

                //string month = "";
                //if (dtpkFilter.Value.Month < 10)
                //    month = "0" + dtpkFilter.Value.Month;
                //else
                //    month = dtpkFilter.Value.Month.ToString();

                //string day = "";
                //if (dtpkFilter.Value.Day < 10)
                //    day = "0" + dtpkFilter.Value.Day;
                //else
                //    day = dtpkFilter.Value.Day.ToString();

                string startDay = dtpkStartDay.Value.ToShortDateString();
                string endDay = dtpkEndDay.Value.ToShortDateString();

                List<RevenueDTO> revenueList = revenueBLL.filterRevenueByDate(startDay, endDay);

                int i = 0;
                gridRevenue.Rows.Clear();

                foreach (RevenueDTO revenue in revenueList)
                {
                    i++;
                    int id = revenue.Id;
                    DateTime dateTime = revenue.Date_Time;
                    string transNo = revenue.Transaction_No;
                    string pName = revenue.Product_Name;
                    int quantity = revenue.Quantity;
                    int price = revenue.Price;
                    int total = quantity * price;
                    string payer = revenue.Payer;

                    gridRevenue.Rows.Add(i, "", "", dateTime.ToString("dd-MM-yyyy HH:mm:ss"), transNo, pName, quantity, price, total, payer);
                }

                if (gridRevenue.Rows.Count == 0)
                    picBoxNoItemsFound.Visible = true;
                else
                    picBoxNoItemsFound.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                loadRevenue();
                dtpkStartDay.Value = DateTime.Now;
                dtpkEndDay.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnRefresh_MouseHover(object sender, EventArgs e)
        {
            toolTip1 = new ToolTip();
            toolTip1.SetToolTip(btnRefresh, "Refresh");
        }

        private void BtnFilter_MouseHover(object sender, EventArgs e)
        {
            toolTip1 = new ToolTip();
            toolTip1.SetToolTip(btnFilter, "Filter");
        }

        void loadRevenue()
        {
            try
            {
                List<RevenueDTO> revenueList = revenueBLL.getAllRevenue();

                int i = 0;
                gridRevenue.Rows.Clear();

                foreach (RevenueDTO revenue in revenueList)
                {
                    i++;
                    int id = revenue.Id;
                    DateTime dateTime = revenue.Date_Time;
                    string transNo = revenue.Transaction_No;
                    string pName = revenue.Product_Name;
                    int quantity = revenue.Quantity;
                    int price = revenue.Price;
                    int total = quantity * price;
                    string payer = revenue.Payer;

                    gridRevenue.Rows.Add(i, "", "", dateTime.ToString("dd-MM-yyyy HH:mm:ss"), transNo, pName, quantity, price, total, payer);
                }

                if (gridRevenue.Rows.Count == 0)
                    picBoxNoItemsFound.Visible = true;
                else
                    picBoxNoItemsFound.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        //{
        //    string year = dateTimePicker1.Value.Year.ToString();

        //    string month = "";
        //    if (dateTimePicker1.Value.Month < 10)
        //        month = "0" + dateTimePicker1.Value.Month;
        //    else
        //        month = dateTimePicker1.Value.Month.ToString();

        //    string day = "";
        //    if (dateTimePicker1.Value.Day < 10)
        //        day = "0" + dateTimePicker1.Value.Day;
        //    else
        //        day = dateTimePicker1.Value.Day.ToString();

        //    MessageBox.Show(year + month + day);
        //}
    }
}
