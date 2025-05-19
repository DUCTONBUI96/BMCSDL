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
    public partial class SearchStatusForm : Form
    {
        public SearchStatusForm()
        {
            InitializeComponent();
            this.txtCCCD.Size=new Size(661, 50);

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

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
    }
}
