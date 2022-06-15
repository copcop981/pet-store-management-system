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
    public partial class ProductModule : Form
    {
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        DbConnect dbcon = new DbConnect();
        string title = "Pet Store Management System";

        ProductForm productForm;

        ErrorProvider errProvider;

        bool drag = false;
        Point startPoint = new Point(0, 0);

        public ProductModule(ProductForm product)
        {
            InitializeComponent();
            AcceptButton = btnSave;
            errProvider = new ErrorProvider();

            cn = new SqlConnection(dbcon.connection());
            productForm = product;

            MouseUp += ProductModule_MouseUp;
            MouseMove += ProductModule_MouseMove;
            MouseDown += ProductModule_MouseDown;

            txbQuantity.KeyPress += TxbQuantity_KeyPress;
            txbPrice.KeyPress += TxbPrice_KeyPress;
        }

        private void TxbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                errProvider.SetError(txbPrice, "Chỉ được nhập số");
            }
            else
                errProvider.SetError(txbPrice, "");

            // Dấu +
            //if ((e.KeyChar == '+') && ((sender as TextBox).Text.IndexOf('+') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void TxbQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                errProvider.SetError(txbQuantity, "Chỉ được nhập số");
            }
            else
                errProvider.SetError(txbQuantity, "");

            // Dấu +
            //if ((e.KeyChar == '+') && ((sender as TextBox).Text.IndexOf('+') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void ProductModule_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void ProductModule_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
            }
        }

        private void ProductModule_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            checkEmptyInput();

            if(cbbCategory.SelectedIndex < 0)
            {
                errProvider.SetError(cbbCategory, "Hãy chọn danh mục cho sản phẩm");
                return;
            }

            if(txbName.Text.Trim() != "" && txbType.Text.Trim() != "" && cbbCategory.SelectedIndex != -1 && txbQuantity.Text.Trim() != "" && txbPrice.Text.Trim() != "")
            {
                try
                {
                    if (MessageBox.Show("Are you sure you want to Register This Product?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("insert dbo.Product(Pname, Ptype, Pcategory, Pquantity, Pprice) values(@Pname, @Ptype, @Pcategory, @Pquantity, @Pprice)", cn);
                        cm.Parameters.Add("@Pname", SqlDbType.NVarChar).Value = txbName.Text;
                        cm.Parameters.Add("@Ptype", SqlDbType.NVarChar).Value = txbType.Text;
                        cm.Parameters.Add("@Pcategory", SqlDbType.NVarChar).Value = cbbCategory.Text;
                        cm.Parameters.Add("@Pquantity", SqlDbType.Int).Value = txbQuantity.Text;
                        cm.Parameters.Add("@Pprice", SqlDbType.Int).Value = txbPrice.Text;

                        cn.Open();
                        cm.ExecuteNonQuery();
                        cn.Close();
                        MessageBox.Show("Product has been Successfully Registered!", title);
                        resetInputData();
                        productForm.loadProductList();
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
                if (MessageBox.Show("Are you sure you want to Update This Product?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cm = new SqlCommand("update dbo.Product set Pname = @Pname, Ptype = @Ptype, Pcategory = @Pcategory, Pquantity =  @Pquantity, Pprice = @Pprice where Pid = @Pid", cn);
                    cm.Parameters.Add("@Pname", SqlDbType.NVarChar).Value = txbName.Text;
                    cm.Parameters.Add("@Ptype", SqlDbType.NVarChar).Value = txbType.Text;
                    cm.Parameters.Add("@Pcategory", SqlDbType.VarChar).Value = cbbCategory.Text;
                    cm.Parameters.Add("@Pquantity", SqlDbType.NVarChar).Value = txbQuantity.Text;
                    cm.Parameters.Add("@Pprice", SqlDbType.NVarChar).Value = txbPrice.Text;
                    cm.Parameters.Add("@Pid", SqlDbType.Int).Value = lblPid.Text;

                    cn.Open();
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Product has been Successfully Updated!", title);
                    Dispose();
                    productForm.loadProductList();
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

        private void txbType_TextChanged(object sender, EventArgs e)
        {
            if (txbType.Text.Trim() != "")
                errProvider.SetError(txbType, null);
        }

        private void cbbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCategory.SelectedIndex > -1)
                errProvider.SetError(cbbCategory, null);
        }

        private void txbQuantity_TextChanged(object sender, EventArgs e)
        {
            if (txbQuantity.Text.Trim() != "")
                errProvider.SetError(txbQuantity, null);
        }

        private void txbPrice_TextChanged(object sender, EventArgs e)
        {
            if (txbPrice.Text.Trim() != "")
                errProvider.SetError(txbPrice, null);
        }

        #region Method
        public void resetInputData()
        {
            foreach (Control ctrl in Controls)
                if (ctrl is TextBox)
                    ctrl.Text = "";
            txbName.Focus();
            cbbCategory.SelectedIndex = -1;
        }

        void checkEmptyInput()
        {
            if (txbName.Text.Trim() == "")
            {
                errProvider.SetError(txbName, "Hãy nhập tên của sản phẩm");
                txbName.Focus();
            }
            else
                txbType.Focus();

            if (txbType.Text.Trim() == "")
                errProvider.SetError(txbType, "Hãy chọn loại sản phẩm");
            else
                txbQuantity.Focus();

            if (txbQuantity.Text.Trim() == "")
                errProvider.SetError(txbQuantity, "Hãy nhập số lượng sản phẩm");
            else
                txbPrice.Focus();

            if (txbPrice.Text.Trim() == "")
                errProvider.SetError(txbPrice, "Hãy nhập giá cho sản phẩm");
            else
                txbName.Focus();
        }
        #endregion
    }
}
