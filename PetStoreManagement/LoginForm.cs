﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetStoreManagement
{
    public partial class LoginForm : Form
    {
        bool drag = false;
        Point startPoint = new Point(0, 0);

        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader rd;
        DbConnect dbcon = new DbConnect();
        string title = "Pet Store Management System";

        ErrorProvider errProvider;

        public LoginForm()
        {
            InitializeComponent();
            AcceptButton = btnLogin;
            errProvider = new ErrorProvider();
            txbUsername.TextChanged += TxbUsername_TextChanged;
            txbPassword.TextChanged += TxbPassword_TextChanged;

            cn = new SqlConnection(dbcon.connection());

            MouseUp += LoginForm_MouseUp;
            MouseDown += LoginForm_MouseDown;
            MouseMove += LoginForm_MouseMove;

            panel1.MouseMove += Panel1_MouseMove;
            panel1.MouseDown += Panel1_MouseDown;
            panel1.MouseUp += Panel1_MouseUp;
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void LoginForm_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void LoginForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void LoginForm_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //checkEmptyInput();
            //if(txbUsername.Text.Trim() != "" && txbPassword.Text.Trim() != "")
            //{

            //}
            if (validateInputData() || checkIsEmployee(txbUsername.Text, txbPassword.Text))
            {
                try
                {
                    cn.Open();
                    cm = new SqlCommand("select name, role from dbo.Userr where name = @name and password = @password", cn);
                    cm.Parameters.Add("@name", SqlDbType.NVarChar).Value = txbUsername.Text;
                    cm.Parameters.Add("@password", SqlDbType.VarChar).Value = txbPassword.Text;

                    rd = cm.ExecuteReader();
                    rd.Read();
                    if (rd.HasRows)
                    {
                        string _name = rd["name"].ToString();
                        string _role = rd["role"].ToString();

                        errProvider.Dispose();
                        MessageBox.Show("Welcome [" + _name + "] !", title);

                        MainForm mf = new MainForm();
                        mf.lblUsername.Text = _name;
                        mf.lblRole.Text = _role;

                        if (_role == "Administrator")
                            mf.btnUser.Enabled = true;

                        errProvider.Clear();
                        Hide();
                        mf.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username or Password!", title);
                        txbUsername.Focus();
                    }
                    rd.Close();
                    cn.Close();
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
            Application.Exit();
        }

        private void TxbUsername_TextChanged(object sender, EventArgs e)
        {
            if (txbUsername.Text.Trim() != "")
                errProvider.SetError(txbUsername, "");
        }

        private void TxbPassword_TextChanged(object sender, EventArgs e)
        {
            if (txbPassword.Text.Trim() != "")
                errProvider.SetError(txbPassword, "");
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        #region Method
        void resetInputData()
        {
            txbUsername.Clear();
            txbPassword.Clear();

            txbUsername.Focus();
        }

        //void checkEmptyInput()
        //{
        //    if (txbUsername.Text.Trim() == "")
        //    {
        //        errProvider.SetError(txbUsername, "Hãy nhập Username");
        //        txbUsername.Focus();
        //    }
        //    else
        //        txbPassword.Focus();

        //    if (txbPassword.Text.Trim() == "")
        //        errProvider.SetError(txbPassword, "Hãy nhập Password");
        //}

        bool validateInputData()
        {
            if(txbUsername.Text.Trim() == "" || txbPassword.Text.Trim() == "")
            {
                if (txbUsername.Text.Trim() == "")
                {
                    errProvider.SetError(txbUsername, "Hãy nhập Username");
                    txbUsername.Focus();
                }
                else txbPassword.Focus();

                if (txbPassword.Text.Trim() == "")
                    errProvider.SetError(txbPassword, "Hãy nhập Password");
                return false;
            }
            return true;
        }

        bool checkIsEmployee(string _username, string _password)
        {
            DataTable data = new DataTable();

            cn.Open();

            cm = new SqlCommand("select * from dbo.Userr where name = '" + _username + "' and password = '" + _password + "'", cn);
            SqlDataAdapter adapter = new SqlDataAdapter(cm);
            adapter.Fill(data);

            cn.Close();
            return data.Rows.Count > 0;
        }
        #endregion
    }
}