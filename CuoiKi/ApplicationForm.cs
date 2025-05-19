using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            // Kiểm tra các trường thông tin
            if (!validEmail())
            {
                MessageBox.Show("Invalid email format.");
            }
            if (!validPhone())
            {
                MessageBox.Show("Invalid phone number format.");
            }
            if (!validCCCD())
            {
                MessageBox.Show("Invalid CCCD format.");
            }

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

        //Hàm kiểm tra định dạng email
        protected bool validEmail()
        {
            bool chk = false;
            Regex r = new Regex(@"^[\w -\.] +@([\w -] +\.) + [\w -]{ 2,4}$");
            if (r.IsMatch(txtEmail.Text))
            {
                chk = true;
            }
            return chk;
        }

        //Hàm kiểm tra định dạng số điện thoại
        protected bool validPhone()
        {
            bool chk = false;
            Regex r = new Regex(@"\d{8}$");
            if (r.IsMatch(txtPhone.Text)&& txtPhone.Text.Length==10)
            {
                chk = true;
            }
            return chk;
        }

        //Hàm kiểm tra định dạng CCCD
        protected bool validCCCD()
        {
            bool chk = false;
            Regex r = new Regex(@"^\d{9}$");
            if (r.IsMatch(txtCCCDid.Text) && txtCCCDid.Text.Length == 12)
            {
                chk = true;
            }
        
            return chk;
        }

        
    }
}
