using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using Business_Layer;
using Data_Layer.NewFolder1;

namespace CuoiKi
{
    public partial class Login : Form
    {
        // Định nghĩa màu sắc chung cho ứng dụng
        private Color primaryColor = Color.FromArgb(0, 123, 255);
        private Color secondaryColor = Color.FromArgb(108, 117, 125);
        private Color dangerColor = Color.FromArgb(220, 53, 69);
        private Color lightBgColor = Color.FromArgb(248, 249, 250);
        private Color textColor = Color.FromArgb(73, 80, 87);

        public Login()
        {
            InitializeComponent();
            CustomizeDesign();
        }

        FunctionService functionService = new FunctionService();
        string otp = "Đây là mã OTP: ", check;
        private void CustomizeDesign()
        {
            // Tùy chỉnh giao diện form
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Tạo viền bo tròn cho form
            Rectangle r = new Rectangle(0, 0, this.Width, this.Height);
            GraphicsPath gp = new GraphicsPath();
            int d = 15;
            gp.AddArc(r.X, r.Y, d, d, 180, 90);
            gp.AddArc(r.X + r.Width - d, r.Y, d, d, 270, 90);
            gp.AddArc(r.X + r.Width - d, r.Y + r.Height - d, d, d, 0, 90);
            gp.AddArc(r.X, r.Y + r.Height - d, d, d, 90, 90);
            this.Region = new Region(gp);

            // Tùy chỉnh các controls
            btnDangnhap.BackColor = primaryColor;
            btnDangnhap.FlatAppearance.BorderSize = 0;
            btnDangnhap.ForeColor = Color.White;
            btnDangnhap.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnDangnhap.Cursor = Cursors.Hand;

            
            btnBack.BackColor = lightBgColor;
            btnBack.FlatAppearance.BorderColor = primaryColor;
            btnBack.ForeColor = primaryColor;
            btnBack.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btnBack.Cursor = Cursors.Hand;

            btnSendOTP.BackColor = lightBgColor;
            btnSendOTP.FlatAppearance.BorderColor = primaryColor;
            btnSendOTP.ForeColor = primaryColor;
            btnSendOTP.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btnSendOTP.Cursor = Cursors.Hand;

            // Tùy chỉnh textboxes
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtOTP.BorderStyle = BorderStyle.FixedSingle;

            txtUsername.BackColor = lightBgColor;
            txtPassword.BackColor = lightBgColor;
            txtOTP.BackColor = lightBgColor;

            // Tùy chỉnh labels
            label1.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            label1.ForeColor = primaryColor;

            label2.ForeColor = textColor;
            label3.ForeColor = textColor;
            label5.ForeColor = textColor;

            ckbShowpassWord.ForeColor = textColor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*'; // Ẩn password mặc định
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đóng không?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            UserService userService = new UserService();
            FunctionService functionService = new FunctionService();
            int IdCheck = userService.LoginAndGetRole(txtUsername.Text,txtPassword.Text);
            //if(txtOTP.Text != check)
            //{
            //    MessageBox.Show("Mã OTP không hợp lệ. Vui lòng thử lại.", "Xác thực thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return; // Dừng quá trình đăng nhập nếu mã OTP không hợp lệ
            //}
            // Kiểm tra đăng nhập
            if (IdCheck > 0)
            {   
                Session.Name = txtUsername.Text; // Lưu tên người dùng vào biến tĩnh tên Session
                Session.RoleId = IdCheck; // Lưu RoleID vào biến tĩnh tên Session
               
                // Mở form chính dựa trên RoleID
                new Menu().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(IdCheck.ToString());
                MessageBox.Show("Tài khoản hoặc Mật khẩu không đúng, Vui lòng thử lại", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus();
            }

        }

        private void ckbShowpassWord_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbShowpassWord.Checked)
            {
                txtPassword.PasswordChar = '\0'; // Hiện mật khẩu
            }
            else
            {
                txtPassword.PasswordChar = '*';  // Ẩn mật khẩu
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new WelcomeScreen().Show();
            this.Hide();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSendOTP_Click(object sender, EventArgs e)
        {
            string emailTest = "ductonbui46@gmail.com";
            ResidentService residentService = new ResidentService();
            check = functionService.GererateOTP();
            otp += check; // Tạo mã OTP
            residentService.NotificationByEmail(emailTest, otp); // Gửi mã OTP đến email
            MessageBox.Show("Mã OTP đã được gửi đến email của bạn. Vui lòng kiểm tra hộp thư đến của bạn.", "Gửi mã OTP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}