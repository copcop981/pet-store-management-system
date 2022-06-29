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
    public partial class CustomerForm : Form
    {
        //SqlConnection cn = new SqlConnection();
        //SqlCommand cm = new SqlCommand();
        //SqlDataReader rd;
        //DbConnect dbcon = new DbConnect();

        CustomerBLL cusBLL = new CustomerBLL();
        string title = "Pet Store Management System";

        public CustomerForm()
        {
            InitializeComponent();

            //cn = new SqlConnection(dbcon.connection());
            loadCustomerList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CustomerModule moduleForm = new CustomerModule(this);
            moduleForm.btnUpdate.Enabled = false;
            moduleForm.btnUpdate.BackColor = Color.Gray;
            moduleForm.ShowDialog();
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            loadCustomerList();
        }

        private void gridCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = gridCustomer.Columns[e.ColumnIndex].Name;
                if (colName == "Editt")
                {
                    CustomerModule moduleForm = new CustomerModule(this);
                    moduleForm.lblCid.Text = gridCustomer.Rows[e.RowIndex].Cells[1].Value.ToString();
                    moduleForm.txbName.Text = gridCustomer.Rows[e.RowIndex].Cells[2].Value.ToString();
                    moduleForm.txbAddress.Text = gridCustomer.Rows[e.RowIndex].Cells[3].Value.ToString();
                    moduleForm.txbPhone.Text = gridCustomer.Rows[e.RowIndex].Cells[4].Value.ToString();

                    moduleForm.btnSave.Enabled = false;
                    moduleForm.btnSave.BackColor = Color.Gray;

                    moduleForm.btnCancel.Enabled = false;
                    moduleForm.btnCancel.BackColor = Color.Gray;

                    moduleForm.ShowDialog();
                }
                else if (colName == "Deletee")
                {
                    if (MessageBox.Show("Are you sure you want to Delete This Customer?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        //cn.Open();
                        //cm = new SqlCommand($"delete from dbo.Customer where Cid = {gridCustomer.Rows[e.RowIndex].Cells[1].Value}", cn);
                        //cm.ExecuteNonQuery();
                        //cn.Close();
                        int result = cusBLL.deleteCustomer((int)gridCustomer.Rows[e.RowIndex].Cells[1].Value);
                        if(result > 0)
                            MessageBox.Show("Customer has been Successfully Deleted!", title);
                    }
                }
                loadCustomerList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        #region Method
        public void loadCustomerList()
        {
            //cm = new SqlCommand($"select * from dbo.Customer where concat(Cname, Caddress, Cphone) like '%{txbSearch.Text}%'", cn);
            //cn.Open();
            //rd = cm.ExecuteReader();
            //while (rd.Read())
            //{
            //    i++;
            //    int id = (int)rd[0];
            //    string name = rd[1].ToString();
            //    string address = rd[2].ToString();
            //    string phone = rd[3].ToString();

            //    gridCustomer.Rows.Add(i, id, name, address, phone);
            //}
            //rd.Close();
            //cn.Close();

            List<CustomerDTO> cusList = cusBLL.getAllCustomer(txbSearch.Text);

            int i = 0;
            gridCustomer.Rows.Clear();

            foreach (CustomerDTO cus in cusList)
            {
                i++;
                int cId = cus.Cid;
                string cName = cus.Cname;
                string cAddress = cus.Caddress;
                string cPhone = cus.Cphone;

                gridCustomer.Rows.Add(i, cId, cName, cAddress, cPhone);
            }

            if (gridCustomer.Rows.Count == 0)
                picBoxNoItemsFound.Visible = true;
            else
                picBoxNoItemsFound.Visible = false;
        }
        #endregion
    }
}
