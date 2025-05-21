using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace CuoiKi
{
    public partial class WelcomeScreen : Form
    {
        // Định nghĩa màu sắc chung cho ứng dụng
        private Color primaryColor = Color.FromArgb(0, 123, 255);
        private Color secondaryColor = Color.FromArgb(108, 117, 125);
        private Color successColor = Color.FromArgb(40, 167, 69);
        private Color lightBgColor = Color.FromArgb(248, 249, 250);
        private Color textColor = Color.FromArgb(73, 80, 87);

        public WelcomeScreen()
        {
            InitializeComponent();
            CustomizeDesign();

            //chinh btn ra giua
            btnSearchStatus.Left = (panel1.Width - btnSearchStatus.Width) / 2;
            btnSearchStatus.Top = (panel1.Height - btnSearchStatus.Height) / 2;

            btnSubmitForm.Left = (panel2.Width - btnSubmitForm.Width) / 2;
            btnSubmitForm.Top = (panel2.Height - btnSubmitForm.Height) / 2;

            // Set thoi gian 
            timer1.Start();
        }

        private void CustomizeDesign()
        {
            // Tùy chỉnh form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Cấp Hộ chiếu";
            this.Icon = SystemIcons.Application;

            // Tùy chỉnh labels
            lblWelcome.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lblWelcome.ForeColor = primaryColor;

            lblTime.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblTime.ForeColor = textColor;
            lblTime.TextAlign = ContentAlignment.MiddleCenter;

            // Tùy chỉnh panels
            panel1.BackColor = Color.FromArgb(232, 245, 233);
            panel2.BackColor = Color.FromArgb(240, 247, 255);

            // Tùy chỉnh buttons
            btnSubmitForm.BackColor = primaryColor;
            btnSubmitForm.FlatAppearance.BorderSize = 0;
            btnSubmitForm.ForeColor = Color.White;
            btnSubmitForm.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btnSubmitForm.Cursor = Cursors.Hand;

            btnSearchStatus.BackColor = lightBgColor;
            btnSearchStatus.FlatAppearance.BorderColor = primaryColor;
            btnSearchStatus.ForeColor = primaryColor;
            btnSearchStatus.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btnSearchStatus.Cursor = Cursors.Hand;

            btnLogin.BackColor = successColor;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.ForeColor = Color.White;
            btnLogin.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            btnLogin.Cursor = Cursors.Hand;

            // Tùy chỉnh các label trong panel
            label1.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(30, 64, 175);

            label2.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            label2.ForeColor = Color.FromArgb(37, 99, 235);

            label3.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(21, 87, 36);

            label4.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            label4.ForeColor = successColor;
        }

        private void btnSubmitForm_Click(object sender, EventArgs e)
        {
            new ApplicationForm().Show();
            this.Hide();
        }

        private void btnSearchStatus_Click(object sender, EventArgs e)
        {
            new SearchStatusForm().Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.lblTime.Text = dateTime.ToString();
        }

        private void WelcomeScreen_Load(object sender, EventArgs e)
        {
            lblTime.Text = System.DateTime.Now.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}