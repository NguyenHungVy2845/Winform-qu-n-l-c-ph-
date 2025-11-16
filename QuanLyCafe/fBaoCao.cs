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
    public partial class fBaoCao : Form
    {
        // Cấu hình lương (Lưu ý: Nên chỉnh cho khớp với bên form fNhanVien)
        // Ví dụ: Nếu bên fNhanVien là 200.000 thì sửa ở đây thành 200.000
        const decimal LUONG_MOT_NGAY = 500000;
        const decimal TRU_LUONG_NGHI = 500000;

        public fBaoCao()
        {
            InitializeComponent();
        }

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            // Lấy khoảng thời gian từ giao diện
            // ToDate: Cộng thêm 1 ngày và trừ 1 giây để lấy đến 23:59:59 của ngày đó
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);

            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                // =================================================================================
                // 1. TÍNH TỔNG DOANH THU (TIỀN VÀO)
                // =================================================================================
                // Lấy tất cả hóa đơn đã thanh toán (TrangThai = 1) trong khoảng thời gian
                var listBill = db.HoaDons
                                 .Where(x => x.ThoiGianRa >= from && x.ThoiGianRa <= to && x.TrangThai == 1)
                                 .ToList();

                decimal tongDoanhThu = 0;
                foreach (var bill in listBill)
                {
                    // Tính tổng tiền món ăn trong hóa đơn này
                    // Dùng (decimal?) và ?? 0 để tránh lỗi nếu hóa đơn bị rỗng chi tiết
                    decimal tienMon = db.ChiTietHoaDons
                                        .Where(ct => ct.IdHoaDon == bill.Id)
                                        .Sum(ct => (decimal?)(ct.SoLuong * ct.DonGiaTaiThoiDiem)) ?? 0;

                    // Doanh thu thực = (Tiền món) - (Tiền giảm giá của hóa đơn)
                    tongDoanhThu += (tienMon - bill.TienGiamGia);
                }

                // =================================================================================
                // 2. TÍNH TỔNG TIỀN NHẬP HÀNG (TIỀN RA - CHI PHÍ MUA HÀNG)
                // =================================================================================
                // Tính tổng tiền đã chi ra để nhập hàng trong khoảng thời gian này
                // Dựa trên bảng Lịch Sử Nhập Hàng
                decimal tongTienNhap = db.LichSuNhapHangs
                                         .Where(x => x.NgayNhap >= from && x.NgayNhap <= to)
                                         .Sum(x => (decimal?)(x.SoLuongNhap * x.DonGiaNhap)) ?? 0;

                // =================================================================================
                // 3. TÍNH TỔNG TIỀN LƯƠNG (TIỀN RA - CHI PHÍ NHÂN SỰ)
                // =================================================================================
                // Đếm số ngày đi làm (trong bảng ChamCong)
                var soNgayLam = db.ChamCongs.Count(x => x.ThoiGianVao >= from && x.ThoiGianVao <= to);

                // Đếm số ngày xin nghỉ (trong bảng NgayNghi)
                // Lưu ý: Thuộc tính trong code C# là NgayNghi1 (do trùng tên với class)
                var soNgayNghi = db.NgayNghis.Count(x => x.NgayNghi1 >= from && x.NgayNghi1 <= to);

                // Công thức lương: (Ngày làm * Lương ngày) - (Ngày nghỉ * Phạt)
                decimal tongLuong = (soNgayLam * LUONG_MOT_NGAY) - (soNgayNghi * TRU_LUONG_NGHI);

                // Đảm bảo lương không bị âm
                if (tongLuong < 0) tongLuong = 0;

                // =================================================================================
                // 4. TÍNH LỢI NHUẬN (DÒNG TIỀN CÒN LẠI)
                // =================================================================================
                // Công thức Cash Flow: Tiền thu về - Tiền chi mua hàng - Tiền trả lương
                decimal loiNhuan = tongDoanhThu - tongTienNhap - tongLuong;

                // =================================================================================
                // 5. HIỂN THỊ KẾT QUẢ LÊN GIAO DIỆN
                // =================================================================================
                lbDoanhThu.Text = $"Doanh thu: {tongDoanhThu:N0} VNĐ";
                lbTienNhap.Text = $"Tiền nhập hàng: {tongTienNhap:N0} VNĐ"; // Hiển thị dòng tiền chi ra
                lbTienLuong.Text = $"Tiền lương: {tongLuong:N0} VNĐ";

                lbLoiNhuan.Text = $"LỢI NHUẬN: {loiNhuan:N0} VNĐ";

                // Đổi màu chữ để dễ nhìn: Lời màu Xanh, Lỗ màu Đỏ
                if (loiNhuan >= 0)
                {
                    lbLoiNhuan.ForeColor = Color.Green;
                    lbLoiNhuan.Text += " (Lãi)";
                }
                else
                {
                    lbLoiNhuan.ForeColor = Color.Red;
                    lbLoiNhuan.Text += " (Lỗ)";
                }
            }
        }

        private void btnInBaoCao_Click(object sender, EventArgs e)
        {
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);

            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                // --- PHẦN 1: TÍNH TOÁN SỐ LIỆU (Copy lại logic từ nút Xem) ---

                // 1.1. Tính Doanh thu
                var listBill = db.HoaDons
                                 .Where(x => x.ThoiGianRa >= from && x.ThoiGianRa <= to && x.TrangThai == 1)
                                 .ToList();
                decimal tongDoanhThu = 0;
                foreach (var bill in listBill)
                {
                    decimal tienMon = db.ChiTietHoaDons
                                        .Where(ct => ct.IdHoaDon == bill.Id)
                                        .Sum(ct => (decimal?)(ct.SoLuong * ct.DonGiaTaiThoiDiem)) ?? 0;
                    tongDoanhThu += (tienMon - bill.TienGiamGia);
                }

                // 1.2. Tính Tiền Nhập Hàng
                decimal tongTienNhap = db.LichSuNhapHangs
                                         .Where(x => x.NgayNhap >= from && x.NgayNhap <= to)
                                         .Sum(x => (decimal?)(x.SoLuongNhap * x.DonGiaNhap)) ?? 0;

                // 1.3. Tính Tiền Lương
                var soNgayLam = db.ChamCongs.Count(x => x.ThoiGianVao >= from && x.ThoiGianVao <= to);
                var soNgayNghi = db.NgayNghis.Count(x => x.NgayNghi1 >= from && x.NgayNghi1 <= to);

                decimal tongLuong = (soNgayLam * LUONG_MOT_NGAY) - (soNgayNghi * TRU_LUONG_NGHI);
                if (tongLuong < 0) tongLuong = 0;

                // 1.4. Tính Lợi Nhuận
                decimal loiNhuan = tongDoanhThu - tongTienNhap - tongLuong;

                // --- PHẦN 2: ĐỔ DỮ LIỆU VÀO REPORT ---

                dsBill ds = new dsBill();
                var row = ds.dtBaoCao.NewdtBaoCaoRow();

                // Gán các biến vừa tính được vào dòng dữ liệu
                row.DoanhThu = (double)tongDoanhThu;
                row.GiaVon = (double)tongTienNhap;    // Ở đây dùng tạm cột GiaVon để hiện Tiền Nhập
                row.ChiPhiLuong = (double)tongLuong;
                row.LoiNhuan = (double)loiNhuan;
                row.ThoiGian = string.Format("Từ {0:dd/MM/yyyy} đến {1:dd/MM/yyyy}", dtpFrom.Value, dtpTo.Value);

                ds.dtBaoCao.AdddtBaoCaoRow(row);

                // Gọi form hiển thị
                fShowBaoCao f = new fShowBaoCao(ds.dtBaoCao);
                f.ShowDialog();
            }
        }
    }
}