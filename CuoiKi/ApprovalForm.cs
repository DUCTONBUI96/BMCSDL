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

namespace CuoiKi
{
    public partial class ApprovalForm : Form
    {
        // Định nghĩa màu sắc chung cho ứng dụng - Màu xanh dương
        private Color primaryColor = Color.FromArgb(0, 122, 204);      // Màu xanh dương chính
        private Color primaryDarkColor = Color.FromArgb(0, 102, 204);  // Màu xanh dương đậm
        private Color primaryLightColor = Color.FromArgb(229, 241, 255); // Màu xanh dương nhạt
        private Color accentColor = Color.FromArgb(0, 153, 255);       // Màu nhấn
        private Color textColor = Color.FromArgb(51, 51, 51);          // Màu chữ
        private Color textLightColor = Color.White;                    // Màu chữ sáng
        private Color dangerColor = Color.FromArgb(220, 53, 69);       // Màu đỏ cho nút từ chối

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
            // Tùy chỉnh form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimumSize = new Size(800, 600); // Đặt kích thước tối thiểu cho form
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Xét duyệt hồ sơ";
            this.Icon = SystemIcons.Application;
            this.BackColor = Color.White;

            // Tùy chỉnh panel header
            panelHeader.BackColor = primaryColor;
            labelTitle.ForeColor = textLightColor;
            labelTitle.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold);

            // Tùy chỉnh panel search
            panelSearch.BackColor = primaryLightColor;
            labelFilter.ForeColor = textColor;
            labelFilter.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular);

            // Tùy chỉnh DataGridView
            dgvApplications.BorderStyle = BorderStyle.None;
            dgvApplications.AlternatingRowsDefaultCellStyle.BackColor = primaryLightColor;
            dgvApplications.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvApplications.DefaultCellStyle.SelectionBackColor = primaryColor;
            dgvApplications.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvApplications.BackgroundColor = Color.White;
            dgvApplications.EnableHeadersVisualStyles = false;
            dgvApplications.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvApplications.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
            dgvApplications.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvApplications.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgvApplications.RowHeadersVisible = false; // Ẩn row headers để giao diện gọn hơn
            dgvApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự động điều chỉnh kích thước cột

            // Tùy chỉnh RichTextBox
            rtbNotes.BorderStyle = BorderStyle.FixedSingle;
            rtbNotes.BackColor = Color.White;
            rtbNotes.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular);
            rtbNotes.ForeColor = Color.Gray;
            rtbNotes.Text = "Nhập ghi chú... ";

            // Tùy chỉnh ComboBox
            cboStatusFilter.FlatStyle = FlatStyle.Flat;
            cboStatusFilter.BackColor = Color.White;
            cboStatusFilter.ForeColor = textColor;
            cboStatusFilter.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular);

            // Tùy chỉnh TextBox
            txtSearchCCCD.BorderStyle = BorderStyle.FixedSingle;
            txtSearchCCCD.BackColor = Color.White;
            txtSearchCCCD.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular);
            txtSearchCCCD.ForeColor = Color.Gray;
            txtSearchCCCD.Text = "Tìm kiếm CCCD";

            // Tùy chỉnh Button
            btnApprove.FlatStyle = FlatStyle.Flat;
            btnApprove.BackColor = primaryColor;
            btnApprove.ForeColor = Color.White;
            btnApprove.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btnApprove.FlatAppearance.BorderColor = primaryDarkColor;
            btnApprove.Cursor = Cursors.Hand;

            btnReject.FlatStyle = FlatStyle.Flat;
            btnReject.BackColor = dangerColor;
            btnReject.ForeColor = Color.White;
            btnReject.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btnReject.FlatAppearance.BorderColor = Color.FromArgb(200, 35, 51);
            btnReject.Cursor = Cursors.Hand;

            // Tùy chỉnh Label
            lblStatus.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular);
            lblStatus.ForeColor = textColor;
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
                rtbNotes.Text = "Nhập ghi chú... ";
                rtbNotes.ForeColor = Color.Gray;
            }
        }

        private void rtbNotes_TextChanged(object sender, EventArgs e)
        {
            // Có thể thêm xử lý khi text thay đổi nếu cần
        }

        private void txtSearchCCCD_Enter(object sender, EventArgs e)
        {
            if (txtSearchCCCD.Text == "Tìm kiếm CCCD")
            {
                txtSearchCCCD.Text = "";
                txtSearchCCCD.ForeColor = textColor;
            }
        }

        private void txtSearchCCCD_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchCCCD.Text))
            {
                txtSearchCCCD.Text = "Tìm kiếm CCCD";
                txtSearchCCCD.ForeColor = Color.Gray;
            }
        }

        DataTable residentTable;
        string connectionString = "Data Source=.;Initial Catalog=PassportManagement;Integrated Security=True";
        private void ApprovalForm_Load(object sender, EventArgs e)
        {
            // Thiết lập placeholder ban đầu
            txtSearchCCCD.Text = "Tìm kiếm CCCD";
            txtSearchCCCD.ForeColor = Color.Gray;

            cboStatusFilter.Items.Add("Tất cả trạng thái");
            cboStatusFilter.Items.Add("Chờ xét");
            cboStatusFilter.Items.Add("Đã duyệt");
            cboStatusFilter.Items.Add("Từ chối");

            // Thiết lập mục mặc định
            cboStatusFilter.SelectedIndex = 0; // "Tất cả trạng thái"

            // Kết nối đến cơ sở dữ liệu và lấy dữ liệu
            string query = "SELECT * FROM ResidentData";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter d = new SqlDataAdapter(cmd);
                    residentTable = new DataTable();
                    d.Fill(residentTable);
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
                }

                // Cập nhật trạng thái
                lblStatus.Text = $"Đã tải {residentTable.Rows.Count} hồ sơ.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách cư dân: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Lỗi khi tải dữ liệu.";
            }
        }

        private void txtSearchCCCD_TextChanged(object sender, EventArgs e)
        {

            string filterCCCD = txtSearchCCCD.Text.Trim(); // Xóa khoảng trắng đầu/cuối chuỗi
            DataView dv = new DataView(residentTable);
            List<string> filters = new List<string>();

            if (residentTable == null) return;
            string filter = txtSearchCCCD.Text.Trim(); //ham trim có tác dụng xóa khoảng trắng ở đầu và cuối chuỗi
            DataView dv = new DataView(residentTable);
            dv.RowFilter = $"CMND LIKE '%{filter}%'"; //tìm kiếm theo CCCD
            dgvApplications.DataSource = dv;

        }
    }
}