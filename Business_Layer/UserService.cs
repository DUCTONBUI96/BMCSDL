using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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


        //Get all user
        public DataTable GetAllUser()
        {
            string query = "SELECT UserID,Username,PasswordHash,RoleID,IsActive,CreatedAT FROM Users";
            return db.ExecuteQuery(query);
        }

        //Insert new user
        public void InsertUser(string user, string password, int RoleID)
        {
            string query = "INSERT INTO Users (Username, PasswordHash, RoleID) VALUES (@Username, @PasswordHash, @RoleID)";
            var parameters = new Dictionary<string, object>
            {
                { "@Username", user },
                { "@PasswordHash", password },
                { "@RoleID", RoleID }
            };
            db.ExecuteNonQuery(query, parameters);
        }

        //Check password
        public bool CheckPassword(int userId, string password)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE UserID = @UserID AND PasswordHash = @Password";
            var parameters = new Dictionary<string, object>
            {
                { "@UserID", userId },
                { "@Password", password }
            };
            var result = db.ExecuteScalar(query, parameters);
            return result != null && Convert.ToInt32(result) > 0;
        }

        //reset pass user
        public void ResetPassword(int userId, string newPass)
        {
            string query = "UPDATE Users SET PasswordHash = @NewPassword WHERE UserID = @UserID";
            var parameters = new Dictionary<string, object>
            {
                { "@NewPassword", newPass },
                { "@UserID", userId }
            };
            db.ExecuteNonQuery(query, parameters);
        }

        //lock user
        public void LockUser(int userId, int IA)
        {
            string query = "UPDATE Users SET IsActive = @IA WHERE UserID = @UserID";
            var parameters = new Dictionary<string, object>
            {
                { "@UserID", userId },
                { "@IA", IA }

            };
            db.ExecuteNonQuery(query, parameters);
        }


        //băm mật khẩu với salt
        public byte[] HashPassword(string password, out byte[] salt)
        {
            // Tạo salt
            using (var rng = new RNGCryptoServiceProvider())
            {
                salt = new byte[16];
                rng.GetBytes(salt);
            }

            // Kết hợp salt + password
            var combined = salt.Concat(Encoding.UTF8.GetBytes(password)).ToArray();
            using (var sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(combined); 
            }
        }

        //lấy Role ID theo UserID
        public int GetRoleIdByUserId(string RoleName)
        {
            string query = "SELECT RoleID FROM Roles WHERE RoleName = @RoleName";
            var parameters = new Dictionary<string, object>
            {
                { "@RoleName", RoleName }
            };
            var result = db.ExecuteScalar(query, parameters);
            return result != null ? Convert.ToInt32(result) : -1; 
        }

        //Create new user
        public void CreateUser(string username, string password, string email,string roleName)
        {
            byte[] salt;
            byte[] emailHash = HashPassword(email, out salt);
            int roleId = GetRoleIdByUserId(roleName);
            string query = "INSERT INTO Users (Username, Salt,PasswordHash, RoleID, ContactInfo) VALUES (@Username, @Salt,@PasswordHash, @RoleID, @ContactInfo)";
            var parameters = new Dictionary<string, object>
            {
                { "@Username", username },
                { "@PasswordHash", password },
                { "@RoleID", roleId },
                {"@Salt", salt },
                { "@ContactInfo", emailHash } 
            };
            db.ExecuteNonQuery(query, parameters);
        }
    }
}
