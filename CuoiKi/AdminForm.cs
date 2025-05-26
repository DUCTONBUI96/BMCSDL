using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
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
        // Định nghĩa màu sắc chung cho ứng dụng - Đồng bộ với ApprovalForm
        private Color primaryColor = Color.FromArgb(0, 122, 204);      // Màu xanh dương chính
        private Color primaryDarkColor = Color.FromArgb(0, 102, 204);  // Màu xanh dương đậm
        private Color primaryLightColor = Color.FromArgb(229, 241, 255); // Màu xanh dương nhạt
        private Color accentColor = Color.FromArgb(0, 153, 255);       // Màu nhấn
        private Color textColor = Color.FromArgb(51, 51, 51);          // Màu chữ
        private Color textLightColor = Color.White;                    // Màu chữ sáng
        private Color lightBgColor = Color.FromArgb(248, 249, 250);    // Màu nền nhạt
        private Color successColor = Color.FromArgb(40, 167, 69);      // Màu xanh lá (thành công)
        private Color dangerColor = Color.FromArgb(220, 53, 69);       // Màu đỏ (nguy hiểm)
        private Color warningColor = Color.FromArgb(255, 193, 7);      // Màu vàng (cảnh báo)

        public AdminForm()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        private void CustomizeDesign()
        {
            // Tùy chỉnh form
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new Size(1300, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Quản trị hệ thống - Cấp hộ chiếu online";
            this.Icon = SystemIcons.Application;
            this.BackColor = Color.White;

            // Tùy chỉnh TabControl
            tabControl.Size = new Size(1250, 650);
            tabControl.Dock = DockStyle.None;
            tabControl.Location = new Point(25, 100);
            tabControl.Appearance = TabAppearance.Normal;
            tabControl.ItemSize = new Size(200, 40);
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            // Tùy chỉnh màu sắc cho các tab
            foreach (TabPage tab in tabControl.TabPages)
            {
                tab.BackColor = Color.White;
                tab.BorderStyle = BorderStyle.None;
            }

            // Tùy chỉnh header labels
            lblTitle.ForeColor = primaryColor;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.Location = new Point(30, 20);

            lblDateTime.ForeColor = Color.FromArgb(108, 117, 125);
            lblDateTime.Font = new Font("Segoe UI", 14F, FontStyle.Regular);
            lblDateTime.Location = new Point(900, 40);

            // Cập nhật thời gian hiện tại
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) => lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            timer.Start();
            lblDateTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            // Tùy chỉnh các tab pages
            CustomizeTabPageQuanLi();
            CustomizeTabPagePhanquyen();
            CustomizeTabCauhinh();
            CustomizeTabBackup();
        }

        private void CustomizeTabPageQuanLi()
        {
            tabPageQuanLi.BackColor = Color.White;

            // Tùy chỉnh DataGridView
            CustomizeDataGridView(dgvUser);

            // Tùy chỉnh search box - SỬA LẠI
            CustomizeSearchBox(txtTimKiem, pictureBox1, tabPageQuanLi);

            // Tùy chỉnh buttons
            CustomizeButton(btnCreate, primaryColor, "➕ Tạo mới");
            CustomizeButton(btnLock, dangerColor, "🔒 Khóa");
            CustomizeButton(btnUnlock, successColor, "🔓 Mở khóa");
            CustomizeButton(btnResetPass, warningColor, "Reset mật khẩu");

            // Điều chỉnh vị trí
            btnCreate.Location = new Point(280, 20);
            btnLock.Location = new Point(430, 20);
            btnUnlock.Location = new Point(550, 20);
            btnResetPass.Location = new Point(680, 20);

            dgvUser.Location = new Point(15, 80);
            dgvUser.Size = new Size(1200, 400);
        }

        private void CustomizeTabPagePhanquyen()
        {
            tabPagePhanquyen.BackColor = Color.White;

            // Tùy chỉnh DataGridView
            CustomizeDataGridView(dgvRole);

            // Tùy chỉnh search box - SỬA LẠI
            CustomizeSearchBox(txtSearch, pictureBox2, tabPagePhanquyen);

            // Tùy chỉnh button
            CustomizeButton(btnResetPassword, primaryColor, "👥 Phân quyền");

            // Điều chỉnh vị trí
            btnResetPassword.Location = new Point(280, 13);
            dgvRole.Location = new Point(16, 80);
            dgvRole.Size = new Size(1200, 400);
        }

        private void CustomizeTabCauhinh()
        {
            tabCauhinh.BackColor = Color.White;

            // Tùy chỉnh labels
            label1.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label1.ForeColor = textColor;
            label2.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label2.ForeColor = textColor;

            // Tùy chỉnh textboxes
            CustomizeTextBox(txtConfigKey);
            CustomizeTextBox(txtConfigValue);

            // Thêm buttons cho tab cấu hình
            Button btnSaveConfig = new Button
            {
                Text = "💾 Lưu cấu hình",
                BackColor = successColor,
                ForeColor = textLightColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Size = new Size(150, 40),
                Location = new Point(27, 120),
                Cursor = Cursors.Hand
            };
            btnSaveConfig.FlatAppearance.BorderSize = 0;

            Button btnLoadConfig = new Button
            {
                Text = "📂 Tải cấu hình",
                BackColor = primaryColor,
                ForeColor = textLightColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Size = new Size(150, 40),
                Location = new Point(200, 120),
                Cursor = Cursors.Hand
            };
            btnLoadConfig.FlatAppearance.BorderSize = 0;

            tabCauhinh.Controls.Add(btnSaveConfig);
            tabCauhinh.Controls.Add(btnLoadConfig);

            // Thêm hover effects
            AddButtonHoverEffect(btnSaveConfig, successColor);
            AddButtonHoverEffect(btnLoadConfig, primaryColor);
        }

        private void CustomizeTabBackup()
        {
            tabBackup.BackColor = Color.White;

            // Tùy chỉnh label
            label3.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            label3.ForeColor = textColor;

            // Tùy chỉnh textbox
            CustomizeTextBox(txtBackupPath);

            // Tùy chỉnh buttons
            CustomizeButton(btnBackup, primaryColor, "💾 Sao lưu cơ sở dữ liệu");
            CustomizeButton(btnRestore, warningColor, "🔄 Phục hồi cơ sở dữ liệu");

            btnBackup.Size = new Size(250, 45);
            btnRestore.Size = new Size(250, 45);
            btnBackup.Location = new Point(20, 80);
            btnRestore.Location = new Point(290, 80);
        }

        private void CustomizeDataGridView(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.White;
            dgv.GridColor = Color.FromArgb(230, 230, 230);
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.EnableHeadersVisualStyles = false;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = primaryLightColor;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Header style
            dgv.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = textLightColor;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 45;

            // Cell style
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgv.DefaultCellStyle.ForeColor = textColor;
            dgv.DefaultCellStyle.SelectionBackColor = primaryLightColor;
            dgv.DefaultCellStyle.SelectionForeColor = primaryColor;
            dgv.RowTemplate.Height = 35;
        }

        // SỬA LẠI PHƯƠNG THỨC NÀY
        private void CustomizeSearchBox(TextBox textBox, PictureBox pictureBox, TabPage parentTab)
        {
            // Tạo panel container cho search box
            Panel searchPanel = new Panel
            {
                Size = new Size(250, 35),
                Location = new Point(15, 20),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            // Lưu vị trí ban đầu của textBox và pictureBox
            Point originalTextBoxLocation = textBox.Location;
            Point originalPictureBoxLocation = pictureBox.Location;

            // Xóa textBox và pictureBox khỏi parent hiện tại
            textBox.Parent?.Controls.Remove(textBox);
            pictureBox.Parent?.Controls.Remove(pictureBox);

            // Tùy chỉnh picture box
            pictureBox.Size = new Size(25, 25);
            pictureBox.Location = new Point(5, 5);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.BackColor = Color.Transparent;

            // Tùy chỉnh textbox
            textBox.BorderStyle = BorderStyle.None;
            textBox.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular);
            textBox.Location = new Point(35, 6);
            textBox.Size = new Size(210, 25);
            textBox.BackColor = Color.White;

            // Thêm vào panel
            searchPanel.Controls.Add(pictureBox);
            searchPanel.Controls.Add(textBox);

            // Thêm panel vào tab
            parentTab.Controls.Add(searchPanel);
        }

        private void CustomizeButton(Button btn, Color backgroundColor, string text)
        {
            btn.BackColor = backgroundColor;
            btn.ForeColor = textLightColor;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Text = text;
            btn.Cursor = Cursors.Hand;
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Size = new Size(140, 40);

            AddButtonHoverEffect(btn, backgroundColor);
        }

        private void CustomizeTextBox(TextBox textBox)
        {
            textBox.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = Color.White;
            textBox.ForeColor = textColor;
        }

        private void AddButtonHoverEffect(Button btn, Color originalColor)
        {
            Color hoverColor = Color.FromArgb(
                Math.Max(0, originalColor.R - 30),
                Math.Max(0, originalColor.G - 30),
                Math.Max(0, originalColor.B - 30)
            );

            btn.MouseEnter += (s, e) => btn.BackColor = hoverColor;
            btn.MouseLeave += (s, e) => btn.BackColor = originalColor;
        }
        UC_quanli uC = new UC_quanli();
        UserService userService = new UserService();
        private void AdminForm_Load(object sender, EventArgs e)
        {
            uC.Dock = DockStyle.Fill;
            uC.load();
            dgvRole.DataSource = userService.GetAllUser();
            dgvUser.DataSource = userService.GetAllUser();
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
            new InformationUser().ShowDialog();
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            int roleId = Convert.ToInt32(dgvUser.CurrentRow.Cells["RoleID"].Value);
            new ChangePasswordForm(roleId).ShowDialog();
        }
    }
}