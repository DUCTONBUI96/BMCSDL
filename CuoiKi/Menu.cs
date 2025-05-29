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
using Data_Layer.NewFolder1;
namespace CuoiKi
{
    public partial class Menu : Form
    {
        // Định nghĩa màu sắc chung cho ứng dụng - Đồng bộ với các form khác
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
        private Color selectedMenuColor = Color.FromArgb(230, 244, 255); // Màu menu được chọn

        public Menu()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        string NameUser = Session.Name; // Lấy tên người dùng từ Session

        private void CustomizeDesign()
        {
            // Tùy chỉnh form
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "🏛️ Hệ thống Quản lý Cấp Hộ chiếu";
            this.BackColor = Color.White;
            this.Size = new Size(1200, 700); // Kích thước vừa phải
            this.MinimumSize = new Size(1000, 600); // Kích thước tối thiểu

            // Tùy chỉnh menuStrip
            menuStrip1.BackColor = primaryColor;
            menuStrip1.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable());
            menuStrip1.Padding = new Padding(10, 5, 10, 5);

            // Tùy chỉnh các menu items chính
            foreach (ToolStripItem item in menuStrip1.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.ForeColor = textLightColor;
                    menuItem.Font = new Font("Segoe UI", 11, FontStyle.Regular);
                    menuItem.Padding = new Padding(15, 8, 15, 8);

                    // Thêm hover effects
                    menuItem.MouseEnter += (s, e) =>
                    {
                        menuItem.BackColor = primaryDarkColor;
                        menuItem.ForeColor = textLightColor;
                    };
                    menuItem.MouseLeave += (s, e) =>
                    {
                        if (!menuItem.Selected)
                        {
                            menuItem.BackColor = primaryColor;
                            menuItem.ForeColor = textLightColor;
                        }
                    };
                }
            }

            // Tùy chỉnh statusStrip
            statusUserName.BackColor = lightBgColor;
            statusUserName.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            toolStripStatusLabel1.ForeColor = textColor;
            toolStripStatusLabel1.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            toolStripStatusLabel2.ForeColor = successColor;
            toolStripStatusLabel2.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            // Tùy chỉnh mainPanel
            mainPanel.BackColor = Color.White;
            mainPanel.Dock = DockStyle.Fill;

            // Thêm welcome message vào mainPanel
            CreateWelcomeContent();
        }

        private void CreateWelcomeContent()
        {

            // Tạo nội dung chào mừng
            Panel welcomePanel = new Panel();
            welcomePanel.Dock = DockStyle.Fill;
            welcomePanel.BackColor = Color.White;
            welcomePanel.Padding = new Padding(30); // Giảm padding

            Label titleLabel = new Label();
            titleLabel.Text = "🏛️ HỆ THỐNG QUẢN LÝ CẤP HỘ CHIẾU";
            titleLabel.Font = new Font("Segoe UI", 20, FontStyle.Bold); // Giảm font size
            titleLabel.ForeColor = primaryColor;
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(50, 40); // Điều chỉnh vị trí

            Label subtitleLabel = new Label();
            subtitleLabel.Text = "Chào mừng bạn đến với hệ thống quản lý cấp hộ chiếu điện tử";
            subtitleLabel.Font = new Font("Segoe UI", 12, FontStyle.Regular); // Giảm font size
            subtitleLabel.ForeColor = textColor;
            subtitleLabel.AutoSize = true;
            subtitleLabel.Location = new Point(50, 80);

            Label instructionLabel = new Label();
            instructionLabel.Text = "📋 Vui lòng chọn chức năng từ menu phía trên để bắt đầu làm việc";
            instructionLabel.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            instructionLabel.ForeColor = successColor;
            instructionLabel.AutoSize = true;
            instructionLabel.Location = new Point(50, 110);

            // Thêm thông tin hệ thống
            Panel infoPanel = new Panel();
            infoPanel.BackColor = lightBgColor;
            infoPanel.Size = new Size(500, 160); // Giảm kích thước
            infoPanel.Location = new Point(50, 150);
            infoPanel.BorderStyle = BorderStyle.FixedSingle;

            Label infoTitle = new Label();
            infoTitle.Text = "📊 Thông tin hệ thống";
            infoTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            infoTitle.ForeColor = primaryColor;
            infoTitle.Location = new Point(15, 15);
            infoTitle.AutoSize = true;

            Label infoContent = new Label();
            infoContent.Text = "🔹 Phiên bản: 1.0.0\n" +
                              "🔹 Ngày phát hành: " + DateTime.Now.ToString("dd/MM/yyyy") + "\n" +
                              "🔹 Trạng thái: Hoạt động bình thường\n" +
                              "🔹 Người dùng hiện tại: " + NameUser;
            infoContent.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            infoContent.ForeColor = textColor;
            infoContent.Location = new Point(15, 45);
            infoContent.AutoSize = true;

            infoPanel.Controls.Add(infoTitle);
            infoPanel.Controls.Add(infoContent);

            welcomePanel.Controls.Add(titleLabel);
            welcomePanel.Controls.Add(subtitleLabel);
            welcomePanel.Controls.Add(instructionLabel);
            welcomePanel.Controls.Add(infoPanel);

            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(welcomePanel);
        }

        // Custom color table cho menu
        private class CustomColorTable : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return Color.FromArgb(0, 102, 204); }
            }

            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.FromArgb(0, 102, 204); }
            }

            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.FromArgb(0, 102, 204); }
            }

            public override Color MenuItemBorder
            {
                get { return Color.FromArgb(0, 153, 255); }
            }

            public override Color MenuBorder
            {
                get { return Color.FromArgb(0, 122, 204); }
            }

            public override Color MenuItemPressedGradientBegin
            {
                get { return Color.FromArgb(0, 86, 179); }
            }

            public override Color MenuItemPressedGradientEnd
            {
                get { return Color.FromArgb(0, 86, 179); }
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // FIX: Kiểm tra kiểu trước khi cast để tránh lỗi InvalidCastException
            if (!(e.ClickedItem is ToolStripMenuItem clickedMenuItem))
                return; // Bỏ qua nếu không phải ToolStripMenuItem (ví dụ: ToolStripSeparator)

            // Reset style cho tất cả menu items
            foreach (ToolStripItem item in menuStrip1.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    menuItem.BackColor = primaryColor;
                    menuItem.ForeColor = textLightColor;
                    menuItem.Font = new Font(menuItem.Font, FontStyle.Regular);
                }
            }

            // Set style cho item được chọn
            clickedMenuItem.BackColor = primaryDarkColor;
            clickedMenuItem.ForeColor = textLightColor;
            clickedMenuItem.Font = new Font(clickedMenuItem.Font, FontStyle.Bold);

            // Xử lý navigation dựa trên tên menu
            HandleMenuNavigation(clickedMenuItem.Name);
        }

        private void HandleMenuNavigation(string menuName)
        {
            try
            {
                switch (menuName)
                {
                    case "trangChủToolStripMenuItem":
                        CreateWelcomeContent();
                        break;

                    case "xácThựcToolStripMenuItem":
                        new VerificationForm().Show();
                        this.Hide();
                        break;

                    case "danhSáchToolStripMenuItem":
                        // Mở form danh sách người dân (nếu có)
                        new ResidentListForm().Show();
                        break;

                    case "thôngBáoToolStripMenuItem":
                        // Mở form thông báo (nếu có)
                        MessageBox.Show("🚧 Chức năng đang được phát triển", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;

                    case "nhậtKýToolStripMenuItem":
                        if(Session.RoleId != 5) // Chỉ cho phép Admin xem nhật ký
                        {
                            // Mở form nhật ký (nếu có)
                            MessageBox.Show("🚧 Chức năng đang được phát triển", "Thông báo",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi điều hướng: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "🚪 Bạn có chắc chắn muốn thoát khỏi hệ thống không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "🔓 Bạn có chắc chắn muốn đăng xuất không?",
                "Xác nhận đăng xuất",
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
            try
            {
                new ChangePasswordForm(Session.RoleId).Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi mở form đổi mật khẩu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handlers cho các menu con
        private void xétDuyệtXDToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                new ApprovalForm().Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi mở form xét duyệt: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lưuTrữLTToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                new PassportIssueForm().Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi mở form cấp hộ chiếu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void giámSátGSToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AuditTrailForm().Show();
            this.Hide();

        }

        private void quảnTrịADMINToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AdminForm().Show();
            this.Hide();
        }

        private void hướngDẫnSửDụngPhầnMềmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("📖 Hướng dẫn sử dụng:\n\n" +
                          "1. 🔍 Xác thực: Kiểm tra và xác thực hồ sơ\n" +
                          "2. ✅ Xét duyệt: Duyệt các hồ sơ hợp lệ\n" +
                          "3. 🛂 Cấp hộ chiếu: Cấp hộ chiếu cho hồ sơ đã duyệt\n" +
                          "4. 📊 Giám sát: Theo dõi hoạt động hệ thống\n" +
                          "5. ⚙️ Quản trị: Quản lý người dùng và hệ thống",
                "Hướng dẫn sử dụng", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void thôngTinPhầnMềmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("🏛️ Hệ thống Quản lý Cấp Hộ chiếu\n\n" +
                          "📋 Phiên bản: 1.0.0\n" +
                          "📅 Ngày phát hành: " + DateTime.Now.ToString("dd/MM/yyyy") + "\n" +
                          "👨‍💻 Phát triển bởi: Nhóm phát triển\n" +
                          "📧 Hỗ trợ: support@passport.gov.vn\n\n" +
                          "© 2025 - Bản quyền thuộc về Bộ Công an",
                "Thông tin phần mềm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            // Hiển thị thông tin người dùng
            toolStripStatusLabel1.Text = "👤 Người dùng: " + NameUser;

            // Tạo timer để cập nhật thời gian
            Timer timeTimer = new Timer();
            timeTimer.Interval = 1000; // 1 giây
            timeTimer.Tick += (s, args) =>
            {
                toolStripStatusLabel2.Text = "🕐 " + DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");
            };
            timeTimer.Start();

            // Hiển thị thời gian ban đầu
            toolStripStatusLabel2.Text = "🕐 " + DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");

            // Ẩn tất cả các chức năng trước
            xétDuyệtXDToolStripMenuItem1.Visible = false;
            giámSátGSToolStripMenuItem1.Visible = false;
            lưuTrữLTToolStripMenuItem1.Visible = false;
            xácThựcToolStripMenuItem.Visible = false;
            quảnTrịADMINToolStripMenuItem1.Visible = false;
            danhSáchToolStripMenuItem.Visible = false;

            switch (Session.RoleId)
            {
                case 1: // Xét duyệt
                    quảnTrịADMINToolStripMenuItem1.Visible = true;
                    break;
                case 2: // Giám sát
                    danhSáchToolStripMenuItem.Visible = true;
                    xácThựcToolStripMenuItem.Visible = true;
                    break;
                case 3: // Lưu trữ
                    xétDuyệtXDToolStripMenuItem1.Visible = true;
                    break;
                case 4: // Xác thực
                    lưuTrữLTToolStripMenuItem1.Visible = true;
                    break;
                case 5: //Admin
                    giámSátGSToolStripMenuItem1.Visible = true;
                    break;
                default:
                    MessageBox.Show("🚫 Bạn không có quyền truy cập vào chức năng này", "Lỗi quyền truy cập",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show(
                    "🚪 Bạn có chắc chắn muốn thoát khỏi hệ thống không?",
                    "Xác nhận thoát",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    Application.Exit();
                }
            }
            base.OnFormClosing(e);
        }

        private void thôngBáoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Session.RoleId == 4)
            {
                new NotificationForm().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("🚫 Bạn không có quyền truy cập vào chức năng này", "Lỗi quyền truy cập",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nhậtKýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Session.RoleId == 5)
            {
                new LogForm().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("🚫 Bạn không có quyền truy cập vào chức năng này", "Lỗi quyền truy cập",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}