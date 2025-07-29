using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_GiangDay
{
    public partial class Quanlymonhoc : UserControl
    {
        private SQL_QLGiangDay qlgd;
        public Quanlymonhoc()
        {
            InitializeComponent();
            qlgd = new SQL_QLGiangDay();
        }
        private void loadData()
        {
            DataTable dt = qlgd.DocBang("SELECT gvmh.MonHocID, mh.TenMonHoc, mh.SoTinChi, gvmh.GiangVienID, gv.HoTen, mh.HocKy\r\nFROM MonHoc mh\r\nJOIN GiangVien_MonHoc gvmh\r\nON mh.MonHocID = gvmh.MonHocID\r\nJOIN GiangVien gv\r\nON gvmh.GiangVienID = gv.GiangVienID");
            try
            {
                if (dt != null)
                {
                    dtGridView_QVMH.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        private void check_kitu(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void check_kituso(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private bool validateInput()
        {
            if (string.IsNullOrEmpty(txtMaMH.Text)
                || string.IsNullOrEmpty(txtTenMh.Text)
                || string.IsNullOrEmpty(txtSotinchi.Text)
                || string.IsNullOrEmpty(txtMaGV.Text)
                || string.IsNullOrEmpty(txtHotenGV.Text)
                || string.IsNullOrEmpty(txtHocKi.Text))
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
                string query = "SELECT COUNT(*) FROM MonHoc WHERE MonHocID = @MaMH OR TenMonHoc = @TenMH";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@MaMH", SqlDbType.NVarChar) { Value = maLH },
            new SqlParameter("@TenMH", SqlDbType.NVarChar) { Value = tenLH }
                };

                int count = (int)this.qlgd.ThucThiScalar(query, parameters);
                return count > 0; // Nếu tồn tại, trả về true
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true; // Trả về true để ngăn thêm dữ liệu khi lỗi xảy ra
            }
        }
        private void ResetTxt()
        {
            txtMaMH.Clear();
            txtTenMh.Clear();
            txtSotinchi.Clear();
            txtMaGV.Clear();
            txtHotenGV.Clear();
            txtHocKi.Clear();
            txtMaMH.Focus();
        }
        private void ThemTT()
        {
            if (!validateInput())
            {
                return;
            }
            if (IsMaLHTenLHExists(txtMaMH.Text, txtTenMh.Text))
            {
                MessageBox.Show("Mã môn hoặc tên môn học đã tồn tại, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn thêm thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                    try
                    {
                        SqlParameter[] parameters = new SqlParameter[] {
                            new SqlParameter("@MaMH", SqlDbType.NVarChar) { Value = txtMaMH.Text },
                            new SqlParameter("@TenMH", SqlDbType.NVarChar) { Value = txtTenMh.Text },
                            new SqlParameter("@SoTC", SqlDbType.Int) { Value = txtSotinchi.Text },
                            new SqlParameter("@HocKy", SqlDbType.NVarChar) {Value = txtHocKi.Text},
                            new SqlParameter("@MaGV", SqlDbType.NVarChar) { Value = txtMaGV.Text },
                            new SqlParameter("@TenGV", SqlDbType.NVarChar) {Value = txtHotenGV.Text}
                        };

                        string query = "EXEC ThemMonHoc @MaMH, @TenMH, @SoTC, @HocKy, @MaGV, @TenGV";

                        this.qlgd.CapNhatDuLieu(query, parameters);

                        MessageBox.Show("Đã thêm thành công!", "Thông báo", MessageBoxButtons.OK);
                        loadData();
                        ResetTxt();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm thông tin: " + ex.Message);
                    }
            }
        }
        private void Hienthi()
        {
            loadData();
            dtGridView_QVMH.ReadOnly = true;
        }
        private void clickdata()
        {
            txtMaMH.Text = dtGridView_QVMH.CurrentRow.Cells[0].Value.ToString();
            txtTenMh.Text = dtGridView_QVMH.CurrentRow.Cells[1].Value.ToString();
            txtSotinchi.Text = dtGridView_QVMH.CurrentRow.Cells[2].Value.ToString();
            txtMaGV.Text = dtGridView_QVMH.CurrentRow.Cells[3].Value.ToString();
            txtHotenGV.Text = dtGridView_QVMH.CurrentRow.Cells[4].Value.ToString();
            txtHocKi.Text = dtGridView_QVMH.CurrentRow.Cells[5].Value.ToString();
        }
        private void Capnhat()
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[] {
                            new SqlParameter("@MaMH", SqlDbType.NVarChar) { Value = txtMaMH.Text },
                            new SqlParameter("@TenMH", SqlDbType.NVarChar) { Value = txtTenMh.Text },
                            new SqlParameter("@SoTC", SqlDbType.Int) { Value = txtSotinchi.Text },
                            new SqlParameter("@HocKy", SqlDbType.NVarChar) {Value = txtHocKi.Text},
                            new SqlParameter("@MaGV", SqlDbType.NVarChar) { Value = txtMaGV.Text },
                            new SqlParameter("@TenGV", SqlDbType.NVarChar) {Value = txtHotenGV.Text}
                        };

                    string query = "EXEC CapNhatMonHoc @MaMH, @TenMH, @SoTC, @HocKy, @MaGV, @TenGV";

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
                            new SqlParameter("@MaMH", SqlDbType.NVarChar) { Value = txtMaMH.Text },
                            new SqlParameter("@MaGV", SqlDbType.NVarChar) { Value = txtMaGV.Text }
                    };
                    string query = "EXEC XoaMonHoc @MaMH, @MaGV";

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
            for (int i = 1; i < dtGridView_QVMH.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dtGridView_QVMH.Columns[i - 1].HeaderText;
            }

            // Ghi dữ liệu từ DataGridView vào Excel
            for (int i = 0; i < dtGridView_QVMH.Rows.Count; i++)
            {
                for (int j = 0; j < dtGridView_QVMH.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dtGridView_QVMH.Rows[i].Cells[j]?.Value?.ToString() ?? "";
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
        private void dtGridView_QVMH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clickdata();
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
        private void Quanlymonhoc_Load(object sender, EventArgs e)
        {
            Hienthi();
        }

        private void txtMaMH_TextChanged(object sender, EventArgs e)
        {
            string MaMH = txtMaMH.Text;
            DataTable db = qlgd.DocBang("select tenmonhoc, sotinchi, hocky from monhoc where monhocid like N'" + MaMH + "'");
            if (db.Rows.Count < 1)
            {
                txtTenMh.Text = "";
                txtSotinchi.Text = "";
                txtHocKi.Text = "";
                return;
            }
            else
            {
                txtTenMh.Text = db.Rows[0]["tenmonhoc"].ToString();
                txtSotinchi.Text = db.Rows[0]["sotinchi"].ToString();
                txtHocKi.Text = db.Rows[0]["hocky"].ToString();
            }
        }

        private void txtMaGV_TextChanged(object sender, EventArgs e)
        {
            string MaGV = txtMaGV.Text;
            DataTable db = qlgd.DocBang("select hoten from giangvien where giangvienid like N'" + MaGV + "'");
            if (db.Rows.Count < 1)
            {
                txtHotenGV.Text = "";
                return;
            }
            else
            {
                txtHotenGV.Text = db.Rows[0]["hoten"].ToString();
            }
        }

        private void txtHotenGV_TextChanged(object sender, EventArgs e)
        {
            string TenGV = txtHotenGV.Text;
            DataTable db = qlgd.DocBang("select giangvienid from giangvien where hoten like N'" + TenGV + "'");
            if (db.Rows.Count < 1)
            {
                txtMaGV.Text = "";
                return;
            }
            else
            {
                txtMaGV.Text = db.Rows[0]["giangvienid"].ToString();
            }
        }
    }
}
