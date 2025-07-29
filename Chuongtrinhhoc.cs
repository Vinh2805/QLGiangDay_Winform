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
    public partial class Chuongtrinhhoc : UserControl
    {
        private SQL_QLGiangDay qlgd;
        public Chuongtrinhhoc()
        {
            InitializeComponent();
            qlgd = new SQL_QLGiangDay();
        }
        private void loadData()
        {
            DataTable dt = qlgd.DocBang("SELECT lhmh.LopHocID, lh.TenLop, mh.MonHocID, mh.TenMonHoc, gvmh.GiangVienID, gv.HoTen,\r\nmh.HocKy, mh.SoTinChi\r\nFROM MonHoc mh\r\nJOIN LopHoc_MonHoc lhmh on mh.MonHocID = lhmh.MonHocID\r\nJOIN LopHoc lh on lhmh.LopHocID = lh.LopHocID\r\nJOIN GiangVien_MonHoc gvmh on lhmh.MonHocID = gvmh.MonHocID\r\nJOIN GiangVien gv on gvmh.GiangVienID = gv.GiangVienID\t\t\t\t");
            try
            {
                if (dt != null)
                {
                    dtGridView_CTH.DataSource = dt;
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
                || string.IsNullOrEmpty(txtHocKi.Text)
                || string.IsNullOrEmpty(txtMaLH.Text)
                || string.IsNullOrEmpty(txtTenLh.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void ResetTxt()
        {
            txtMaMH.Clear();
            txtTenMh.Clear();
            txtMaLH.Clear();
            txtTenLh.Clear();
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
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thêm thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        SqlParameter[] parameters = new SqlParameter[] {
                            new SqlParameter("@MaMH", SqlDbType.NVarChar) { Value = txtMaMH.Text },
                            new SqlParameter("@TenMH", SqlDbType.NVarChar) { Value = txtTenMh.Text },
                            new SqlParameter("@MaLH", SqlDbType.NVarChar) { Value = txtMaLH.Text },
                            new SqlParameter("@TenLH", SqlDbType.NVarChar) { Value = txtTenLh.Text },
                            new SqlParameter("@MaGV", SqlDbType.NVarChar) { Value = txtMaGV.Text },
                            new SqlParameter("@TenGV", SqlDbType.NVarChar) {Value = txtHotenGV.Text},
                            new SqlParameter("@HocKi", SqlDbType.NVarChar) {Value = txtHocKi.Text},
                            new SqlParameter("@SoTinChi", SqlDbType.Int) { Value = int.Parse(txtSotinchi.Text) }
                        };

                        string query = "EXEC ThemCTH @MaMH, @TenMH, @MaLH, @TenLH, @MaGV, @TenGV, @HocKi, @SoTinChi";

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
        }
        private void Hienthi()
        {
            loadData();
            dtGridView_CTH.ReadOnly = true;
        }
        private void clickdata()
        {
            txtMaLH.Text = dtGridView_CTH.CurrentRow.Cells[0].Value.ToString();
            txtTenLh.Text = dtGridView_CTH.CurrentRow.Cells[1].Value.ToString();
            txtMaMH.Text = dtGridView_CTH.CurrentRow.Cells[2].Value.ToString();
            txtTenMh.Text = dtGridView_CTH.CurrentRow.Cells[3].Value.ToString();
            txtMaGV.Text = dtGridView_CTH.CurrentRow.Cells[4].Value.ToString();
            txtHotenGV.Text = dtGridView_CTH.CurrentRow.Cells[5].Value.ToString();
            txtHocKi.Text = dtGridView_CTH.CurrentRow.Cells[6].Value.ToString();
            txtSotinchi.Text = dtGridView_CTH.CurrentRow.Cells[7].Value.ToString();
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
                        new SqlParameter("@MaLH", SqlDbType.NVarChar) { Value = txtMaLH.Text },
                        new SqlParameter("@TenLH", SqlDbType.NVarChar) { Value = txtTenLh.Text },
                        new SqlParameter("@MaGV", SqlDbType.NVarChar) { Value = txtMaGV.Text },
                        new SqlParameter("@TenGV", SqlDbType.NVarChar) {Value = txtHotenGV.Text},
                        new SqlParameter("@HocKi", SqlDbType.NVarChar) {Value = txtHocKi.Text},
                        new SqlParameter("@SoTinChi", SqlDbType.Int) { Value = txtSotinchi.Text }
                        };

                    string query = "EXEC CapNhatCTH @MaMH, @TenMH, @MaLH, @TenLH, @MaGV, @TenGV, @HocKi, @SoTinChi";

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
                            new SqlParameter("@MaLH", SqlDbType.NVarChar) { Value = txtMaGV.Text }
                    };
                    string query = "EXEC XoaCTH @MaMH, @MaLH";

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
            for (int i = 1; i < dtGridView_CTH.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dtGridView_CTH.Columns[i - 1].HeaderText;
            }

            // Ghi dữ liệu từ DataGridView vào Excel
            for (int i = 0; i < dtGridView_CTH.Rows.Count; i++)
            {
                for (int j = 0; j < dtGridView_CTH.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dtGridView_CTH.Rows[i].Cells[j]?.Value?.ToString() ?? "";
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
        private void dtGridView_CTH_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
        private void Chuongtrinhhoc_Load(object sender, EventArgs e)
        {
            Hienthi();
            txtTenLh.ReadOnly = true;
            txtTenMh.ReadOnly = true;
            txtHotenGV.ReadOnly = true;
            txtSotinchi.ReadOnly = true;
        }
        private void txtMaLH_TextChanged(object sender, EventArgs e)
        {
            string idlop = txtMaLH.Text;
            DataTable db = qlgd.DocBang("select tenlop from lophoc where lophocid like N'" + idlop + "'");
            if (db.Rows.Count < 1)
            {
                txtTenLh.Text = "";
                return;
            }
            else
            {
                txtTenLh.Text = db.Rows[0]["tenlop"].ToString();
            }
        }
        private void txtMaMH_TextChanged(object sender, EventArgs e)
        {
            string monhocid = txtMaMH.Text;
            DataTable db = qlgd.DocBang("select tenmonhoc, sotinchi from monhoc where monhocid like N'" + monhocid + "'");
            if (db.Rows.Count < 1)
            {
                txtTenMh.Text = "";
                txtSotinchi.Text = "";
                return;
            }
            else
            {
                txtTenMh.Text = db.Rows[0]["tenmonhoc"].ToString();
                txtSotinchi.Text = db.Rows[0]["sotinchi"].ToString();
            }
        }
        private void txtMaGV_TextChanged(object sender, EventArgs e)
        {
            string giangvienid = txtMaGV.Text;
            DataTable db = qlgd.DocBang("select hoten from giangvien where giangvienid like N'" + giangvienid + "'");
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
    }
}
