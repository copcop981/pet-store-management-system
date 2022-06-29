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
    public partial class CustomerModule : Form
    {
        //SqlConnection cn = new SqlConnection();
        //SqlCommand cm = new SqlCommand();
        //SqlDataReader rd;
        //DbConnect dbcon = new DbConnect();

        CustomerBLL cusBLL = new CustomerBLL();
        string title = "Pet Store Management System";

        CustomerForm customerForm;

        ErrorProvider errProvider;

        bool drag = false;
        Point startPoint = new Point(0, 0);

        public CustomerModule(CustomerForm customer)
        {
            InitializeComponent();
            AcceptButton = btnSave;
            errProvider = new ErrorProvider();

            //cn = new SqlConnection(dbcon.connection());
            customerForm = customer;

            MouseUp += CustomerModule_MouseUp;
            MouseMove += CustomerModule_MouseMove;
            MouseDown += CustomerModule_MouseDown;

            txbPhone.KeyPress += TxbPhone_KeyPress;

            txbName.GotFocus += TxbName_GotFocus;
            txbName.LostFocus += TxbName_LostFocus;

            txbAddress.GotFocus += TxbAddress_GotFocus;
            txbAddress.LostFocus += TxbAddress_LostFocus;

            txbPhone.GotFocus += TxbPhone_GotFocus;
            txbPhone.LostFocus += TxbPhone_LostFocus;
        }

        private void TxbName_GotFocus(object sender, EventArgs e)
        {
            pbName.Image = Image.FromFile(Application.StartupPath + "\\Resources\\imgs\\IconUserFill_new.png");
            pnTxbName.BackColor = Color.FromArgb(3, 172, 220);
            txbName.ForeColor = Color.Green;
        }

        private void TxbName_LostFocus(object sender, EventArgs e)
        {
            pbName.Image = Image.FromFile(Application.StartupPath + "\\Resources\\imgs\\IconUser_new (2).png");
            pnTxbName.BackColor = Color.FromArgb(224, 224, 224);
            txbName.ForeColor = Color.FromKnownColor(KnownColor.WindowText);
        }

        private void TxbAddress_GotFocus(object sender, EventArgs e)
        {
            pbAddress.Image = Image.FromFile(Application.StartupPath + "\\Resources\\imgs\\IconLocationFill_new.png");
            pnTxbAddress.BackColor = Color.FromArgb(3, 172, 220);
            txbAddress.ForeColor = Color.Green;
        }

        private void TxbAddress_LostFocus(object sender, EventArgs e)
        {
            pbAddress.Image = Image.FromFile(Application.StartupPath + "\\Resources\\imgs\\IconLocation_new.png");
            pnTxbAddress.BackColor = Color.FromArgb(224, 224, 224);
            txbAddress.ForeColor = Color.FromKnownColor(KnownColor.WindowText);
        }

        private void TxbPhone_GotFocus(object sender, EventArgs e)
        {
            pbPhone.Image = Image.FromFile(Application.StartupPath + "\\Resources\\imgs\\IconPhoneFill_new.png");
            pnTxbPhone.BackColor = Color.FromArgb(3, 172, 220);
            txbPhone.ForeColor = Color.Green;
        }

        private void TxbPhone_LostFocus(object sender, EventArgs e)
        {
            pbPhone.Image = Image.FromFile(Application.StartupPath + "\\Resources\\imgs\\IconPhone_new.png");
            pnTxbPhone.BackColor = Color.FromArgb(224, 224, 224);
            txbPhone.ForeColor = Color.FromKnownColor(KnownColor.WindowText);
        }

        private void TxbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '+'))
            {
                e.Handled = true;
                errProvider.SetError(txbPhone, "Chỉ được nhập số");
            }
            else
                errProvider.SetError(txbPhone, "");

            // Dấu +
            //if ((e.KeyChar == '+') && ((sender as TextBox).Text.IndexOf('+') > -1))
            //{
            //    e.Hand
        }

        private void CustomerModule_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void CustomerModule_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void CustomerModule_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txbName.Text.Trim() == "")
            {
                errProvider.SetError(txbName, "Hãy nhập tên khách hàng");
                txbName.Focus();
                return;
            }
            try
            {
                if (MessageBox.Show("Are you sure you want to Register This Customer?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //cm = new SqlCommand("insert dbo.Customer (Cname, Caddress, Cphone) values(@Cname, @Caddress, @Cphone)", cn);
                    //cm.Parameters.Add("@Cname", SqlDbType.NVarChar).Value = txbName.Text;
                    //cm.Parameters.Add("@Caddress", SqlDbType.NVarChar).Value = txbAddress.Text;
                    //cm.Parameters.Add("@Cphone", SqlDbType.VarChar).Value = txbPhone.Text;

                    //cn.Open();
                    //cm.ExecuteNonQuery();
                    //cn.Close();

                    string cName = txbName.Text;
                    string cAddress = txbAddress.Text;
                    string cPhone = txbPhone.Text;

                    CustomerDTO cus = new CustomerDTO();
                    cus.Cname = cName;
                    cus.Caddress = cAddress;
                    cus.Cphone = cPhone;

                    int result = cusBLL.addNewCustomer(cName, cAddress, cPhone);
                    if (result > 0)
                    {
                        MessageBox.Show("Customer has been Successfully Registered!", title);
                        resetInputData();
                        customerForm.loadCustomerList();
                        errProvider.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to Update This Customer?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //cm = new SqlCommand("update dbo.Customer set Cname = @Cname, Caddress = @Caddress, Cphone = @Cphone where Cid = @Cid", cn);
                    //cm.Parameters.Add("@Cname", SqlDbType.NVarChar).Value = txbName.Text;
                    //cm.Parameters.Add("@Caddress", SqlDbType.NVarChar).Value = txbAddress.Text;
                    //cm.Parameters.Add("@Cphone", SqlDbType.VarChar).Value = txbPhone.Text;
                    //cm.Parameters.Add("@Cid", SqlDbType.Int).Value = lblCid.Text;

                    //cn.Open();
                    //cm.ExecuteNonQuery();
                    //cn.Close();

                    int cId = int.Parse(lblCid.Text);
                    string cName = txbName.Text;
                    string cAddress = txbAddress.Text;
                    string cPhone = txbPhone.Text;

                    CustomerDTO cus = new CustomerDTO();
                    cus.Cname = cName;
                    cus.Caddress = cAddress;
                    cus.Cphone = cPhone;

                    int result = cusBLL.updateCustomer(cName, cAddress, cPhone, cId);
                    if (result > 0)
                    {
                        MessageBox.Show("Customer has been Successfully Updated!", title);
                        Dispose();
                        customerForm.loadCustomerList();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            resetInputData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void txbName_TextChanged(object sender, EventArgs e)
        {
            if (txbName.Text.Trim() != "")
                errProvider.SetError(txbName, "");
        }

        #region Method
        public void resetInputData()
        {
            foreach (Control ctrl in Controls)
                if (ctrl is TextBox)
                    ctrl.Text = "";
            txbName.Focus();
        }
        #endregion
    }
}
