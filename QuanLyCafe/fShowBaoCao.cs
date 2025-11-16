using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyCafe
{
    public partial class fShowBaoCao : Form
    {
        private DataTable _dtBaoCao;

        // Constructor nhận DataTable chứa dữ liệu báo cáo
        public fShowBaoCao(DataTable dt)
        {
            InitializeComponent();
            _dtBaoCao = dt;
        }

        private void fShowBaoCao_Load(object sender, EventArgs e)
        {
            try
            {
                // 1. Reset báo cáo
                rpvBaoCao.LocalReport.DataSources.Clear();

                // 2. Cấu hình đường dẫn theo kiểu Embedded Resource (Nhúng)
                // Cú pháp: [Tên_Project].[Tên_File_Report].rdlc
                rpvBaoCao.LocalReport.ReportEmbeddedResource = "QuanLyCafe.rpBaoCao.rdlc";

                // 3. Tạo nguồn dữ liệu
                // "DataSet1" phải trùng tên với Dataset bạn tạo trong file thiết kế rpBaoCao.rdlc
                ReportDataSource rds = new ReportDataSource("DataSet1", _dtBaoCao);

                // 4. Add vào viewer và refresh
                rpvBaoCao.LocalReport.DataSources.Add(rds);
                rpvBaoCao.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load báo cáo: " + ex.Message);
            }
        }
    }
}