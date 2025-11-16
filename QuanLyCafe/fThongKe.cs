using System;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace QuanLyCafe
{
    public partial class fThongKe : Form
    {
        public fThongKe()
        {
            InitializeComponent();
            // Mặc định xem tháng hiện tại
            DateTime today = DateTime.Now;
            dtpkfromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpktoDate.Value = dtpkfromDate.Value.AddMonths(1).AddDays(-1);
            LoadListBillByDate(dtpkfromDate.Value, dtpktoDate.Value);
        }

        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                var listBill = from b in db.HoaDons
                               where b.ThoiGianRa >= checkIn && b.ThoiGianRa <= checkOut && b.TrangThai == 1
                               select new
                               {
                                   Tên_Bàn = b.Ban.TenBan,
                                   Tổng_Tiền = db.ChiTietHoaDons.Where(ct => ct.IdHoaDon == b.Id).Sum(ct => ct.SoLuong * ct.DonGiaTaiThoiDiem) - b.TienGiamGia,
                                   Ngày_Vào = b.ThoiGianVao,
                                   Ngày_Ra = b.ThoiGianRa,
                                   Giảm_Giá = b.TienGiamGia
                               };
                d.DataSource = listBill.ToList();

                // Vẽ biểu đồ
                try
                {
                    var chartData = from b in db.HoaDons
                                    where b.ThoiGianRa >= checkIn && b.ThoiGianRa <= checkOut && b.TrangThai == 1
                                    group b by b.ThoiGianRa.Value.Date into g
                                    select new
                                    {
                                        Ngay = g.Key,
                                        Tien = g.Sum(x => db.ChiTietHoaDons.Where(ct => ct.IdHoaDon == x.Id).Sum(ct => ct.SoLuong * ct.DonGiaTaiThoiDiem) - x.TienGiamGia)
                                    };

                    chartDoanhThu.Series.Clear();
                    Series series = new Series("Doanh Thu");
                    series.ChartType = SeriesChartType.Column;
                    foreach (var item in chartData) series.Points.AddXY(item.Ngay.ToString("dd/MM"), item.Tien);
                    chartDoanhThu.Series.Add(series);
                }
                catch { }
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpkfromDate.Value.Date, dtpktoDate.Value.Date.AddDays(1).AddSeconds(-1));
        }
    }
}