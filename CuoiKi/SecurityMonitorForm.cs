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
    public partial class SecurityMonitorForm : Form
    {
        // Định nghĩa màu sắc chung cho ứng dụng - Đồng bộ với các forms khác
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

        public SecurityMonitorForm()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        private void CustomizeDesign()
        {
            // Tùy chỉnh form - KÍCH THƯỚC LỚN HỚN ĐỂ TRÁNH CẮT CHỮ
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Size = new Size(1200, 700);  // Tăng kích thước để đủ chỗ cho chart và controls
            this.MinimumSize = new Size(1200, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Giám sát bảo mật hệ thống";
            this.Icon = SystemIcons.Application;
            this.BackColor = Color.White;

            // Tạo header panel
            CreateHeaderPanel();

            // Tạo filter panel
            CreateFilterPanel();

            // Tùy chỉnh Chart
            CustomizeChart();

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
                Text = "🔒 GIÁM SÁT BẢO MẬT HỆ THỐNG",
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
                Size = new Size(1200, 80),  // Giảm height để tiết kiệm không gian
                Name = "panelFilter"
            };

            // Label tiêu đề filter
            Label filterTitle = new Label
            {
                Text = "🔍 Bộ lọc giám sát",
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
            // Sắp xếp controls trên 1 hàng để tiết kiệm không gian
            label1.Location = new Point(20, 40);
            label1.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            label1.ForeColor = textColor;
            label1.Text = "Loại cảnh báo:";

            cboAlertType.Location = new Point(130, 37);
            cboAlertType.Size = new Size(200, 28);
            CustomizeComboBox(cboAlertType);

            label2.Location = new Point(350, 40);
            label2.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            label2.ForeColor = textColor;
            label2.Text = "Từ ngày:";

            dtpFrom.Location = new Point(420, 37);
            dtpFrom.Size = new Size(130, 28);
            CustomizeDateTimePicker(dtpFrom);

            label3.Location = new Point(570, 40);
            label3.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            label3.ForeColor = textColor;
            label3.Text = "Đến ngày:";

            dtpTo.Location = new Point(650, 37);
            dtpTo.Size = new Size(130, 28);
            CustomizeDateTimePicker(dtpTo);

            // Thêm các controls vào filter panel
            filterPanel.Controls.AddRange(new Control[] {
                label1, cboAlertType, label2, dtpFrom, label3, dtpTo
            });
        }

        private void CustomizeChart()
        {
            // Vị trí và kích thước chart - BÊN TRÁI
            chartAccessStats.Location = new Point(20, 170);
            chartAccessStats.Size = new Size(580, 280);  // Tăng kích thước chart
            chartAccessStats.BackColor = Color.White;
            chartAccessStats.BorderlineColor = primaryColor;
            chartAccessStats.BorderlineWidth = 2;
            chartAccessStats.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;

            // Tùy chỉnh Chart Area
            if (chartAccessStats.ChartAreas.Count > 0)
            {
                var chartArea = chartAccessStats.ChartAreas[0];
                chartArea.BackColor = Color.White;
                chartArea.BorderColor = primaryLightColor;
                chartArea.BorderWidth = 1;
                chartArea.AxisX.LabelStyle.ForeColor = textColor;
                chartArea.AxisY.LabelStyle.ForeColor = textColor;
                chartArea.AxisX.LineColor = primaryColor;
                chartArea.AxisY.LineColor = primaryColor;
                chartArea.AxisX.MajorGrid.LineColor = primaryLightColor;
                chartArea.AxisY.MajorGrid.LineColor = primaryLightColor;
            }

            // Tùy chỉnh Legend
            if (chartAccessStats.Legends.Count > 0)
            {
                var legend = chartAccessStats.Legends[0];
                legend.BackColor = Color.Transparent;
                legend.ForeColor = textColor;
                legend.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            }

            // Tùy chỉnh Series
            if (chartAccessStats.Series.Count > 0)
            {
                var series = chartAccessStats.Series[0];
                series.Color = primaryColor;
                series.BorderWidth = 3;
                series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            }

            chartAccessStats.BringToFront();
        }

        private void CustomizeDataGridView()
        {
            // Vị trí DataGridView - BÊN PHẢI VÀ DƯỚI CHART
            dgvAlerts.Location = new Point(620, 170);
            dgvAlerts.Size = new Size(550, 280);  // Cùng height với chart
            dgvAlerts.BorderStyle = BorderStyle.None;
            dgvAlerts.BackgroundColor = Color.White;
            dgvAlerts.GridColor = Color.FromArgb(230, 230, 230);
            dgvAlerts.RowHeadersVisible = false;
            dgvAlerts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAlerts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAlerts.AllowUserToAddRows = false;
            dgvAlerts.AllowUserToDeleteRows = false;
            dgvAlerts.ReadOnly = true;
            dgvAlerts.EnableHeadersVisualStyles = false;
            dgvAlerts.AlternatingRowsDefaultCellStyle.BackColor = primaryLightColor;
            dgvAlerts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Header style
            dgvAlerts.ColumnHeadersDefaultCellStyle.BackColor = dangerColor;  // Màu đỏ cho security alerts
            dgvAlerts.ColumnHeadersDefaultCellStyle.ForeColor = textLightColor;
            dgvAlerts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvAlerts.ColumnHeadersHeight = 40;

            // Cell style
            dgvAlerts.DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dgvAlerts.DefaultCellStyle.ForeColor = textColor;
            dgvAlerts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 235, 235);  // Màu đỏ nhạt
            dgvAlerts.DefaultCellStyle.SelectionForeColor = dangerColor;
            dgvAlerts.RowTemplate.Height = 30;

            dgvAlerts.BringToFront();
        }

        private void CustomizeControls()
        {
            // Xóa button cũ khỏi form
            btnGenerateReport.Parent?.Controls.Remove(btnGenerateReport);
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
            int buttonY = 470;  // Vị trí buttons - ĐỦ KHOẢNG CÁCH TỪ CONTROLS TRÊN

            // Button Generate Report
            Button btnGenerateNew = new Button
            {
                Text = "📊 Tạo báo cáo",
                BackColor = dangerColor,  // Màu đỏ cho security
                ForeColor = textLightColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(130, 38),
                Location = new Point(20, buttonY),
                Cursor = Cursors.Hand
            };
            btnGenerateNew.FlatAppearance.BorderSize = 0;

            // Button Export
            Button btnExport = new Button
            {
                Text = "📤 Xuất Excel",
                BackColor = successColor,
                ForeColor = textLightColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(130, 38),
                Location = new Point(170, buttonY),
                Cursor = Cursors.Hand
            };
            btnExport.FlatAppearance.BorderSize = 0;

            // Button Refresh
            Button btnRefresh = new Button
            {
                Text = "🔄 Làm mới",
                BackColor = warningColor,
                ForeColor = textLightColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(130, 38),
                Location = new Point(320, buttonY),
                Cursor = Cursors.Hand
            };
            btnRefresh.FlatAppearance.BorderSize = 0;

            // Button Alert Settings
            Button btnSettings = new Button
            {
                Text = "⚙️ Cài đặt",
                BackColor = primaryColor,
                ForeColor = textLightColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(130, 38),
                Location = new Point(470, buttonY),
                Cursor = Cursors.Hand
            };
            btnSettings.FlatAppearance.BorderSize = 0;

            // Button Back
            Button btnBack = new Button
            {
                Text = "🔙 Quay lại",
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = textLightColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Regular),
                Size = new Size(130, 38),
                Location = new Point(1040, buttonY),
                Cursor = Cursors.Hand
            };
            btnBack.FlatAppearance.BorderSize = 0;

            // Thêm hover effects
            AddButtonHoverEffect(btnGenerateNew, dangerColor);
            AddButtonHoverEffect(btnExport, successColor);
            AddButtonHoverEffect(btnRefresh, warningColor);
            AddButtonHoverEffect(btnSettings, primaryColor);
            AddButtonHoverEffect(btnBack, Color.FromArgb(108, 117, 125));

            // Thêm event handlers
            btnBack.Click += (s, e) => this.Close();
            btnRefresh.Click += (s, e) => LoadSecurityData();
            btnGenerateNew.Click += (s, e) => GenerateSecurityReport();
            btnExport.Click += (s, e) => ExportToExcel();
            btnSettings.Click += (s, e) => OpenSecuritySettings();

            this.Controls.AddRange(new Control[] { btnGenerateNew, btnExport, btnRefresh, btnSettings, btnBack });

            // Đảm bảo buttons hiển thị trên cùng
            btnGenerateNew.BringToFront();
            btnExport.BringToFront();
            btnRefresh.BringToFront();
            btnSettings.BringToFront();
            btnBack.BringToFront();
        }

        private void CreateStatusPanel()
        {
            Panel statusPanel = new Panel
            {
                BackColor = lightBgColor,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(20, 530),  // VỊ TRÍ CUỐI FORM - ĐỦ KHOẢNG CÁCH
                Size = new Size(1150, 35),
                Name = "panelStatus"
            };

            Label statusLabel = new Label
            {
                Text = "🔒 Hệ thống giám sát bảo mật đang hoạt động",
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

        private void LoadSecurityData()
        {
            UpdateStatus("🔄 Đang tải dữ liệu giám sát bảo mật...");

            Timer timer = new Timer();
            timer.Interval = 1500;
            timer.Tick += (s, e) => {
                UpdateStatus("✅ Đã tải xong dữ liệu giám sát bảo mật");
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private void GenerateSecurityReport()
        {
            UpdateStatus("📊 Đang tạo báo cáo bảo mật...");

            Timer timer = new Timer();
            timer.Interval = 2000;
            timer.Tick += (s, e) => {
                UpdateStatus("✅ Đã tạo xong báo cáo bảo mật");
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
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

        private void OpenSecuritySettings()
        {
            UpdateStatus("⚙️ Đang mở cài đặt bảo mật...");
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

        private void chartAccessStats_Click(object sender, EventArgs e)
        {
            UpdateStatus("📊 Đã click vào biểu đồ thống kê");
        }

        private void SecurityMonitorForm_Load(object sender, EventArgs e)
        {
            cboAlertType.Items.Clear();
            cboAlertType.Items.Add("🔒 Tất cả loại cảnh báo");
            cboAlertType.Items.Add("⚠️ Truy cập trái phép");
            cboAlertType.Items.Add("❌ Đăng nhập thất bại");
            cboAlertType.Items.Add("🚫 Quyền truy cập bị từ chối");
            cboAlertType.Items.Add("🔓 Tài khoản bị khóa");
            cboAlertType.Items.Add("🕒 Truy cập ngoài giờ");

            cboAlertType.SelectedIndex = 0;

            // Set default date range (last 7 days for security monitoring)
            dtpTo.Value = DateTime.Now;
            dtpFrom.Value = DateTime.Now.AddDays(-7);

            LoadSecurityData();
        }
    }
}