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
using Business_Layer;
using Data_Layer;
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

           ResidentValidator valid = new ResidentValidator();
           ResidentService residentService = new ResidentService();
           ResidentDTO residentDTO = new ResidentDTO();
            {
                residentDTO.FullName = txtFullName.Text;
                residentDTO.CCCD=txtCCCDid.Text;
                residentDTO.Gender = cboGender.Text;
                residentDTO.Nationality = cboNationality.Text;
                residentDTO.DOB = dtpDOB.Value;
                residentDTO.Phone = txtPhone.Text;
                residentDTO.Email= txtEmail.Text;
                residentDTO.Address = rtbAddress.Text;
            }
            if (residentService.InsertResident(residentDTO))
            {
                MessageBox.Show("Đăng ký thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            else
            {
                MessageBox.Show("Lỗi khi đăng ký.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            new WelcomeScreen().Show();
            this.Hide();
        }
    }
}