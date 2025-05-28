using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data_Layer
{
    public class DatabaseHelper
    {
        private string connectionString = "Data Source=.;Initial Catalog=PassportManagement;Integrated Security=True";

        //phương thức thực thi câu lệnh SQL TRẢ VỀ DỮ LIỆU DẠNG BẢNG (SELECT)
        public DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                con.Open();
                da.Fill(dt);
            }
            return dt;
        }

        //Phương thức thực thi câu lệnh SQL không trả về dữ liệu (INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                // Thêm các tham số truyền vào (nếu có)
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                }

                con.Open(); 
                return cmd.ExecuteNonQuery(); 
            }
        }

        //Phương thức thực thi câu lệnh SQL không trả về dữ liệu (INSERT, UPDATE, DELETE) với tham số kiểu VarBinary
        public Dictionary<string, object> ExecuteStoredProcedure(
        string procedureName,
        Dictionary<string, object> parameters,
        List<string> outputParamNames)
        {
            var outputValues = new Dictionary<string, object>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(procedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                // Map kiểu cho output parameters
                var outputParamTypeMap = new Dictionary<string, SqlParameter>
        {
            { "@ErrorMessage", new SqlParameter("@ErrorMessage", SqlDbType.NVarChar, 255) { Direction = ParameterDirection.Output } },
            { "@IsAuthenticated", new SqlParameter("@IsAuthenticated", SqlDbType.Bit) { Direction = ParameterDirection.Output } },
            { "@UserID", new SqlParameter("@UserID", SqlDbType.Int) { Direction = ParameterDirection.Output } },
            { "@RoleID", new SqlParameter("@RoleID", SqlDbType.Int) { Direction = ParameterDirection.Output } }
        };

                // Thêm các input parameters
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        var p = cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);

                        // Nếu là output parameter, chỉnh lại kiểu và hướng
                        if (outputParamNames != null && outputParamNames.Contains(param.Key) && outputParamTypeMap.ContainsKey(param.Key))
                        {
                            p.SqlDbType = outputParamTypeMap[param.Key].SqlDbType;
                            p.Size = outputParamTypeMap[param.Key].Size;
                            p.Direction = ParameterDirection.Output;
                        }
                    }
                }

                // Thêm output parameters nếu chưa có
                if (outputParamNames != null)
                {
                    foreach (var outParam in outputParamNames)
                    {
                        if (!cmd.Parameters.Contains(outParam) && outputParamTypeMap.ContainsKey(outParam))
                        {
                            cmd.Parameters.Add(outputParamTypeMap[outParam]);
                        }
                    }
                }

                conn.Open();
                cmd.ExecuteNonQuery();

                // Lấy giá trị output
                foreach (var outParam in outputParamNames)
                {
                    outputValues[outParam] = cmd.Parameters[outParam].Value;
                }
            }

            return outputValues;
        }





        //Phương thức thực thi câu lệnh SQL trả về một giá trị đơn (SELECT)
        public object ExecuteScalar(string query, Dictionary<string, object> parameters)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                }

                con.Open();
                return cmd.ExecuteScalar();
            }
        }
    }
}
