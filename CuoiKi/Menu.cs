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
    public partial class Menu : Form
    {
        // Định nghĩa màu sắc chung cho ứng dụng
        private Color primaryColor = Color.FromArgb(0, 123, 255);
        private Color secondaryColor = Color.FromArgb(108, 117, 125);
        private Color accentColor = Color.FromArgb(40, 167, 69);
        private Color lightBgColor = Color.FromArgb(248, 249, 250);
        private Color textColor = Color.FromArgb(73, 80, 87);
        private Color selectedMenuColor = Color.FromArgb(230, 244, 255);

        public Menu()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        private void CustomizeDesign()
        {
            // Tùy chỉnh form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Cấp Hộ chiếu";
            this.Icon = SystemIcons.Application;

            // Tùy chỉnh menuStrip
            menuStrip1.BackColor = lightBgColor;
            menuStrip1.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable());

            // Tùy chỉnh các menu items
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                if (item is ToolStripMenuItem)
                {
                    item.ForeColor = textColor;
                    item.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                }
            }

            // Tùy chỉnh statusStrip
            statusUserName.BackColor = lightBgColor;
            statusUserName.ForeColor = textColor;

            // Tùy chỉnh mainPanel
            mainPanel.BackColor = Color.White;
            mainPanel.Dock = DockStyle.Fill;
        }

        // Custom color table cho menu
        private class CustomColorTable : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return Color.FromArgb(230, 244, 255); }
            }

            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.FromArgb(230, 244, 255); }
            }

            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.FromArgb(230, 244, 255); }
            }

            public override Color MenuItemBorder
            {
                get { return Color.FromArgb(0, 123, 255); }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hệ thống Quản lý Cấp Hộ chiếu\nPhiên bản 1.0", "Thông tin",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Bước 1: Reset style cho tất cả menu items (chỉ áp dụng cho ToolStripMenuItem)
            foreach (ToolStripItem item in menuStrip1.Items)
            {
                if (item is ToolStripMenuItem)
                {
                    item.BackColor = lightBgColor;
                    item.ForeColor = textColor;
                    item.Font = new Font(item.Font, FontStyle.Regular);
                }
            }

            // Bước 2: Set style cho item được chọn (chỉ nếu nó là ToolStripMenuItem)
            if (e.ClickedItem is ToolStripMenuItem clickedItem)
            {
                clickedItem.BackColor = selectedMenuColor;
                clickedItem.ForeColor = primaryColor;
                clickedItem.Font = new Font(clickedItem.Font, FontStyle.Bold);
            }

            // Optional: gọi hàm load giao diện tương ứng ở đây
        }


        private void HighlightMenu(ToolStripMenuItem selectedItem)
        {
            // Reset màu của tất cả menu
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.BackColor = lightBgColor; // màu mặc định
            }

            // Đổi màu của item đang chọn
            selectedItem.BackColor = selectedMenuColor; // màu khi được chọn
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                new Login().Show();
                this.Hide();
            }
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ChangePasswordForm().Show();
            this.Hide();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin người dùng
            toolStripStatusLabel1.Text = "Người dùng: " + Environment.UserName;
            toolStripStatusLabel2.Text = DateTime.Now.ToString("HH:mm:ss");
        }

    }
}