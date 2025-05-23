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
        private DatabaseHelper db = new DatabaseHelper();
        public void UpdateStatusAndNote(int residentID,string reviewNote, string status)
        {
            // Cập nhật trạng thái của người dân
            string query = $"UPDATE PassportApplications SET Status = N'{status}', ReviewNotes = @ReviewNote WHERE ResidentID = @ResidentID";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@ReviewNote", reviewNote },
                { "@ResidentID", residentID }
            };
            db.ExecuteNonQuery(query, parameters);
        }
        public void UpdateStatus(int residentID, string status)
        {
            // Cập nhật trạng thái của người dân
            string query = $"UPDATE PassportApplications SET Status = N'{status}' WHERE ResidentID = @ResidentID";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                { "@ResidentID", residentID }
            };
            db.ExecuteNonQuery(query, parameters);
        }
    }
}
