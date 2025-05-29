using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Business_Layer;
using Data_Layer.NewFolder1;

namespace CuoiKi
{
    public partial class ApprovalForm : Form
    {
        // Định nghĩa màu sắc chung cho ứng dụng - Đồng bộ với VerificationForm
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

        public ApprovalForm()
        {
            InitializeComponent();
            CustomizeDesign();
            rtbNotes.ForeColor = Color.Gray;
            rtbNotes.GotFocus += RemovePlaceholder;
            rtbNotes.LostFocus += SetPlaceholder;
            this.txtSearchCCCD.Enter += new System.EventHandler(this.txtSearchCCCD_Enter);
            this.txtSearchCCCD.Leave += new System.EventHandler(this.txtSearchCCCD_Leave);
        }

        private void CustomizeDesign()
        {
            // Tùy chỉnh form với kích thước vừa phải
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Xét duyệt hồ sơ cấp hộ chiếu";
            this.BackColor = Color.White;
            this.MinimumSize = new Size(1000, 600);
            this.Size = new Size(1000, 600);

            // Tùy chỉnh panel header với kích thước nhỏ hơn
            panelHeader.BackColor = primaryColor;
            panelHeader.Height = 60;
            labelTitle.Text = "📋 XÉT DUYỆT HỒ SƠ CẤP HỘ CHIẾU";
            labelTitle.ForeColor = textLightColor;
            labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelTitle.Location = new Point(20, 15);

            // Tùy chỉnh DataGridView với kích thước compact
            CustomizeDataGridView();

            // Tùy chỉnh RichTextBox với label
            CustomizeNotesSection();

            // Tùy chỉnh ComboBox
            CustomizeComboBox();

            // Tùy chỉnh TextBox search
            CustomizeSearchBox();

            // Tùy chỉnh Buttons với kích thước nhỏ hơn
            CustomizeButtons();

            // Tùy chỉnh Status Panel
            CustomizeStatusPanel();

            // Thêm hover effects
            AddButtonHoverEffects();
        }

        private void CustomizeDataGridView()
        {
            // Style compact cho DataGridView
            dgvApplications.BorderStyle = BorderStyle.None;
            dgvApplications.BackgroundColor = Color.White;
            dgvApplications.GridColor = Color.FromArgb(230, 230, 230);
            dgvApplications.RowHeadersVisible = false;
            dgvApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvApplications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvApplications.AllowUserToAddRows = false;
            dgvApplications.AllowUserToDeleteRows = false;
            dgvApplications.ReadOnly = true;
            dgvApplications.EnableHeadersVisualStyles = false;
            dgvApplications.AlternatingRowsDefaultCellStyle.BackColor = primaryLightColor;
            dgvApplications.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvApplications.MultiSelect = false;

            // Header style compact
            dgvApplications.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
            dgvApplications.ColumnHeadersDefaultCellStyle.ForeColor = textLightColor;
            dgvApplications.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvApplications.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvApplications.ColumnHeadersHeight = 40;
            dgvApplications.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Cell style compact
            dgvApplications.DefaultCellStyle.Font = new Font("Segoe UI", 8.5F, FontStyle.Regular);
            dgvApplications.DefaultCellStyle.ForeColor = textColor;
            dgvApplications.DefaultCellStyle.SelectionBackColor = primaryLightColor;
            dgvApplications.DefaultCellStyle.SelectionForeColor = primaryColor;
            dgvApplications.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvApplications.RowTemplate.Height = 30;

            // Vị trí và kích thước compact
            dgvApplications.Location = new Point(20, 120);
            dgvApplications.Size = new Size(960, 320);
        }

        private void CustomizeNotesSection()
        {
            // Thêm label cho notes section
            Label notesLabel = new Label
            {
                Text = "📝 Ghi chú xét duyệt:",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(20, 450),
                AutoSize = true
            };
            this.Controls.Add(notesLabel);
            notesLabel.BringToFront();

            // Điều chỉnh vị trí RichTextBox compact
            rtbNotes.Location = new Point(20, 480);
            rtbNotes.Size = new Size(450, 60);
            rtbNotes.BorderStyle = BorderStyle.FixedSingle;
            rtbNotes.BackColor = Color.White;
            rtbNotes.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            rtbNotes.ForeColor = Color.Gray;
            rtbNotes.Text = "💬 Nhập lý do phê duyệt hoặc từ chối hồ sơ...";
        }

        private void CustomizeComboBox()
        {
            // Ẩn combobox và search box
            cboStatusFilter.Visible = false;
            pictureBox2.Visible = false;
            txtSearchCCCD.Visible = false;
            panelSearch.Visible = false;
        }

        private void CustomizeSearchBox()
        {
            // Không cần search box trong layout này
        }

        private void CustomizeButtons()
        {
            // Button style compact
            btnApprove.BackColor = primaryColor;
            btnApprove.FlatAppearance.BorderSize = 0;
            btnApprove.ForeColor = textLightColor;
            btnApprove.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnApprove.Cursor = Cursors.Hand;
            btnApprove.TextAlign = ContentAlignment.MiddleCenter;
            btnApprove.Text = "✅ Phê duyệt";
            btnApprove.Size = new Size(140, 35);
            btnApprove.Location = new Point(490, 480);

            btnReject.BackColor = dangerColor;
            btnReject.FlatAppearance.BorderSize = 0;
            btnReject.ForeColor = textLightColor;
            btnReject.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnReject.Cursor = Cursors.Hand;
            btnReject.TextAlign = ContentAlignment.MiddleCenter;
            btnReject.Text = "❌ Từ chối";
            btnReject.Size = new Size(140, 35);
            btnReject.Location = new Point(650, 480);

            // Thêm button Refresh và Back compact
            System.Windows.Forms.Button btnRefresh = new System.Windows.Forms.Button
            {
                Text = "🔄 Làm mới",
                BackColor = successColor,
                ForeColor = textLightColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                Size = new Size(120, 35),
                Location = new Point(810, 480),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter
            };
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Click += (s, e) => RefreshData();
            this.Controls.Add(btnRefresh);

            System.Windows.Forms.Button btnBack = new System.Windows.Forms.Button
            {
                Text = "🔙 Quay lại",
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = textLightColor,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Regular),
                Size = new Size(120, 35),
                Location = new Point(810, 525),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter
            };
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Click += (s, e) => {
                new Menu().Show();
                this.Hide();
            };
            this.Controls.Add(btnBack);
        }

        private void CustomizeStatusPanel()
        {
            // Status label compact
            lblStatus.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            lblStatus.ForeColor = Color.FromArgb(108, 117, 125);
            lblStatus.Location = new Point(20, 560);
            lblStatus.Text = "📊 Sẵn sàng xử lý hồ sơ";
        }

        private void AddButtonHoverEffects()
        {
            // Hover effects
            btnApprove.MouseEnter += (s, e) => btnApprove.BackColor = Color.FromArgb(0, 86, 179);
            btnApprove.MouseLeave += (s, e) => btnApprove.BackColor = primaryColor;

            btnReject.MouseEnter += (s, e) => btnReject.BackColor = Color.FromArgb(200, 35, 51);
            btnReject.MouseLeave += (s, e) => btnReject.BackColor = dangerColor;
        }

        private void RefreshData()
        {
            ApprovalForm_Load(this, EventArgs.Empty);
            lblStatus.Text = "🔄 Đã làm mới dữ liệu";
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (rtbNotes.ForeColor == Color.Gray)
            {
                rtbNotes.Text = "";
                rtbNotes.ForeColor = textColor;
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbNotes.Text))
            {
                rtbNotes.Text = "💬 Nhập lý do phê duyệt hoặc từ chối hồ sơ...";
                rtbNotes.ForeColor = Color.Gray;
            }
        }

        private void rtbNotes_TextChanged(object sender, EventArgs e)
        {
            // Có thể thêm xử lý khi text thay đổi nếu cần
        }

        private void txtSearchCCCD_Enter(object sender, EventArgs e)
        {
            if (txtSearchCCCD.Text == "🔍 Tìm kiếm theo CCCD...")
            {
                txtSearchCCCD.Text = "";
                txtSearchCCCD.ForeColor = textColor;
            }
        }

        private void txtSearchCCCD_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchCCCD.Text))
            {
                txtSearchCCCD.Text = "🔍 Tìm kiếm theo CCCD...";
                txtSearchCCCD.ForeColor = Color.Gray;
            }
        }

        DataTable residentTable;
        private void ApprovalForm_Load(object sender, EventArgs e)
        {
            // Thêm label danh sách
            Label listLabel = new Label
            {
                Text = "📋 Danh sách hồ sơ chờ xét duyệt",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 58, 64),
                Location = new Point(20, 90),
                AutoSize = true
            };
            this.Controls.Add(listLabel);

            // Load dữ liệu - GIỮ NGUYÊN LOGIC GỐC
            ResidentService residentService = new ResidentService();
            residentTable = residentService.GetAllResidentForEachUser(3, "SP_ListAllApplicationsForXD");
            dgvApplications.DataSource = residentTable;

            // Tùy chỉnh tên cột hiển thị với icons
            CustomizeColumnHeaders();

            // Tùy chỉnh độ rộng cột compact
            SetColumnWidths();

            // Cập nhật trạng thái với thống kê
            UpdateStatusWithStats();
        }

        private void CustomizeColumnHeaders()
        {
            var columnMappings = new Dictionary<string, string>
            {
                {"FullName", "👤 Họ tên"},
                {"CMND", "🆔 CCCD"},
                {"Gender", "⚥ GT"},
                {"DateOfBirth", "📅 Ngày sinh"},
                {"Address", "🏠 Địa chỉ"},
                {"Nationality", "🌍 QT"},
                {"PhoneNumber", "📞 SĐT"},
                {"Email", "📧 Email"},
                {"CreatedAt", "⏰ Ngày tạo"},
                {"Status", "🔍 Trạng thái"}
            };

            foreach (var mapping in columnMappings)
            {
                if (dgvApplications.Columns.Contains(mapping.Key))
                {
                    dgvApplications.Columns[mapping.Key].HeaderText = mapping.Value;
                }
            }

            // Ẩn cột ResidentID
            if (dgvApplications.Columns.Contains("ResidentID"))
            {
                dgvApplications.Columns["ResidentID"].Visible = false;
            }
        }

        private void SetColumnWidths()
        {
            // Đặt AutoSizeColumnsMode về None để có thể tùy chỉnh độ rộng
            dgvApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Tùy chỉnh độ rộng từng cột compact
            var columnWidths = new Dictionary<string, int>
            {
                {"FullName", 120},
                {"CMND", 90},
                {"Gender", 50},
                {"DateOfBirth", 90},
                {"Address", 150},
                {"Nationality", 60},
                {"PhoneNumber", 100},
                {"Email", 130},
                {"CreatedAt", 100},
                {"Status", 90}
            };

            foreach (var columnWidth in columnWidths)
            {
                if (dgvApplications.Columns.Contains(columnWidth.Key))
                {
                    dgvApplications.Columns[columnWidth.Key].Width = columnWidth.Value;
                }
            }
        }

        private void UpdateStatusWithStats()
        {
            // Thống kê
            int totalRecords = residentTable.Rows.Count;
            int approvedCount = 0;
            int rejectedCount = 0;
            int pendingCount = totalRecords;

            // Đếm theo trạng thái nếu có cột Status
            if (residentTable.Columns.Contains("Status"))
            {
                approvedCount = residentTable.AsEnumerable().Count(row =>
                    row.Field<string>("Status")?.Contains("Đã duyệt") == true);
                rejectedCount = residentTable.AsEnumerable().Count(row =>
                    row.Field<string>("Status")?.Contains("Từ chối") == true);
                pendingCount = totalRecords - approvedCount - rejectedCount;
            }

            lblStatus.Text = $"📊 Tổng: {totalRecords} | ✅ Duyệt: {approvedCount} | ❌ Từ chối: {rejectedCount} | ⏳ Chờ: {pendingCount}";
            lblStatus.ForeColor = successColor;
        }

        private void txtSearchCCCD_TextChanged(object sender, EventArgs e)
        {
            // Giữ nguyên logic search nếu cần
        }

        // GIỮ NGUYÊN LOGIC GỐC
        ApplicationService applicationService = new ApplicationService();
        FunctionService functionService = new FunctionService();

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 0)
            {
                MessageBox.Show("⚠️ Vui lòng chọn hồ sơ cần phê duyệt!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // GIỮ NGUYÊN LOGIC GỐC
            string x = dgvApplications.CurrentRow.Cells["ApplicationID"].Value?.ToString();
            int ID = int.Parse(x);
            string note = rtbNotes.Text;
            string fullName = dgvApplications.CurrentRow.Cells["FullName"].Value?.ToString();

            DialogResult result = MessageBox.Show($"✅ Xác nhận phê duyệt hồ sơ của:\n{fullName}?",
                "Xác nhận phê duyệt", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes && applicationService.Update(ID, "SP_UpdateApplicationStatusForXD", "Đã phê duyệt"))
            {

                
                MessageBox.Show($"✅ Đã phê duyệt thành công hồ sơ của {fullName}!",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RefreshData();
            }
            
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 0)
            {
                MessageBox.Show("⚠️ Vui lòng chọn hồ sơ cần từ chối!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // GIỮ NGUYÊN LOGIC GỐC
            string x = dgvApplications.CurrentRow.Cells["ApplicationID"].Value?.ToString();
            int ID = int.Parse(x);
            string note = rtbNotes.Text;
            string fullName = dgvApplications.CurrentRow.Cells["FullName"].Value?.ToString();

            DialogResult result = MessageBox.Show($"❌ Xác nhận từ chối hồ sơ của:\n{fullName}?",
                "Xác nhận từ chối", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes && applicationService.Update(ID, "SP_UpdateApplicationStatusForXD", "Từ chối"))
            {
                functionService.SystemLog("Reject", Session.RoleId.ToString(), "PassportApplication");


                MessageBox.Show($"❌ Đã từ chối hồ sơ của {fullName}!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RefreshData();
            }
            
        }
    }
}