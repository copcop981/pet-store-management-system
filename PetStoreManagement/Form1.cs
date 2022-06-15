using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PetStoreManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int startPoint = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            startPoint += 10;
            pgrbLogin.Value = startPoint;

            if(pgrbLogin.Value == 80)
            {
                pgrbLogin.Value = 0;
                timer1.Stop();
                LoginForm lf = new LoginForm();
                Hide();
                lf.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}
