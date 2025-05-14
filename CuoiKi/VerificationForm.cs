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
    public partial class VerificationForm : Form
    {
        public VerificationForm()
        {
            InitializeComponent();
            txtSearchCCCD.ForeColor = Color.Gray;
            txtSearchCCCD.GotFocus += RemovePlaceholder;
            txtSearchCCCD.LostFocus += SetPlaceholder;
        }
        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (txtSearchCCCD.ForeColor == Color.Gray)
            {
                txtSearchCCCD.Text = "";
                txtSearchCCCD.ForeColor = Color.Black;
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchCCCD.Text))
            {
                //txtSearchCCCD.Text = "Nhập ghi chú... ";
                txtSearchCCCD.ForeColor = Color.Gray;
            }
        }

        private void VerificationForm_Load(object sender, EventArgs e)
        {

        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            lblResult.Text = " Đã Xác thực thành công!";
            lblResult.ForeColor = Color.Green;
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            lblResult.Text = "Đã từ chối xác thực!";
            lblResult.ForeColor = Color.Red;
        }

        private void txtSearchCCCD_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
