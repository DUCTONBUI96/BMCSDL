using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuoiKi
{
    public partial class PassportIssueForm : Form
    {
        // Định nghĩa màu sắc chung cho ứng dụng - Màu xanh dương (đồng bộ với các form khác)
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

        DataTable approvedResidentTable;
        DataTable historyTable;
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=PassportManagement;Integrated Security=True");
        string query;
        SqlCommand cmd;
        DataGridViewRow selectedRow;

        public PassportIssueForm()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        private void CustomizeDesign()
        {
            // Tùy chỉnh form
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimumSize = new Size(1400, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Cấp hộ chiếu";
            this.BackColor = Color.White;

            // Tùy chỉnh panel header
            panelHeader.BackColor = primaryColor;
            labelTitle.ForeColor = textLightColor;
            labelTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);

            // Tùy chỉnh DataGridView cho danh sách hồ sơ đã duyệt
            dgvApprovedApps.BorderStyle = BorderStyle.None;
            dgvApprovedApps.BackgroundColor = Color.White;
            dgvApprovedApps.GridColor = Color.FromArgb(230, 230, 230);
            dgvApprovedApps.RowHeadersVisible = false;
            dgvApprovedApps.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvApprovedApps.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvApprovedApps.AllowUserToAddRows = false;
            dgvApprovedApps.AllowUserToDeleteRows = false;
            dgvApprovedApps.ReadOnly = true;
            dgvApprovedApps.EnableHeadersVisualStyles = false;
            dgvApprovedApps.AlternatingRowsDefaultCellStyle.BackColor = primaryLightColor;
            dgvApprovedApps.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Tùy chỉnh header style cho dgvApprovedApps
            dgvApprovedApps.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
            dgvApprovedApps.ColumnHeadersDefaultCellStyle.ForeColor = textLightColor;
            dgvApprovedApps.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvApprovedApps.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvApprovedApps.ColumnHeadersHeight = 50;

            // Tùy chỉnh cell style cho dgvApprovedApps
            dgvApprovedApps.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvApprovedApps.DefaultCellStyle.ForeColor = textColor;
            dgvApprovedApps.DefaultCellStyle.SelectionBackColor = primaryLightColor;
            dgvApprovedApps.DefaultCellStyle.SelectionForeColor = primaryColor;
            dgvApprovedApps.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvApprovedApps.RowTemplate.Height = 35;

            // Tùy chỉnh DataGridView cho lịch sử
            dgvHistory.BorderStyle = BorderStyle.None;
            dgvHistory.BackgroundColor = Color.White;
            dgvHistory.GridColor = Color.FromArgb(230, 230, 230);
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.AllowUserToDeleteRows = false;
            dgvHistory.ReadOnly = true;
            dgvHistory.EnableHeadersVisualStyles = false;
            dgvHistory.AlternatingRowsDefaultCellStyle.BackColor = primaryLightColor;
            dgvHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Tùy chỉnh header style cho dgvHistory
            dgvHistory.ColumnHeadersDefaultCellStyle.BackColor = successColor;
            dgvHistory.ColumnHeadersDefaultCellStyle.ForeColor = textLightColor;
            dgvHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvHistory.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvHistory.ColumnHeadersHeight = 50;

            // Tùy chỉnh cell style cho dgvHistory
            dgvHistory.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvHistory.DefaultCellStyle.ForeColor = textColor;
            dgvHistory.DefaultCellStyle.SelectionBackColor = primaryLightColor;
            dgvHistory.DefaultCellStyle.SelectionForeColor = successColor;
            dgvHistory.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvHistory.RowTemplate.Height = 35;

            // Tùy chỉnh TextBox
            txtPassportNumber.BorderStyle = BorderStyle.FixedSingle;
            txtPassportNumber.BackColor = Color.White; // Cho phép nhập
            txtPassportNumber.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            txtPassportNumber.ForeColor = textColor;

            txtTrangThai.BorderStyle = BorderStyle.FixedSingle;
            txtTrangThai.BackColor = lightBgColor;
            txtTrangThai.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            txtTrangThai.ForeColor = textColor;

            // Tùy chỉnh DateTimePicker
            dtpIssueDate.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            dtpExpiryDate.Font = new Font("Segoe UI", 11F, FontStyle.Regular);

            // Tùy chỉnh Button "Cấp hộ chiếu"
            btnIssue.BackColor = primaryColor;
            btnIssue.FlatAppearance.BorderSize = 0;
            btnIssue.ForeColor = textLightColor;
            btnIssue.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnIssue.Cursor = Cursors.Hand;
            btnIssue.TextAlign = ContentAlignment.MiddleCenter;

            // Tùy chỉnh Button "Kiểm tra xác thực"
            btnVerify.BackColor = successColor;
            btnVerify.FlatAppearance.BorderSize = 0;
            btnVerify.ForeColor = textLightColor;
            btnVerify.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            btnVerify.Cursor = Cursors.Hand;
            btnVerify.TextAlign = ContentAlignment.MiddleCenter;

            // Tùy chỉnh Button "Đăng xuất"
            btnBack.BackColor = Color.FromArgb(108, 117, 125);
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.ForeColor = Color.White;
            btnBack.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            btnBack.Cursor = Cursors.Hand;
            btnBack.TextAlign = ContentAlignment.MiddleCenter;

            // Tùy chỉnh Labels
            label1.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            label1.ForeColor = textColor;
            label2.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            label2.ForeColor = textColor;
            label3.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            label3.ForeColor = textColor;
            label6.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            label6.ForeColor = textColor;

            labelApprovedList.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            labelApprovedList.ForeColor = Color.FromArgb(52, 58, 64);

            labelHistory.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            labelHistory.ForeColor = Color.FromArgb(52, 58, 64);

            lblLog.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblLog.ForeColor = successColor;

            // Thêm hover effects
            AddButtonHoverEffects();
        }

        private void AddButtonHoverEffects()
        {
            // Hover effect cho btnIssue
            btnIssue.MouseEnter += (s, e) => btnIssue.BackColor = Color.FromArgb(0, 86, 179);
            btnIssue.MouseLeave += (s, e) => btnIssue.BackColor = primaryColor;

            // Hover effect cho btnVerify
            btnVerify.MouseEnter += (s, e) => btnVerify.BackColor = Color.FromArgb(34, 142, 58);
            btnVerify.MouseLeave += (s, e) => btnVerify.BackColor = successColor;

            // Hover effect cho btnBack
            btnBack.MouseEnter += (s, e) => btnBack.BackColor = Color.FromArgb(90, 98, 104);
            btnBack.MouseLeave += (s, e) => btnBack.BackColor = Color.FromArgb(108, 117, 125);
        }

        private void PassportIssueForm_Load(object sender, EventArgs e)
        {
            // Thiết lập TextBox
            txtPassportNumber.ReadOnly = false; // Cho phép nhập số hộ chiếu
            txtTrangThai.ReadOnly = true;

            // Thiết lập DateTimePicker với ngày mặc định theo yêu cầu
            dtpIssueDate.Format = DateTimePickerFormat.Custom;
            dtpIssueDate.CustomFormat = "dd/MM/yyyy";
            dtpIssueDate.Value = new DateTime(2025, 5, 14); // Mặc định: 14/05/2025

            dtpExpiryDate.Format = DateTimePickerFormat.Custom;
            dtpExpiryDate.CustomFormat = "dd/MM/yyyy";
            dtpExpiryDate.MinDate = DateTime.Today;
            dtpExpiryDate.MaxDate = new DateTime(2040, 12, 31);
            dtpExpiryDate.Value = new DateTime(2035, 5, 14); // Mặc định: 14/05/2035 (10 năm sau)

            // Load dữ liệu
            LoadApprovedApplications();
            LoadHistoryData();

            // Đăng ký events
            dgvApprovedApps.CellClick += dgvApprovedApps_CellContentClick;

            // Cập nhật log ban đầu
            lblLog.Text = "📋 Chọn hồ sơ từ danh sách để bắt đầu cấp hộ chiếu";
        }

        private void LoadApprovedApplications()
        {
            // Chỉ load những hồ sơ đã được duyệt
            query = @"SELECT r.ResidentID, r.CMND, r.FullName, r.DateOfBirth, r.Address, pa.Status, pa.ApplicationDate 
                     FROM ResidentData r 
                     INNER JOIN PassportApplications pa ON r.ResidentID = pa.ResidentID 
                     WHERE pa.Status = 'Đã duyệt'";

            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    approvedResidentTable = new DataTable();
                    da.Fill(approvedResidentTable);
                    dgvApprovedApps.DataSource = approvedResidentTable;
                }

                // Tùy chỉnh tên cột hiển thị
                if (dgvApprovedApps.Columns.Contains("ResidentID"))
                {
                    dgvApprovedApps.Columns["ResidentID"].Visible = false; // Ẩn cột ID
                }
                if (dgvApprovedApps.Columns.Contains("CMND"))
                    dgvApprovedApps.Columns["CMND"].HeaderText = "🆔 Số CCCD";
                if (dgvApprovedApps.Columns.Contains("FullName"))
                    dgvApprovedApps.Columns["FullName"].HeaderText = "👤 Họ và tên";
                if (dgvApprovedApps.Columns.Contains("DateOfBirth"))
                    dgvApprovedApps.Columns["DateOfBirth"].HeaderText = "📅 Ngày sinh";
                if (dgvApprovedApps.Columns.Contains("Address"))
                    dgvApprovedApps.Columns["Address"].HeaderText = "🏠 Địa chỉ";
                if (dgvApprovedApps.Columns.Contains("Status"))
                    dgvApprovedApps.Columns["Status"].HeaderText = "🔍 Trạng thái";
                if (dgvApprovedApps.Columns.Contains("ApplicationDate"))
                    dgvApprovedApps.Columns["ApplicationDate"].HeaderText = "📋 Ngày nộp đơn";

                lblLog.Text = $"✅ Đã tải {approvedResidentTable.Rows.Count} hồ sơ đã được duyệt";
                lblLog.ForeColor = successColor;
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi tải danh sách hồ sơ đã duyệt: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblLog.Text = "❌ Lỗi khi tải dữ liệu hồ sơ";
                lblLog.ForeColor = dangerColor;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void LoadHistoryData()
        {
            // Load lịch sử thay đổi trạng thái
            query = @"SELECT pa.ResidentID, r.FullName, pa.Status, pa.ApplicationDate, pa.Notes,
                            CASE 
                                WHEN pp.PassportNumber IS NOT NULL THEN 'Đã cấp hộ chiếu'
                                ELSE 'Chưa cấp hộ chiếu'
                            END as PassportStatus,
                            pp.IssueDate, pp.ExpiryDate
                     FROM PassportApplications pa
                     INNER JOIN ResidentData r ON pa.ResidentID = r.ResidentID
                     LEFT JOIN PassportData pp ON pa.ResidentID = pp.ResidentID
                     ORDER BY pa.ApplicationDate DESC";

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    historyTable = new DataTable();
                    da.Fill(historyTable);
                    dgvHistory.DataSource = historyTable;
                }

                // Tùy chỉnh tên cột hiển thị cho lịch sử
                if (dgvHistory.Columns.Contains("ResidentID"))
                    dgvHistory.Columns["ResidentID"].Visible = false;
                if (dgvHistory.Columns.Contains("FullName"))
                    dgvHistory.Columns["FullName"].HeaderText = "👤 Họ tên";
                if (dgvHistory.Columns.Contains("Status"))
                    dgvHistory.Columns["Status"].HeaderText = "📋 Trạng thái đơn";
                if (dgvHistory.Columns.Contains("ApplicationDate"))
                    dgvHistory.Columns["ApplicationDate"].HeaderText = "📅 Ngày nộp";
                if (dgvHistory.Columns.Contains("PassportStatus"))
                    dgvHistory.Columns["PassportStatus"].HeaderText = "🛂 Tình trạng HC";
                if (dgvHistory.Columns.Contains("IssueDate"))
                    dgvHistory.Columns["IssueDate"].HeaderText = "📅 Ngày cấp HC";
                if (dgvHistory.Columns.Contains("ExpiryDate"))
                    dgvHistory.Columns["ExpiryDate"].HeaderText = "⏰ Ngày hết hạn";
                if (dgvHistory.Columns.Contains("Notes"))
                    dgvHistory.Columns["Notes"].HeaderText = "📝 Ghi chú";
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi tải lịch sử: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void dgvApprovedApps_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                try
                {
                    selectedRow = dgvApprovedApps.Rows[e.RowIndex];
                    string residentId = selectedRow.Cells["ResidentID"].Value.ToString();
                    string fullName = selectedRow.Cells["FullName"].Value.ToString();
                    string status = selectedRow.Cells["Status"].Value.ToString();

                    // Hiển thị thông tin
                    txtTrangThai.Text = status;

                    // Auto-generate số hộ chiếu nhưng cho phép chỉnh sửa
                    txtPassportNumber.Text = GeneratePassportNumber(residentId);

                    // Cập nhật log
                    lblLog.Text = $"📋 Đã chọn hồ sơ của {fullName} - Trạng thái: {status}";
                    lblLog.ForeColor = primaryColor;

                    // Kiểm tra xem đã cấp hộ chiếu chưa
                    CheckExistingPassport(residentId, fullName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Lỗi khi chọn hồ sơ: " + ex.Message, "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lblLog.Text = "❌ Lỗi khi tải thông tin hồ sơ";
                    lblLog.ForeColor = dangerColor;
                }
            }
        }

        private void CheckExistingPassport(string residentId, string fullName)
        {
            query = "SELECT PassportNumber, IssueDate, ExpiryDate FROM PassportData WHERE ResidentID = @ResidentID";

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ResidentID", residentId);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Đã có hộ chiếu
                        txtPassportNumber.Text = reader["PassportNumber"].ToString();
                        dtpIssueDate.Value = Convert.ToDateTime(reader["IssueDate"]);
                        dtpExpiryDate.Value = Convert.ToDateTime(reader["ExpiryDate"]);

                        lblLog.Text = $"⚠️ {fullName} đã được cấp hộ chiếu số {reader["PassportNumber"]}";
                        lblLog.ForeColor = warningColor;

                        btnIssue.Text = "🔄 Cập nhật hộ chiếu";
                    }
                    else
                    {
                        // Chưa có hộ chiếu
                        lblLog.Text = $"✅ {fullName} chưa được cấp hộ chiếu - Sẵn sàng cấp mới";
                        lblLog.ForeColor = successColor;

                        btnIssue.Text = "🛂 Cấp hộ chiếu";
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi kiểm tra hộ chiếu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private string GeneratePassportNumber(string residentId)
        {
            // Tạo số hộ chiếu theo format VN + ResidentID với padding
            int paddingLength = Math.Max(6, 8 - residentId.Length);
            return "VN" + residentId.PadLeft(paddingLength, '0');
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (dgvApprovedApps.SelectedRows.Count == 0)
            {
                MessageBox.Show("⚠️ Vui lòng chọn hồ sơ cần kiểm tra", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string fullName = selectedRow.Cells["FullName"].Value.ToString();
                string status = txtTrangThai.Text;
                string passportNumber = txtPassportNumber.Text.Trim();

                // Kiểm tra các điều kiện
                List<string> issues = new List<string>();

                if (status != "Đã duyệt")
                {
                    issues.Add($"- Trạng thái không hợp lệ: {status}");
                }

                if (string.IsNullOrEmpty(passportNumber))
                {
                    issues.Add("- Chưa nhập số hộ chiếu");
                }
                else if (!passportNumber.StartsWith("VN") || passportNumber.Length < 8)
                {
                    issues.Add("- Số hộ chiếu không đúng định dạng (VN + ít nhất 6 số)");
                }

                if (dtpExpiryDate.Value <= dtpIssueDate.Value)
                {
                    issues.Add("- Ngày hết hạn phải sau ngày cấp");
                }

                if (issues.Count > 0)
                {
                    string message = $"❌ Phát hiện các vấn đề với hồ sơ của {fullName}:\n\n" + string.Join("\n", issues);
                    MessageBox.Show(message, "Kiểm tra không thành công", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblLog.Text = $"❌ Kiểm tra thất bại - {fullName} có {issues.Count} vấn đề";
                    lblLog.ForeColor = dangerColor;
                }
                else
                {
                    MessageBox.Show($"✅ Hồ sơ của {fullName} đã được xác thực thành công!\n\n" +
                                  $"📋 Thông tin hộ chiếu:\n" +
                                  $"🛂 Số hộ chiếu: {passportNumber}\n" +
                                  $"📅 Ngày cấp: {dtpIssueDate.Value:dd/MM/yyyy}\n" +
                                  $"⏰ Ngày hết hạn: {dtpExpiryDate.Value:dd/MM/yyyy}\n\n" +
                                  $"Sẵn sàng cấp hộ chiếu!",
                        "Xác thực thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lblLog.Text = $"✅ Xác thực thành công - {fullName} sẵn sàng cấp hộ chiếu {passportNumber}";
                    lblLog.ForeColor = successColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi kiểm tra xác thực: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblLog.Text = "❌ Lỗi khi kiểm tra xác thực";
                lblLog.ForeColor = dangerColor;
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (dgvApprovedApps.SelectedRows.Count == 0)
            {
                MessageBox.Show("⚠️ Vui lòng chọn hồ sơ cần cấp hộ chiếu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                string residentId = selectedRow.Cells["ResidentID"].Value.ToString();
                string fullName = selectedRow.Cells["FullName"].Value.ToString();
                string passportNumber = txtPassportNumber.Text.Trim();
                DateTime issueDate = dtpIssueDate.Value;
                DateTime expiryDate = dtpExpiryDate.Value;

                // Validate dữ liệu
                if (string.IsNullOrEmpty(passportNumber))
                {
                    MessageBox.Show("⚠️ Vui lòng nhập số hộ chiếu", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (expiryDate <= issueDate)
                {
                    MessageBox.Show("⚠️ Ngày hết hạn phải sau ngày cấp", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra xem số hộ chiếu đã tồn tại chưa
                if (IsPassportNumberExists(passportNumber, residentId))
                {
                    MessageBox.Show($"⚠️ Số hộ chiếu {passportNumber} đã tồn tại trong hệ thống", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lưu vào database
                bool success = SavePassportToDatabase(residentId, passportNumber, issueDate, expiryDate);

                if (success)
                {
                    MessageBox.Show($"✅ Đã cấp hộ chiếu thành công!\n\n" +
                                  $"👤 Họ tên: {fullName}\n" +
                                  $"🛂 Số hộ chiếu: {passportNumber}\n" +
                                  $"📅 Ngày cấp: {issueDate:dd/MM/yyyy}\n" +
                                  $"⏰ Ngày hết hạn: {expiryDate:dd/MM/yyyy}",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string logTime = DateTime.Now.ToString("HH:mm tt, dd/MM/yyyy");
                    lblLog.Text = $"✅ Cấp hộ chiếu {passportNumber} cho {fullName} lúc {logTime}";
                    lblLog.ForeColor = successColor;

                    // Refresh data
                    LoadHistoryData();
                    btnIssue.Text = "🔄 Cập nhật hộ chiếu";
                }
                else
                {
                    lblLog.Text = "❌ Lỗi khi cấp hộ chiếu";
                    lblLog.ForeColor = dangerColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi cấp hộ chiếu: {ex.Message}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblLog.Text = "❌ Lỗi khi cấp hộ chiếu";
                lblLog.ForeColor = dangerColor;
            }
        }

        private bool IsPassportNumberExists(string passportNumber, string currentResidentId)
        {
            query = "SELECT COUNT(*) FROM PassportData WHERE PassportNumber = @PassportNumber AND ResidentID != @ResidentID";

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@PassportNumber", passportNumber);
                    cmd.Parameters.AddWithValue("@ResidentID", currentResidentId);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi kiểm tra số hộ chiếu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // Trả về true để an toàn
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private bool SavePassportToDatabase(string residentId, string passportNumber, DateTime issueDate, DateTime expiryDate)
        {
            // Kiểm tra xem đã có hộ chiếu chưa để quyết định INSERT hay UPDATE
            query = "SELECT COUNT(*) FROM PassportData WHERE ResidentID = @ResidentID";

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                using (SqlCommand checkCmd = new SqlCommand(query, con))
                {
                    checkCmd.Parameters.AddWithValue("@ResidentID", residentId);
                    int existingCount = (int)checkCmd.ExecuteScalar();

                    if (existingCount > 0)
                    {
                        // UPDATE existing passport
                        query = @"UPDATE PassportData 
                                 SET PassportNumber = @PassportNumber, 
                                     IssueDate = @IssueDate, 
                                     ExpiryDate = @ExpiryDate,
                                     UpdatedAt = GETDATE()
                                 WHERE ResidentID = @ResidentID";
                    }
                    else
                    {
                        // INSERT new passport
                        query = @"INSERT INTO PassportData (ResidentID, PassportNumber, IssueDate, ExpiryDate, CreatedAt) 
                                 VALUES (@ResidentID, @PassportNumber, @IssueDate, @ExpiryDate, GETDATE())";
                    }
                }

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@ResidentID", residentId);
                    cmd.Parameters.AddWithValue("@PassportNumber", passportNumber);
                    cmd.Parameters.AddWithValue("@IssueDate", issueDate);
                    cmd.Parameters.AddWithValue("@ExpiryDate", expiryDate);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi khi lưu hộ chiếu vào database: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new Menu().Show();
            this.Hide();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }
    }
}