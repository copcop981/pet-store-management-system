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
    public partial class Dashboard : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader rd;
        DbConnect dbcon = new DbConnect();
        public string uName;
        string title = "Pet Store Management System";

        public Dashboard()
        {
            InitializeComponent();

            cn = new SqlConnection(dbcon.connection());
        }

        public int countPet(string petCategory)
        {
            int data = 0;
            try
            {
                cn.Open();
                cm = new SqlCommand("select isnull(sum(Pquantity), 0) from dbo.Product where Pcategory = N'" + petCategory + "'", cn);
                data = (int)cm.ExecuteScalar();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
            return data;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            lblDogCount.Text = countPet("Dog") + "";
            lblCatCount.Text = countPet("Cat") + "";
            lblBirdCount.Text = countPet("Bird") + "";
            lblFishCount.Text = countPet("Fish") + "";
        }
    }
}
