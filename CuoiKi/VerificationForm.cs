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

        public VerificationForm()
        {
            InitializeComponent();
            CustomizeDesign();
            txtSearchCCCD.ForeColor = Color.Gray;
            txtSearchCCCD.GotFocus += RemovePlaceholder;
            txtSearchCCCD.LostFocus += SetPlaceholder;
        }

        private void CustomizeDesign()
        {
            // Tùy chỉnh form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new Size(800, 500); // Đặt kích thước tối thiểu cho form
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Xác thực hồ sơ";
            this.Icon = SystemIcons.Application;
            this.BackColor = Color.White;

            // Tùy chỉnh panel
            panel1.BackColor = primaryColor;
            label1.ForeColor = textLightColor;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);

            // Tùy chỉnh DataGridView
            dgvApplications.BorderStyle = BorderStyle.None;
            dgvApplications.BackgroundColor = Color.White;
            dgvApplications.GridColor = lightBgColor;
            dgvApplications.RowHeadersVisible = false;
            dgvApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvApplications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvApplications.AllowUserToAddRows = false;
            dgvApplications.AllowUserToDeleteRows = false;
            dgvApplications.ReadOnly = true;
            dgvApplications.EnableHeadersVisualStyles = false;
            dgvApplications.AlternatingRowsDefaultCellStyle.BackColor = primaryLightColor;
            dgvApplications.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            // Tùy chỉnh header style
            dgvApplications.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
            dgvApplications.ColumnHeadersDefaultCellStyle.ForeColor = textLightColor;
            dgvApplications.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvApplications.ColumnHeadersHeight = 40;

            // Tùy chỉnh cell style
            dgvApplications.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            dgvApplications.DefaultCellStyle.ForeColor = textColor;
            dgvApplications.DefaultCellStyle.SelectionBackColor = primaryColor;
            dgvApplications.DefaultCellStyle.SelectionForeColor = textLightColor;
            dgvApplications.RowTemplate.Height = 30;

            // Tùy chỉnh buttons
            btnViewDetails.BackColor = primaryColor;
            btnViewDetails.FlatAppearance.BorderSize = 0;
            btnViewDetails.ForeColor = textLightColor;
            btnViewDetails.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btnViewDetails.Cursor = Cursors.Hand;

            btnApprove.BackColor = successColor;
            btnApprove.FlatAppearance.BorderSize = 0;
            btnApprove.ForeColor = textLightColor;
            btnApprove.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btnApprove.Cursor = Cursors.Hand;

            btnReject.BackColor = dangerColor;
            btnReject.FlatAppearance.BorderSize = 0;
            btnReject.ForeColor = textLightColor;
            btnReject.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btnReject.Cursor = Cursors.Hand;

            btnBack.BackColor = lightBgColor;
            btnBack.FlatAppearance.BorderColor = primaryColor;
            btnBack.ForeColor = primaryColor;
            btnBack.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btnBack.Cursor = Cursors.Hand;

            // Tùy chỉnh textbox
            txtSearchCCCD.BorderStyle = BorderStyle.FixedSingle;
            txtSearchCCCD.BackColor = lightBgColor;
            txtSearchCCCD.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            txtSearchCCCD.Text = "Tìm kiếm CCCD";

            // Tùy chỉnh pictureBox
            pictureBox2.BackColor = lightBgColor;

            // Tùy chỉnh label
            lblResult.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            lblResult.ForeColor = textColor;
        }

        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (txtSearchCCCD.ForeColor == Color.Gray)
            {
                txtSearchCCCD.Text = "";
                txtSearchCCCD.ForeColor = textColor;
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchCCCD.Text))
            {
                txtSearchCCCD.Text = "Tìm kiếm CCCD";
                txtSearchCCCD.ForeColor = Color.Gray;
            }
        }

        ResidentService residentService = new ResidentService();
        DataTable residentTable= new DataTable();
        private void VerificationForm_Load(object sender, EventArgs e)
        {
            
            residentTable = residentService.GetAllResident();
            dgvApplications.DataSource = residentTable;

            // Tùy chỉnh tên cột hiển thị nếu cần
            if (dgvApplications.Columns.Contains("FullName"))
                dgvApplications.Columns["FullName"].HeaderText = "Họ và tên";
            if (dgvApplications.Columns.Contains("CMND"))
                dgvApplications.Columns["CMND"].HeaderText = "Số CCCD";
            if (dgvApplications.Columns.Contains("Gender"))
                dgvApplications.Columns["Gender"].HeaderText = "Giới tính";
            if (dgvApplications.Columns.Contains("DateOfBirth"))
                dgvApplications.Columns["DateOfBirth"].HeaderText = "Ngày sinh";
            if (dgvApplications.Columns.Contains("Address"))
                dgvApplications.Columns["Address"].HeaderText = "Địa chỉ";
            if (dgvApplications.Columns.Contains("Nationality"))
                dgvApplications.Columns["Nationality"].HeaderText = "Quốc tịch";
            if (dgvApplications.Columns.Contains("PhoneNumber"))
                dgvApplications.Columns["PhoneNumber"].HeaderText = "Số điện thoại";
            if (dgvApplications.Columns.Contains("Email"))
                dgvApplications.Columns["Email"].HeaderText = "Email";

            lblResult.Text = $"Đã tải {residentTable.Rows.Count} hồ sơ.";
        }


        ApplicationService ApplicationService = new ApplicationService();
        private void btnApprove_Click(object sender, EventArgs e)
        {
            string x = dgvApplications.CurrentRow.Cells["ResidentID"].Value?.ToString();
            int id= int.Parse(x);
            ApplicationService.UpdateStatus(id, "Đã xác thực");
            if (dgvApplications.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hồ sơ cần xác thực", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy thông tin hồ sơ được chọn
            DataGridViewRow selectedRow = dgvApplications.SelectedRows[0];
            string fullName = selectedRow.Cells["FullName"].Value?.ToString() ?? "";
            string cccd = selectedRow.Cells["CMND"].Value?.ToString() ?? "";

            lblResult.Text = $"Đã xác thực thành công hồ sơ của {fullName} (CCCD: {cccd})!";
            lblResult.ForeColor = successColor;
        }

        private void btnReject_Click(object sender, EventArgs e)
        {

            string x = dgvApplications.CurrentRow.Cells["ResidentID"].Value?.ToString();
            int id = int.Parse(x);
            ApplicationService.UpdateStatus(id, "Từ chối");
            if (dgvApplications.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hồ sơ cần từ chối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy thông tin hồ sơ được chọn
            DataGridViewRow selectedRow = dgvApplications.SelectedRows[0];
            string fullName = selectedRow.Cells["FullName"].Value?.ToString() ?? "";
            string cccd = selectedRow.Cells["CMND"].Value?.ToString() ?? "";

            lblResult.Text = $"Đã từ chối xác thực hồ sơ của {fullName} (CCCD: {cccd})!";
            lblResult.ForeColor = dangerColor;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new Menu().Show();
            this.Hide();
        }

        private void txtSearchCCCD_TextChanged(object sender, EventArgs e)
        {
            if (residentTable == null || txtSearchCCCD.Text == "Tìm kiếm CCCD") return;

            string filter = txtSearchCCCD.Text.Trim();
            DataView dv = new DataView(residentTable);

            try
            {
                dv.RowFilter = $"CMND LIKE '%{filter}%'"; // Tìm kiếm theo CCCD
                dgvApplications.DataSource = dv;
                lblResult.Text = $"Đã tìm thấy {dv.Count} hồ sơ.";
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có
                lblResult.Text = "Lỗi khi tìm kiếm: " + ex.Message;
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn hồ sơ cần xem chi tiết", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Lấy thông tin hồ sơ được chọn
            DataGridViewRow selectedRow = dgvApplications.SelectedRows[0];
            string fullName = selectedRow.Cells["FullName"].Value?.ToString() ?? "";
            string cccd = selectedRow.Cells["CMND"].Value?.ToString() ?? "";
            string gender = selectedRow.Cells["Gender"].Value?.ToString() ?? "";
            string dob = selectedRow.Cells["DateOfBirth"].Value?.ToString() ?? "";
            string address = selectedRow.Cells["Address"].Value?.ToString() ?? "";
            string nationality = selectedRow.Cells["Nationality"].Value?.ToString() ?? "";
            string phone = selectedRow.Cells["PhoneNumber"].Value?.ToString() ?? "";
            string email = selectedRow.Cells["Email"].Value?.ToString() ?? "";

            // Hiển thị thông tin chi tiết
            string details = $"Thông tin chi tiết hồ sơ:\n\n" +
                            $"Họ và tên: {fullName}\n" +
                            $"Số CCCD: {cccd}\n" +
                            $"Giới tính: {gender}\n" +
                            $"Ngày sinh: {dob}\n" +
                            $"Địa chỉ: {address}\n" +
                            $"Quốc tịch: {nationality}\n" +
                            $"Số điện thoại: {phone}\n" +
                            $"Email: {email}";

            MessageBox.Show(details, "Chi tiết hồ sơ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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