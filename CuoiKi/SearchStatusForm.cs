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
    public partial class SearchStatusForm : Form
    {
        public SearchStatusForm()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // Set form properties
            this.Size = new Size(820, 500);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Add rounded corners effect to buttons
            btnSearch.FlatAppearance.BorderSize = 0;
            btnBack.FlatAppearance.BorderSize = 0;

            // Add hover effects
            btnSearch.MouseEnter += (s, e) => btnSearch.BackColor = Color.FromArgb(0, 86, 179);
            btnSearch.MouseLeave += (s, e) => btnSearch.BackColor = Color.FromArgb(0, 123, 255);

            btnBack.MouseEnter += (s, e) => btnBack.BackColor = Color.FromArgb(90, 98, 104);
            btnBack.MouseLeave += (s, e) => btnBack.BackColor = Color.FromArgb(108, 117, 125);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCCCD.Text) || txtCCCD.Text == "Nhập số CCCD")
            {
                MessageBox.Show("Vui lòng nhập số CCCD!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCCCD.Focus();
                return;
            }

            // Add loading effect
            btnSearch.Text = "Đang tra cứu...";
            btnSearch.Enabled = false;
            this.Cursor = Cursors.WaitCursor;

            try
            {
                ApplicationService applicationService = new ApplicationService();
                string status = applicationService.TakeStatus(txtCCCD.Text.Trim());

                if (status == null)
                {
                    lblResult.Text = "❌ Không tìm thấy thông tin";
                    lblResult.ForeColor = Color.FromArgb(220, 53, 69);
                    lblDetail.Text = $"Không tìm thấy hồ sơ với số CCCD: {txtCCCD.Text.Trim()}\n\n" +
                                   "• Vui lòng kiểm tra lại số CCCD\n" +
                                   "• Đảm bảo số CCCD đã được nhập chính xác\n" +
                                   "• Liên hệ bộ phận hỗ trợ nếu vấn đề vẫn tiếp tục\n\n" +
                                   $"Thời gian tra cứu: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                    lblDetail.ForeColor = Color.FromArgb(108, 117, 125);
                }
                else
                {
                    lblResult.Text = "✅ Tìm thấy thông tin";
                    lblResult.ForeColor = Color.FromArgb(40, 167, 69);
                    lblDetail.Text = $"📋 THÔNG TIN HỒ SƠ\n\n" +
                                   $"Số CCCD: {txtCCCD.Text.Trim()}\n" +
                                   $"Trạng thái: {status}\n" +
                                   $"Ngày tra cứu: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n\n" +
                                   "📌 Lưu ý:\n" +
                                   "• Thông tin được cập nhật theo thời gian thực\n" +
                                   "• Vui lòng lưu lại thông tin để theo dõi\n" +
                                   "• Liên hệ hotline nếu cần hỗ trợ thêm";
                    lblDetail.ForeColor = Color.FromArgb(52, 58, 64);
                }
            }
            catch (Exception ex)
            {
                lblResult.Text = "⚠️ Có lỗi xảy ra";
                lblResult.ForeColor = Color.FromArgb(255, 193, 7);
                lblDetail.Text = $"Lỗi hệ thống: {ex.Message}\n\n" +
                               "Vui lòng thử lại sau hoặc liên hệ bộ phận kỹ thuật.";
                lblDetail.ForeColor = Color.FromArgb(220, 53, 69);
            }
            finally
            {
                // Reset button state
                btnSearch.Text = "Tra cứu";
                btnSearch.Enabled = true;
                this.Cursor = Cursors.Default;
            }
        }

        private void SearchStatusForm_Load(object sender, EventArgs e)
        {
            txtCCCD.Text = "Nhập số CCCD";
            txtCCCD.ForeColor = Color.Gray;
            lblResult.Text = "";
            lblDetail.Text = "Nhập số CMND/CCCD và nhấn 'Tra cứu' để xem thông tin chi tiết về trạng thái hồ sơ của bạn.\n\n" +
                           "Hệ thống sẽ hiển thị thông tin đầy đủ về tình trạng xử lý hồ sơ của bạn.";
            lblDetail.ForeColor = Color.FromArgb(108, 117, 125);
        }

        private void txtCCCD_Enter(object sender, EventArgs e)
        {
            if (txtCCCD.Text == "Nhập số CCCD")
            {
                txtCCCD.Text = "";
                txtCCCD.ForeColor = Color.Black;
            }
        }

        private void txtCCCD_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                txtCCCD.Text = "Nhập số CCCD";
                txtCCCD.ForeColor = Color.Gray;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new WelcomeScreen().Show();
            this.Hide();
        }

        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only allow numbers and control characters
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // Limit to 12 digits (CCCD length)
            if (txtCCCD.Text.Length >= 12 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

            // Allow Enter key to trigger search
            if (e.KeyChar == (char)Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}