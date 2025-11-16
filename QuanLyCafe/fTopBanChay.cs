using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class fTopBanChay : Form
    {
        public fTopBanChay()
        {
            InitializeComponent();
        }

        private void fTopBanChay_Load(object sender, EventArgs e)
        {
            // Mặc định chọn từ đầu tháng đến cuối tháng này
            DateTime now = DateTime.Now;
            dtpFrom.Value = new DateTime(now.Year, now.Month, 1);
            dtpTo.Value = dtpFrom.Value.AddMonths(1).AddDays(-1);
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            // Đổi tên biến để tránh lỗi từ khóa
            DateTime dateFrom = dtpFrom.Value.Date;
            DateTime dateTo = dtpTo.Value.Date.AddDays(1).AddSeconds(-1);

            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                var list = from hd in db.HoaDons
                           join ct in db.ChiTietHoaDons on hd.Id equals ct.IdHoaDon
                           join m in db.Mons on ct.IdMon equals m.Id
                           // --- KIỂM TRA ĐOẠN NÀY ---
                           where hd.TrangThai == 1                   // 1. Phải có điều kiện này trước
                                 && hd.ThoiGianRa >= dateFrom        // 2. Sau đó mới đến &&
                                 && hd.ThoiGianRa <= dateTo
                           // --------------------------
                           group ct by new { m.TenMon, m.GiaTien } into g
                           select new
                           {
                               Tên_Món = g.Key.TenMon,
                               Số_Lượng_Bán = g.Sum(x => x.SoLuong),
                               Doanh_Thu = g.Sum(x => x.SoLuong * x.DonGiaTaiThoiDiem)
                           };

                var top10 = list.OrderByDescending(x => x.Số_Lượng_Bán).Take(10).ToList();

                dtgvTopMon.DataSource = top10;

                if (dtgvTopMon.Columns["Doanh_Thu"] != null)
                {
                    dtgvTopMon.Columns["Doanh_Thu"].DefaultCellStyle.Format = "N0";
                }
            }
        }
    }
}