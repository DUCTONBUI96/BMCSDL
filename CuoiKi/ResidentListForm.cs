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
    public partial class ResidentListForm : Form
    {
        public ResidentListForm()
        {
            InitializeComponent();
            txtSearch.ForeColor = Color.Gray;
            txtSearch.GotFocus += RemovePlaceholder;
            txtSearch.LostFocus += SetPlaceholder;

        }
        private void RemovePlaceholder(object sender, EventArgs e)
        {
            if (txtSearch.ForeColor == Color.Gray)
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void SetPlaceholder(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                txtSearch.ForeColor = Color.Gray;
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
