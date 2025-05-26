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
    public partial class UC_Phanquyen : UserControl
    {
        public static UC_Phanquyen _instance;
        public static UC_Phanquyen Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UC_Phanquyen();
                return _instance;
            }
        }
        public UC_Phanquyen()
        {
            InitializeComponent();
            this.Controls.Remove(this.pictureBox2);
        }

        public void UC_Phanquyen_Load(object sender, EventArgs e)
        {
            
        }
        public DataTable load()
        {
            DataTable dt = new DataTable();
            UserService userService = new UserService();
            dt = userService.GetAllUser();
            return dt;
        }
    }
}
