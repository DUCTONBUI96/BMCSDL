using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CuoiKi
{
    public partial class PassportIssueForm : Form
    {
        public PassportIssueForm()
        {
            InitializeComponent();
        }
        DataTable residentTable;
        SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=PassportManagement;Integrated Security=True");
        string query;
        SqlCommand cmd;
        private void PassportIssueForm_Load(object sender, EventArgs e)
        {
            txtPassportNumber.ReadOnly = true;
            txtTrangThai.ReadOnly = true;
            query = "SELECT ResidentID, CMND, FullName FROM ResidentData WHERE ResidentID IN (SELECT ResidentID FROM PassportApplications WHERE Status = N'Đã duyệt')";
            try
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    residentTable = new DataTable();
                    da.Fill(residentTable);
                    dgvApprovedApps.DataSource = residentTable;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách cư dân: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
