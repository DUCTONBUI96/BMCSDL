using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_Layer;
using Data_Layer.NewFolder1;

namespace Business_Layer
{
    public class ResidentService
    {
        DatabaseHelper db = new DatabaseHelper();

        // lấy danh sách tất cả cư dân
        public DataTable GetAllResidentForEachUser(int id,String proc)
        {
            var parameters = new Dictionary<string, object>
            {
            { "@UserID", id },
            { "@ErrorMessage", null } 
            };

            var outputParamNames = new List<string> { "@ErrorMessage" };

            var (dataTable, outputValues) = db.ExecuteStoredProcedureWithDataTable(
                proc,
                parameters,
                outputParamNames
            );

            // Truy cập kết quả trả về từ SELECT
            string errorMessage = outputValues.ContainsKey("@ErrorMessage")
                ? outputValues["@ErrorMessage"]?.ToString()
                : null;

            // Xử lý kết quả
            if (!string.IsNullOrEmpty(errorMessage) && errorMessage.Contains("không có quyền"))
            {
                dataTable = null;
                return dataTable;
            }
            else
            {
                
                return  dataTable;
            }

        }



        // lấy ID theo ResidentName
        public DataTable  GetResidentByID(string Resident)
        {
            string query = $"SELECT ResidentID FROM ResidentData WHERE ResidentID = '{Resident}'";
            return db.ExecuteQuery(query);
        }

        // lấy danh sách cư dân theo trạng thái
        public DataTable GetResidentByStatus(string Status)
        {
            string query = $"SELECT * FROM ResidentData WHERE ResidentID IN (SELECT ResidentID FROM PassportApplications WHERE Status = '{Status}')"; ;
            return db.ExecuteQuery(query);
        }

        // Thêm dân cư 
        public string InsertEncryptedResident(ResidentDTO resident)
        {

            var parameters = new Dictionary<string, object>
    {
        { "@CMND", resident.CCCD },
        { "@FullName", resident.FullName },
        { "@Gender", resident.Gender },
        { "@DateOfBirth", resident.DOB },
        { "@Address", resident.Address },
        { "@PhoneNumber", resident.Phone },
        { "@Email", resident.Email },
        { "@ErrorMessage", DBNull.Value },
         {"@RegistrationID",DBNull.Value }
    };

            var outputParams = new List<string> { "@ErrorMessage","@RegistrationID" };

            var outputValues = db.ExecuteStoredProcedure("SP_InsertPassportRegistration", parameters, outputParams);

            var errorMessage = outputValues["@ErrorMessage"]?.ToString();

            return errorMessage;
        }

        //hàm update
        public string Registration(int registrationId,  string Reason)
        {
            try
            {
                var parameters = new Dictionary<string, object>
        {
            { "@RegistrationID", registrationId },
            { "@UserID", 2 },
            {"@ApplicationID", DBNull.Value },
            { "@ErrorMessage", null } // Output parameter
        };

                var outputParamNames = new List<string> { "@ErrorMessage", "@ApplicationID" };

                // Giả định: db.ExecuteNonQuery là hàm thực thi stored procedure không trả về dữ liệu
                var outputValues = db.ExecuteStoredProcedure(
                    "SP_TransferToReview",
                    parameters,
                    outputParamNames
                );

                string errorMessage = outputValues.ContainsKey("@ErrorMessage")
                    ? outputValues["@ErrorMessage"]?.ToString()
                    : null;

                return errorMessage ?? $"{Reason} đơn thành công!";
            }
            catch (Exception ex)
            {
                // Ghi log lỗi nếu cần
                return $"Lỗi hệ thống: {ex.Message}";
            }
        }

        // gửi thông báo qua email
        public bool NotificationByEmail(string EmailResident, string message)
        {
            string subject = "Thông báo từ hệ thống quản lý cư dân";
            try
            {
                string smtpServer = "smtp.gmail.com"; // Địa chỉ máy chủ SMTP
                int smtpPort = 587; // Cổng SMTP
                string Email = "ductonb123@gmail.com"; // Địa chỉ email người gửi
                string password = "cfbv wntl wuid fdds"; // Mật khẩu email người gửi
                string recipientEmail = EmailResident; // Địa chỉ email người nhận

                using (MailMessage mail = new MailMessage(Email, recipientEmail, subject, message))
                using (SmtpClient smtp = new SmtpClient(smtpServer, smtpPort))
                {
                    smtp.UseDefaultCredentials = false; // Không sử dụng thông tin xác thực mặc định
                    smtp.Credentials = new System.Net.NetworkCredential(Email, password);
                    smtp.EnableSsl = true; // Bật SSL nếu cần
                    smtp.Send(mail);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
