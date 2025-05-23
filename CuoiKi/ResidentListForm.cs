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

namespace CuoiKi
{
    public partial class ResidentListForm : Form
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

        public ResidentListForm()
        {
            InitializeComponent();
            CustomizeDesign();
            txtSearch.ForeColor = Color.Gray;
            txtSearch.GotFocus += RemovePlaceholder;
            txtSearch.LostFocus += SetPlaceholder;
        }

        private void CustomizeDesign()
        {
            // Tùy chỉnh form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new Size(800, 500); // Đặt kích thước tối thiểu cho form
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Danh sách cư dân";
            this.Icon = SystemIcons.Application;
            this.BackColor = Color.White;

            // Thêm panel header giống AdminForm
            Panel panelHeader = new Panel();
            panelHeader.BackColor = primaryColor;
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 60;
            this.Controls.Add(panelHeader);
            panelHeader.BringToFront();

            // Thêm label tiêu đề vào panel header
            Label labelTitle = new Label();
            labelTitle.Text = "Danh sách cư dân";
            labelTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.AutoSize = true;
            labelTitle.Location = new Point(20, 14);
            panelHeader.Controls.Add(labelTitle);

            // Di chuyển các control xuống dưới để tránh bị che bởi header
            foreach (Control control in this.Controls)
            {
                if (control != panelHeader)
                {
                    control.Top += 60;
                }
            }

            // Tùy chỉnh DataGridView
            dgvResidents.BorderStyle = BorderStyle.None;
            dgvResidents.BackgroundColor = Color.White;
            dgvResidents.GridColor = lightBgColor;
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
            dgvResidents.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvResidents.ColumnHeadersHeight = 40;

            // Tùy chỉnh cell style
            dgvResidents.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dgvResidents.DefaultCellStyle.ForeColor = textColor;
            dgvResidents.DefaultCellStyle.SelectionBackColor = primaryColor;
            dgvResidents.DefaultCellStyle.SelectionForeColor = textLightColor;
            dgvResidents.RowTemplate.Height = 30;

            // Tùy chỉnh buttons
            btnViewDetails.BackColor = primaryColor;
            btnViewDetails.FlatStyle = FlatStyle.Flat;
            btnViewDetails.FlatAppearance.BorderSize = 0;
            btnViewDetails.ForeColor = textLightColor;
            btnViewDetails.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btnViewDetails.Cursor = Cursors.Hand;
            btnViewDetails.Size = new Size(150, 40);

            btnExport.BackColor = accentColor;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.ForeColor = textLightColor;
            btnExport.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btnExport.Cursor = Cursors.Hand;
            btnExport.Size = new Size(180, 40);

            // Thêm nút quay lại
            Button btnBack = new Button();
            btnBack.Text = "Quay lại";
            btnBack.BackColor = lightBgColor;
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderColor = primaryColor;
            btnBack.ForeColor = primaryColor;
            btnBack.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btnBack.Cursor = Cursors.Hand;
            btnBack.Size = new Size(120, 40);
            btnBack.Location = new Point(dgvResidents.Right - btnBack.Width, btnViewDetails.Top);
            btnBack.Click += BtnBack_Click;
            this.Controls.Add(btnBack);

            // Tùy chỉnh textbox
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.BackColor = lightBgColor;
            txtSearch.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Text = "Tìm kiếm theo tên hoặc CCCD";

            // Tùy chỉnh pictureBox
            pictureBox2.BackColor = lightBgColor;

            // Thêm label kết quả
            Label lblResult = new Label();
            lblResult.AutoSize = true;
            lblResult.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblResult.ForeColor = textColor;
            lblResult.Location = new Point(12, dgvResidents.Bottom + 10);
            lblResult.Name = "lblResult";
            this.Controls.Add(lblResult);
        }
        DataTable dt = new DataTable();
        private void BtnBack_Click(object sender, EventArgs e)
        {
            new Menu().Show();
            this.Hide();
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (txtSearch.ForeColor == Color.Gray)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = textColor;
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.Text = "Tìm kiếm theo tên hoặc CCCD";
                txtSearch.ForeColor = Color.Gray;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dt == null || txtSearch.Text == "Tìm kiếm theo tên hoặc CCCD" || txtSearch.ForeColor == Color.Gray) return;

            string filter = txtSearch.Text.Trim();
            DataView dv = new DataView(dt);

            try
            {
                // Tìm kiếm theo tên hoặc CCCD
                dv.RowFilter = $"FullName LIKE '%{filter}%' OR CMND LIKE '%{filter}%'";
                dgvResidents.DataSource = dv;

                // Cập nhật label kết quả
                Label lblResult = this.Controls.Find("lblResult", true).FirstOrDefault() as Label;
                if (lblResult != null)
                {
                    lblResult.Text = $"Đã tìm thấy {dv.Count} cư dân.";
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                Label lblResult = this.Controls.Find("lblResult", true).FirstOrDefault() as Label;
                if (lblResult != null)
                {
                    lblResult.Text = "Lỗi khi tìm kiếm: " + ex.Message;
                }
            }
        }
        
        private void ResidentListForm_Load(object sender, EventArgs e)
        {
            ResidentService residentService = new ResidentService();
            dt = residentService.GetAllResident();
            dgvResidents.DataSource = dt;

            // Tùy chỉnh tên cột hiển thị
            if (dgvResidents.Columns.Contains("FullName"))
                dgvResidents.Columns["FullName"].HeaderText = "Họ và tên";
            if (dgvResidents.Columns.Contains("CMND"))
                dgvResidents.Columns["CMND"].HeaderText = "Số CCCD";
            if (dgvResidents.Columns.Contains("Gender"))
                dgvResidents.Columns["Gender"].HeaderText = "Giới tính";
            if (dgvResidents.Columns.Contains("DateOfBirth"))
                dgvResidents.Columns["DateOfBirth"].HeaderText = "Ngày sinh";
            if (dgvResidents.Columns.Contains("Address"))
                dgvResidents.Columns["Address"].HeaderText = "Địa chỉ";
            if (dgvResidents.Columns.Contains("Nationality"))
                dgvResidents.Columns["Nationality"].HeaderText = "Quốc tịch";
            if (dgvResidents.Columns.Contains("PhoneNumber"))
                dgvResidents.Columns["PhoneNumber"].HeaderText = "Số điện thoại";
            if (dgvResidents.Columns.Contains("Email"))
                dgvResidents.Columns["Email"].HeaderText = "Email";

            // Cập nhật label kết quả
            Label lblResult = this.Controls.Find("lblResult", true).FirstOrDefault() as Label;
            if (lblResult != null)
            {
                lblResult.Text = $"Đã tải {dt.Rows.Count} cư dân.";
            }
        }


        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvResidents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn cư dân cần xem chi tiết", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy thông tin cư dân được chọn
            DataGridViewRow selectedRow = dgvResidents.SelectedRows[0];
            string fullName = selectedRow.Cells["FullName"].Value?.ToString() ?? "";
            string cccd = selectedRow.Cells["CMND"].Value?.ToString() ?? "";
            string gender = selectedRow.Cells["Gender"].Value?.ToString() ?? "";
            string dob = selectedRow.Cells["DateOfBirth"].Value?.ToString() ?? "";
            string address = selectedRow.Cells["Address"].Value?.ToString() ?? "";
            string nationality = selectedRow.Cells["Nationality"].Value?.ToString() ?? "";
            string phone = selectedRow.Cells["PhoneNumber"].Value?.ToString() ?? "";
            string email = selectedRow.Cells["Email"].Value?.ToString() ?? "";

            // Hiển thị thông tin chi tiết
            string details = $"Thông tin chi tiết cư dân:\n\n" +
                            $"Họ và tên: {fullName}\n" +
                            $"Số CCCD: {cccd}\n" +
                            $"Giới tính: {gender}\n" +
                            $"Ngày sinh: {dob}\n" +
                            $"Địa chỉ: {address}\n" +
                            $"Quốc tịch: {nationality}\n" +
                            $"Số điện thoại: {phone}\n" +
                            $"Email: {email}";

            MessageBox.Show(details, "Chi tiết cư dân", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvResidents.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV (*.csv)|*.csv";
            saveFileDialog.FileName = "DanhSachCuDan_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Tạo StringBuilder để lưu dữ liệu CSV
                    StringBuilder sb = new StringBuilder();

                    // Thêm header
                    string[] columnNames = new string[dgvResidents.Columns.Count];
                    for (int i = 0; i < dgvResidents.Columns.Count; i++)
                    {
                        columnNames[i] = dgvResidents.Columns[i].HeaderText;
                    }
                    sb.AppendLine(string.Join(",", columnNames));

                    // Thêm dữ liệu từng dòng
                    foreach (DataGridViewRow row in dgvResidents.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string[] fields = new string[dgvResidents.Columns.Count];
                            for (int i = 0; i < dgvResidents.Columns.Count; i++)
                            {
                                fields[i] = row.Cells[i].Value?.ToString() ?? "";
                                // Escape dấu phẩy trong dữ liệu
                                fields[i] = fields[i].Replace(",", ";");
                            }
                            sb.AppendLine(string.Join(",", fields));
                        }
                    }

                    // Ghi file
                    System.IO.File.WriteAllText(saveFileDialog.FileName, sb.ToString(), Encoding.UTF8);

                    MessageBox.Show("Xuất dữ liệu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Thêm xử lý resize để đảm bảo giao diện hiển thị đúng
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Cập nhật lại kích thước và vị trí các control nếu cần
            Invalidate();
        }
    }
}