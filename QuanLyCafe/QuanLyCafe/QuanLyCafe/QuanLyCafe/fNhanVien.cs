using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class fNhanVien : Form
    {
        // Lương cứng 1 ngày làm (Ví dụ)
        const decimal LUONG_MOT_NGAY = 200000;
        // Phạt trừ lương khi nghỉ
        const decimal TRU_LUONG_NGHI = 200000;

        public fNhanVien()
        {
            InitializeComponent();
        }

        private void fNhanVien_Load(object sender, EventArgs e)
        {
            LoadThongTin();
            LoadLichSuNghi();
        }

        void LoadThongTin()
        {
            if (Session.CurrentUser == null) return;

            string username = Session.CurrentUser.TenDangNhap;
            lbXinChao.Text = "Xin chào: " + Session.CurrentUser.TenHienThi;

            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                // 1. Tính số ngày đi làm (Dựa vào bảng ChamCong)
                int soNgayLam = db.ChamCongs.Count(x => x.TenDangNhap == username);

                // 2. Tính số ngày đã xin nghỉ
                int soNgayNghi = db.NgayNghis.Count(x => x.TenDangNhap == username);

                // 3. Tính lương
                decimal luong = (soNgayLam * LUONG_MOT_NGAY) - (soNgayNghi * TRU_LUONG_NGHI);
                if (luong < 0) luong = 0;

                lbNgayLam.Text = soNgayLam.ToString();
                lbNgayNghi.Text = soNgayNghi.ToString();
                lbLuong.Text = luong.ToString("N0") + " VNĐ";
            }
        }

        void LoadLichSuNghi()
        {
            if (Session.CurrentUser == null) return;
            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                dtgvLichSu.DataSource = db.NgayNghis
                                          .Where(x => x.TenDangNhap == Session.CurrentUser.TenDangNhap)
                                          // SỬA LỖI 1: Đổi NgayNghi thành NgayNghi1
                                          .Select(x => new { Ngày = x.NgayNghi1, Lý_Do = x.LyDo })
                                          .ToList();
            }
        }

        private void btnXinNghi_Click(object sender, EventArgs e)
        {
            if (Session.CurrentUser == null)
            {
                MessageBox.Show("Vui lòng đăng nhập trước!");
                return;
            }

            DateTime ngayNghi = dtpNgayNghi.Value.Date;
            string lyDo = tbLyDo.Text;

            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                // SỬA LỖI 2: Đổi NgayNghi thành NgayNghi1
                if (db.NgayNghis.Any(x => x.TenDangNhap == Session.CurrentUser.TenDangNhap && x.NgayNghi1 == ngayNghi))
                {
                    MessageBox.Show("Bạn đã xin nghỉ ngày này rồi!");
                    return;
                }

                NgayNghi don = new NgayNghi()
                {
                    TenDangNhap = Session.CurrentUser.TenDangNhap,
                    // SỬA LỖI 3: Đổi NgayNghi thành NgayNghi1
                    NgayNghi1 = ngayNghi,
                    LyDo = lyDo
                };

                db.NgayNghis.InsertOnSubmit(don);
                db.SubmitChanges();

                MessageBox.Show("Đã gửi yêu cầu nghỉ! (Bị trừ 200k)");
                LoadThongTin(); // Cập nhật lại lương
                LoadLichSuNghi();
            }
        }

        private void btnInLuong_Click(object sender, EventArgs e)
        {
            // Lấy tháng được chọn từ DateTimePicker
            DateTime thangChon = dtpThang.Value;

            // Xác định ngày đầu tháng và cuối tháng
            DateTime from = new DateTime(thangChon.Year, thangChon.Month, 1);
            DateTime to = from.AddMonths(1).AddDays(-1).AddHours(23).AddMinutes(59).AddSeconds(59);

            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                dsBill ds = new dsBill();

                // Lấy danh sách nhân viên đang hoạt động
                var listNV = db.TaiKhoans.Where(x => x.DangHoatDong == true).ToList();

                foreach (var nv in listNV)
                {
                    // --- TÍNH TOÁN CHO TỪNG NHÂN VIÊN ---

                    // Đếm ngày làm
                    int soNgayLam = db.ChamCongs.Count(cc => cc.TenDangNhap == nv.TenDangNhap
                                                         && cc.ThoiGianVao >= from
                                                         && cc.ThoiGianVao <= to);

                    // Đếm ngày nghỉ (Chú ý: tên cột là NgayNghi1)
                    int soNgayNghi = db.NgayNghis.Count(nn => nn.TenDangNhap == nv.TenDangNhap
                                                         && nn.NgayNghi1 >= from
                                                         && nn.NgayNghi1 <= to);

                    // Tính lương thực lĩnh
                    decimal luongThucLinh = (soNgayLam * LUONG_MOT_NGAY) - (soNgayNghi * TRU_LUONG_NGHI);
                    if (luongThucLinh < 0) luongThucLinh = 0;

                    // --- ĐỔ VÀO DÒNG DỮ LIỆU ---
                    var row = ds.dtLuong.NewdtLuongRow();
                    row.TenNhanVien = nv.TenHienThi;
                    row.NgayCong = soNgayLam;
                    row.NgayNghi = soNgayNghi;
                    row.TongLuong = (double)luongThucLinh;
                    row.Thang = "Tháng " + thangChon.ToString("MM/yyyy");

                    ds.dtLuong.AdddtLuongRow(row);
                }

                // Gọi form hiển thị
                fShowLuong f = new fShowLuong(ds.dtLuong);
                f.ShowDialog();
            }
        }
    }
}