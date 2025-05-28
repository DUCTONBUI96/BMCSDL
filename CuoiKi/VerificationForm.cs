using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Layer;
using Data_Layer.NewFolder1;

namespace CuoiKi
{
    public partial class VerificationForm : Form
    {
        // Định nghĩa màu sắc chung cho ứng dụng - Màu xanh dương (giống AdminForm)
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
        ApplicationService applicationService = new ApplicationService();
        DataTable residentTable = new DataTable();

        public VerificationForm()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        private void CustomizeDesign()
        {
            // Tùy chỉnh form
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Xác thực hồ sơ CCCD";
            this.BackColor = Color.White;

            // Tùy chỉnh panel
            panel1.BackColor = primaryColor;
            label1.ForeColor = textLightColor;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);

            // Tùy chỉnh DataGridView
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

            // Tùy chỉnh header style - Tăng chiều cao và không wrap text
            dgvApplications.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
            dgvApplications.ColumnHeadersDefaultCellStyle.ForeColor = textLightColor;
            dgvApplications.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvApplications.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvApplications.ColumnHeadersHeight = 50;

            // Tùy chỉnh cell style
            dgvApplications.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvApplications.DefaultCellStyle.ForeColor = textColor;
            dgvApplications.DefaultCellStyle.SelectionBackColor = primaryLightColor;
            dgvApplications.DefaultCellStyle.SelectionForeColor = primaryColor;
            dgvApplications.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvApplications.RowTemplate.Height = 35;

            // Tùy chỉnh buttons với text alignment
            btnViewDetails.BackColor = primaryColor;
            btnViewDetails.FlatAppearance.BorderSize = 0;
            btnViewDetails.ForeColor = textLightColor;
            btnViewDetails.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnViewDetails.Cursor = Cursors.Hand;
            btnViewDetails.TextAlign = ContentAlignment.MiddleCenter;

            btnBack.BackColor = Color.FromArgb(108, 117, 125);
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.ForeColor = Color.White;
            btnBack.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            btnBack.Cursor = Cursors.Hand;
            btnBack.TextAlign = ContentAlignment.MiddleCenter;

            btnRefresh.BackColor = successColor;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.ForeColor = textLightColor;
            btnRefresh.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.TextAlign = ContentAlignment.MiddleCenter;

            // Tùy chỉnh label
            lblResult.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            lblResult.ForeColor = textColor;

            // Hover effect cho buttons
            AddButtonHoverEffects();
        }

        private void AddButtonHoverEffects()
        {
            // Hover effect cho btnViewDetails
            btnViewDetails.MouseEnter += (s, e) => btnViewDetails.BackColor = Color.FromArgb(0, 86, 179);
            btnViewDetails.MouseLeave += (s, e) => btnViewDetails.BackColor = primaryColor;

            // Hover effect cho btnBack
            btnBack.MouseEnter += (s, e) => btnBack.BackColor = Color.FromArgb(90, 98, 104);
            btnBack.MouseLeave += (s, e) => btnBack.BackColor = Color.FromArgb(108, 117, 125);

            // Hover effect cho btnRefresh
            btnRefresh.MouseEnter += (s, e) => btnRefresh.BackColor = Color.FromArgb(34, 142, 58);
            btnRefresh.MouseLeave += (s, e) => btnRefresh.BackColor = successColor;
        }

        private void VerificationForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                residentTable = residentService.GetAllResidentForEachUser(2, "SP_ListAllPassportRegistrations");

                // Thêm cột trạng thái nếu chưa có
                if (!residentTable.Columns.Contains("Status"))
                {
                    residentTable.Columns.Add("Status", typeof(string));
                }

                dgvApplications.DataSource = residentTable;

                // Ẩn cột SensitivityLevel nếu có
                if (dgvApplications.Columns.Contains("SensitivityLevel"))
                {
                    dgvApplications.Columns["SensitivityLevel"].Visible = false;
                }

                // Ẩn cột ResidentID
                if (dgvApplications.Columns.Contains("ResidentID"))
                {
                    dgvApplications.Columns["ResidentID"].Visible = false;
                }

                // Tùy chỉnh tên cột hiển thị
                CustomizeColumnHeaders();

                // Tùy chỉnh độ rộng cột để tránh text bị wrap
                SetColumnWidths();

                // Tùy chỉnh màu sắc cho cột trạng thái
                CustomizeStatusColumn();

                // Đếm số lượng theo trạng thái
                int totalRecords = residentTable.Rows.Count;
                int verifiedCount = residentTable.AsEnumerable().Count(row => row.Field<string>("Status") == "Đã xác thực");
                int pendingCount = totalRecords - verifiedCount;

                lblResult.Text = $"Tổng số hồ sơ: {totalRecords} |Đã xác thực: {verifiedCount} | Chưa xác thực: {pendingCount}";
                lblResult.ForeColor = successColor;
            }
            catch (Exception ex)
            {
                lblResult.Text = $"❌ Lỗi khi tải dữ liệu: {ex.Message}";
                lblResult.ForeColor = dangerColor;
            }
        }

        private void CustomizeColumnHeaders()
        {
            var columnMappings = new Dictionary<string, string>
            {
                {"FullName", "👤 Họ và tên"},
                {"CMND", "🆔 Số CCCD"},
                {"Gender", "⚥ Giới tính"},
                {"DateOfBirth", "📅 Ngày sinh"},
                {"Address", "🏠 Địa chỉ"},
                {"Nationality", "🌍 Quốc tịch"},
                {"PhoneNumber", "📞 Số điện thoại"},
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
        }

        private void SetColumnWidths()
        {
            // Đặt AutoSizeColumnsMode về None để có thể tùy chỉnh độ rộng
            dgvApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Tùy chỉnh độ rộng từng cột
            var columnWidths = new Dictionary<string, int>
            {
                {"FullName", 160},
                {"CMND", 110},
                {"Gender", 90},
                {"DateOfBirth", 110},
                {"Address", 220},
                {"Nationality", 100},
                {"PhoneNumber", 130},
                {"Email", 180},
                {"CreatedAt", 130},
                {"Status", 120}
            };

            foreach (var columnWidth in columnWidths)
            {
                if (dgvApplications.Columns.Contains(columnWidth.Key))
                {
                    dgvApplications.Columns[columnWidth.Key].Width = columnWidth.Value;
                }
            }
        }

        private void CustomizeStatusColumn()
        {
            if (dgvApplications.Columns.Contains("Status"))
            {
                // Đặt cột Status ở cuối
                dgvApplications.Columns["Status"].DisplayIndex = dgvApplications.Columns.Count - 1;

                // Tùy chỉnh style cho cột Status
                dgvApplications.Columns["Status"].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                dgvApplications.Columns["Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dgvApplications_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Tùy chỉnh màu sắc cho cột Status
            if (dgvApplications.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();

                if (status == "Đã xác thực")
                {
                    e.CellStyle.ForeColor = successColor;
                    e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    e.Value = "✅ Đã xác thực";
                }
                else if (status == "Từ chối")
                {
                    e.CellStyle.ForeColor = dangerColor;
                    e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    e.Value = "❌ Từ chối";
                }
                else
                {
                    e.CellStyle.ForeColor = warningColor;
                    e.CellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    e.Value = "⏳ Chưa xác thực";
                }
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 0)
            {
                MessageBox.Show("⚠️ Vui lòng chọn hồ sơ cần xem chi tiết", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowDetailDialog();
        }

        private void ShowDetailDialog()
        {
            DataGridViewRow selectedRow = dgvApplications.SelectedRows[0];

            // Lấy thông tin từ row được chọn
            string residentId = selectedRow.Cells["ResidentID"].Value?.ToString() ?? "";
            string fullName = selectedRow.Cells["FullName"].Value?.ToString() ?? "";
            string cccd = selectedRow.Cells["CMND"].Value?.ToString() ?? "";
            string gender = selectedRow.Cells["Gender"].Value?.ToString() ?? "";
            string dob = selectedRow.Cells["DateOfBirth"].Value?.ToString() ?? "";
            string address = selectedRow.Cells["Address"].Value?.ToString() ?? "";
            string nationality ="Viet Nam";
            string phone = selectedRow.Cells["PhoneNumber"].Value?.ToString() ?? "";
            string email = selectedRow.Cells["Email"].Value?.ToString() ?? "";
            //string createdAt = selectedRow.Cells["CreatedAt"].Value?.ToString() ?? "";
            string currentStatus = selectedRow.Cells["Status"].Value?.ToString() ?? "";

            // Tạo form chi tiết với các nút xác thực
            Form detailForm = new Form
            {
                Text = "Chi tiết hồ sơ",
                Size = new Size(600, 550),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                BackColor = Color.White
            };

            // Panel header
            Panel headerPanel = new Panel
            {
                BackColor = primaryColor,
                Dock = DockStyle.Top,
                Height = 60
            };

            Label headerLabel = new Label
            {
                Text = "📋 THÔNG TIN CHI TIẾT HỒ SƠ",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 15),
                AutoSize = true
            };

            headerPanel.Controls.Add(headerLabel);
            detailForm.Controls.Add(headerPanel);

            // Panel nội dung
            Panel contentPanel = new Panel
            {
                Location = new Point(20, 80),
                Size = new Size(540, 320),
                BackColor = lightBgColor,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Hiển thị trạng thái hiện tại với màu sắc
            string statusDisplay = "";
            Color statusColor = textColor;

            if (currentStatus.Contains("Đã xác thực"))
            {
                statusDisplay = "✅ Đã xác thực";
                statusColor = successColor;
            }
            else if (currentStatus.Contains("Từ chối"))
            {
                statusDisplay = "❌ Từ chối";
                statusColor = dangerColor;
            }
            else
            {
                statusDisplay = "⏳ Chưa xác thực";
                statusColor = warningColor;
            }

            string detailText = $"👤 Họ và tên: {fullName}\n\n" +
                              $"🆔 Số CCCD: {cccd}\n\n" +
                              $"⚥ Giới tính: {gender}\n\n" +
                              $"📅 Ngày sinh: {dob}\n\n" +
                              $"🏠 Địa chỉ: {address}\n\n" +
                              $"🌍 Quốc tịch: {nationality}\n\n" +
                              $"📞 Số điện thoại: {phone}\n\n" +
                              $"📧 Email: {email}\n\n" +
                              //$"⏰ Ngày tạo: {createdAt}\n\n" +
                              $"🔍 Trạng thái hiện tại: ";

            Label detailLabel = new Label
            {
                Text = detailText,
                Font = new Font("Segoe UI", 10),
                ForeColor = textColor,
                Location = new Point(15, 15),
                Size = new Size(510, 280),
                AutoSize = false
            };

            Label statusLabel = new Label
            {
                Text = statusDisplay,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = statusColor,
                Location = new Point(200, 280),
                AutoSize = true
            };

            contentPanel.Controls.Add(detailLabel);
            contentPanel.Controls.Add(statusLabel);
            detailForm.Controls.Add(contentPanel);

            // Buttons
           
            Button btnApprove = new Button
            {
                Text = "✅ Xác thực",
                BackColor = successColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Size = new Size(120, 40),
                Location = new Point(150, 420),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter

            };
        
        btnApprove.Click += (sender, e) =>
            {
               
                try
                {
                // Lấy RegistrationID từ form (ví dụ: txtRegistrationID.Text)
                int registrationId = int.Parse(residentId);


                // Gọi stored procedure
                string result = residentService.Registration(registrationId, "Xác thực hồ sơ");

                // Hiển thị kết quả
                MessageBox.Show(result, "Kết quả", MessageBoxButtons.OK,
                                            result.Contains("thành công") ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };
            // Thêm button vào form
            this.Controls.Add(btnApprove);

            btnApprove.FlatAppearance.BorderSize = 0;

            Button btnReject = new Button
            {

                
                Text = "❌ Từ chối",
                BackColor = dangerColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Size = new Size(120, 40),
                Location = new Point(290, 420),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter


            };

            btnApprove.Click += (sender, e) =>
            {
                try
                {
                    // Lấy RegistrationID từ form (ví dụ: txtRegistrationID.Text)
                    int registrationId = int.Parse(residentId);

                    // Gọi stored procedure
                    string result = residentService.Registration(registrationId, "Từ chốihồ sơ");

                    // Hiển thị kết quả
                    MessageBox.Show(result, "Kết quả", MessageBoxButtons.OK,
                                                result.Contains("thành công") ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            // Thêm button vào form
            btnReject.FlatAppearance.BorderSize = 0;

            Button btnClose = new Button
            {
                Text = "🔙 Đóng",
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11),
                Size = new Size(120, 40),
                Location = new Point(430, 420),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter
            };
            btnClose.FlatAppearance.BorderSize = 0;

            // Event handlers
            btnApprove.Click += (s, e) => {
                try
                {
                    int id = int.Parse(residentId);
                    applicationService.UpdateStatus(id, "Đã xác thực");
                    MessageBox.Show($"✅ Đã xác thực thành công hồ sơ của {fullName}!",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    detailForm.Close();
                    LoadData(); // Refresh data
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Lỗi khi xác thực: {ex.Message}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            btnReject.Click += (s, e) => {
                try
                {
                    int id = int.Parse(residentId);
                    applicationService.UpdateStatus(id, "Từ chối");
                    MessageBox.Show($"❌ Đã từ chối hồ sơ của {fullName}!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    detailForm.Close();
                    LoadData(); // Refresh data
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"❌ Lỗi khi từ chối: {ex.Message}",
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            btnClose.Click += (s, e) => detailForm.Close();

            detailForm.Controls.AddRange(new Control[] { btnApprove, btnReject, btnClose });
            detailForm.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
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

        private void button1_Click(object sender, EventArgs e)
        {
            new ResidentListForm().Show();
        }
    }
}