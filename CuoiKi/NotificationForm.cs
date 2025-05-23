﻿using System;
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
        public NotificationForm()
        {
            InitializeComponent();
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
                txtMessage.ForeColor = Color.Black;
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                txtMessage.Text = "Nhập nội dung thông báo...";
                txtMessage.ForeColor = Color.Gray;
            }
        }

        ResidentService residentService = new ResidentService();
        DataTable dt = new DataTable();

        private void NotificationForm_Load(object sender, EventArgs e)
        {
            cboStatusFilter.Items.Add("Tất cả trạng thái");
            cboStatusFilter.Items.Add("Chờ xét");
            cboStatusFilter.Items.Add("Đã duyệt");
            cboStatusFilter.Items.Add("Từ chối");

            // Thiết lập mục mặc định
            cboStatusFilter.SelectedIndex = 0; // "Tất cả trạng thái"
            dt = residentService.GetAllResident();
            dgvResidentsOrApps.DataSource = dt;
        }

        private void chkEmail_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkEmail.Checked)
            {
                chkSMS.Enabled = false;
                chkCaHai.Enabled = false;
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
            }
            else
            {
                chkEmail.Enabled = true;
                chkSMS.Enabled = true;
            }
        }
        private void btnSendNotification_Click(object sender, EventArgs e)
        {
            string value = dgvResidentsOrApps.CurrentRow.Cells["Email"].Value?.ToString();
            string message = txtMessage.Text;
            if (residentService.NotificationByEmail(value, message))
            {
                MessageBox.Show("Gửi email thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Không thể gửi email!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

    }
}
