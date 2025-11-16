using Microsoft.Reporting.WinForms;
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
    public partial class fReport : Form
    {
        private int _idBill;

        // Sửa Constructor để nhận idBill từ TableManager gửi sang
        public fReport(int idBill)
        {
            InitializeComponent();
            _idBill = idBill;
        }

        private void fReport_Load(object sender, EventArgs e)
        {
            using (QuanLyCafeDataContext db = new QuanLyCafeDataContext())
            {
                // 1. Lấy thông tin chung của Bill
                var bill = db.HoaDons.SingleOrDefault(b => b.Id == _idBill);
                var ban = db.Bans.SingleOrDefault(b => b.Id == bill.IdBan);

                // 2. Lấy danh sách món ăn
                // Join bảng ChiTietHoaDon với Mon để lấy tên và giá
                var listMon = from ct in db.ChiTietHoaDons
                              join m in db.Mons on ct.IdMon equals m.Id
                              where ct.IdHoaDon == _idBill
                              select new
                              {
                                  TenMon = m.TenMon,
                                  SoLuong = ct.SoLuong,
                                  DonGia = ct.DonGiaTaiThoiDiem,
                                  ThanhTien = ct.SoLuong * ct.DonGiaTaiThoiDiem
                              };

                // 3. Đổ dữ liệu vào ReportDataSource (Phải đúng tên DataSet tạo ở Bước 1)
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1"; // *Lưu ý: Check lại tên DataSet trong file .rdlc (thường là DataSet1)

                // Map dữ liệu LINQ sang List object hoặc DataTable
                // Cách nhanh nhất: Tạo class DTO hoặc gán thủ công nếu ít trường
                // Ở đây tôi giả định bạn add từng dòng vào DataTable của DataSet

                dsBill ds = new dsBill();
                foreach (var item in listMon)
                {
                    var row = ds.dtBill.NewdtBillRow();
                    row.TenMon = item.TenMon;
                    row.SoLuong = item.SoLuong;
                    row.DonGia = (double)item.DonGia;
                    row.ThanhTien = (double)item.ThanhTien;

                    // Các thông tin chung gán lặp lại hoặc dùng Parameter (cách này hơi "củ chuối" nhưng dễ hiểu cho người mới)
                    row.TenBan = ban.TenBan;
                    row.NgayRa = bill.ThoiGianRa.Value;
                    row.GiamGia = (double)bill.TienGiamGia;
                    // row.TongTien = ... tính tổng;

                    ds.dtBill.AdddtBillRow(row);
                }

                rds.Value = ds.dtBill;

                // 4. Clear và Add lại
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rds);
                this.reportViewer1.RefreshReport();
            }
        }

    }
}