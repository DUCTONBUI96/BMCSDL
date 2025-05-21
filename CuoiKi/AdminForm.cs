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
            CustomizeDesign();
        }

        private void CustomizeDesign()
        {
            // Tùy chỉnh giao diện TabControl
            tabControl.Size = new Size(884, 426);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 30);
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            // Tùy chỉnh màu sắc cho các tab
            foreach (TabPage tab in tabControl.TabPages)
            {
                tab.BackColor = lightBgColor;
            }

            // Tùy chỉnh form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản trị hệ thống - Cấp hộ chiếu online";
            this.Icon = SystemIcons.Application;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            UC_quanli uc1 = new UC_quanli();
            uc1.Dock = DockStyle.Fill;
            tabPageQuanLi.Controls.Add(uc1);

            UC_Phanquyen uc2 = new UC_Phanquyen();
            uc2.Dock = DockStyle.Fill;
            tabPagePhanquyen.Controls.Add(uc2);
        }
    }
}