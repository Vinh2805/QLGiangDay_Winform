using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Caching;
using System.Windows.Forms;

namespace QL_GiangDay
{
    public partial class Quanlygiangvien : UserControl
    {
        private SQL_QLGiangDay qlgd;
        public Quanlygiangvien()
        {
            InitializeComponent();
            qlgd = new SQL_QLGiangDay();
        }
        private void check_kituso(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void check_kitu(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private bool validateInput()
        {
            if (string.IsNullOrEmpty(txtMaGV.Text)
                || string.IsNullOrEmpty(txtHoten.Text)
                || string.IsNullOrEmpty(txtChucVu.Text)
                || string.IsNullOrEmpty(txtDiachi.Text)
                || string.IsNullOrEmpty(txtSDT.Text)
                || string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Kiểm tra xem người dùng đã chọn ảnh chưa
            if (Ptb_AnhGV.Tag == null || string.IsNullOrEmpty(Ptb_AnhGV.Tag.ToString()))
            {
                MessageBox.Show("Vui lòng chọn ảnh!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            // Ví dụ biểu thức chính quy cho số điện thoại (có thể tùy chỉnh theo định dạng mong muốn)
            string phonePattern = @"^\d{10}$"; // Chấp nhận số điện thoại có 10 chữ số
            return Regex.IsMatch(phoneNumber, phonePattern);
        }
        private void ResetTxt()
        {
            txtMaGV.Clear();
            txtHoten.Clear();
            txtChucVu.Clear();
            txtDiachi.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            Ptb_AnhGV.Image = null;
            txtMaGV.Focus();
        }
        private void loadData()
        {
            DataTable dt = qlgd.DocBang("SELECT * FROM GiangVien");
            try
            {
                if (dt != null)
                {
                    dtGridView_QVGV.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        private void ThemTT()
        {
            if (!validateInput())
            {
                return;
            }
            else
            {
                if (!IsValidPhoneNumber(txtSDT.Text))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (!IsValidEmail(txtEmail.Text))
                {
                    MessageBox.Show("Email không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (MessageBox.Show("Bạn có chắc chắn muốn thêm thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string maGV = txtMaGV.Text;

                        // Kiểm tra trùng mã sinh viên
                        string checkQuery = "SELECT COUNT(*) FROM GiangVien WHERE GiangVienID = @MaGV";
                        SqlParameter[] checkParams = new SqlParameter[]
                        {
                            new SqlParameter("@MaGV", SqlDbType.NVarChar) { Value = maGV }
                        };

                        int count = (int)this.qlgd.ThucThiScalar(checkQuery, checkParams);

                        if (count > 0)
                        {
                            MessageBox.Show("Mã giảng viên này đã tồn tại. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        string relativeImagePath = Ptb_AnhGV.Tag?.ToString();  // Lưu tên ảnh hoặc đường dẫn tương đối
                        // Tạo các tham số cho câu lệnh SQL
                        SqlParameter[] parameters = new SqlParameter[] {
                            new SqlParameter("@MaGV", SqlDbType.NVarChar) { Value = txtMaGV.Text },
                            new SqlParameter("@TenGV", SqlDbType.NVarChar) { Value = txtHoten.Text },
                            new SqlParameter("@Chucvu", SqlDbType.NVarChar) {Value = txtChucVu.Text},
                            new SqlParameter("@DiaChi", SqlDbType.NVarChar) {Value = txtDiachi.Text},
                            new SqlParameter("@SDT", SqlDbType.NVarChar) {Value = txtSDT.Text},
                            new SqlParameter("@Email", SqlDbType.NVarChar) {Value = txtEmail.Text},
                            new SqlParameter("@anhGV", SqlDbType.NVarChar) {Value = relativeImagePath}  // Lưu tên ảnh vào cơ sở dữ liệu
                        };

                        // Câu lệnh SQL để gọi thủ tục lưu thông tin sinh viên
                        string query = "EXEC ThemGiangVien @MaGV, @TenGV, @Chucvu, @DiaChi, @SDT, @Email, @anhGV";

                        // Gọi phương thức cập nhật dữ liệu
                        this.qlgd.CapNhatDuLieu(query, parameters);

                        // Hiển thị thông báo thành công và cập nhật lại dữ liệu
                        MessageBox.Show("Đã thêm thành công!", "Thông báo", MessageBoxButtons.OK);
                        loadData();
                        ResetTxt();
                    }
                    catch (Exception ex)
                    {
                        // Hiển thị lỗi nếu có
                        MessageBox.Show("Lỗi khi thêm thông tin: " + ex.Message);
                    }
                }
            }
        }
        private void Hienthi()
        {
            loadData();
            dtGridView_QVGV.ReadOnly = true;
        }
        private void ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }
        private void clickdata()
        {
            txtMaGV.Text = dtGridView_QVGV.CurrentRow.Cells[0].Value.ToString();
            txtHoten.Text = dtGridView_QVGV.CurrentRow.Cells[1].Value.ToString();
            txtChucVu.Text = dtGridView_QVGV.CurrentRow.Cells[2].Value.ToString();
            txtDiachi.Text = dtGridView_QVGV.CurrentRow.Cells[3].Value.ToString();
            txtSDT.Text = dtGridView_QVGV.CurrentRow.Cells[4].Value.ToString();
            txtEmail.Text = dtGridView_QVGV.CurrentRow.Cells[5].Value.ToString();
            string imagePath = dtGridView_QVGV.CurrentRow.Cells[6].Value.ToString();

            // Kiểm tra nếu đường dẫn ảnh hợp lệ, hiển thị lên PictureBox
            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                Ptb_AnhGV.Image = Image.FromFile(imagePath); // Hiển thị ảnh
                Ptb_AnhGV.Tag = imagePath; // Lưu đường dẫn vào Tag để sử dụng lại nếu cần
            }
            else
            {
                Ptb_AnhGV.Image = null; // Nếu không có ảnh, đặt PictureBox về null
                Ptb_AnhGV.Tag = null;
                MessageBox.Show("Không tìm thấy ảnh hoặc đường dẫn không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private string imagePath;
        private void HienthiAnh()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Lấy đường dẫn đầy đủ của ảnh (bao gồm cả thư mục và tên tệp)
                imagePath = openFileDialog.FileName;

                // Lưu đường dẫn đầy đủ vào Tag (bao gồm cả thư mục và tên tệp)
                Ptb_AnhGV.Tag = imagePath;

                // Hiển thị ảnh từ đường dẫn đầy đủ
                Ptb_AnhGV.Image = Image.FromFile(imagePath);
            }
        }
        private void Capnhat()
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string relativeImagePath = Ptb_AnhGV.Tag?.ToString();  // Lưu tên ảnh hoặc đường dẫn tương đối
                                                                           // Tạo các tham số cho câu lệnh SQL
                    SqlParameter[] parameters = new SqlParameter[] {
                            new SqlParameter("@MaGV", SqlDbType.NVarChar) { Value = txtMaGV.Text },
                            new SqlParameter("@TenGV", SqlDbType.NVarChar) { Value = txtHoten.Text },
                            new SqlParameter("@Chucvu", SqlDbType.NVarChar) {Value = txtChucVu.Text},
                            new SqlParameter("@DiaChi", SqlDbType.NVarChar) {Value = txtDiachi.Text},
                            new SqlParameter("@SDT", SqlDbType.NVarChar) {Value = txtSDT.Text},
                            new SqlParameter("@Email", SqlDbType.NVarChar) {Value = txtEmail.Text},
                            new SqlParameter("@anhGV", SqlDbType.NVarChar) {Value = relativeImagePath}  // Lưu tên ảnh vào cơ sở dữ liệu
                        };

                    // Câu lệnh SQL để gọi thủ tục lưu thông tin sinh viên
                    string query = "EXEC CapNhatGiangVien @MaGV, @TenGV, @Chucvu, @DiaChi, @SDT, @Email, @anhGV";

                    // Gọi phương thức cập nhật dữ liệu
                    this.qlgd.CapNhatDuLieu(query, parameters);

                    // Hiển thị thông báo thành công và cập nhật lại dữ liệu
                    MessageBox.Show("Đã cập nhật thành công!", "Thông báo", MessageBoxButtons.OK);
                    loadData();
                    ResetTxt();
                }
                catch (Exception ex)
                {
                    // Hiển thị lỗi nếu có
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
                    string relativeImagePath = Ptb_AnhGV.Tag?.ToString();  // Lưu tên ảnh hoặc đường dẫn tương đối
                                                                           // Tạo các tham số cho câu lệnh SQL
                    SqlParameter[] parameters = new SqlParameter[] {
                            new SqlParameter("@MaGV", SqlDbType.NVarChar) { Value = txtMaGV.Text },
                            };

                    // Câu lệnh SQL để gọi thủ tục lưu thông tin sinh viên
                    string query = "EXEC XoaGiangVien @MaGV";

                    // Gọi phương thức cập nhật dữ liệu
                    this.qlgd.CapNhatDuLieu(query, parameters);

                    // Hiển thị thông báo thành công và cập nhật lại dữ liệu
                    MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK);
                    loadData();
                    ResetTxt();
                }
                catch (Exception ex)
                {
                    // Hiển thị lỗi nếu có
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
            for (int i = 1; i < dtGridView_QVGV.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dtGridView_QVGV.Columns[i - 1].HeaderText;
            }

            // Ghi dữ liệu từ DataGridView vào Excel
            for (int i = 0; i < dtGridView_QVGV.Rows.Count; i++)
            {
                for (int j = 0; j < dtGridView_QVGV.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dtGridView_QVGV.Rows[i].Cells[j]?.Value?.ToString() ?? "";
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

        private void dtGridView_QVGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clickdata();
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            HienthiAnh();
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

        private void Quanlygiangvien_Load(object sender, EventArgs e)
        {
            loadData();
            dtGridView_QVGV.ReadOnly = true;
        }
    }
}
