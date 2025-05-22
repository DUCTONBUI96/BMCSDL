using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuoiKi
{
    public partial class SearchStatusForm : Form
    {
        public SearchStatusForm()
        {
            InitializeComponent();
            this.txtCCCD.Size=new Size(661, 50);

        }
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=PassportManagement;Integrated Security=True");
        DataTable dt = new DataTable();
        string status = "";
        private void button1_Click(object sender, EventArgs e)
        {
            
            connectToDatabase();
            lblResult.Text = "Trạng thái hồ sơ của bạn là: " + status;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void connectToDatabase()
        {
            
            // Kết nối đến cơ sở dữ liệu SQL Server
            string query = "SELECT Status FROM PassportApplications Where ResidentID IN (SELECT ResidentID FROM ResidentData WHERE CMND = @CMND )";
            // Tạo kết nối và thực thi truy vấn
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    cmd.Parameters.AddWithValue("@CMND", txtCCCD.Text);
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        status = result.ToString();

                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy hồ sơ với ID cư trú này.");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu: " + ex.Message);
            }
        }
        private void SearchStatusForm_Load(object sender, EventArgs e)
        {
            txtCCCD.Text = "Tên người dùng";
            txtCCCD.ForeColor = Color.Gray;
            
        }

        private void txtCCCD_Enter(object sender, EventArgs e)
        {

            if (txtCCCD.Text == "Tên người dùng")
            {
                txtCCCD.Text = "";
                txtCCCD.ForeColor = Color.Black;
            }
        }

        private void txtCCCD_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                txtCCCD.Text = "Tên người dùng";
                txtCCCD.ForeColor = Color.Gray;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new WelcomeScreen().Show();
            this.Hide();
        }

    }
}
