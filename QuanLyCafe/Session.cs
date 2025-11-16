using System;

namespace QuanLyCafe
{
    public static class Session
    {
        // Lưu tài khoản hiện tại sau khi đăng nhập thành công
        public static TaiKhoan CurrentUser { get; set; }
    }
}
