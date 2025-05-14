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
    public partial class NotificationForm : Form
    {
        public NotificationForm()
        {
            InitializeComponent();
            txtMessage.ForeColor = Color.Gray;
            txtMessage.GotFocus += RemovePlaceholder; 
            txtMessage.LostFocus += SetPlaceholder;
        }

        //làm mờ nội dung textbox
        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (txtMessage.ForeColor == Color.Gray)
            {
                txtMessage.Text = "";
                txtMessage.ForeColor = Color.Black;
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                txtMessage.Text = "Nhập nội dung thông báo...";
                txtMessage.ForeColor = Color.Gray;
            }
        }



    }
}
