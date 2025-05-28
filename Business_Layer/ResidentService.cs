using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;

namespace Business_Layer
{
    public class ResidentService
    {
        DatabaseHelper db = new DatabaseHelper();

        // lấy danh sách tất cả cư dân
        public DataTable GetAllResident()
        {
            string query = "SELECT * FROM ResidentData";
            return db.ExecuteQuery(query);
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
