using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuoiKi
{
    public partial class ApplicationForm : Form
    {
        public ApplicationForm()
        {
            InitializeComponent();
            // panel1
          

        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //chuyen lenh sang string rồi dùng using gọi lại
            string connectionString = "Data Source=.;Initial Catalog=PassportManagement;Integrated Security=True";
            string query = "INSERT INTO ResidentData (FullName, Gender, DateOfBirth, CMND, Address, Nationality, PhoneNumber, Email) " +
                           "VALUES (@FullName, @Gender, @DateOfBirth, @CMND, @Address, @Nationality, @PhoneNumber, @Email)";

            //test connect database
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@Gender", cboGender.Text);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dtpDOB.Value);
                    cmd.Parameters.AddWithValue("@CMND", txtCCCDid.Text);
                    cmd.Parameters.AddWithValue("@Address", rtbAddress.Text);
                    cmd.Parameters.AddWithValue("@Nationality", cboNationality.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                MessageBox.Show("Đăng ký thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng ký: " + ex.Message);
            }
        }
    }
}
