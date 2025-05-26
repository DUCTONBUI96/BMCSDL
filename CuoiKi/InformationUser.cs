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
    public partial class InformationUser : Form
    {
        public InformationUser()
        {
            InitializeComponent();
            //txtPassword.UseSystemPasswordChar = true;
            //txtConfirmPass.UseSystemPasswordChar = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

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
    }
}
