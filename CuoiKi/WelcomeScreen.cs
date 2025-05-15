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

namespace CuoiKi
{
    public partial class WelcomeScreen : Form
    {
        public WelcomeScreen()
        {
            InitializeComponent();
            //chinh btn ra giua
            btnSearchStatus.Left = (panel1.Width - btnSearchStatus.Width) / 2;
            btnSearchStatus.Top = (panel1.Height - btnSearchStatus.Height) / 2;

            btnSubmitForm.Left = (panel2.Width - btnSubmitForm.Width) / 2;
            btnSubmitForm.Top = (panel2.Height - btnSubmitForm.Height) / 2;

            btnSearchStatus.Region = new Region(new Rectangle(0, 0, btnSearchStatus.Width, btnSearchStatus.Height));
            btnSubmitForm.Region = new Region(new Rectangle(0, 0, btnSubmitForm.Width, btnSubmitForm.Height));

            // Set thoi gian 
            timer1.Start();

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

      //  Image icon = Image.FromFile("image/tick.png");
       // btnSearchStatus.Image = new Bitmap(icon, new Size(20, 20)); // Resize icon nhỏ lại

    }
}
