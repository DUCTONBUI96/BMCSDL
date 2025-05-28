using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        // Cập nhật trạng thái của người dân không có ghi chú
        public void UpdateStatus(int residentID, string status)
        {
            string query = $"UPDATE PassportApplications SET Status = N'{status}' WHERE ResidentID = @ResidentID";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@ResidentID", residentID }
            };
            db.ExecuteNonQuery(query, parameters);
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
            
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@CMND", CCCD },
                { "@ErrorMessage", null }
            };
            var outputParamNames = new List<string> { "@ErrorMessage" };
            object result = db.ExecuteStoredProcedure("SP_ViewResidentApplicationStatus", parameters, outputParamNames);
            return result != null ? result.ToString() : null;
        }

    }
}
