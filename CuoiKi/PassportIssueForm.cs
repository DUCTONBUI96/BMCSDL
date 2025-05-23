using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
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
        DataGridViewRow row; 

        private void PassportIssueForm_Load(object sender, EventArgs e)
        {
            txtPassportNumber.ReadOnly = true;
            txtTrangThai.ReadOnly = true;
            query = "SELECT ResidentID, CMND, FullName FROM ResidentData ";
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
            dgvApprovedApps.CellClick += dgvApprovedApps_CellContentClick;
        }

        //Load Status by pressing Data in DATAGRIDVIEW
        private void dgvApprovedApps_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                string ResidentID = dgvApprovedApps.CurrentRow.Cells["ResidentID"].Value.ToString();
                query = "SELECT Status FROM PassportApplications WHERE ResidentID = @ResidentID";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@ResidentID", ResidentID);
                row = this.dgvApprovedApps.Rows[e.RowIndex];// trỏ đến dòng hiện tại
                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtTrangThai.Text = reader["Status"].ToString();
                        txtPassportNumber.Text = Load_NumberPassport(ResidentID);
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin trạng thái cho cư dân này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    reader.Close();// Đóng SqlDataReader để giải phóng tài nguyên
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải trạng thái: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        //Load Passport Number
        private string Load_NumberPassport(string ID)
        {
            int number = 8-ID.Length;
            string passportNumber = "VN"+ ID.PadLeft(number,'0') ;
            return passportNumber;
        }
    }
}
