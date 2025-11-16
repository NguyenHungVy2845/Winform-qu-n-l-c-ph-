using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class fShowLuong : Form
    {
        private DataTable _dtLuong;

        // Constructor nhận DataTable chứa danh sách lương
        public fShowLuong(DataTable dt)
        {
            InitializeComponent();
            _dtLuong = dt;
        }

        private void fShowLuong_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Reset báo cáo
                rpvLuong.LocalReport.DataSources.Clear();

                // 2. Cấu hình đường dẫn theo kiểu Embedded Resource (Nhúng)
                // Cú pháp: [Tên_Project].[Tên_File_Report].rdlc
                rpvLuong.LocalReport.ReportEmbeddedResource = "QuanLyCafe.rpLuong.rdlc";

                // 3. Tạo nguồn dữ liệu
                // "DataSet1" phải trùng tên với Dataset bạn tạo trong file thiết kế rpLuong.rdlc
                ReportDataSource rds = new ReportDataSource("DataSet1", _dtLuong);

                // 4. Add vào viewer và refresh
                rpvLuong.LocalReport.DataSources.Add(rds);
                rpvLuong.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load bảng lương: " + ex.Message);
            }
        }
    }
}