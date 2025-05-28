using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Layer;

namespace CuoiKi
{
    public partial class NotificationForm : Form
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

        ResidentService residentService = new ResidentService();
        DataTable dt = new DataTable();

        public NotificationForm()
        {
            InitializeComponent();
            CustomizeDesign();
            SetupPlaceholder();
        }

        private void CustomizeDesign()
        {
            // Tùy chỉnh form chính
            this.BackColor = Color.White;
            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.Text = "📢 Quản lý Thông báo";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.Size = new Size(1000, 650); // Kích thước vừa phải

            // Tùy chỉnh DataGridView
            dgvResidentsOrApps.BackgroundColor = Color.White;
            dgvResidentsOrApps.BorderStyle = BorderStyle.None;
            dgvResidentsOrApps.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvResidentsOrApps.DefaultCellStyle.SelectionBackColor = primaryLightColor;
            dgvResidentsOrApps.DefaultCellStyle.SelectionForeColor = textColor;
            dgvResidentsOrApps.DefaultCellStyle.BackColor = Color.White;
            dgvResidentsOrApps.DefaultCellStyle.ForeColor = textColor;
            dgvResidentsOrApps.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgvResidentsOrApps.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
            dgvResidentsOrApps.ColumnHeadersDefaultCellStyle.ForeColor = textLightColor;
            dgvResidentsOrApps.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvResidentsOrApps.ColumnHeadersHeight = 40;
            dgvResidentsOrApps.RowTemplate.Height = 35;
            dgvResidentsOrApps.EnableHeadersVisualStyles = false;
            dgvResidentsOrApps.AllowUserToAddRows = false;
            dgvResidentsOrApps.AllowUserToDeleteRows = false;
            dgvResidentsOrApps.ReadOnly = true;
            dgvResidentsOrApps.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResidentsOrApps.MultiSelect = false;

            // Tùy chỉnh ComboBox
            cboStatusFilter.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            cboStatusFilter.BackColor = Color.White;
            cboStatusFilter.ForeColor = textColor;
            cboStatusFilter.FlatStyle = FlatStyle.Flat;

            // Tùy chỉnh CheckBoxes
            CustomizeCheckBox(chkEmail, "📧 Email");
            CustomizeCheckBox(chkSMS, "📱 SMS");
            CustomizeCheckBox(chkCaHai, "📧📱 Cả hai");

            // Tùy chỉnh RichTextBox
            txtMessage.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtMessage.BackColor = Color.White;
            txtMessage.ForeColor = textColor;
            txtMessage.BorderStyle = BorderStyle.FixedSingle;

            // Tùy chỉnh Button
            CustomizeButton(btnSendNotification, "📤 Gửi thông báo", successColor);

            // Tùy chỉnh Labels
            CustomizeLabel(label1, "📝 Nội dung thông báo:");
            CustomizeLabel(label2, "📬 Phương thức gửi:");
            CustomizeLabel(lblSendStatus, "📊 Trạng thái gửi:");

            // Thêm label tiêu đề
            Label titleLabel = new Label();
            titleLabel.Text = "📢 QUẢN LÝ THÔNG BÁO";
            titleLabel.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            titleLabel.ForeColor = primaryColor;
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(20, 20);
            this.Controls.Add(titleLabel);
            titleLabel.BringToFront();

            // Thêm đường phân cách
            Panel separatorPanel = new Panel();
            separatorPanel.BackColor = primaryLightColor;
            separatorPanel.Height = 2;
            separatorPanel.Location = new Point(20, 55);
            separatorPanel.Width = this.Width - 60;
            separatorPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(separatorPanel);
        }

        private void CustomizeCheckBox(CheckBox checkBox, string text)
        {
            checkBox.Text = text;
            checkBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            checkBox.ForeColor = textColor;
            checkBox.FlatStyle = FlatStyle.Flat;
            checkBox.FlatAppearance.BorderColor = primaryColor;
            checkBox.FlatAppearance.CheckedBackColor = primaryLightColor;
        }

        private void CustomizeButton(Button button, string text, Color backColor)
        {
            button.Text = text;
            button.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            button.BackColor = backColor;
            button.ForeColor = textLightColor;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Cursor = Cursors.Hand;
            button.Height = 40;

            // Thêm hover effects
            button.MouseEnter += (s, e) => {
                button.BackColor = ControlPaint.Dark(backColor, 0.1f);
            };
            button.MouseLeave += (s, e) => {
                button.BackColor = backColor;
            };
        }

        private void CustomizeLabel(Label label, string text)
        {
            label.Text = text;
            label.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            label.ForeColor = textColor;
            label.AutoSize = true;
        }

        private void SetupPlaceholder()
        {
            txtMessage.Text = "💬 Nhập nội dung thông báo tại đây...";
            txtMessage.ForeColor = Color.Gray;
            txtMessage.GotFocus += RemovePlaceholder;
            txtMessage.LostFocus += SetPlaceholder;
        }

        //làm mờ nội dung textbox
        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (txtMessage.ForeColor == Color.Gray)
            {
                txtMessage.Text = "";
                txtMessage.ForeColor = textColor;
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                txtMessage.Text = "💬 Nhập nội dung thông báo tại đây...";
                txtMessage.ForeColor = Color.Gray;
            }
        }

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            // Thiết lập ComboBox filter
            cboStatusFilter.Items.Clear();
            cboStatusFilter.Items.Add("📋 Tất cả trạng thái");
            cboStatusFilter.Items.Add("⏳ Chờ xét duyệt");
            cboStatusFilter.Items.Add("✅ Đã duyệt");
            cboStatusFilter.Items.Add("❌ Từ chối");

            // Thiết lập mục mặc định
            cboStatusFilter.SelectedIndex = 0; // "Tất cả trạng thái"

            // Load dữ liệu
            LoadResidentData();

            // Thiết lập mặc định cho checkbox
            chkEmail.Checked = true;
        }

        private void LoadResidentData()
        {
            try
            {
                dt = residentService.GetAllResidentForEachUser(3, "SP_ListAllApplicationsForXD");
                dgvResidentsOrApps.DataSource = dt;

                // Tùy chỉnh header columns và ẩn các cột không cần thiết
                if (dgvResidentsOrApps.Columns.Count > 0)
                {
                    foreach (DataGridViewColumn column in dgvResidentsOrApps.Columns)
                    {
                        // Ẩn cột SensitiveLevel nếu có
                        if (column.Name.ToLower().Contains("sensitive") ||
                            column.Name.ToLower().Contains("level"))
                        {
                            column.Visible = false;
                            continue;
                        }

                        column.HeaderText = GetFriendlyColumnName(column.Name);
                    }

                    // Ẩn các cột không cần thiết khác
                    if (dgvResidentsOrApps.Columns["SensitiveLevel"] != null)
                        dgvResidentsOrApps.Columns["SensitiveLevel"].Visible = false;

                    if (dgvResidentsOrApps.Columns["SensitiveLevelId"] != null)
                        dgvResidentsOrApps.Columns["SensitiveLevelId"].Visible = false;
                }

                // Hiển thị thông tin
                lblSendStatus.Text = $"📊 Tổng số bản ghi: {dt.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetFriendlyColumnName(string columnName)
        {
            switch (columnName.ToLower())
            {
                case "id": return "🆔 ID";
                case "name":
                case "fullname":
                case "hoten": return "👤 Họ tên";
                case "email": return "📧 Email";
                case "phone":
                case "phonenumber":
                case "sdt": return "📱 Điện thoại";
                case "status":
                case "trangthai": return "📊 Trạng thái";
                case "createdate":
                case "ngaytao": return "📅 Ngày tạo";
                case "address":
                case "diachi": return "🏠 Địa chỉ";
                case "cccd":
                case "cmnd": return "🆔 CCCD/CMND";
                // Bỏ qua các trường sensitive
                case "sensitive":
                case "sensitivelevel":
                case "sensitivelevelid":
                    return null; // Sẽ được ẩn
                default: return columnName;
            }
        }

        private void chkEmail_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkEmail.Checked)
            {
                chkSMS.Enabled = false;
                chkCaHai.Enabled = false;
                chkSMS.Checked = false;
                chkCaHai.Checked = false;
            }
            else
            {
                chkSMS.Enabled = true;
                chkCaHai.Enabled = true;
            }
        }

        private void chkSMS_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkSMS.Checked)
            {
                chkEmail.Enabled = false;
                chkCaHai.Enabled = false;
                chkEmail.Checked = false;
                chkCaHai.Checked = false;
            }
            else
            {
                chkEmail.Enabled = true;
                chkCaHai.Enabled = true;
            }
        }

        private void chkCaHai_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkCaHai.Checked)
            {
                chkEmail.Enabled = false;
                chkSMS.Enabled = false;
                chkEmail.Checked = false;
                chkSMS.Checked = false;
            }
            else
            {
                chkEmail.Enabled = true;
                chkSMS.Enabled = true;
            }
        }

        private void btnSendNotification_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra có dòng nào được chọn không
                if (dgvResidentsOrApps.CurrentRow == null)
                {
                    MessageBox.Show("⚠️ Vui lòng chọn một người dân để gửi thông báo!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra nội dung thông báo
                string message = txtMessage.Text.Trim();
                if (string.IsNullOrEmpty(message) || message == "💬 Nhập nội dung thông báo tại đây...")
                {
                    MessageBox.Show("⚠️ Vui lòng nhập nội dung thông báo!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMessage.Focus();
                    return;
                }

                // Kiểm tra phương thức gửi
                if (!chkEmail.Checked && !chkSMS.Checked && !chkCaHai.Checked)
                {
                    MessageBox.Show("⚠️ Vui lòng chọn phương thức gửi thông báo!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy thông tin email
                string email = dgvResidentsOrApps.CurrentRow.Cells["Email"].Value?.ToString();
                if (string.IsNullOrEmpty(email))
                {
                    MessageBox.Show("⚠️ Người dân được chọn không có địa chỉ email!", "Cảnh báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị dialog xác nhận
                string confirmMessage = $"📤 Bạn có chắc chắn muốn gửi thông báo đến:\n" +
                                      $"📧 Email: {email}\n" +
                                      $"📝 Nội dung: {message.Substring(0, Math.Min(50, message.Length))}...";

                DialogResult result = MessageBox.Show(confirmMessage, "Xác nhận gửi thông báo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Gửi thông báo
                    bool success = false;

                    if (chkEmail.Checked || chkCaHai.Checked)
                    {
                        success = residentService.NotificationByEmail(email, message);
                    }

                    if (chkSMS.Checked || chkCaHai.Checked)
                    {
                        // TODO: Implement SMS sending
                        // success = residentService.NotificationBySMS(phone, message);
                    }

                    if (success)
                    {
                        MessageBox.Show("✅ Gửi thông báo thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        lblSendStatus.Text = $"✅ Đã gửi thành công đến: {email} lúc {DateTime.Now:HH:mm:ss}";
                        lblSendStatus.ForeColor = successColor;

                        // Reset form
                        txtMessage.Text = "💬 Nhập nội dung thông báo tại đây...";
                        txtMessage.ForeColor = Color.Gray;
                    }
                    else
                    {
                        MessageBox.Show("❌ Không thể gửi thông báo! Vui lòng kiểm tra lại.", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);

                        lblSendStatus.Text = $"❌ Gửi thất bại đến: {email} lúc {DateTime.Now:HH:mm:ss}";
                        lblSendStatus.ForeColor = dangerColor;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi gửi thông báo: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                lblSendStatus.Text = $"❌ Lỗi hệ thống lúc {DateTime.Now:HH:mm:ss}";
                lblSendStatus.ForeColor = dangerColor;
            }
        }

        private void cboStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                // TODO: Implement filtering logic based on selected status
                string selectedStatus = cboStatusFilter.SelectedItem?.ToString();

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataView dv = dt.DefaultView;

                    switch (cboStatusFilter.SelectedIndex)
                    {
                        case 0: // Tất cả
                            dv.RowFilter = "";
                            break;
                        case 1: // Chờ xét duyệt
                            dv.RowFilter = "Status = 'Pending' OR Status = 'Chờ xét'";
                            break;
                        case 2: // Đã duyệt
                            dv.RowFilter = "Status = 'Approved' OR Status = 'Đã duyệt'";
                            break;
                        case 3: // Từ chối
                            dv.RowFilter = "Status = 'Rejected' OR Status = 'Từ chối'";
                            break;
                    }

                    lblSendStatus.Text = $"📊 Hiển thị: {dv.Count} / {dt.Rows.Count} bản ghi";
                    lblSendStatus.ForeColor = textColor;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Lỗi khi lọc dữ liệu: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "🚪 Bạn có chắc chắn muốn đóng form thông báo không?",
                "Xác nhận đóng",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                // Quay về Menu
                new Menu().Show();
            }

            base.OnFormClosing(e);
        }
    }
}