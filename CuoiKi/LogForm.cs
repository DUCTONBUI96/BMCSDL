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
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();

        }

        private void txtUserFilter_TextChanged(object sender, EventArgs e)
        {

        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            txtUserFilter.Text = "Tên người dùng";
            txtUserFilter.ForeColor = Color.Gray;


            cboHanhDong.Items.Clear();
            cboHanhDong.Items.Add("Tất cả");
            cboHanhDong.Items.Add("Login");
            cboHanhDong.Items.Add("Logout");
            cboHanhDong.Items.Add("View");
            cboHanhDong.Items.Add("Create");
            cboHanhDong.Items.Add("Update");
            cboHanhDong.Items.Add("Delete");

            // Chọn giá trị mặc định (ví dụ: Tất cả)
            cboHanhDong.SelectedIndex = 0;



            cbbModel.Items.Clear();

            cbbModel.Items.Add("Tất cả");
            cbbModel.Items.Add("Authentication");
            cbbModel.Items.Add("User Management");
            cbbModel.Items.Add("Resident Info");
            cbbModel.Items.Add("Passports");
            cbbModel.Items.Add("Audit Logs");
            cbbModel.Items.Add("Settings");

            // Chọn mặc định là "Tất cả"
            cbbModel.SelectedIndex = 0;
        }

        private void txtUserFilter_Enter(object sender, EventArgs e)
        {
            if (txtUserFilter.Text == "Tên người dùng")
            {
                txtUserFilter.Text = "";
                txtUserFilter.ForeColor = Color.Black;
            }
        }

        private void txtUserFilter_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserFilter.Text))
            {
                txtUserFilter.Text = "Tên người dùng";
                txtUserFilter.ForeColor = Color.Gray;
            }
        }

      

        private void cboTableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedAction = cboHanhDong.SelectedItem.ToString();
        }

        private void cbbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbbModel.SelectedItem.ToString();
        }
    }
}
