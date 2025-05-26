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
    public partial class AdminForm : Form
    {
        // Định nghĩa màu sắc chung cho ứng dụng
        private Color primaryColor = Color.FromArgb(0, 123, 255);
        private Color secondaryColor = Color.FromArgb(108, 117, 125);
        private Color accentColor = Color.FromArgb(40, 167, 69);
        private Color lightBgColor = Color.FromArgb(248, 249, 250);

        public AdminForm()
        {
            
            InitializeComponent();
            //CustomizeDesign();

        }

        //private void CustomizeDesign()
        //{
        //    // Tùy chỉnh giao diện TabControl
        //    tabControl.Size = new Size(884, 426);
        //    tabControl.Dock = DockStyle.Fill;
        //    tabControl.Appearance = TabAppearance.FlatButtons;
        //    tabControl.ItemSize = new Size(0, 30);
        //    tabControl.SizeMode = TabSizeMode.Fixed;
        //    tabControl.Font = new Font("Segoe UI", 10, FontStyle.Regular);

        //    // Tùy chỉnh màu sắc cho các tab
        //    foreach (TabPage tab in tabControl.TabPages)
        //    {
        //        tab.BackColor = lightBgColor;
        //    }

        //    // Tùy chỉnh form
        //    this.FormBorderStyle = FormBorderStyle.FixedSingle;
        //    this.MaximizeBox = true;
        //    this.StartPosition = FormStartPosition.CenterScreen;
        //    this.Text = "Quản trị hệ thống - Cấp hộ chiếu online";
        //    this.Icon = SystemIcons.Application;
        //}
        UC_quanli uc1 = new UC_quanli();
        private void AdminForm_Load(object sender, EventArgs e)
        {
            uc1.Dock = DockStyle.Fill;
            dgvUser.DataSource = uc1.load();

            //UC_Phanquyen uc2 = new UC_Phanquyen();
            //uc2.Dock = DockStyle.Fill;
            //tabPagePhanquyen.Controls.Add(uc2);
            txtTimKiem.Focus();
            txtSearch.Focus();
            txtConfigKey.Text = "Nhập khóa cấu hình";
            txtConfigKey.ForeColor = Color.Gray;
            txtConfigValue.Focus();


        }
       
        private void txtTimKiem_Enter(object sender, EventArgs e)
        {
            if (txtTimKiem.Text == "Tìm kiếm người dùng")
            {
                txtTimKiem.Text = "";
                txtTimKiem.ForeColor = Color.Black;
            }
        }

        private void txtTimKiem_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                txtTimKiem.Text = "Tìm kiếm người dùng";
                txtTimKiem.ForeColor = Color.Gray;
            }
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Tìm kiếm người dùng")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Tìm kiếm người dùng";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void txtConfigKey_Enter(object sender, EventArgs e)
        {
            if (txtConfigKey.Text == "Nhập khóa cấu hình")
            {
                txtConfigKey.Text = "";
                txtConfigKey.ForeColor = Color.Black;
            }
        }

        private void txtConfigKey_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfigKey.Text))
            {
                txtConfigKey.Text = "Nhập khóa cấu hình";
                txtConfigKey.ForeColor = Color.Gray;
            }
        }

        private void txtConfigValue_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtConfigValue.Text))
            {
                txtConfigValue.Text = "Nhập giá trị cấu hình";
                txtConfigValue.ForeColor = Color.Gray;
            }
        }

        private void txtConfigValue_Enter(object sender, EventArgs e)
        {
            if (txtConfigValue.Text == "Nhập giá trị cấu hình")
            {
                txtConfigValue.Text = "";
                txtConfigValue.ForeColor = Color.Black;
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            
        }
    }
}