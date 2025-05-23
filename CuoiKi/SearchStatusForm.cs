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
using Business_Layer;

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

            ApplicationService applicationService = new ApplicationService();
            string status = applicationService.TakeStatus(txtCCCD.Text.Trim());
            if (status==null)
            {
                MessageBox.Show("Không tìm thấy thông tin hồ sơ của bạn" , "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                lblResult.Text = "Trạng thái hồ sơ của bạn là: " + status;
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
