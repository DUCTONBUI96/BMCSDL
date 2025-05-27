using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;
using Data_Layer.NewFolder1;

namespace Business_Layer
{
    public class FunctionService
    {

        private DatabaseHelper db = new DatabaseHelper();
        //hàm tạo mã OTP
        public string GererateOTP()
        {
            Random random = new Random();
            int otp = random.Next(100000, 1000000); // Tạo OTP 6 chữ số
            return otp.ToString();
        }

        //Hàm systemLog
        public void SystemLog(string Type, string ID,string EType)
        {
            string query = @"
            INSERT INTO SystemLogs 
            (UserID, ActionType, EntityType, EntityID, Description, IPAddress)
            VALUES 
            (@UserID, @ActionType, @EntityType, @EntityID, @Description, @IPAddress)";

            var parameters = new Dictionary<string, object>
            {
                { "@UserID", Session.RoleId },
                { "@ActionType", Type }, 
                { "EntityType", EType },
                { "@EntityID", ID },
                { "@Description", "Thực hiện hành động " + Type + " trên thực thể " + EType + " với ID " + ID },
                {"@IPAddress","192.168.1.10" }
            };
            db.ExecuteNonQuery(query, parameters);
        }

        // Hàm audittrail
        public void AUdit()
        {

        }

    }
}
