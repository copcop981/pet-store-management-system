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
using Microsoft.Reporting.WinForms;
using PetStoreManagement.DTO;

namespace PetStoreManagement
{
    public partial class InvoiceForm : Form
    {
        bool drag = false;
        Point startPoint = new Point(0, 0);

        List<InvoiceDTO> _ds;
        string _total;
        //string _total, _cash, _change, _date;

        public InvoiceForm(List<InvoiceDTO> dataSource, string total)
        {
            InitializeComponent();

            _ds = dataSource;
            _total = total;
            //_cash = cash;
            //_change = change;
            //_date = date;

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

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            //SqlConnection conn = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=QuanLyCuaHangPet;Integrated Security=True");
            //SqlDataAdapter adapter = new SqlDataAdapter("");

            ReportParameter[] param = new ReportParameter[]
            {
                new ReportParameter("pTotal", _total)
                //new ReportParameter("pCash", _cash),
                //new ReportParameter("pChange", _change),
                //new ReportParameter("pDate", _date);
            };
            this.reportViewer1.LocalReport.SetParameters(param);

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "DataSet1";
            rds.Value = _ds;
            reportViewer1.LocalReport.DataSources.Add(rds);

            this.reportViewer1.RefreshReport();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
