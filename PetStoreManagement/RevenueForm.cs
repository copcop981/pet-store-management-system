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

                    gridRevenue.Rows.Add(i, "", "", dateTime, transNo, pName, quantity, price, total, payer);
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
    }
}
