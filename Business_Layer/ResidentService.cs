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

        // lấy danh sách cư dân theo trạng thái
        public DataTable GetResidentByStatus(string Status)
        {
            string query = $"SELECT * FROM ResidentData WHERE ResidentID IN (SELECT ResidentID FROM PassportApplications WHERE Status = '{Status}')"; ;
            return db.ExecuteQuery(query);
        }

        // Thêm dân cư 
        public bool InsertResident(ResidentDTO resident)
        {
            string query = "INSERT INTO ResidentData (FullName, Gender, DateOfBirth, CMND, Address, Nationality, PhoneNumber, Email) " +
                           "VALUES (@FullName, @Gender, @DateOfBirth, @CMND, @Address, @Nationality, @PhoneNumber, @Email)";

            var parameters = new Dictionary<string, object>
        {
            { "@FullName", resident.FullName },
            { "@Gender", resident.Gender },
            { "@DateOfBirth", resident.DOB },
            { "@CMND", resident.CCCD },
            { "@Address", resident.Address },
            { "@Nationality", resident.Nationality },
            { "@PhoneNumber", resident.Phone },
            { "@Email", resident.Email }
        };
            return db.ExecuteNonQuery(query, parameters) > 0;
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
