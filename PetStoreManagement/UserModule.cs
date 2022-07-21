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
    public partial class UserModule : Form
    {
        //SqlConnection cn = new SqlConnection();
        //SqlCommand cm = new SqlCommand();
        //SqlDataReader rd;
        //DbConnect dbcon = new DbConnect();

        UserBLL userBLL = new UserBLL();
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
            userForm = user;

            //cn = new SqlConnection(dbcon.connection());

            MouseUp += UserModule_MouseUp;
            MouseMove += UserModule_MouseMove;
            MouseDown += UserModule_MouseDown;

            txbPhone.KeyPress += TxbPhone_KeyPress;

            txbName.GotFocus += TxbName_GotFocus;
            txbName.LostFocus += TxbName_LostFocus;

            txbAddress.GotFocus += TxbAddress_GotFocus;
            txbAddress.LostFocus += TxbAddress_LostFocus;

            txbPhone.GotFocus += TxbPhone_GotFocus;
            txbPhone.LostFocus += TxbPhone_LostFocus;

            cbbRole.GotFocus += CbbRole_GotFocus;
            cbbRole.LostFocus += CbbRole_LostFocus;

            dtpkBirth.GotFocus += DtpkBirth_GotFocus;
            dtpkBirth.LostFocus += DtpkBirth_LostFocus;

            txbPassword.GotFocus += TxbPassword_GotFocus;
            txbPassword.LostFocus += TxbPassword_LostFocus;
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

        private void CbbRole_GotFocus(object sender, EventArgs e)
        {
            pbRole.Image = Image.FromFile(Application.StartupPath + "\\Resources\\imgs\\IconRoleFill_new.png");
            pnCbbRole.BackColor = Color.FromArgb(3, 172, 220);
            cbbRole.ForeColor = Color.Green;
        }

        private void CbbRole_LostFocus(object sender, EventArgs e)
        {
            pbRole.Image = Image.FromFile(Application.StartupPath + "\\Resources\\imgs\\IconRole_new.png");
            pnCbbRole.BackColor = Color.FromArgb(224, 224, 224);
            cbbRole.ForeColor = Color.FromKnownColor(KnownColor.WindowText);
        }

        private void DtpkBirth_GotFocus(object sender, EventArgs e)
        {
            pbDateOfBirth.Image = Image.FromFile(Application.StartupPath + "\\Resources\\imgs\\IconDateOfBirthFill_new.png");
            pnDtpkBirth.BackColor = Color.FromArgb(3, 172, 220);
            dtpkBirth.ForeColor = Color.Green;
        }

        private void DtpkBirth_LostFocus(object sender, EventArgs e)
        {
            pbDateOfBirth.Image = Image.FromFile(Application.StartupPath + "\\Resources\\imgs\\IconDateOfBirth_new.png");
            pnDtpkBirth.BackColor = Color.FromArgb(224, 224, 224);
            dtpkBirth.ForeColor = Color.FromKnownColor(KnownColor.WindowText);
        }

        private void TxbPassword_GotFocus(object sender, EventArgs e)
        {
            pbPassword.Image = Image.FromFile(Application.StartupPath + "\\Resources\\imgs\\IconPasswordFill_new.png");
            pnTxbPassword.BackColor = Color.FromArgb(3, 172, 220);
            txbPassword.ForeColor = Color.Green;
        }

        private void TxbPassword_LostFocus(object sender, EventArgs e)
        {
            pbPassword.Image = Image.FromFile(Application.StartupPath + "\\Resources\\imgs\\IconPassword_new.png");
            pnTxbPassword.BackColor = Color.FromArgb(224, 224, 224);
            txbPassword.ForeColor = Color.FromKnownColor(KnownColor.WindowText);
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
                        //cm = new SqlCommand("insert dbo.Userr(name, address, phone, role, birth, password) values(@name, @address, @phone, @role, @birth, @password)", cn);
                        //cm.Parameters.Add("@name", SqlDbType.NVarChar).Value = txbName.Text;
                        //cm.Parameters.Add("@address", SqlDbType.NVarChar).Value = txbAddress.Text;
                        //cm.Parameters.Add("@phone", SqlDbType.VarChar).Value = txbPhone.Text;
                        //cm.Parameters.Add("@role", SqlDbType.NVarChar).Value = cbbRole.Text;
                        //cm.Parameters.Add("@birth", SqlDbType.NVarChar).Value = dtpkBirth.Value;
                        //cm.Parameters.Add("@password", SqlDbType.VarChar).Value = txbPassword.Text;

                        //cn.Open();
                        //cm.ExecuteNonQuery();
                        //cn.Close();

                        string name = txbName.Text;
                        string address = txbAddress.Text;
                        string phone = txbPhone.Text;
                        string role = cbbRole.Text;
                        DateTime birth = dtpkBirth.Value;
                        string password = txbPassword.Text;

                        UserDTO user = new UserDTO();
                        user.Name = name;
                        user.Address = address;
                        user.Phone = phone;
                        user.Role = role;
                        user.Birth = birth;
                        user.Password = password;

                        int result = userBLL.addNewUser(name, address, phone, role, birth, password);
                        if(result > 0)
                        {
                            MessageBox.Show("User has been Successfully Registered!", title);
                            resetInputData();
                            userForm.loadUserList();
                            errProvider.Clear();
                        }
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
            checkEmptyInput();
            if (txbPassword.Visible == true && txbName.Text.Trim() != "" && txbPassword.Text.Trim() != "" && cbbRole.SelectedIndex != -1
                || txbPassword.Visible == false && txbName.Text.Trim() != "" && cbbRole.SelectedIndex != -1)
            {
                try
                {
                    if (MessageBox.Show("Are you sure you want to Update This User?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //cm = new SqlCommand("update dbo.Userr set name = @name, address = @address, phone = @phone, role =  @role, birth = @birth, password = @password where id = @id", cn);
                        //cm.Parameters.Add("@name", SqlDbType.NVarChar).Value = txbName.Text;
                        //cm.Parameters.Add("@address", SqlDbType.NVarChar).Value = txbAddress.Text;
                        //cm.Parameters.Add("@phone", SqlDbType.VarChar).Value = txbPhone.Text;
                        //cm.Parameters.Add("@role", SqlDbType.NVarChar).Value = cbbRole.Text;
                        //cm.Parameters.Add("@birth", SqlDbType.NVarChar).Value = dtpkBirth.Value;
                        //cm.Parameters.Add("@password", SqlDbType.VarChar).Value = txbPassword.Text; 
                        //cm.Parameters.Add("@id", SqlDbType.Int).Value = lblUid.Text;

                        //cn.Open();
                        //cm.ExecuteNonQuery();
                        //cn.Close();

                        int id = int.Parse(lblUid.Text);
                        string name = txbName.Text;
                        string address = txbAddress.Text;
                        string phone = txbPhone.Text;
                        string role = cbbRole.Text;
                        DateTime birth = dtpkBirth.Value;
                        string password;

                        if (cbbRole.Text == "Employee")
                            password = "";
                        else
                            password = txbPassword.Text;

                        UserDTO user = new UserDTO();
                        user.Name = name;
                        user.Address = address;
                        user.Phone = phone;
                        user.Role = role;
                        user.Birth = birth;
                        user.Password = password;

                        int result = userBLL.updateUser(name, address, phone, role, birth, password, id);

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
                Height = 455 - cbbRole.Height - 45;
                lblPassword.Visible = false;
                txbPassword.Visible = false;
                pnTxbPassword.Visible = false;
                pbPassword.Visible = false;
                chkbShowHide.Visible = false;
            }
            else
            {
                Height = 455;
                txbPassword.Visible = true;
                lblPassword.Visible = true;
                pnTxbPassword.Visible = true;
                pbPassword.Visible = true;
                chkbShowHide.Visible = true;
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

        private void chkbShowHide_CheckedChanged(object sender, EventArgs e)
        {
            //txbPassword.Focus();
            if (chkbShowHide.Checked)
                //txbPassword.UseSystemPasswordChar = true;
                txbPassword.PasswordChar = '\0';
            else
                //txbPassword.UseSystemPasswordChar = false;
                txbPassword.PasswordChar = '♦';
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
