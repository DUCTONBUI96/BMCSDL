using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business_Layer;
namespace CuoiKi
{
    public partial class UC_quanli : UserControl
    {
        public static UC_quanli _instance;
        public static UC_quanli Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_quanli();
                return _instance;
            }
        }

        public UC_quanli()
        {
            InitializeComponent();
            this.Controls.Remove(this.pictureBox2);
        }


        private void txtSearchCCCD_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchCCCD.Text))
            {
                txtSearchCCCD.Text = "Tìm kiếm CCCD";
                txtSearchCCCD.ForeColor = Color.Gray;
            }
        }

        public void UC_quanli_Load(object sender, EventArgs e)
        {

        }
        public DataTable load()
        {
            DataTable dt = new DataTable();
            UserService userService = new UserService();
            dt = userService.GetAllUser();
            return dt;
        }
        public void InsertUser(string user, string password, int RoleID)
        {
            UserService userService = new UserService();
            userService.InsertUser(user, password, RoleID);
        }

        public void LoadChangPassword(int id)
        {

        }
        public void btnResetPassword_Click(object sender, EventArgs e)
        {
            MessageBox.Show("bla");
        }
        public void ResetPassword(DataGridView row)
        {
            int id = Convert.ToInt32(row.CurrentRow.Cells["UserID"].Value);
            new ChangePasswordForm(id).ShowDialog();
        }

    }
}
