using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
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
            this.txtSearchCCCD.Enter += new System.EventHandler(this.txtSearchCCCD_Enter);
            this.txtSearchCCCD.Leave += new System.EventHandler(this.txtSearchCCCD_Leave);
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
        private void txtSearchCCCD_Enter(object sender, EventArgs e)
        {
            if (txtSearchCCCD.Text == "Tìm kiếm CCCD")
            {
                txtSearchCCCD.Text = "";
                txtSearchCCCD.ForeColor = Color.Black;
            }
        }

        private void txtSearchCCCD_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchCCCD.Text))
            {
                txtSearchCCCD.Text = "Tìm kiếm CCCD";
                txtSearchCCCD.ForeColor = Color.Gray;
            }
        }
        DataTable residentTable;
        private void ApprovalForm_Load(object sender, EventArgs e)
        {
            // Thiết lập placeholder ban đầu
            txtSearchCCCD.Text = "Tìm kiếm CCCD";
            txtSearchCCCD.ForeColor = Color.Gray;


            cboStatusFilter.Items.Add("Tất cả trạng thái");
            cboStatusFilter.Items.Add("Chờ xét");
            cboStatusFilter.Items.Add("Đã duyệt");
            cboStatusFilter.Items.Add("Từ chối");

            // Thiết lập mục mặc định
            cboStatusFilter.SelectedIndex = 0; // "Tất cả trạng thái"
            //txtNote.Text = "Nhập ghi chú...";
            //txtNote.ForeColor = Color.Gray;



            // Kết nối đến cơ sở dữ liệu và lấy dữ liệu
            string connectionString = "Data Source=.;Initial Catalog=PassportManagement;Integrated Security=True";
            string query = "SELECT * FROM ResidentData";
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    
                    SqlDataAdapter d = new SqlDataAdapter(cmd);
                    residentTable = new DataTable();
                    d.Fill(residentTable);
                    dgvApplications.DataSource = residentTable;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách cư dân: " + ex.Message);
            }
        }



        private void txtSearchCCCD_TextChanged(object sender, EventArgs e)
        {


            if (residentTable == null) return;
            string filter = txtSearchCCCD.Text.Trim(); //ham trim có tác dụng xóa khoảng trắng ở đầu và cuối chuỗi
            DataView dv = new DataView(residentTable);
            dv.RowFilter = $"CMND LIKE '%{filter}%'"; //tìm kiếm theo CCCD
            dgvApplications.DataSource = dv;

        }
    }
}
