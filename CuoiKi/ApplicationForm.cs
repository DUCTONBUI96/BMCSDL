using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuoiKi
{
    public partial class ApplicationForm : Form
    {
        // Định nghĩa màu sắc chung cho ứng dụng
        private Color primaryColor = Color.FromArgb(0, 123, 255);
        private Color secondaryColor = Color.FromArgb(108, 117, 125);
        private Color successColor = Color.FromArgb(40, 167, 69);
        private Color dangerColor = Color.FromArgb(220, 53, 69);
        private Color lightBgColor = Color.FromArgb(248, 249, 250);
        private Color textColor = Color.FromArgb(73, 80, 87);

        public ApplicationForm()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        private void CustomizeDesign()
        {
            // Tùy chỉnh form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Đăng ký cấp hộ chiếu";
            this.Icon = SystemIcons.Application;
            this.BackColor = Color.White;

            // Tùy chỉnh các controls
            // Tùy chỉnh buttons
            btnSubmit.BackColor = primaryColor;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.ForeColor = Color.White;
            btnSubmit.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnSubmit.Cursor = Cursors.Hand;

            btnBack.BackColor = lightBgColor;
            btnBack.FlatAppearance.BorderColor = primaryColor;
            btnBack.ForeColor = primaryColor;
            btnBack.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btnBack.Cursor = Cursors.Hand;

            btnUpload.BackColor = lightBgColor;
            btnUpload.FlatAppearance.BorderColor = primaryColor;
            btnUpload.ForeColor = primaryColor;
            btnUpload.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btnUpload.Cursor = Cursors.Hand;

            // Tùy chỉnh textboxes
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtCCCDid.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtPhone.BorderStyle = BorderStyle.FixedSingle;
            rtbAddress.BorderStyle = BorderStyle.FixedSingle;

            txtFullName.BackColor = lightBgColor;
            txtCCCDid.BackColor = lightBgColor;
            txtEmail.BackColor = lightBgColor;
            txtPhone.BackColor = lightBgColor;
            rtbAddress.BackColor = lightBgColor;

            txtFullName.ForeColor = textColor;
            txtCCCDid.ForeColor = textColor;
            txtEmail.ForeColor = textColor;
            txtPhone.ForeColor = textColor;
            rtbAddress.ForeColor = textColor;

            // Tùy chỉnh comboboxes
            cboGender.FlatStyle = FlatStyle.Flat;
            cboNationality.FlatStyle = FlatStyle.Flat;

            cboGender.BackColor = lightBgColor;
            cboNationality.BackColor = lightBgColor;

            cboGender.ForeColor = textColor;
            cboNationality.ForeColor = textColor;

            // Tùy chỉnh DateTimePicker
            dtpDOB.Format = DateTimePickerFormat.Custom;
            dtpDOB.CustomFormat = "dd-MM-yyyy";

            // Tùy chỉnh labels
            foreach (Control c in this.Controls)
            {
                if (c is Label && c != label9)
                {
                    ((Label)c).Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    ((Label)c).ForeColor = textColor;
                }
            }

            label9.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            label9.ForeColor = primaryColor;
            label9.BackColor = Color.White;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            // Kiểm tra các trường thông tin
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập họ và tên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCCCDid.Text))
            {
                MessageBox.Show("Vui lòng nhập số CCCD", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCDid.Focus();
                return;
            }

            if (cboGender.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn giới tính", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboGender.Focus();
                return;
            }

            if (cboNationality.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn quốc tịch", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboNationality.Focus();
                return;
            }

            if (!validEmail())
            {
                MessageBox.Show("Email không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (!validPhone())
            {
                MessageBox.Show("Số điện thoại không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhone.Focus();
                return;
            }

            if (!validCCCD())
            {
                MessageBox.Show("Số CCCD không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCDid.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(rtbAddress.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtbAddress.Focus();
                return;
            }

            //chuyen lenh sang string rồi dùng using gọi lại
            string connectionString = "Data Source=.;Initial Catalog=PassportManagement;Integrated Security=True";
            string query = "INSERT INTO ResidentData (FullName, Gender, DateOfBirth, CMND, Address, Nationality, PhoneNumber, Email) " +
                           "VALUES (@FullName, @Gender, @DateOfBirth, @CMND, @Address, @Nationality, @PhoneNumber, @Email)";

            //test connect database
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                    cmd.Parameters.AddWithValue("@Gender", cboGender.Text);
                    cmd.Parameters.AddWithValue("@DateOfBirth", dtpDOB.Value);
                    cmd.Parameters.AddWithValue("@CMND", txtCCCDid.Text);
                    cmd.Parameters.AddWithValue("@Address", rtbAddress.Text);
                    cmd.Parameters.AddWithValue("@Nationality", cboNationality.Text);
                    cmd.Parameters.AddWithValue("@PhoneNumber", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng ký: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtFullName.Text = "";
            txtCCCDid.Text = "";
            cboGender.SelectedIndex = -1;
            cboNationality.SelectedIndex = -1;
            dtpDOB.Value = DateTime.Now;
            txtEmail.Text = "";
            txtPhone.Text = "";
            rtbAddress.Text = "";
        }

        // Hàm kiểm tra định dạng Email
        protected bool validEmail()
        {
            return !string.IsNullOrWhiteSpace(txtEmail.Text) &&
                   Regex.IsMatch(txtEmail.Text, @"^[\w\-\.]+@([\w\-]+\.)+[\w\-]{2,4}$");
        }

        // Hàm kiểm tra định dạng Số điện thoại (10 chữ số)
        protected bool validPhone()
        {
            return !string.IsNullOrWhiteSpace(txtPhone.Text) &&
                   Regex.IsMatch(txtPhone.Text, @"^\d{10}$");
        }

        // Hàm kiểm tra định dạng CCCD (12 chữ số)
        protected bool validCCCD()
        {
            return !string.IsNullOrWhiteSpace(txtCCCDid.Text) &&
                   Regex.IsMatch(txtCCCDid.Text, @"^\d{12}$");
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            new WelcomeScreen().Show();
            this.Hide();
        }
    }
}