using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Layer;

namespace CuoiKi
{
    
    public partial class ResidentListForm : Form
    {
        // Định nghĩa màu sắc chung cho ứng dụng - Màu xanh dương (giống VerificationForm)
        private Color primaryColor = Color.FromArgb(0, 122, 204);      // Màu xanh dương chính
        private Color primaryDarkColor = Color.FromArgb(0, 102, 204);  // Màu xanh dương đậm
        private Color primaryLightColor = Color.FromArgb(229, 241, 255); // Màu xanh dương nhạt
        private Color accentColor = Color.FromArgb(0, 153, 255);       // Màu nhấn
        private Color textColor = Color.FromArgb(51, 51, 51);          // Màu chữ
        private Color textLightColor = Color.White;                    // Màu chữ sáng
        private Color lightBgColor = Color.FromArgb(248, 249, 250);    // Màu nền nhạt
        private Color successColor = Color.FromArgb(40, 167, 69);      // Màu xanh lá (thành công)
        private Color warningColor = Color.FromArgb(255, 193, 7);      // Màu vàng (cảnh báo)

        ResidentService residentService = new ResidentService();
        DataTable residentTable = new DataTable();

        public ResidentListForm()
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
            this.Text = "Danh sách cư dân";
            this.BackColor = Color.White;

            // Tùy chỉnh panel header
            panel1.BackColor = primaryColor;
            label1.ForeColor = textLightColor;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold);

            // Tùy chỉnh DataGridView
            dgvResidents.BorderStyle = BorderStyle.None;
            dgvResidents.BackgroundColor = Color.White;
            dgvResidents.GridColor = Color.FromArgb(230, 230, 230);
            dgvResidents.RowHeadersVisible = false;
            dgvResidents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResidents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResidents.AllowUserToAddRows = false;
            dgvResidents.AllowUserToDeleteRows = false;
            dgvResidents.ReadOnly = true;
            dgvResidents.EnableHeadersVisualStyles = false;
            dgvResidents.AlternatingRowsDefaultCellStyle.BackColor = primaryLightColor;
            dgvResidents.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Tùy chỉnh header style
            dgvResidents.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
            dgvResidents.ColumnHeadersDefaultCellStyle.ForeColor = textLightColor;
            dgvResidents.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvResidents.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvResidents.ColumnHeadersHeight = 50;

            // Tùy chỉnh cell style
            dgvResidents.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            dgvResidents.DefaultCellStyle.ForeColor = textColor;
            dgvResidents.DefaultCellStyle.SelectionBackColor = primaryLightColor;
            dgvResidents.DefaultCellStyle.SelectionForeColor = primaryColor;
            dgvResidents.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            dgvResidents.RowTemplate.Height = 35;

            // Tùy chỉnh buttons
            btnViewDetails.BackColor = primaryColor;
            btnViewDetails.FlatAppearance.BorderSize = 0;
            btnViewDetails.ForeColor = textLightColor;
            btnViewDetails.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btnViewDetails.Cursor = Cursors.Hand;
            btnViewDetails.TextAlign = ContentAlignment.MiddleCenter;

            btnExport.BackColor = successColor;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.ForeColor = textLightColor;
            btnExport.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            btnExport.Cursor = Cursors.Hand;
            btnExport.TextAlign = ContentAlignment.MiddleCenter;

            btnRefresh.BackColor = warningColor;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.ForeColor = textLightColor;
            btnRefresh.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.TextAlign = ContentAlignment.MiddleCenter;

            btnBack.BackColor = Color.FromArgb(108, 117, 125);
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.ForeColor = Color.White;
            btnBack.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            btnBack.Cursor = Cursors.Hand;
            btnBack.TextAlign = ContentAlignment.MiddleCenter;

            // Tùy chỉnh label
            lblResult.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            lblResult.ForeColor = Color.FromArgb(108, 117, 125);

            // Hover effects
            AddButtonHoverEffects();
        }

        private void AddButtonHoverEffects()
        {
            // Hover effect cho btnViewDetails
            btnViewDetails.MouseEnter += (s, e) => btnViewDetails.BackColor = Color.FromArgb(0, 86, 179);
            btnViewDetails.MouseLeave += (s, e) => btnViewDetails.BackColor = primaryColor;

            // Hover effect cho btnExport
            btnExport.MouseEnter += (s, e) => btnExport.BackColor = Color.FromArgb(34, 142, 58);
            btnExport.MouseLeave += (s, e) => btnExport.BackColor = successColor;

            // Hover effect cho btnRefresh
            btnRefresh.MouseEnter += (s, e) => btnRefresh.BackColor = Color.FromArgb(255, 173, 0);
            btnRefresh.MouseLeave += (s, e) => btnRefresh.BackColor = warningColor;

            // Hover effect cho btnBack
            btnBack.MouseEnter += (s, e) => btnBack.BackColor = Color.FromArgb(90, 98, 104);
            btnBack.MouseLeave += (s, e) => btnBack.BackColor = Color.FromArgb(108, 117, 125);
        }

        private void ResidentListForm_Load(object sender, EventArgs e)
        {
            LoadData();

        }

        private void LoadData()
        {
            try
            {
                residentTable = residentService.GetAllResidentForEachUser(2,"SP_ListAllResidentData");
                dgvResidents.DataSource = residentTable;

                // Ẩn cột SensitivityLevel nếu có
                if (dgvResidents.Columns.Contains("SensitivityLevel"))
                {
                    dgvResidents.Columns["SensitivityLevel"].Visible = false;
                }

                // Ẩn cột ResidentID
                if (dgvResidents.Columns.Contains("ResidentID"))
                {
                    dgvResidents.Columns["ResidentID"].Visible = false;
                }

                // Tùy chỉnh tên cột hiển thị
                CustomizeColumnHeaders();

                // Tùy chỉnh độ rộng cột
                SetColumnWidths();

                // Thống kê chi tiết
                int totalResidents = residentTable.Rows.Count;
                int maleCount = residentTable.AsEnumerable().Count(row => row.Field<string>("Gender")?.ToLower().Contains("nam") == true);
                int femaleCount = totalResidents - maleCount;

                lblResult.Text = $"👥 Tổng số cư dân: {totalResidents} | 👨 Nam: {maleCount} | 👩 Nữ: {femaleCount} | 📅 Cập nhật: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                lblResult.ForeColor = successColor;
            }
            catch (Exception ex)
            {
                lblResult.Text = $"❌ Lỗi khi tải dữ liệu: {ex.Message}";
                lblResult.ForeColor = Color.FromArgb(220, 53, 69);
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
                {"CreatedAt", "⏰ Ngày đăng ký"}
            };

            foreach (var mapping in columnMappings)
            {
                if (dgvResidents.Columns.Contains(mapping.Key))
                {
                    dgvResidents.Columns[mapping.Key].HeaderText = mapping.Value;
                }
            }
        }

        private void SetColumnWidths()
        {
            // Đặt AutoSizeColumnsMode về None để có thể tùy chỉnh độ rộng
            dgvResidents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Tùy chỉnh độ rộng từng cột
            var columnWidths = new Dictionary<string, int>
            {
                {"FullName", 180},
                {"CMND", 120},
                {"Gender", 100},
                {"DateOfBirth", 120},
                {"Address", 250},
                {"Nationality", 120},
                {"PhoneNumber", 140},
                {"Email", 200},
                {"CreatedAt", 140}
            };

            foreach (var columnWidth in columnWidths)
            {
                if (dgvResidents.Columns.Contains(columnWidth.Key))
                {
                    dgvResidents.Columns[columnWidth.Key].Width = columnWidth.Value;
                }
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvResidents.SelectedRows.Count == 0)
            {
                MessageBox.Show("⚠️ Vui lòng chọn cư dân cần xem chi tiết", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ShowDetailDialog();
        }

        private void ShowDetailDialog()
        {
            DataGridViewRow selectedRow = dgvResidents.SelectedRows[0];

            // Lấy thông tin từ row được chọn
            string fullName = selectedRow.Cells["FullName"].Value?.ToString() ?? "";
            string cccd = selectedRow.Cells["CMND"].Value?.ToString() ?? "";
            string gender = selectedRow.Cells["Gender"].Value?.ToString() ?? "";
            string dob = selectedRow.Cells["DateOfBirth"].Value?.ToString() ?? "";
            string address = selectedRow.Cells["Address"].Value?.ToString() ?? "";
            string nationality = selectedRow.Cells["Nationality"].Value?.ToString() ?? "";
            string phone = selectedRow.Cells["PhoneNumber"].Value?.ToString() ?? "";
            string email = selectedRow.Cells["Email"].Value?.ToString() ?? "";
            string createdAt = selectedRow.Cells["CreatedAt"].Value?.ToString() ?? "";

            // Tạo form chi tiết
            Form detailForm = new Form
            {
                Text = "Chi tiết cư dân",
                Size = new Size(600, 500),
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

            System.Windows.Forms.Label headerLabel = new System.Windows.Forms.Label
            {
                Text = "👤 THÔNG TIN CHI TIẾT CƯ DÂN",
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

            string detailText = $"👤 Họ và tên: {fullName}\n\n" +
                              $"🆔 Số CCCD: {cccd}\n\n" +
                              $"⚥ Giới tính: {gender}\n\n" +
                              $"📅 Ngày sinh: {dob}\n\n" +
                              $"🏠 Địa chỉ: {address}\n\n" +
                              $"🌍 Quốc tịch: {nationality}\n\n" +
                              $"📞 Số điện thoại: {phone}\n\n" +
                              $"📧 Email: {email}\n\n" +
                              $"⏰ Ngày đăng ký: {createdAt}";

            System.Windows.Forms.Label detailLabel = new System.Windows.Forms.Label
            {
                Text = detailText,
                Font = new Font("Segoe UI", 10),
                ForeColor = textColor,
                Location = new Point(15, 15),
                Size = new Size(510, 290),
                AutoSize = false
            };

            contentPanel.Controls.Add(detailLabel);
            detailForm.Controls.Add(contentPanel);

            // Button đóng
            Button btnClose = new Button
            {
                Text = "🔙 Đóng",
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11),
                Size = new Size(120, 40),
                Location = new Point(460, 420),
                Cursor = Cursors.Hand,
                TextAlign = ContentAlignment.MiddleCenter
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => detailForm.Close();

            detailForm.Controls.Add(btnClose);
            detailForm.ShowDialog();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvResidents.Rows.Count == 0)
            {
                MessageBox.Show("⚠️ Không có dữ liệu để xuất", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV (*.csv)|*.csv|Excel (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = "DanhSachCuDan_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Tạo StringBuilder để lưu dữ liệu CSV
                    StringBuilder sb = new StringBuilder();

                    // Thêm header (bỏ qua các cột ẩn)
                    List<string> columnNames = new List<string>();
                    for (int i = 0; i < dgvResidents.Columns.Count; i++)
                    {
                        if (dgvResidents.Columns[i].Visible)
                        {
                            columnNames.Add(dgvResidents.Columns[i].HeaderText);
                        }
                    }
                    sb.AppendLine(string.Join(",", columnNames));

                    // Thêm dữ liệu từng dòng
                    foreach (DataGridViewRow row in dgvResidents.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            List<string> fields = new List<string>();
                            for (int i = 0; i < dgvResidents.Columns.Count; i++)
                            {
                                if (dgvResidents.Columns[i].Visible)
                                {
                                    string value = row.Cells[i].Value?.ToString() ?? "";
                                    // Escape dấu phẩy trong dữ liệu
                                    value = value.Replace(",", ";");
                                    fields.Add(value);
                                }
                            }
                            sb.AppendLine(string.Join(",", fields));
                        }
                    }

                    // Ghi file
                    System.IO.File.WriteAllText(saveFileDialog.FileName, sb.ToString(), Encoding.UTF8);

                    MessageBox.Show("✅ Xuất dữ liệu thành công!\n📁 Đường dẫn: " + saveFileDialog.FileName,
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("❌ Lỗi khi xuất dữ liệu: " + ex.Message,
                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
    }
}