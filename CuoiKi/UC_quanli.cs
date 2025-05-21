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
    public partial class UC_quanli : UserControl
    {
        public UC_quanli()
        {
            InitializeComponent();
        }

        private void txtSearchCCCD_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchCCCD.Text))
            {
                txtSearchCCCD.Text = "Tìm kiếm CCCD";
                txtSearchCCCD.ForeColor = Color.Gray;
            }
        }
    }
}
