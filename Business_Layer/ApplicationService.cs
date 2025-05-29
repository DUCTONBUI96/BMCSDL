using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_Layer;

namespace Business_Layer
{
    public class ApplicationService
    {
        private DatabaseHelper db = new DatabaseHelper();//goi csdl

        // Cập nhật trạng thái của người dân
        public void UpdateStatusAndNote(int residentID,string reviewNote, string status)
        {  
            string query = $"UPDATE PassportApplications SET Status = N'{status}', ReviewNotes = @ReviewNote WHERE ResidentID = @ResidentID";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@ReviewNote", reviewNote },
                { "@ResidentID", residentID }
            };
            db.ExecuteNonQuery(query, parameters);
        }

        public bool Update(int id, string Proce, string status)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>
    {
        { "@ApplicationID", id },
        { "@UserID", 3 }, 
        { "@Status", status }, 
        { "@ReviewNotes", "Hồ sơ hợp lệ" },
        { "@PassportID",string.Empty },
        { "@ErrorMessage", string.Empty } 
    };

            var outputParamNames = new List<string> { "@ErrorMessage","@PassportID" };
            // Giả sử ExecuteStoredProcedure trả về Dictionary<string, object>
            var result = db.ExecuteStoredProcedure(Proce, parameters, outputParamNames);

            // Kiểm tra kết quả và trả về
            if (result != null && result.ContainsKey("@ErrorMessage"))
            {
                string errorMsg = result["@ErrorMessage"].ToString();
                return string.IsNullOrEmpty(errorMsg) || errorMsg.Contains("thành công");
            }

            return false; // Trường hợp không đọc được kết quả
        }

        // Cập nhật trạng thái của người dân không có ghi chú
        public bool UpdateStatus(int id, string status, out string errorMessage, out int? applicationId)
        {
            errorMessage = null;
            applicationId = null;
            try
            {
                var parameters = new Dictionary<string, object>
        {
            { "@RegistrationID", id },
            { "@UserID", 2 },
            { "@ApplicationID", null },
            { "@ErrorMessage", null }
        };

                var outputValues = db.ExecuteStoredProcedure(
                    status,
                    parameters,
                    new List<string> { "@ErrorMessage", "@ApplicationID" }
                );

                // Xử lý ErrorMessage
                errorMessage = outputValues["@ErrorMessage"]?.ToString();

                // Xử lý ApplicationID (kiểm tra NULL/DBNull trước)
                if (outputValues["@ApplicationID"] != null && outputValues["@ApplicationID"] != DBNull.Value)
                {
                    applicationId = Convert.ToInt32(outputValues["@ApplicationID"]);
                }

                return string.IsNullOrEmpty(errorMessage);
            }
            catch (Exception ex)
            {
                errorMessage = $"Lỗi khi cập nhật trạng thái: {ex.Message}";
                return false;
            }
        }

        public bool UpdateStatusReject(int id, string status, out string errorMessage, out int? applicationId)
        {
            errorMessage = null;
            applicationId = null;
            try
            {
                var parameters = new Dictionary<string, object>
        {
            { "@RegistrationID", id },
            { "@UserID", 2 },
            { "@ErrorMessage", null }
        };

                var outputValues = db.ExecuteStoredProcedure(
                    status,
                    parameters,
                    new List<string> { "@ErrorMessage" }
                );

                // Xử lý ErrorMessage
                errorMessage = outputValues["@ErrorMessage"]?.ToString();

                // Xử lý ApplicationID (kiểm tra NULL/DBNull trước)
                if (outputValues["@ApplicationID"] != null && outputValues["@ApplicationID"] != DBNull.Value)
                {
                    applicationId = Convert.ToInt32(outputValues["@ApplicationID"]);
                }

                return string.IsNullOrEmpty(errorMessage);
            }
            catch (Exception ex)
            {
                errorMessage = $"Lỗi khi cập nhật trạng thái: {ex.Message}";
                return false;
            }
        }

        public void UpdateStatusAndNote(int residentID, string reviewNote)
        {
            string query = $"UPDATE PassportApplications SET ReviewNotes = @ReviewNote WHERE ResidentID = @ResidentID";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@ReviewNote", reviewNote },
                { "@ResidentID", residentID }
            };
            db.ExecuteNonQuery(query, parameters);
        }

        // Lấy trạng thái của người dân
        public string TakeStatus(string CCCD)
        {
            var parameters = new Dictionary<string, object>
    {
        { "@CMND", CCCD },
        { "@Status", DBNull.Value },
        { "@Message", DBNull.Value }
    };

            var outputParamNames = new List<string> { "@Message", "@Status" };

            var result = db.ExecuteStoredProcedure("SP_GetPassportStatusByCMND", parameters, outputParamNames);
            string finalStatus = result.TryGetValue("@Status", out var status).ToString();
            
            return status.ToString();
        }



    }
}
