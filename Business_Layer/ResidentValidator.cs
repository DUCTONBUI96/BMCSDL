using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Data_Layer;

namespace Business_Layer
{
    public class ResidentValidator
    {
        public static string Validate(ResidentDTO resident)
        {
            if (string.IsNullOrWhiteSpace(resident.FullName))
                return "Vui lòng nhập họ và tên";

            if (string.IsNullOrWhiteSpace(resident.CCCD))
                return "Vui lòng nhập số CCCD";

            if (!Regex.IsMatch(resident.CCCD, @"^\d{12}$"))
                return "Số CCCD không hợp lệ";

            if (string.IsNullOrWhiteSpace(resident.Gender))
                return "Vui lòng chọn giới tính";

            if (string.IsNullOrWhiteSpace(resident.Nationality))
                return "Vui lòng chọn quốc tịch";

            if (string.IsNullOrWhiteSpace(resident.Email) ||
                !Regex.IsMatch(resident.Email, @"^[\w\-\.]+@([\w\-]+\.)+[\w\-]{2,4}$"))
                return "Email không hợp lệ";

            if (string.IsNullOrWhiteSpace(resident.Phone) ||
                !Regex.IsMatch(resident.Phone, @"^\d{10}$"))
                return "Số điện thoại không hợp lệ";

            if (string.IsNullOrWhiteSpace(resident.Address))
                return "Vui lòng nhập địa chỉ";

            return null; // valid
        }
    }
}
