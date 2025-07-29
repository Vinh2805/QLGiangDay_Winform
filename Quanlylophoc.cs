using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_GiangDay
{
    public partial class Quanlylophoc : UserControl
    {
        private SQL_QLGiangDay qlgd;
        public Quanlylophoc()
        {
            InitializeComponent();
            qlgd = new SQL_QLGiangDay();
        }
        private void loadData()
        {
            DataTable dt = qlgd.DocBang("SELECT lh.LopHocID, lh.TenLop, lh.NamHoc, svlh.SinhVienID, sv.HoTen\r\nFROM LopHoc lh\r\nJOIN SinhVien_LopHoc svlh\r\nON lh.LopHocID = svlh.LopHocID\r\nJOIN SinhVien sv\r\nON svlh.SinhVienID = sv.SinhVienID");
            try
            {
                if (dt != null)
                {
                    dtGridView_QVLH.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        private void check_kitudacbiet(object sender, KeyPressEventArgs e)
        {
            // Cho phép số, dấu '-' và phím Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true; // Chặn ký tự không hợp lệ
            }

            // Đảm bảo chỉ có một dấu '-'
            if (e.KeyChar == '-' && txtNamHoc.Text.Contains("-"))
            {
                e.Handled = true;
            }
        }
        private void check_kitu(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private bool validateInput()
        {
            if (string.IsNullOrEmpty(txtMaLH.Text)
                || string.IsNullOrEmpty(txtHoten.Text)
                || string.IsNullOrEmpty(txtMaSV.Text)
                || string.IsNullOrEmpty(txtNamHoc.Text)
                || string.IsNullOrEmpty(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private bool IsMaLHTenLHExists(string maLH, string tenLH)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM LopHoc WHERE LopHocID = @MaLH OR TenLop = @TenLop";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@MaLH", SqlDbType.NVarChar) { Value = maLH },
            new SqlParameter("@TenLop", SqlDbType.NVarChar) { Value = tenLH }
                };

                int count = (int)this.qlgd.ThucThiScalar(query, parameters);
                return count > 0; // Nếu tồn tại, trả về true
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra mã lớp hoặc tên lớp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // Trả về true để ngăn thêm dữ liệu khi lỗi xảy ra
            }
        }

        private void ResetTxt()
        {
            txtMaLH.Clear();
            txtHoten.Clear();
            txtNamHoc.Clear();
            txtTenLop.Clear();
            txtMaSV.Clear();
            txtMaLH.Focus();
        }

        private void ThemTT()
        {
            if (!validateInput())
            {
                return;
            }

            // Kiểm tra xem mã lớp hoặc tên lớp đã tồn tại chưa
            if (IsMaLHTenLHExists(txtMaLH.Text, txtTenLop.Text))
            {
                MessageBox.Show("Mã lớp hoặc tên lớp đã tồn tại, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận thêm thông tin
            if (MessageBox.Show("Bạn có chắc chắn muốn thêm thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@MaLH", SqlDbType.NVarChar) { Value = txtMaLH.Text },
                new SqlParameter("@TenLop", SqlDbType.NVarChar) { Value = txtTenLop.Text },
                new SqlParameter("@NamHoc", SqlDbType.NVarChar) { Value = txtNamHoc.Text },
                new SqlParameter("@MaSV", SqlDbType.NVarChar) { Value = txtMaSV.Text }
            };

                    string query = "EXEC ThemLopHoc @MaLH, @TenLop, @NamHoc, @MaSV";

                    this.qlgd.CapNhatDuLieu(query, parameters);

                    MessageBox.Show("Đã thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadData();
                    ResetTxt();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Hienthi()
        {
            loadData();
            dtGridView_QVLH.ReadOnly = true;
        }
        private void clickdata()
        {
            txtMaLH.Text = dtGridView_QVLH.CurrentRow.Cells[0].Value.ToString();
            txtTenLop.Text = dtGridView_QVLH.CurrentRow.Cells[1].Value.ToString();
            txtNamHoc.Text = dtGridView_QVLH.CurrentRow.Cells[2].Value.ToString();
            txtMaSV.Text = dtGridView_QVLH.CurrentRow.Cells[3].Value.ToString();
            txtHoten.Text = dtGridView_QVLH.CurrentRow.Cells[4].Value.ToString();
        }
        private void Capnhat()
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Tạo các tham số cho câu lệnh SQL
                    SqlParameter[] parameters = new SqlParameter[] {
                            new SqlParameter("@MaLH", SqlDbType.NVarChar) { Value = txtMaLH.Text },
                            new SqlParameter("@TenLop", SqlDbType.NVarChar) { Value = txtTenLop.Text },
                            new SqlParameter("@NamHoc", SqlDbType.NVarChar) { Value = txtNamHoc.Text },
                            new SqlParameter("@MaSV", SqlDbType.NVarChar) {Value = txtMaSV.Text}
                        };

                    string query = "EXEC CapNhatLopHoc @MaLH, @TenLop, @NamHoc, @MaSV";

                    this.qlgd.CapNhatDuLieu(query, parameters);

                    MessageBox.Show("Đã cập nhật thành công!", "Thông báo", MessageBoxButtons.OK);
                    loadData();
                    ResetTxt();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật thông tin: " + ex.Message);
                }
            }
        }
        private void Xoa()
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[] {
                            new SqlParameter("@MaLH", SqlDbType.NVarChar) { Value = txtMaLH.Text },
                            new SqlParameter("@MaSV", SqlDbType.NVarChar) { Value = txtMaSV.Text }
                    };
                    string query = "EXEC XoaLopHoc @MaLH, @MaSV";

                    this.qlgd.CapNhatDuLieu(query, parameters);

                    MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK);
                    loadData();
                    ResetTxt();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa thông tin: " + ex.Message);
                }
            }
        }
        private void XuatExcel()
        {
            // Khởi tạo ứng dụng Excel
            Microsoft.Office.Interop.Excel.Application exApp = new Microsoft.Office.Interop.Excel.Application();
            exApp.Visible = false;
            exApp.DisplayAlerts = false;

            // Tạo workbook mới
            Microsoft.Office.Interop.Excel.Workbook excelWorkbook = exApp.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = excelWorkbook.Sheets[1];
            worksheet = excelWorkbook.ActiveSheet;

            // Ghi tiêu đề cột từ DataGridView
            for (int i = 1; i < dtGridView_QVLH.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dtGridView_QVLH.Columns[i - 1].HeaderText;
            }

            // Ghi dữ liệu từ DataGridView vào Excel
            for (int i = 0; i < dtGridView_QVLH.Rows.Count; i++)
            {
                for (int j = 0; j < dtGridView_QVLH.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dtGridView_QVLH.Rows[i].Cells[j]?.Value?.ToString() ?? "";
                }
            }

            // Hiển thị hộp thoại lưu file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Lưu file Excel";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lưu file excel
                excelWorkbook.SaveAs(saveFileDialog.FileName);
                MessageBox.Show("Xuất ra file Excel thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Đóng workbook và Excel
            excelWorkbook.Close();
            exApp.Quit();

            // Giải phóng tài nguyên
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelWorkbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(exApp);

        }
        private void Quanlylophoc_Load(object sender, EventArgs e)
        {
            Hienthi();
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            ThemTT();
        }
        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            Capnhat();
        }
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            Xoa();
        }
        private void btn_excel_Click(object sender, EventArgs e)
        {
            XuatExcel();
        }
        private void dtGridView_QVLH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clickdata();
        }

        private void txtMaLH_TextChanged(object sender, EventArgs e)
        {
            string MaLH = txtMaLH.Text;
            DataTable db = qlgd.DocBang("select tenlop, namhoc from lophoc where lophocid like N'" + MaLH + "'");
            if (db.Rows.Count < 1)
            {
                txtTenLop.Text = "";
                txtNamHoc.Text = "";
                return;
            }
            else
            {
                txtTenLop.Text = db.Rows[0]["tenlop"].ToString();
                txtNamHoc.Text = db.Rows[0]["namhoc"].ToString();
            }
        }

        private void txtMaSV_TextChanged(object sender, EventArgs e)
        {
            string MaSV = txtMaSV.Text;
            DataTable db = qlgd.DocBang("select hoten from sinhvien where sinhvienid like N'" + MaSV + "'");
            if (db.Rows.Count < 1)
            {
                txtHoten.Text = "";
                return;
            }
            else
            {
                txtHoten.Text = db.Rows[0]["hoten"].ToString();
            }
        }
    }
}
