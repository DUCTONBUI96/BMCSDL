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
    public partial class SecurityMonitorForm : Form
    {
        public SecurityMonitorForm()
        {
            InitializeComponent();
        }

        private void chartAccessStats_Click(object sender, EventArgs e)
        {

        }

        private void SecurityMonitorForm_Load(object sender, EventArgs e)
        {
            cboAlertType.Items.Add("⚠️ Tất cả loại cảnh báo");
            cboAlertType.Items.Add("Truy cập trái phép");
            cboAlertType.Items.Add("Đăng nhập thất bại");

            cboAlertType.SelectedIndex = 0;
        }
    }
}
