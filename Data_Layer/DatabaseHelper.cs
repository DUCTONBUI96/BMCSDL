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
        public object ExecuteStoredProcedure(string procedureName, Dictionary<string, object> parameters, string outputParamName = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(procedureName, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                foreach (var param in parameters)
                {
                    var p = cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    if (outputParamName != null && param.Key == outputParamName)
                    {
                        p.Direction = ParameterDirection.Output;
                    }
                }

                conn.Open();
                cmd.ExecuteNonQuery();

                if (outputParamName != null && cmd.Parameters.Contains(outputParamName))
                {
                    return cmd.Parameters[outputParamName].Value;
                }

                return null;
            }
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
