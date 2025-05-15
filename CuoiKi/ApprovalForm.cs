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
    public partial class ApprovalForm : Form
    {
        public ApprovalForm()
        {
            InitializeComponent();
            rtbNotes.ForeColor = Color.Gray;
            rtbNotes.GotFocus += RemovePlaceholder;
            rtbNotes.LostFocus += SetPlaceholder;
        }
        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (rtbNotes.ForeColor == Color.Gray)
            {
                rtbNotes.Text = "";
                rtbNotes.ForeColor = Color.Black;
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rtbNotes.Text))
            {
                rtbNotes.Text = "Nhập ghi chú... ";
                rtbNotes.ForeColor = Color.Gray;
            }
        }
        
        private void rtbNotes_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
