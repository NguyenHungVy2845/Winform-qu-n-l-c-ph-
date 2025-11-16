using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class fNhapHang : Form
    {
        public fNhapHang()
        {
            InitializeComponent();
        }

        // Sự kiện khi mở Form
        private void fNhapHang_Load(object sender, EventArgs e)
        {
            LoadKhoHang();
            LoadLichSu(); // <--- THÊM DÒNG NÀY

            lbTenMon.Text = "Chọn món từ danh sách";
            lbTenMon.Tag = null;
        }

        // Hàm load danh sách món và tồn kho hiện tại
        void LoadKhoHang()
        {
            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                var list = from m in db.Mons
                           select new
                           {
                               ID = m.Id,
                               Tên_Món = m.TenMon,
                               Tồn_Kho = m.SoLuongTon,
                               Giá_Bán = m.GiaTien,
                               Giá_Vốn_Mới_Nhất = m.GiaNhap
                           };
                dtgvKho.DataSource = list.ToList();
            }
        }

        // --- HÀM MỚI: LOAD LỊCH SỬ NHẬP HÀNG ---
        void LoadLichSu()
        {
            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                // Lấy dữ liệu từ bảng LichSuNhapHang, sắp xếp ngày gần nhất lên đầu
                var listHistory = from ls in db.LichSuNhapHangs
                                  orderby ls.NgayNhap descending
                                  select new
                                  {
                                      Tên_Món = ls.Mon.TenMon,
                                      Số_Lượng = ls.SoLuongNhap,
                                      Đơn_Giá = ls.DonGiaNhap,
                                      Thành_Tiền = ls.TongTien, // Cột này SQL tự tính
                                      Ngày_Nhập = ls.NgayNhap
                                  };

                // Gán vào bảng dtgvLichSu mới tạo
                dtgvLichSu.DataSource = listHistory.ToList();
            }
        }

        // Sự kiện click vào bảng Kho để chọn món
        private void dtgvKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dtgvKho.SelectedCells.Count == 0) return;

            int rowIndex = dtgvKho.SelectedCells[0].OwningRow.Index;

            var cellId = dtgvKho.Rows[rowIndex].Cells["ID"].Value;
            var cellTen = dtgvKho.Rows[rowIndex].Cells["Tên_Món"].Value;
            var cellGiaVon = dtgvKho.Rows[rowIndex].Cells["Giá_Vốn_Mới_Nhất"].Value;

            if (cellId != null)
            {
                lbTenMon.Text = cellTen.ToString();
                lbTenMon.Tag = (int)cellId;

                if (cellGiaVon != null)
                    nmGiaNhap.Value = Convert.ToDecimal(cellGiaVon);
            }
        }

        // Nút Nhập Hàng
        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            if (lbTenMon.Tag == null) { MessageBox.Show("Vui lòng chọn món cần nhập!"); return; }

            int idMon = (int)lbTenMon.Tag;
            int soLuongNhap = (int)nmSoLuong.Value;
            decimal donGiaNhap = nmGiaNhap.Value;

            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                // 1. Cập nhật kho
                var mon = db.Mons.SingleOrDefault(x => x.Id == idMon);
                if (mon != null)
                {
                    mon.SoLuongTon += soLuongNhap;
                    mon.GiaNhap = donGiaNhap;
                }

                // 2. Lưu lịch sử
                LichSuNhapHang ls = new LichSuNhapHang()
                {
                    IdMon = idMon,
                    SoLuongNhap = soLuongNhap,
                    DonGiaNhap = donGiaNhap,
                    NgayNhap = DateTime.Now
                };
                db.LichSuNhapHangs.InsertOnSubmit(ls);

                db.SubmitChanges();

                MessageBox.Show($"Đã nhập thêm {soLuongNhap} {mon.TenMon}.\nTổng chi phí: {(soLuongNhap * donGiaNhap):N0}");

                // Load lại cả 2 bảng để thấy thay đổi
                LoadKhoHang();
                LoadLichSu(); // <--- THÊM DÒNG NÀY
            }
        }
    }
}