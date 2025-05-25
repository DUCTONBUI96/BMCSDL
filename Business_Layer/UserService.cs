using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Layer;

namespace Business_Layer
{
    public class UserService
    {
        DatabaseHelper db = new DatabaseHelper();
        public int LoginAndGetRole(string username, string password)
        {
            string query = "SELECT RoleID FROM Users WHERE Username = @Username AND PasswordHash = @Password";
            var parameters = new Dictionary<string, object>
    {
        { "@Username", username },
        { "@Password", password }
    };

            var result = db.ExecuteScalar(query, parameters);

            if (result != null && int.TryParse(result.ToString(), out int roleId))
            {
                return roleId; // Trả về RoleID nếu đăng nhập thành công
            }

            return -1; // Đăng nhập thất bại hoặc không tìm thấy vai trò
        }

    }
}
