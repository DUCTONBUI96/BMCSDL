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


        // Phương thức thực thi câu lệnh SQL trả về dữ liệu dạng DataTable và các tham số đầu ra
        public (DataTable, Dictionary<string, object>) ExecuteStoredProcedureWithDataTable(
        string procedureName,
        Dictionary<string, object> parameters,
        List<string> outputParamNames)
        {
            var outputValues = new Dictionary<string, object>();
            DataTable result = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Predefined output parameters
                    var outputParamTypeMap = new Dictionary<string, (SqlDbType Type, int Size)>
            {
                { "@ErrorMessage", (SqlDbType.NVarChar, 255) },
                { "@IsAuthenticated", (SqlDbType.Bit, 0) },
                { "@UserID", (SqlDbType.Int, 0) },
                { "@RoleID", (SqlDbType.Int, 0) }
            };

                    // Add input parameters
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            var p = cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);

                            // Mark as output if specified and exists in output map
                            if (outputParamNames?.Contains(param.Key) == true &&
                                outputParamTypeMap.ContainsKey(param.Key))
                            {
                                var (type, size) = outputParamTypeMap[param.Key];
                                p.SqlDbType = type;
                                if (size > 0) p.Size = size;
                                p.Direction = ParameterDirection.InputOutput;
                            }
                        }
                    }

                    // Add additional output parameters not in input
                    if (outputParamNames != null)
                    {
                        foreach (var outParam in outputParamNames)
                        {
                            if (!cmd.Parameters.Contains(outParam) &&
                                outputParamTypeMap.ContainsKey(outParam))
                            {
                                var (type, size) = outputParamTypeMap[outParam];
                                var p = new SqlParameter(outParam, type);
                                if (size > 0) p.Size = size;
                                p.Direction = ParameterDirection.Output;
                                cmd.Parameters.Add(p);
                            }
                        }
                    }

                    conn.Open();

                    // Handle result set if any
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            result.Load(reader);
                        }
                    }

                    // Collect output values
                    if (outputParamNames != null)
                    {
                        foreach (var outParam in outputParamNames)
                        {
                            if (cmd.Parameters.Contains(outParam))
                            {
                                outputValues[outParam] = cmd.Parameters[outParam].Value;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log error or handle as needed
                throw new ApplicationException($"Error executing stored procedure {procedureName}", ex);
            }

            return (result, outputValues);
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
