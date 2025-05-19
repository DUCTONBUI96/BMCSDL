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
     


        private void NotificationForm_Load(object sender, EventArgs e)
        {
            cboStatusFilter.Items.Add("Tất cả trạng thái");
            cboStatusFilter.Items.Add("Chờ xét");
            cboStatusFilter.Items.Add("Đã duyệt");
            cboStatusFilter.Items.Add("Từ chối");

            // Thiết lập mục mặc định
            cboStatusFilter.SelectedIndex = 0; // "Tất cả trạng thái"
            string connectionString = "Data Source=.;Initial Catalog=PassportManagement;Integrated Security=True";
            string query = "SELECT * FROM ResidentData";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter d = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    d.Fill(dt);
                    dgvResidentsOrApps.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách cư dân: " + ex.Message);
            }

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
            string subject = "Thông báo từ hệ thống quản lý cư dân";
            string message = txtMessage.Text;
            try
            {
                string smtpServer = "smtp.gmail.com"; // Địa chỉ máy chủ SMTP
                int smtpPort = 587; // Cổng SMTP
                string Email = "ductonb123@gmail.com"; // Địa chỉ email người gửi
                string password = "cfbv wntl wuid fdds"; // Mật khẩu email người gửi
                string recipientEmail = value; // Địa chỉ email người nhận

                using (MailMessage mail = new MailMessage(Email, recipientEmail, subject, message))
                using (SmtpClient smtp = new SmtpClient(smtpServer, smtpPort))
                {
                    smtp.UseDefaultCredentials = false; // Không sử dụng thông tin xác thực mặc định
                    smtp.Credentials = new System.Net.NetworkCredential(Email, password);
                    smtp.EnableSsl = true; // Bật SSL nếu cần
                    smtp.Send(mail);
                }

                lblSendStatus.Text = "Email đã được gửi thành công!";
            }
            catch (Exception ex)
            {
                lblSendStatus.Text = "Lỗi khi gửi email: " + ex.Message;
            }
        }

    }
}
