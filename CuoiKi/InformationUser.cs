using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Business_Layer;
namespace CuoiKi
{
    public partial class InformationUser : Form
    {
        public InformationUser()
        {
            InitializeComponent();
            //txtPassword.UseSystemPasswordChar = true;
            //txtConfirmPass.UseSystemPasswordChar = true;
        }
        UserService userService = new UserService();
        private void ckbviewPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbviewPass.Checked)
            {
                txtPassword.PasswordChar = '\0';

            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
         //   txtPassword.UseSystemPasswordChar = !ckbviewPass.Checked;
        }

        private void ckbViewPass2_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbViewPass2.Checked)
            {
                txtConfirmPass.PasswordChar = '\0'; 

            }
            else
            {
               txtConfirmPass.PasswordChar= '*';    
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            txtName.Text = txtName.Text.Trim();
            cbbVaitro.Text = cbbVaitro.Text.Trim();
            string role;
            switch(cbbVaitro.Text)
            {
                case "Xác thực (XT)":
                    role = "Xác thực";
                    break;
                case "Lưu trữ (LT)":
                    role = "Lưu trữ";
                    break;
                case "Xét duyệt (XD)":
                    role = "Xét duyệt";
                    break;
                case "Giám sát (GS)":
                    role = "Giám sát";
                    break;
                default:
                    MessageBox.Show("Vui lòng chọn vai trò hợp lệ!");
                    return;
            }
            if (txtPassword.Text != txtConfirmPass.Text)
            {
                MessageBox.Show("Mật khẩu không khớp, vui lòng nhập lại!");
                return;
            }
            else
            {

                userService.CreateUser(txtName.Text, txtPassword.Text,txtEmail.Text, role);
            }
        }
    }
}
