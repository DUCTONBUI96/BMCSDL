
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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            //txtSearchCCCD.Text = "Tên người dùng";
            //txtSearchCCCD.ForeColor = Color.Gray;

            UC_quanli uc1 = new UC_quanli();
            uc1.Dock = DockStyle.Fill;         // Giúp nó fill hết không gian của tab
            tabPageQuanLi.Controls.Add(uc1);


            UC_Phanquyen uc2 = new UC_Phanquyen();
            uc2.Dock = DockStyle.Fill;         // Giúp nó fill hết không gian của tab
            tabPagePhanquyen.Controls.Add(uc2);
        }

       
        //private void txtSearchCCCD_Enter(object sender, EventArgs e)
        //{
        //    if (txtSearchCCCD.Text == "Tên người dùng")
        //    {
        //        txtSearchCCCD.Text = "";
        //        txtSearchCCCD.ForeColor = Color.Black;
        //    }
        //}

        //private void txtSearchCCCD_Leave(object sender, EventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(  txtSearchCCCD.Text))
        //    {
        //        txtSearchCCCD.Text = "Tên người dùng";
        //        txtSearchCCCD.ForeColor = Color.Gray;
        //    }
        //}
    }
}
