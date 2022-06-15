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
    public partial class UserModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DbConnect dbcon = new DbConnect();
        string title = "Pet Store Management System";

        UserForm userForm;

        ErrorProvider errProvider;

        bool drag = false;
        Point startPoint = new Point(0, 0);

        public UserModule(UserForm user)
        {
            InitializeComponent();
            errProvider = new ErrorProvider();
            AcceptButton = btnSave;

            cn = new SqlConnection(dbcon.connection());
            userForm = user;

            MouseUp += UserModule_MouseUp;
            MouseMove += UserModule_MouseMove;
            MouseDown += UserModule_MouseDown;

            txbPhone.KeyPress += TxbPhone_KeyPress;
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
            //    e.Handled = true;
            //}
        }

        private void UserModule_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void UserModule_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void UserModule_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (validateInput())
            //{
            //}

            checkEmptyInput();
            if (txbPassword.Visible == true && txbName.Text.Trim() != "" && txbPassword.Text.Trim() != "" && cbbRole.SelectedIndex != -1 
                || txbPassword.Visible == false && txbName.Text.Trim() != "" && cbbRole.SelectedIndex != -1)
            {
                try
                {
                    if (MessageBox.Show("Are you sure you want to Register This User?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("insert dbo.Userr(name, address, phone, role, birth, password) values(@name, @address, @phone, @role, @birth, @password)", cn);
                        cm.Parameters.Add("@name", SqlDbType.NVarChar).Value = txbName.Text;
                        cm.Parameters.Add("@address", SqlDbType.NVarChar).Value = txbAddress.Text;
                        cm.Parameters.Add("@phone", SqlDbType.VarChar).Value = txbPhone.Text;
                        cm.Parameters.Add("@role", SqlDbType.NVarChar).Value = cbbRole.Text;
                        cm.Parameters.Add("@birth", SqlDbType.NVarChar).Value = dtpkBirth.Value;
                        cm.Parameters.Add("@password", SqlDbType.VarChar).Value = txbPassword.Text;

                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("User has been Successfully Registered!", title);
                        resetInputData();
                        userForm.loadUserList();
                        errProvider.Clear();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, title);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure you want to Update This User?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("update dbo.Userr set name = @name, address = @address, phone = @phone, role =  @role, birth = @birth, password = @password where id = @id", cn);
                    cm.Parameters.Add("@name", SqlDbType.NVarChar).Value = txbName.Text;
                    cm.Parameters.Add("@address", SqlDbType.NVarChar).Value = txbAddress.Text;
                    cm.Parameters.Add("@phone", SqlDbType.VarChar).Value = txbPhone.Text;
                    cm.Parameters.Add("@role", SqlDbType.NVarChar).Value = cbbRole.Text;
                    cm.Parameters.Add("@birth", SqlDbType.NVarChar).Value = dtpkBirth.Value;
                    cm.Parameters.Add("@password", SqlDbType.VarChar).Value = txbPassword.Text; 
                    cm.Parameters.Add("@id", SqlDbType.Int).Value = lblUid.Text;

                    cn.Open();
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("User has been Successfully Updated!", title);
                    Dispose();
                    userForm.loadUserList();
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

        private void cbbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbRole.SelectedIndex != -1)
                errProvider.SetError(cbbRole, "");

            if(cbbRole.Text == "Employee")
            {
                Height = 426 - cbbRole.Height - 15;
                lblPassword.Visible = false;
                txbPassword.Visible = false;
            }
            else
            {
                Height = 426;
                txbPassword.Visible = true;
                lblPassword.Visible = true;
            }
        }

        private void txbName_TextChanged(object sender, EventArgs e)
        {
            if (txbName.Text.Trim() != "")
                errProvider.SetError(txbName, "");
        }

        private void txbPassword_TextChanged(object sender, EventArgs e)
        {
            if (txbPassword.Text.Trim() != "")
                errProvider.SetError(txbPassword, "");
        }

        #region Method
        public void resetInputData()
        {
            foreach (Control ctrl in Controls)
                if (ctrl is TextBox)
                    ctrl.Text = "";
            txbName.Focus();
            cbbRole.SelectedIndex = -1;
            dtpkBirth.Value = DateTime.Now;
        }

        public static int checkAge(DateTime birth)
        {
            int age = DateTime.Now.Year - birth.Year;
            //if (DateTime.Now.DayOfYear < birth.DayOfYear)
            //    age = age - 1;
            return age;
        }

        void checkEmptyInput()
        {
            if (cbbRole.SelectedIndex == -1)
                errProvider.SetError(cbbRole, "Hãy chọn quyền của tài khoản này");
            else
                txbName.Focus();

            if (txbName.Text.Trim() == "")
            {
                errProvider.SetError(txbName, "Hãy nhập Username");
                txbName.Focus();
            }
            else
                txbPassword.Focus();

            if (txbPassword.Text.Trim() == "")
                errProvider.SetError(txbPassword, "Hãy nhập Password");
        }

        //bool validateInput()
        //{
        //    if(cbbRole.SelectedIndex == -1 || txbName.Text.Trim() == "" || txbPassword.Text.Trim() == "" || txbPassword.Visible == true)
        //    {
        //        if (cbbRole.SelectedIndex == -1)
        //            errProvider.SetError(cbbRole, "Hãy chọn vị trí cho tài khoản");
        //        else
        //            txbName.Focus();

        //        if (txbName.Text.Trim() == "")
        //        {
        //            errProvider.SetError(txbName, "Hãy nhập Username");
        //            txbName.Focus();
        //        }
        //        else
        //            txbPassword.Focus();

        //        if (txbPassword.Text.Trim() == "")
        //            errProvider.SetError(txbPassword, "Hãy nhập Password");
        //        return false;
        //    }
        //    return true;
        //}
        #endregion
    }
}
