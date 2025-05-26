using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Layer;

namespace CuoiKi
{
    public partial class ChangePasswordForm : Form
    {
        private int _UserID;
        public ChangePasswordForm(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }

       

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
         //   txtOldPassword.UseSystemPasswordChar = true;
            txtOldPassword.PasswordChar = '*';
            txtNewPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            UserService userService = new UserService();

            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp. Vui lòng kiểm tra lại.");
                return;
            }
            else 
            {
             userService.ResetPassword(_UserID, txtNewPassword.Text); 
             MessageBox.Show("Đổi mật khẩu thành công!");
            }
        }
    }
}
