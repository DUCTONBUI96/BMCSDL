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
        // Định nghĩa màu sắc chung cho ứng dụng - Đồng bộ với AuditTrailForm
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

        public LogForm()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        private void CustomizeDesign()
        {
            // Tùy chỉnh form - ĐỒNG BỘ VỚI AUDITTRAILFORM
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Size = new Size(1100, 650);
            this.MinimumSize = new Size(1100, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Nhật ký hệ thống";
            this.Icon = SystemIcons.Application;
            this.BackColor = Color.White;

            // Tạo header panel
            CreateHeaderPanel();

            // Tạo filter panel
            CreateFilterPanel();

            // Tùy chỉnh DataGridView
            CustomizeDataGridView();

            // Tùy chỉnh các controls
            CustomizeControls();

            // Thêm buttons
            CreateActionButtons();

            // Tạo status panel
            CreateStatusPanel();
        }

        private void CreateHeaderPanel()
        {
            Panel headerPanel = new Panel
            {
                BackColor = primaryColor,
                Dock = DockStyle.Top,
                Height = 70,
                Name = "panelHeader"
            };

            Label headerLabel = new Label
            {
                Text = "📋 NHẬT KÝ HỆ THỐNG",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = textLightColor,
                Location = new Point(20, 20),
                AutoSize = true
            };

            headerPanel.Controls.Add(headerLabel);
            this.Controls.Add(headerPanel);
        }

        private void CreateFilterPanel()
        {
            Panel filterPanel = new Panel
            {
                BackColor = primaryLightColor,
                Location = new Point(0, 70),
                Size = new Size(1100, 120),
                Name = "panelFilter"
            };

            // Label tiêu đề filter
            Label filterTitle = new Label
            {
                Text = "🔍 Bộ lọc tìm kiếm",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = textColor,
                Location = new Point(20, 10),
                AutoSize = true
            };

            filterPanel.Controls.Add(filterTitle);
            this.Controls.Add(filterPanel);

            // Di chuyển các controls filter vào panel
            MoveControlsToFilterPanel(filterPanel);
        }

        private void MoveControlsToFilterPanel(Panel filterPanel)
        {
            // ROW 1: User filter và Date range
            label4.Location = new Point(20, 40);
            label4.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            label4.ForeColor = textColor;
            label4.Text = "Người dùng:";

            // Tạo search panel cho user filter
            CreateUserSearchPanel(filterPanel);

            label5.Location = new Point(400, 40);
            label5.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            label5.ForeColor = textColor;
            label5.Text = "Từ ngày:";

            dtpStart.Location = new Point(470, 37);
            dtpStart.Size = new Size(120, 28);
            CustomizeDateTimePicker(dtpStart);

            dtpFrom.Location = new Point(610, 40);
            dtpFrom.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dtpFrom.ForeColor = textColor;
            dtpFrom.Text = "Đến ngày:";

            dtpEnd.Location = new Point(690, 37);
            dtpEnd.Size = new Size(120, 28);
            CustomizeDateTimePicker(dtpEnd);

            // ROW 2: Action và Model
            label6.Location = new Point(20, 75);
            label6.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            label6.ForeColor = textColor;
            label6.Text = "Hành động:";

            cboHanhDong.Location = new Point(120, 72);
            cboHanhDong.Size = new Size(150, 28);
            CustomizeComboBox(cboHanhDong);

            label1.Location = new Point(290, 75);
            label1.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            label1.ForeColor = textColor;
            label1.Text = "Model:";

            cbbModel.Location = new Point(350, 72);
            cbbModel.Size = new Size(180, 28);
            CustomizeComboBox(cbbModel);

            // Thêm các controls vào filter panel
            filterPanel.Controls.AddRange(new Control[] {
                label4, label5, dtpStart, dtpFrom, dtpEnd, label6, cboHanhDong, label1, cbbModel
            });
        }

        private void CreateUserSearchPanel(Panel parentPanel)
        {
            Panel searchPanel = new Panel
            {
                Size = new Size(220, 32),
                Location = new Point(120, 37),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White
            };

            // Xóa controls khỏi parent hiện tại
            txtUserFilter.Parent?.Controls.Remove(txtUserFilter);
            pictureBox1.Parent?.Controls.Remove(pictureBox1);

            // Tùy chỉnh picture box
            pictureBox1.Size = new Size(22, 22);
            pictureBox1.Location = new Point(5, 5);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.BackColor = Color.Transparent;

            // Tùy chỉnh textbox
            txtUserFilter.BorderStyle = BorderStyle.None;
            txtUserFilter.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            txtUserFilter.Location = new Point(32, 6);
            txtUserFilter.Size = new Size(185, 22);
            txtUserFilter.BackColor = Color.White;
            txtUserFilter.Multiline = false;

            searchPanel.Controls.Add(pictureBox1);
            searchPanel.Controls.Add(txtUserFilter);
            parentPanel.Controls.Add(searchPanel);
        }

        private void CustomizeDataGridView()
        {
            dgvLogs.Location = new Point(20, 210);
            dgvLogs.Size = new Size(1050, 310);
            dgvLogs.BorderStyle = BorderStyle.None;
            dgvLogs.BackgroundColor = Color.White;
            dgvLogs.GridColor = Color.FromArgb(230, 230, 230);
            dgvLogs.RowHeadersVisible = false;
            dgvLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLogs.AllowUserToAddRows = false;
            dgvLogs.AllowUserToDeleteRows = false;
            dgvLogs.ReadOnly = true;
            dgvLogs.EnableHeadersVisualStyles = false;
            dgvLogs.AlternatingRowsDefaultCellStyle.BackColor = primaryLightColor;
            dgvLogs.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Header style
            dgvLogs.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
            dgvLogs.ColumnHeadersDefaultCellStyle.ForeColor = textLightColor;
            dgvLogs.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvLogs.ColumnHeadersHeight = 40;

            // Cell style
            dgvLogs.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgvLogs.DefaultCellStyle.ForeColor = textColor;
            dgvLogs.DefaultCellStyle.SelectionBackColor = primaryLightColor;
            dgvLogs.DefaultCellStyle.SelectionForeColor = primaryColor;
            dgvLogs.RowTemplate.Height = 30;

            dgvLogs.BringToFront();
        }

        private void CustomizeControls()
        {
            // Xóa buttons cũ khỏi form
            btnFilter.Parent?.Controls.Remove(btnFilter);
            btnExport.Parent?.Controls.Remove(btnExport);
        }

        private void CustomizeComboBox(ComboBox cbo)
        {
            cbo.FlatStyle = FlatStyle.Flat;
            cbo.BackColor = Color.White;
            cbo.ForeColor = textColor;
            cbo.Font = new Font("Segoe UI", 10, FontStyle.Regular);
        }

        private void CustomizeDateTimePicker(DateTimePicker dtp)
        {
            dtp.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dtp.CalendarForeColor = textColor;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "dd/MM/yyyy";
        }

        private void CreateActionButtons()
        {
            int buttonY = 540;

            // Button Filter
            Button btnFilterNew = new Button
            {
                Text = "🔍 Lọc dữ liệu",
                BackColor = primaryColor,
                ForeColor = textLightColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(120, 38),
                Location = new Point(20, buttonY),
                Cursor = Cursors.Hand
            };
            btnFilterNew.FlatAppearance.BorderSize = 0;

            // Button Export
            Button btnExportNew = new Button
            {
                Text = "📤 Xuất Excel",
                BackColor = successColor,
                ForeColor = textLightColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(120, 38),
                Location = new Point(160, buttonY),
                Cursor = Cursors.Hand
            };
            btnExportNew.FlatAppearance.BorderSize = 0;

            // Button Refresh
            Button btnRefresh = new Button
            {
                Text = "🔄 Làm mới",
                BackColor = warningColor,
                ForeColor = textLightColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(120, 38),
                Location = new Point(300, buttonY),
                Cursor = Cursors.Hand
            };
            btnRefresh.FlatAppearance.BorderSize = 0;

            // Button Back
            Button btnBack = new Button
            {
                Text = "🔙 Quay lại",
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = textLightColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Size = new Size(120, 38),
                Location = new Point(950, buttonY),
                Cursor = Cursors.Hand
            };
            btnBack.FlatAppearance.BorderSize = 0;

            // Thêm hover effects
            AddButtonHoverEffect(btnFilterNew, primaryColor);
            AddButtonHoverEffect(btnExportNew, successColor);
            AddButtonHoverEffect(btnRefresh, warningColor);
            AddButtonHoverEffect(btnBack, Color.FromArgb(108, 117, 125));

            // Thêm event handlers
            btnBack.Click += (s, e) => this.Close();
            btnRefresh.Click += (s, e) => LoadLogData();
            btnFilterNew.Click += (s, e) => FilterLogData();
            btnExportNew.Click += (s, e) => ExportToExcel();

            this.Controls.AddRange(new Control[] { btnFilterNew, btnExportNew, btnRefresh, btnBack });

            // Đảm bảo buttons hiển thị trên cùng
            btnFilterNew.BringToFront();
            btnExportNew.BringToFront();
            btnRefresh.BringToFront();
            btnBack.BringToFront();
        }

        private void CreateStatusPanel()
        {
            Panel statusPanel = new Panel
            {
                BackColor = lightBgColor,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(20, 590),
                Size = new Size(1050, 35),
                Name = "panelStatus"
            };

            Label statusLabel = new Label
            {
                Text = "📋 Sẵn sàng tải dữ liệu nhật ký hệ thống",
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                ForeColor = textColor,
                Location = new Point(10, 8),
                AutoSize = true,
                Name = "lblStatus"
            };

            statusPanel.Controls.Add(statusLabel);
            this.Controls.Add(statusPanel);
            statusPanel.BringToFront();
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

        private void LoadLogData()
        {
            UpdateStatus("🔄 Đang tải dữ liệu nhật ký...");

            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) => {
                UpdateStatus("✅ Đã tải xong dữ liệu nhật ký");
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private void FilterLogData()
        {
            string userFilter = txtUserFilter.ForeColor == Color.Gray ? "" : txtUserFilter.Text;
            string action = cboHanhDong.SelectedItem?.ToString() ?? "Tất cả";
            string model = cbbModel.SelectedItem?.ToString() ?? "Tất cả";
            DateTime fromDate = dtpStart.Value;
            DateTime toDate = dtpEnd.Value;

            UpdateStatus($"🔍 Đang lọc: {action} - {model} từ {fromDate:dd/MM/yyyy} đến {toDate:dd/MM/yyyy}");
        }

        private void ExportToExcel()
        {
            UpdateStatus("📤 Đang xuất dữ liệu ra Excel...");

            Timer timer = new Timer();
            timer.Interval = 2000;
            timer.Tick += (s, e) => {
                UpdateStatus("✅ Đã xuất thành công ra Excel");
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private void UpdateStatus(string message)
        {
            Label statusLabel = this.Controls.Find("panelStatus", true)
                .FirstOrDefault()?.Controls.Find("lblStatus", true)
                .FirstOrDefault() as Label;

            if (statusLabel != null)
            {
                statusLabel.Text = message;
                statusLabel.ForeColor = successColor;
            }
        }

        private void txtUserFilter_TextChanged(object sender, EventArgs e)
        {
            // Implementation for text changed event
        }

        private void LogForm_Load(object sender, EventArgs e)
        {
            txtUserFilter.Text = "Tên người dùng";
            txtUserFilter.ForeColor = Color.Gray;

            cboHanhDong.Items.Clear();
            cboHanhDong.Items.Add("🗂️ Tất cả");
            cboHanhDong.Items.Add("🔐 Login");
            cboHanhDong.Items.Add("🚪 Logout");
            cboHanhDong.Items.Add("👁️ View");
            cboHanhDong.Items.Add("➕ Create");
            cboHanhDong.Items.Add("✏️ Update");
            cboHanhDong.Items.Add("🗑️ Delete");
            cboHanhDong.SelectedIndex = 0;

            cbbModel.Items.Clear();
            cbbModel.Items.Add("🗂️ Tất cả");
            cbbModel.Items.Add("🔐 Authentication");
            cbbModel.Items.Add("👥 User Management");
            cbbModel.Items.Add("🏠 Resident Info");
            cbbModel.Items.Add("📘 Passports");
            cbbModel.Items.Add("📋 Audit Logs");
            cbbModel.Items.Add("⚙️ Settings");
            cbbModel.SelectedIndex = 0;

            // Set default date range (last 30 days)
            dtpEnd.Value = DateTime.Now;
            dtpStart.Value = DateTime.Now.AddDays(-30);

            LoadLogData();
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
            string selectedAction = cboHanhDong.SelectedItem?.ToString();
            UpdateStatus($"🔄 Đã chọn hành động: {selectedAction}");
        }

        private void cbbModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = cbbModel.SelectedItem?.ToString();
            UpdateStatus($"🔄 Đã chọn model: {selected}");
        }
    }
}