using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace QuanLyCafe
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Có thể thêm code load cấu hình nếu cần
        }

        // --- HÀM MÃ HÓA SHA256 (Dùng UTF8) ---
        private static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Chuyển đổi chuỗi thành mảng byte (Dùng UTF8 cho chuẩn quốc tế)
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Chuyển mảng byte thành chuỗi hex
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        // --- XỬ LÝ ĐĂNG NHẬP ---
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txbUserName.Text.Trim();
            string password = txbPassWord.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Mã hóa mật khẩu người dùng nhập vào
                string hashedPass = ComputeSha256Hash(password);

                using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
                {
                    // 2. Tìm tài khoản trong CSDL
                    var user = db.TaiKhoans.SingleOrDefault(t => t.TenDangNhap == username && t.MatKhauMaHoa == hashedPass);

                    if (user == null)
                    {
                        MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // 3. Kiểm tra tài khoản có bị khóa không
                    if (user.DangHoatDong == false)
                    {
                        MessageBox.Show("Tài khoản này đã bị khóa. Vui lòng liên hệ Admin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    // 4. Đăng nhập thành công -> Lưu Session
                    Session.CurrentUser = user;

                    // 5. Ghi log chấm công (Nếu có lỗi chấm công thì bỏ qua, vẫn cho vào)
                    try
                    {
                        ChamCong cc = new ChamCong()
                        {
                            TenDangNhap = user.TenDangNhap,
                            ThoiGianVao = DateTime.Now,
                            ThoiGianRa = null
                        };
                        db.ChamCongs.InsertOnSubmit(cc);
                        db.SubmitChanges();
                    }
                    catch { /* Bỏ qua lỗi chấm công nếu chưa có bảng */ }

                    // 6. Chuyển sang Form Chính
                    ChucNang f = new ChucNang();
                    this.Hide();
                    f.ShowDialog();
                    this.Show(); // Hiện lại form login khi đăng xuất
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu:\n" + ex.Message, "Lỗi Hệ Thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txbPassWord.Text = ""; // Xóa mật khẩu sau khi xử lý xong
            }
        }

        // --- NÚT THOÁT ---
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // --- SỰ KIỆN ĐÓNG FORM ---
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        // --- NÚT THÔNG TIN QUÁN (Nếu có) ---
        private void btnThongTinQuan_Click(object sender, EventArgs e)
        {
            ThongTinNhom f = new ThongTinNhom();
            f.ShowDialog();
        }

        private void MatKhau_Click(object sender, EventArgs e) { }
    }
}