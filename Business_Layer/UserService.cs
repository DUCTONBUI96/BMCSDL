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
            var parameters = new Dictionary<string, object>
    {
        { "@Username", username },
        { "@Password", password },
        { "@IsAuthenticated", DBNull.Value },
        { "@RoleID", DBNull.Value },
        { "@UserID", DBNull.Value },
        { "@ContactInfo", DBNull.Value },
        { "@ErrorMessage", DBNull.Value }
    };

            var outputParams = new List<string> { "@IsAuthenticated", "@RoleID", "@UserID", "@ContactInfo", "@ErrorMessage" };
            var result = db.ExecuteStoredProcedure("SP_AuthenticateUser", parameters, outputParams);

            // Kiểm tra kết quả đầu ra
            return result["@IsAuthenticated"] != null && Convert.ToBoolean(result["@IsAuthenticated"]) ? Convert.ToInt32(result["@RoleID"]) : 0;
        }



        //Get all user
        public DataTable GetAllUser()
        {
            string query = "SELECT" +
                "  u.UserID," +
                "  u.Username," +
                "  r.RoleName  FROM  Users u JOIN Roles r ON u.RoleID = r.RoleID; ";
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


        //lấy Role ID theo UserID
        public string GetRoleIdByUserId(string RoleName)
        {
            string query = "SELECT RoleID FROM Roles WHERE RoleName = @RoleName";
            var parameters = new Dictionary<string, object>
            {
                { "@RoleName", RoleName }
            };
            object result = db.ExecuteScalar(query, parameters);
            return result != null ? result.ToString() : null;
        }

        //Create new user
        public void CreateUser(string username, string password, string email, string roleName)
        {
            string roleId = GetRoleIdByUserId(roleName);

            var parameters = new Dictionary<string, object>
        {
        { "@Username", username },
        { "@Password", password },
        { "@ContactInfo", email },
        { "@RoleID", roleId }
        };

            var outputs = db.ExecuteStoredProcedure("SP_PlusUser", parameters, new List<string> { "@UserID", "@ErrorMessage" });
        }

        //Lấy thông tin liên hệ của người dùng theo UserID
        public string GetUserContactInfo(int userId)
        {
            string query = "SELECT  FROM Users WHERE UserID = @UserID";
            var parameters = new Dictionary<string, object>
            {
                { "@UserID", userId }
            };
            object result = db.ExecuteScalar(query, parameters);
            return result != null ? result.ToString() : null;
        }
    }
}
