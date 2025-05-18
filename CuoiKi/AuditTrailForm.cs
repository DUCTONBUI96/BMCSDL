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
    public partial class AuditTrailForm : Form
    {
        public AuditTrailForm()
        {
            InitializeComponent();
        }

        private void AuditTrailForm_Load(object sender, EventArgs e)
        {
            txtUserFilter.Text = "Tên người dùng";
            txtUserFilter.ForeColor = Color.Gray;


            cboTableName.Items.Clear();
            cboTableName.Items.Add("All Tables");
            cboTableName.Items.Add("Applications");
            cboTableName.Items.Add("Residents");
            cboTableName.Items.Add("Passports");
            cboTableName.Items.Add("Notifications");
            cboTableName.Items.Add("Users");

            // (Tùy chọn) Chọn mặc định mục đầu tiên:
            cboTableName.SelectedIndex = 0;
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
    }
}
