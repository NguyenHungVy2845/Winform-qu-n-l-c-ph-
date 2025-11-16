using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class ChucNang : Form
    {
        public ChucNang()
        {
            InitializeComponent();

            // Gán sự kiện Click cho các nút
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // --- BỔ SUNG MỚI ---
            // Code sẽ báo lỗi dòng này nếu bạn chưa thêm nút tên 'btnKhuyenMai' ở Bước 1
            this.btnKhuyenMai.Click += new System.EventHandler(this.btnKhuyenMai_Click);
        }

        // Sự kiện Form Load: Phân quyền người dùng
        private void ChucNang_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session.CurrentUser != null)
                {
                    // Hiển thị tên
                    lblWelcome.Text = $"Chào mừng: {Session.CurrentUser.TenHienThi}";

                    // Phân quyền: 0 = Nhân viên, 1 = Quản lý
                    if (Session.CurrentUser.LoaiTaiKhoan == 0) // Là Nhân Viên
                    {
                        btnAdmin.Enabled = false;
                        btnThongKe.Enabled = false;
                        btnKhuyenMai.Enabled = false; // --- BỔ SUNG MỚI ---
                    }
                    else // Là Quản lý (Admin)
                    {
                        btnAdmin.Enabled = true;
                        btnThongKe.Enabled = true;
                        btnKhuyenMai.Enabled = true; // --- BỔ SUNG MỚI ---
                    }
                }
                else
                {
                    // Trường hợp chạy thẳng không Login (để test)
                    lblWelcome.Text = "Chào mừng: (Chưa đăng nhập)";
                    btnAdmin.Enabled = false; // Khóa hết nếu chưa đăng nhập
                    btnThongKe.Enabled = false;
                    btnKhuyenMai.Enabled = false; // --- BỔ SUNG MỚI ---
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi phân quyền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- CÁC NÚT ĐIỀU HƯỚNG ---

        // Nút 1: Vào trang Quản trị (Admin)
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            QuanLy f = new QuanLy();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        // Nút 2: Vào trang Bán hàng (POS)
        private void btnBanHang_Click(object sender, EventArgs e)
        {
            TableManager f = new TableManager();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        // Nút 3: Vào trang Thống kê (Mới)
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            fThongKe f = new fThongKe();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        // Nút 4: Vào trang Nhân Viên (Mới)
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            fNhanVien f = new fNhanVien();
            f.ShowDialog();
        }

        // --- HÀM MỚI ĐƯỢC BỔ SUNG ---
        // Nút 5: Vào trang tạo Combo/Khuyến mãi
        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            fKhuyenMai f = new fKhuyenMai();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        //Nút 6: Nhập hàng
        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            // Chỉ quản lý mới được nhập hàng
            if (Session.CurrentUser.LoaiTaiKhoan == 0)
            {
                MessageBox.Show("Bạn không có quyền nhập hàng!");
                return;
            }
            fNhapHang f = new fNhapHang();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        // NÚT 7: Báo cáo
        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUser.LoaiTaiKhoan == 0)
            {
                MessageBox.Show("Bạn không có quyền xem báo cáo!");
                return;
            }
            fBaoCao f = new fBaoCao();
            f.ShowDialog();
        }

        // Nút 8: Top món ăn bán chạy
        private void btnTopMon_Click(object sender, EventArgs e)
        {
            fTopBanChay f = new fTopBanChay();
            f.ShowDialog();
        }

        // Nút 9: Đăng xuất (Ghi chấm công ra)
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUser == null)
            {
                this.Close(); // Nếu chưa đăng nhập thì đóng luôn
                return;
            }

            var username = Session.CurrentUser.TenDangNhap;
            try
            {
                // Cập nhật ThoiGianRa cho bản ghi ChamCong gần nhất
                using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
                {
                    var last = db.ChamCongs.Where(c => c.TenDangNhap == username && c.ThoiGianRa == null)
                                           .OrderByDescending(c => c.ThoiGianVao)
                                           .FirstOrDefault();
                    if (last != null)
                    {
                        last.ThoiGianRa = DateTime.Now;
                        db.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật chấm công: {ex.Message}", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Xóa session và đóng form để trở về Login
            Session.CurrentUser = null;
            this.Close();
        }
    }
}