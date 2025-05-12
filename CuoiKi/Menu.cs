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
        

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void statusUserName_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sample WinForms Application\nVersion 1.0", "About",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }
    }
    

}
