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

namespace PetStoreManagement
{
    public partial class MainForm : Form
    {
        MainBLL mainBLL = new MainBLL();
        public string uName;
        string title = "Pet Store Management System";

        bool drag = false;
        Point startPoint = new Point(0, 0);

        public MainForm()
        {
            InitializeComponent();
            ActiveControl = lblUsername;

            pnNav.Height = btnDashboard.Height;
            pnNav.Top = btnDashboard.Top;
            pnNav.Left = btnDashboard.Left;

            btnDashboard.PerformClick();
            loadDailySale();

            lblTitle.MouseUp += LblTitle_MouseUp;
            lblTitle.MouseMove += LblTitle_MouseMove;
            lblTitle.MouseDown += LblTitle_MouseDown;
        }

        private void LblTitle_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void LblTitle_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void LblTitle_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            openChildForm(new Dashboard());

            pnNav.Height = btnDashboard.Height;
            pnNav.Top = btnDashboard.Top;
            pnNav.Left = btnDashboard.Left;
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            openChildForm(new CustomerForm());

            pnNav.Height = btnCustomers.Height;
            pnNav.Top = btnCustomers.Top;
            pnNav.Left = btnCustomers.Left;
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            openChildForm(new UserForm());

            pnNav.Height = btnUser.Height;
            pnNav.Top = btnUser.Top;
            pnNav.Left = btnUser.Left;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductForm());

            pnNav.Height = btnProduct.Height;
            pnNav.Top = btnProduct.Top;
            pnNav.Left = btnProduct.Left;
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            openChildForm(new CashForm(this));

            pnNav.Height = btnCash.Height;
            pnNav.Top = btnCash.Top;
            pnNav.Left = btnCash.Left;
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            openChildForm(new RevenueForm());

            pnNav.Height = btnRevenue.Height;
            pnNav.Top = btnRevenue.Top;
            pnNav.Left = btnRevenue.Left;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            pnNav.Height = btnLogout.Height;
            pnNav.Top = btnLogout.Top;
            pnNav.Left = btnLogout.Left;

            if (MessageBox.Show("Are you sure you want to sign out?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoginForm lf = new LoginForm();
                Dispose();
                lf.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            //WindowState = WindowState == FormWindowState.Normal ? FormWindowState.Maximized : FormWindowState.Normal;
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                btnMaximize.Image = Image.FromFile($@"{Application.StartupPath}\Resources\imgs\IconRestoreBrowser_new.png");
                btnMaximize.HoverState.Image = Image.FromFile($@"{Application.StartupPath}\Resources\imgs\IconRestoreBrowserFill_new.png");
            }
            else if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                btnMaximize.Image = new Bitmap($@"{Application.StartupPath}\Resources\imgs\IconMaximize_new.png");
                btnMaximize.HoverState.Image = new Bitmap($@"{Application.StartupPath}\Resources\imgs\IconMaximizeFill_new.png");
            }
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            pgTimer.Invoke((MethodInvoker)delegate
            {
                pgTimer.Text = DateTime.Now.ToString("hh:mm:ss");
                pgTimer.Value = Convert.ToInt32(DateTime.Now.Second);
            });
        }

        #region Method
        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;

            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            lblTitle.Text = childForm.Text;

            pnChildForm.Controls.Add(childForm);
            pnChildForm.Tag = childForm;

            childForm.BringToFront();
            childForm.Show();
        }

        public void loadDailySale()
        {
            string sDate = DateTime.Now.ToString("yyyyMMdd");

            try
            {
                //cn.Open();
                //cm = new SqlCommand("select isnull(sum(Total), 0) from dbo.Cash where TransactionNo LIKE '%" + sDate + "%'", cn);
                //lblDailySale.Text = cm.ExecuteScalar() + "";
                //lblDailySale.Text = string.Format("{0:#,##0.00}đ", double.Parse(lblDailySale.Text));
                //cn.Close();
                lblDailySale.Text = mainBLL.getDailySale(sDate).ToString();
                lblDailySale.Text = string.Format("{0:#,##0.00}đ", double.Parse(lblDailySale.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }
        #endregion
    }
}
