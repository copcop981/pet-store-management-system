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
    public partial class UserForm : Form
    {
        //SqlConnection cn = new SqlConnection();
        //SqlCommand cm = new SqlCommand();
        //SqlDataReader rd;
        //DbConnect dbcon = new DbConnect();

        UserBLL userBLL = new UserBLL();
        string title = "Pet Store Management System";

        public UserForm()
        {
            InitializeComponent();

            //cn = new SqlConnection(dbcon.connection());
            loadUserList();
        }

        private void txbSearch_TextChanged(object sender, EventArgs e)
        {
            loadUserList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserModule moduleForm = new UserModule(this);
            moduleForm.btnUpdate.Enabled = false;
            moduleForm.btnUpdate.BackColor = Color.Gray;
            moduleForm.ShowDialog();
        }

        private void gridUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string colName = gridUser.Columns[e.ColumnIndex].Name;
                if (colName == "Edit")
                {
                    UserModule moduleForm = new UserModule(this);
                    moduleForm.lblUid.Text = gridUser.Rows[e.RowIndex].Cells[1].Value.ToString();
                    moduleForm.txbName.Text = gridUser.Rows[e.RowIndex].Cells[2].Value.ToString();
                    moduleForm.txbAddress.Text = gridUser.Rows[e.RowIndex].Cells[3].Value.ToString();
                    moduleForm.txbPhone.Text = gridUser.Rows[e.RowIndex].Cells[4].Value.ToString();
                    moduleForm.cbbRole.Text = gridUser.Rows[e.RowIndex].Cells[5].Value.ToString();
                    moduleForm.dtpkBirth.Text = gridUser.Rows[e.RowIndex].Cells[6].Value.ToString();
                    moduleForm.txbPassword.Text = gridUser.Rows[e.RowIndex].Cells[7].Value.ToString();

                    moduleForm.btnCancel.Enabled = false;
                    moduleForm.btnCancel.BackColor = Color.Gray;

                    moduleForm.btnSave.Enabled = false;
                    moduleForm.btnSave.BackColor = Color.Gray;

                    moduleForm.ShowDialog();
                }
                else if (colName == "Delete")
                {
                    if(MessageBox.Show("Are you sure you want to Delete This User?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        //cn.Open();
                        //cm = new SqlCommand($"delete from dbo.Userr where id = {gridUser.Rows[e.RowIndex].Cells[1].Value}", cn);
                        //cm.ExecuteNonQuery();
                        //cn.Close();
                        int result = userBLL.deleteUser((int)gridUser.Rows[e.RowIndex].Cells[1].Value);
                        if(result > 0)
                            MessageBox.Show("User has been Successfully Deleted!", title);
                    }
                }
                loadUserList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        #region Method
        public void loadUserList()
        {
            try
            {
                //cm = new SqlCommand($"select * from dbo.Userr where concat(name, address, phone, role, birth) like '%{txbSearch.Text}%'", cn);
                //cn.Open();
                //rd = cm.ExecuteReader();
                //while (rd.Read())
                //{
                //    i++;
                //    int id = (int)rd[0];
                //    string name = rd[1].ToString();
                //    string address = rd[2].ToString();
                //    string phone = rd[3].ToString();
                //    string role = rd[4].ToString();
                //    DateTime birth = (DateTime)rd[5];
                //    string password = rd[6].ToString();

                //    gridUser.Rows.Add(i, id, name, address, phone, role, birth, password);
                //}
                //rd.Close();
                //cn.Close();

                List<UserDTO> userList = userBLL.getAllUser(txbSearch.Text);

                int i = 0;
                gridUser.Rows.Clear();

                foreach (UserDTO user in userList)
                {
                    i++;
                    int id = user.Id;
                    string name = user.Name;
                    string address = user.Address;
                    string phone = user.Phone;
                    string role = user.Role;
                    DateTime birth = user.Birth;
                    string password = user.Password;

                    gridUser.Rows.Add(i, id, name, address, phone, role, birth, password);
                }

                if (gridUser.Rows.Count == 0)
                    picBoxNoItemsFound.Visible = true;
                else
                    picBoxNoItemsFound.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }
        #endregion
    }
}
