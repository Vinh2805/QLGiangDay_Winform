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
    public partial class Thongbaogiangvien : UserControl
    {
        private SQL_QLGiangDay qlgd;
        public Thongbaogiangvien()
        {
            InitializeComponent();
            qlgd = new SQL_QLGiangDay();
        }
        private void comboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }
        private void loadData()
        {
            DataTable dt = qlgd.DocBang("SELECT tb.ThongBaoID, tb.TieuDe, tb.NoiDung, tb.NgayGui, tb.TrangThai, tbgv.GiangVienID AS NguoiNhanID, gv.HoTen AS NguoiNhan, tbgv.LoaiNguoiNhan\r\nFROM ThongBao tb\r\nJOIN ThongBao_GiangVien tbgv ON tb.ThongBaoID = tbgv.ThongBaoID\r\nJOIN GiangVien gv ON tbgv.GiangVienID = gv.GiangVienID");
            try
            {
                if (dt != null)
                {
                    dataGridView_TBGV.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }
        private bool validateInput()
        {
            if (string.IsNullOrEmpty(txtMaTB.Text)
                || string.IsNullOrEmpty(txtTieuDe.Text)
                || string.IsNullOrEmpty(txtNoidung.Text)
                || string.IsNullOrEmpty(txtNgayGui.Text)
                || string.IsNullOrEmpty(txtMaNgNhan.Text)
                || string.IsNullOrEmpty(txtHotenNN.Text)
                || string.IsNullOrEmpty(txtLoaiDoituong.Text)
                || Cbb_TrangThai.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool ValidateDateOfBirth(string input)
        {
            DateTime parsedDate;
            string format = "dd-MMM-yy HH:mm:ss";

            bool isValid = DateTime.TryParseExact(
                input,          // Chuỗi cần kiểm tra
                format,         // Định dạng mong muốn
                null,           // Sử dụng văn hóa mặc định (có thể là CultureInfo.InvariantCulture)
                System.Globalization.DateTimeStyles.None, // Không áp dụng thêm kiểu phân tích nào
                out parsedDate  // Kết quả được phân tích sẽ lưu trong parsedDate
            );

            return isValid;
        }
        private void ResetTxt()
        {
            txtMaTB.Clear();
            txtTieuDe.Clear();
            txtNoidung.Clear();
            txtNgayGui.Clear();
            txtMaNgNhan.Clear();
            txtHotenNN.Clear();
            Cbb_TrangThai.SelectedIndex = -1;
            txtMaTB.Focus();
        }
        private void loadComboBox()
        {
            try
            {
                DataTable dtTrangThai = new DataTable();

                // Tạo các cột cho DataTable
                dtTrangThai.Columns.Add("TrangThaiText", typeof(string));
                dtTrangThai.Columns.Add("TrangThaiValue", typeof(string));  // Thay đổi kiểu dữ liệu thành nvarchar

                // Thêm các trạng thái vào DataTable
                dtTrangThai.Rows.Add("Mới", "Moi");  // Trạng thái Mới
                dtTrangThai.Rows.Add("Đã Xem", "DaXem"); // Trạng thái Đã Xem
                dtTrangThai.Rows.Add("Hủy", "Huy");    // Trạng thái Hủy

                // Gán DataTable vào ComboBox
                Cbb_TrangThai.DataSource = dtTrangThai;
                Cbb_TrangThai.DisplayMember = "TrangThaiText";  // Hiển thị tên trạng thái
                Cbb_TrangThai.ValueMember = "TrangThaiValue";  // Lưu giá trị trạng thái (Mới, Đã Xem, Hủy)
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu cho ComboBox: " + ex.Message);
            }
        }
        private void ThemTT()
        {
            if (!validateInput())
            {
                return;
            }
            else if (!ValidateDateOfBirth(txtNgayGui.Text))
            {
                MessageBox.Show("Ngày sinh không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn thêm thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        SqlParameter[] parameters = new SqlParameter[] {
                            new SqlParameter("@ThongBaoID", SqlDbType.NVarChar) { Value = txtMaTB.Text },
                            new SqlParameter("@TieuDe", SqlDbType.NVarChar) { Value = txtTieuDe.Text },
                            new SqlParameter("@NoiDung", SqlDbType.NVarChar) { Value = txtNoidung.Text },
                            new SqlParameter("@NgayGui", SqlDbType.Date) { Value = txtNgayGui.Text },
                            new SqlParameter("@TrangThai", SqlDbType.NVarChar) { Value = Cbb_TrangThai.SelectedValue},
                            new SqlParameter("@GiangVienID", SqlDbType.NVarChar) {Value = txtMaNgNhan.Text},
                            new SqlParameter("@LoaiNguoiNhan", SqlDbType.NVarChar) {Value = txtLoaiDoituong.Text},
                        };

                        string query = "EXEC ThemThongBao_GV @ThongBaoID, @TieuDe, @NoiDung, @NgayGui, @TrangThai, @GiangVienID, @LoaiNguoiNhan";

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
            loadComboBox();
            Cbb_TrangThai.SelectedIndex = -1;
            dataGridView_TBGV.ReadOnly = true;
        }
        private void clickdata()
        {
            txtMaTB.Text = dataGridView_TBGV.CurrentRow.Cells[0].Value.ToString();
            txtTieuDe.Text = dataGridView_TBGV.CurrentRow.Cells[1].Value.ToString();
            txtNoidung.Text = dataGridView_TBGV.CurrentRow.Cells[2].Value.ToString();
            txtNgayGui.Text = dataGridView_TBGV.CurrentRow.Cells[3].Value.ToString();
            Cbb_TrangThai.SelectedValue = dataGridView_TBGV.CurrentRow.Cells[4].Value.ToString();
            txtMaNgNhan.Text = dataGridView_TBGV.CurrentRow.Cells[5].Value.ToString();
            txtHotenNN.Text = dataGridView_TBGV.CurrentRow.Cells[6].Value.ToString();
            txtLoaiDoituong.Text = dataGridView_TBGV.CurrentRow.Cells[7].Value.ToString();
        }
        private void Capnhat()
        {
            if (!validateInput())
            {
                return;
            }
            else if (!ValidateDateOfBirth(txtNgayGui.Text))
            {
                MessageBox.Show("Ngày sinh không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[] {
                            new SqlParameter("@ThongBaoID", SqlDbType.NVarChar) { Value = txtMaTB.Text },
                            new SqlParameter("@TieuDe", SqlDbType.NVarChar) { Value = txtTieuDe.Text },
                            new SqlParameter("@NoiDung", SqlDbType.NVarChar) { Value = txtNoidung.Text },
                            new SqlParameter("@NgayGui", SqlDbType.Date) { Value = txtNgayGui.Text },
                            new SqlParameter("@TrangThai", SqlDbType.NVarChar) { Value = Cbb_TrangThai.SelectedValue},
                            new SqlParameter("@GiangVienID", SqlDbType.NVarChar) {Value = txtMaNgNhan.Text},
                            new SqlParameter("@LoaiNguoiNhan", SqlDbType.NVarChar) {Value = txtLoaiDoituong.Text},
                        };

                    string query = "EXEC CapNhatThongBao_GV @ThongBaoID, @TieuDe, @NoiDung, @NgayGui, @TrangThai, @GiangVienID, @LoaiNguoiNhan";

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
                            new SqlParameter("@ThongBaoID", SqlDbType.NVarChar) { Value = txtMaTB.Text },
                    };
                    string query = "EXEC XoaThongBao_GV @ThongBaoID";

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
            for (int i = 1; i < dataGridView_TBGV.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView_TBGV.Columns[i - 1].HeaderText;
            }

            // Ghi dữ liệu từ DataGridView vào Excel
            for (int i = 0; i < dataGridView_TBGV.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView_TBGV.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dataGridView_TBGV.Rows[i].Cells[j]?.Value?.ToString() ?? "";
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
        private void Thongbaogiangvien_Load(object sender, EventArgs e)
        {
            Hienthi();
            txtLoaiDoituong.Text = "GiangVien";
            txtLoaiDoituong.ReadOnly = true;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemTT();
        }
        private void btnCapnhat_Click(object sender, EventArgs e)
        {
            Capnhat();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            Xoa();
        }
        private void btnExcel_Click(object sender, EventArgs e)
        {
            XuatExcel();
        }
        private void dataGridView_TBGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clickdata();
        }
        private void txtMaTB_TextChanged(object sender, EventArgs e)
        {
            string tbid = txtMaTB.Text;
            DataTable db = qlgd.DocBang("select tieude, noidung from thongbao where thongbaoid like N'" + tbid + "'");
            if (db.Rows.Count < 1)
            {
                txtTieuDe.Text = "";
                txtNoidung.Text = "";
                return;
            }
            else
            {
                txtTieuDe.Text = db.Rows[0]["tieude"].ToString();
                txtNoidung.Text = db.Rows[0]["noidung"].ToString();
            }
        }
        private void txtMaNgNhan_TextChanged(object sender, EventArgs e)
        {
            string nguoinhanid = txtMaNgNhan.Text;
            DataTable db = qlgd.DocBang("select hoten from giangvien where giangvienid like N'" + nguoinhanid + "'");
            if (db.Rows.Count < 1)
            {
                txtHotenNN.Text = "";
                return;
            }
            else
            {
                txtHotenNN.Text = db.Rows[0]["hoten"].ToString();
            }
        }
        private void txtHotenNN_TextChanged(object sender, EventArgs e)
        {
            string nguoinhan = txtHotenNN.Text;
            DataTable db = qlgd.DocBang("select giangvienid from giangvien where hoten like N'" + nguoinhan + "'");
            if (db.Rows.Count < 1)
            {
                txtMaNgNhan.Text = "";
                return;
            }
            else
            {
                txtMaNgNhan.Text = db.Rows[0]["giangvienid"].ToString();
            }
        }
    }
}
