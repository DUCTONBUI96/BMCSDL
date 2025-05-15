using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace CuoiKi
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        // CSDL
        public SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=PassportManagement;Integrated Security=True");
        public SqlCommand cmd;
        public SqlDataReader rd;
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đóng không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {

            cmd = new SqlCommand("SELECT * FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash", con);
            cmd.Parameters.AddWithValue("@Username",txtUsername.Text);
            cmd.Parameters.AddWithValue("@PasswordHash", txtPassword.Text);

            con.Open();
            rd = cmd.ExecuteReader();

            if (rd.Read() == true)
            {
                //new ApplicationForm().Show();
                //new Menu().Show();
                new VerificationForm().Show();
                //new ApprovalForm().Show();
                //new SearchStatusForm().Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Tài khoản hoặc Mật khẩu không đúng, Vui lòng thử lại", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus();    
            }
        }

        private void ckbShowpassWord_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShowpassWord.Checked)
            {
                txtPassword.PasswordChar = '*';
                txtPassword.PasswordChar = '\0';
               
            }
            else
            {
                txtPassword.PasswordChar = '*';
                
            }
        }

        private void btn_Dangki_Click(object sender, EventArgs e)
        {
            new Form1().Show();
            this.Hide   ( );    
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnSendOTP_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Mã OTP đã được gửi đến email của bạn. Vui lòng kiểm tra hộp thư đến của bạn.", "Gửi mã OTP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
