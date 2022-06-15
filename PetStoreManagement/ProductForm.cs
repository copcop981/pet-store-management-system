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
    public partial class ProductForm : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader rd;
        DbConnect dbcon = new DbConnect();
        string title = "Pet Store Management System";

        public ProductForm()
        {
            InitializeComponent();

            cn = new SqlConnection(dbcon.connection());
            loadProductList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProductModule moduleForm = new ProductModule(this);
            moduleForm.btnUpdate.Enabled = false;
            moduleForm.btnUpdate.BackColor = Color.Gray;
            moduleForm.ShowDialog();
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            loadProductList();
        }

        private void gridProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = gridProduct.Columns[e.ColumnIndex].Name;
                if (colName == "Edit")
                {
                    ProductModule moduleForm = new ProductModule(this);
                    moduleForm.lblPid.Text = gridProduct.Rows[e.RowIndex].Cells[1].Value.ToString();
                    moduleForm.txbName.Text = gridProduct.Rows[e.RowIndex].Cells[2].Value.ToString();
                    moduleForm.txbType.Text = gridProduct.Rows[e.RowIndex].Cells[3].Value.ToString();
                    moduleForm.cbbCategory.Text = gridProduct.Rows[e.RowIndex].Cells[4].Value.ToString();
                    moduleForm.txbQuantity.Text = gridProduct.Rows[e.RowIndex].Cells[5].Value.ToString();
                    moduleForm.txbPrice.Text = gridProduct.Rows[e.RowIndex].Cells[6].Value.ToString();

                    moduleForm.btnCancel.Enabled = false;
                    moduleForm.btnCancel.BackColor = Color.Gray;

                    moduleForm.btnSave.Enabled = false;
                    moduleForm.btnSave.BackColor = Color.Gray;

                    moduleForm.ShowDialog();
                }
                else if (colName == "Delete")
                {
                    if (MessageBox.Show("Are you sure you want to Delete This Product?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand($"delete from dbo.Product where Pid = {gridProduct.Rows[e.RowIndex].Cells[1].Value}", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Product has been Successfully Deleted!", title);
                    }
                }
                loadProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        #region Method
        public void loadProductList()
        {
            int i = 0;
            gridProduct.Rows.Clear();

            cm = new SqlCommand($"select * from dbo.Product where concat(Pname, Ptype, Pcategory) like '%{txbSearch.Text}%'", cn);
            cn.Open();
            rd = cm.ExecuteReader();
            while (rd.Read())
            {
                i++;
                string Pid = rd[0].ToString();
                string Pname = rd[1].ToString();
                string Ptype = rd[2].ToString();
                string Pcategory = rd[3].ToString();
                int Pquantity = (int)rd[4];
                int Pprice = (int)rd[5];

                gridProduct.Rows.Add(i, Pid, Pname, Ptype, Pcategory, Pquantity, Pprice);
            }
            rd.Close();
            cn.Close();
        }
        #endregion
    }
}
