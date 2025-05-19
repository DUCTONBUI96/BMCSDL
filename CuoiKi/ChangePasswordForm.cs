using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuoiKi
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

       

        private void ChangePasswordForm_Load(object sender, EventArgs e)
        {
         //   txtOldPassword.UseSystemPasswordChar = true;
            txtOldPassword.PasswordChar = '*';

            txtNewPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
        }

       
    }
}
