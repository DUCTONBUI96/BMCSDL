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
namespace CuoiKi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
      
            
        }
        OleDbConnection con = new OleDbConnection("");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void txtConfirmPass_TextChanged(object sender, EventArgs e)
        {
            txtConfirmPass.PasswordChar = '*';
        }

        private void btnDangky_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPass.Text))
            {
                MessageBox.Show("Tài khoản và Mật khẩu không được để trống", "Đăng ký lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text == txtConfirmPass.Text)
            {
                try
                {
                    con.Open();
                    string register = "INSERT INTO tbl_users (Username, Password) VALUES (@user, @pass)";


                    OleDbCommand cmd = new OleDbCommand(register, con);
                    cmd.Parameters.AddWithValue("@user", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@pass", txtPassword.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();


                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtConfirmPass.Text = "";
                    MessageBox.Show("Tài khoản của bạn đã được tạo thành công", "Đăng ký thành công",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo tài khoản: " + ex.Message, "Lỗi hệ thống",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu không đúng, vui lòng nhập lại", "Đăng ký thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtConfirmPass.Text = "";
                txtPassword.Focus();
            }
        }

        private void ckbShowpassWord_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShowpassWord.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfirmPass.PasswordChar = '\0'; 
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtConfirmPass.PasswordChar= '*';   
            }
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }
    }
}
