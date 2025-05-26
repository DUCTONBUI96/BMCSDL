using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer
{
    public class FunctionService
    {
        //hàm tạo mã OTP
        public string GererateOTP()
        {
            Random random = new Random();
            int otp = random.Next(100000, 1000000); // Tạo OTP 6 chữ số
            return otp.ToString();
        }
    }
}
