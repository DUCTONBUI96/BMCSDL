using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuoiKi
{

    public partial class Menu : Form
    {
        private void form1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new ChildForm1());
        }

        private void form2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new ChildForm2());
        }

        private void form3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new ChildForm3());
        }

        public Menu()
        {
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            InitializeComponent();
            statusUserName.Text=Environment.UserName;
            Timer timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += (sender, e) => {
                toolStripStatusLabel2.Text = DateTime.Now.ToString("HH:mm:ss");
            };
            timer.Start();
        }
        
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sample WinForms Application\nVersion 1.0", "About",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Bước 1: Reset style cho tất cả menu items
            foreach (ToolStripItem item in menuStrip1.Items)
            {
                item.BackColor = SystemColors.Control;
                item.ForeColor = Color.Black;
                item.Font = new Font(item.Font, FontStyle.Regular);
            }

            // Bước 2: Set style cho item được chọn
            ToolStripItem clickedItem = e.ClickedItem;
            clickedItem.BackColor = Color.LightBlue;
            clickedItem.ForeColor = Color.Black;
            clickedItem.Font = new Font(clickedItem.Font, FontStyle.Bold);

            // Optional: gọi hàm load giao diện tương ứng ở đây
        
        }

        private void HighlightMenu(ToolStripMenuItem selectedItem)
        {
            // Reset màu của tất cả menu
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.BackColor = SystemColors.Control; // màu mặc định
            }

            // Đổi màu của item đang chọn
            selectedItem.BackColor = Color.LightBlue; // màu khi được chọn
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new ChangePasswordForm().Show();
            this.Hide();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }


}
