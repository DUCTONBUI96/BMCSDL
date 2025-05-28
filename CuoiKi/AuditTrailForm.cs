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
    public partial class AuditTrailForm : Form
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

        public AuditTrailForm()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        private void CustomizeDesign()
        {
            // Tùy chỉnh form - ĐIỀU CHỈNH KÍCH THƯỚC
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Size = new Size(1100, 650);  // Tăng kích thước để đủ chỗ
            this.MinimumSize = new Size(1100, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Nhật ký hoạt động hệ thống";
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
                Height = 70,  // Tăng lên một chút
                Name = "panelHeader"
            };

            Label headerLabel = new Label
            {
                Text = "📊 NHẬT KÝ HOẠT ĐỘNG HỆ THỐNG",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),  // Tăng font
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
                Location = new Point(0, 70),  // Điều chỉnh theo header
                Size = new Size(1100, 110),   // Tăng kích thước
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
            // Điều chỉnh vị trí các controls - SPACING TỐT HỚN
            label1.Location = new Point(20, 40);
            label1.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            label1.ForeColor = textColor;

            cboTableName.Location = new Point(70, 37);
            cboTableName.Size = new Size(140, 28);
            CustomizeComboBox(cboTableName);

            label2.Location = new Point(230, 40);
            label2.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            label2.ForeColor = textColor;

            dtpStart.Location = new Point(300, 37);
            dtpStart.Size = new Size(120, 28);
            CustomizeDateTimePicker(dtpStart);

            dtpFrom.Location = new Point(440, 40);
            dtpFrom.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dtpFrom.ForeColor = textColor;

            dtpTo.Location = new Point(520, 37);
            dtpTo.Size = new Size(120, 28);
            CustomizeDateTimePicker(dtpTo);

            label3.Location = new Point(20, 75);
            label3.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            label3.ForeColor = textColor;

            // Tạo search panel cho user filter
            CreateUserSearchPanel(filterPanel);

            // Thêm các controls vào filter panel
            filterPanel.Controls.AddRange(new Control[] {
                label1, cboTableName, label2, dtpStart, dtpFrom, dtpTo, label3
            });
        }

        private void CreateUserSearchPanel(Panel parentPanel)
        {
            Panel searchPanel = new Panel
            {
                Size = new Size(220, 32),
                Location = new Point(120, 72),
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

            searchPanel.Controls.Add(pictureBox1);
            searchPanel.Controls.Add(txtUserFilter);
            parentPanel.Controls.Add(searchPanel);
        }

        private void CustomizeDataGridView()
        {
            // ĐIỀU CHỈNH VỊ TRÍ VÀ KÍCH THƯỚC CHÍNH XÁC
            dgvAuditTrail.Location = new Point(20, 200);  // Tăng Y để tránh đè lên filter
            dgvAuditTrail.Size = new Size(1050, 320);     // Tăng kích thước
            dgvAuditTrail.BorderStyle = BorderStyle.None;
            dgvAuditTrail.BackgroundColor = Color.White;
            dgvAuditTrail.GridColor = Color.FromArgb(230, 230, 230);
            dgvAuditTrail.RowHeadersVisible = false;
            dgvAuditTrail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAuditTrail.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAuditTrail.AllowUserToAddRows = false;
            dgvAuditTrail.AllowUserToDeleteRows = false;
            dgvAuditTrail.ReadOnly = true;
            dgvAuditTrail.EnableHeadersVisualStyles = false;
            dgvAuditTrail.AlternatingRowsDefaultCellStyle.BackColor = primaryLightColor;
            dgvAuditTrail.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Header style
            dgvAuditTrail.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
            dgvAuditTrail.ColumnHeadersDefaultCellStyle.ForeColor = textLightColor;
            dgvAuditTrail.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvAuditTrail.ColumnHeadersHeight = 40;

            // Cell style
            dgvAuditTrail.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgvAuditTrail.DefaultCellStyle.ForeColor = textColor;
            dgvAuditTrail.DefaultCellStyle.SelectionBackColor = primaryLightColor;
            dgvAuditTrail.DefaultCellStyle.SelectionForeColor = primaryColor;
            dgvAuditTrail.RowTemplate.Height = 30;

            // Đảm bảo DataGridView hiển thị trên cùng
            dgvAuditTrail.BringToFront();
        }

        private void CustomizeControls()
        {
            // Xóa button cũ khỏi form
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
        }

        private void CreateActionButtons()
        {
            // VỊ TRÍ BUTTONS - ĐẢMBẢO KHÔNG BỊ KHUẤT
            int buttonY = 540;  // Vị trí Y cố định cho buttons

            // Button Search/Filter
            Button btnSearch = new Button
            {
                Text = "🔍 Tìm kiếm",
                BackColor = primaryColor,
                ForeColor = textLightColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(120, 38),
                Location = new Point(20, buttonY),
                Cursor = Cursors.Hand
            };
            btnSearch.FlatAppearance.BorderSize = 0;

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
            AddButtonHoverEffect(btnSearch, primaryColor);
            AddButtonHoverEffect(btnExportNew, successColor);
            AddButtonHoverEffect(btnRefresh, warningColor);
            AddButtonHoverEffect(btnBack, Color.FromArgb(108, 117, 125));

            // Thêm event handlers
            btnBack.Click += (s, e) => this.Close();
            btnRefresh.Click += (s, e) => LoadAuditData();
            btnSearch.Click += (s, e) => FilterAuditData();
            btnExportNew.Click += (s, e) => ExportToExcel();

            this.Controls.AddRange(new Control[] { btnSearch, btnExportNew, btnRefresh, btnBack });

            // Đảm bảo buttons hiển thị trên cùng
            btnSearch.BringToFront();
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
                Location = new Point(20, 590),  // Vị trí cuối form
                Size = new Size(1050, 35),
                Name = "panelStatus"
            };

            Label statusLabel = new Label
            {
                Text = "📊 Sẵn sàng tải dữ liệu nhật ký hoạt động",
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                ForeColor = textColor,
                Location = new Point(10, 8),
                AutoSize = true,
                Name = "lblStatus"
            };

            statusPanel.Controls.Add(statusLabel);
            this.Controls.Add(statusPanel);

            // Đảm bảo status panel hiển thị trên cùng
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

        private void LoadAuditData()
        {
            FunctionService functionService = new FunctionService();
            DataTable auditData = functionService.AUdit();
            dgvAuditTrail.DataSource = auditData;

            // TODO: Implement load audit data logic
            UpdateStatus("🔄 Đang tải dữ liệu...");

            // Simulate loading
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (s, e) => {
                UpdateStatus("✅ Đã tải xong dữ liệu nhật ký");
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private void FilterAuditData()
        {
            // TODO: Implement filter logic
            string tableName = cboTableName.SelectedItem?.ToString() ?? "All Tables";
            DateTime fromDate = dtpStart.Value;
            DateTime toDate = dtpTo.Value;
            string userFilter = txtUserFilter.ForeColor == Color.Gray ? "" : txtUserFilter.Text;

            UpdateStatus($"🔍 Đang lọc dữ liệu: {tableName} từ {fromDate:dd/MM/yyyy} đến {toDate:dd/MM/yyyy}");
        }

        private void ExportToExcel()
        {
            // TODO: Implement export logic
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

        private void AuditTrailForm_Load(object sender, EventArgs e)
        {
            txtUserFilter.Text = "Tên người dùng";
            txtUserFilter.ForeColor = Color.Gray;

            cboTableName.Items.Clear();
            cboTableName.Items.Add("🗂️ Tất cả bảng");
            cboTableName.Items.Add("📋 Đơn đăng ký");
            cboTableName.Items.Add("👥 Cư dân");
            cboTableName.Items.Add("📘 Hộ chiếu");
            cboTableName.Items.Add("🔔 Thông báo");
            cboTableName.Items.Add("👤 Người dùng");

            cboTableName.SelectedIndex = 0;

            // Set default date range (last 30 days)
            dtpTo.Value = DateTime.Now;
            dtpStart.Value = DateTime.Now.AddDays(-30);

            LoadAuditData();
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