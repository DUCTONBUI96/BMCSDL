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
        public void UpdateStatus(int residentID,string reviewNote, string status)
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
    }
}
