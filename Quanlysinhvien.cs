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
    public partial class Quanlysinhvien : UserControl
    {
        private SQL_QLGiangDay qlgd;
        public Quanlysinhvien()
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
            if ( string.IsNullOrEmpty(txtMaSV.Text)
                || string.IsNullOrEmpty(txtHoten.Text)
                || string.IsNullOrEmpty(txtDateTime.Text)
                || Cbb_Gioitinh.SelectedIndex == -1
                || string.IsNullOrEmpty(txtDiachi.Text)
                || string.IsNullOrEmpty(txtSDT.Text)
                || string.IsNullOrEmpty(txtEmail.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Kiểm tra xem người dùng đã chọn ảnh chưa
            if (Ptb_AnhSv.Tag == null || string.IsNullOrEmpty(Ptb_AnhSv.Tag.ToString()))
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
            txtMaSV.Clear();
            txtHoten.Clear();
            txtDateTime.Clear();
            txtDiachi.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            Cbb_Gioitinh.SelectedIndex = -1;
            Ptb_AnhSv.Image = null;
            txtMaSV.Focus();
        }
        private void loadData()
        {
            DataTable dt = qlgd.DocBang("SELECT * FROM SinhVien");
            try
            {
                if (dt != null)
                {
                    // Thêm cột mới để hiển thị giá trị NVARCHAR cho cột GioiTinh
                    dt.Columns.Add("Gioitinhs", typeof(string));

                    // Duyệt qua các dòng trong DataTable để chuyển giá trị BIT thành NVARCHAR
                    foreach (DataRow row in dt.Rows)
                    {
                        // Kiểm tra kiểu dữ liệu và chuyển đổi thành Nam hoặc Nữ
                        if (row["GioiTinh"] != DBNull.Value)
                        {
                            row["Gioitinhs"] = (bool)row["GioiTinh"] ? "Nam" : "Nữ";
                        }
                    }

                    // Gán DataSource cho DataGridView
                    dtGridView_QVSV.DataSource = dt;

                    // Ẩn cột gốc GioiTinh nếu không cần thiết
                    dtGridView_QVSV.Columns["GioiTinh"].Visible = false;

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
                else if (!ValidateDateOfBirth(txtDateTime.Text))
                {
                    MessageBox.Show("Ngày sinh không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (MessageBox.Show("Bạn có chắc chắn muốn thêm thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        string maSV = txtMaSV.Text;

                        string checkQuery = "SELECT COUNT(*) FROM SinhVien WHERE SinhVienID = @MaSV";
                        SqlParameter[] checkParams = new SqlParameter[]
                        {
                            new SqlParameter("@MaSV", SqlDbType.NVarChar) { Value = maSV }
                        };

                        int count = (int)this.qlgd.ThucThiScalar(checkQuery, checkParams);

                        if (count > 0)
                        {
                            MessageBox.Show("Mã sinh viên này đã tồn tại. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        string relativeImagePath = Ptb_AnhSv.Tag?.ToString(); 

                        SqlParameter[] parameters = new SqlParameter[] {
                            new SqlParameter("@MaSV", SqlDbType.NVarChar) { Value = txtMaSV.Text },
                            new SqlParameter("@TenSV", SqlDbType.NVarChar) { Value = txtHoten.Text },
                            new SqlParameter("@NgaySinh", SqlDbType.Date) {Value = txtDateTime.Text},
                            new SqlParameter("@GioiTinh", SqlDbType.Bit) {Value = Cbb_Gioitinh.SelectedValue},
                            new SqlParameter("@DiaChi", SqlDbType.NVarChar) {Value = txtDiachi.Text},
                            new SqlParameter("@SDT", SqlDbType.NVarChar) {Value = txtSDT.Text},
                            new SqlParameter("@Email", SqlDbType.NVarChar) {Value = txtEmail.Text},
                            new SqlParameter("@anhSV", SqlDbType.NVarChar) {Value = relativeImagePath}
                        };


                        string query = "EXEC ThemSinhVien @MaSV, @TenSV, @NgaySinh, @GioiTinh, @DiaChi, @SDT, @Email, @anhSV";

                        this.qlgd.CapNhatDuLieu(query, parameters);

                        MessageBox.Show("Đã thêm thành công!", "Thông báo", MessageBoxButtons.OK);
                        loadData();
                        ResetTxt();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi thêm thông tin sinh viên: " + ex.Message);
                    }
                }
            }
        }
        private void btn_them_Click(object sender, EventArgs e)
        {
            ThemTT();
        }
        private void loadComboBox()
        {
            try
            {
                DataTable dtbGioiTinh = new DataTable();

                dtbGioiTinh.Columns.Add("GioiTinhText", typeof(string));
                dtbGioiTinh.Columns.Add("GioiTinhValue", typeof(bool));

                dtbGioiTinh.Rows.Add("Nam", true);
                dtbGioiTinh.Rows.Add("Nữ", false);

                Cbb_Gioitinh.DataSource = dtbGioiTinh;
                Cbb_Gioitinh.DisplayMember = "GioiTinhText";
                Cbb_Gioitinh.ValueMember = "GioiTinhValue";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu cho ComboBox: " + ex.Message);
            }
        }
        private void Hienthi()
        {
            loadData();
            loadComboBox();
            dtGridView_QVSV.ReadOnly = true;
            Cbb_Gioitinh.SelectedIndex = -1;
        }
        private void ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
            }
        }
        private void Quanlysinhvien_Load(object sender, EventArgs e)
        {
            Hienthi();
        }
        private void clickdata()
        {
            txtMaSV.Text = dtGridView_QVSV.CurrentRow.Cells[0].Value.ToString();
            txtHoten.Text = dtGridView_QVSV.CurrentRow.Cells[1].Value.ToString();
            txtDateTime.Text = dtGridView_QVSV.CurrentRow.Cells[2].Value.ToString();
            bool gt = Convert.ToBoolean(dtGridView_QVSV.CurrentRow.Cells[3].Value.ToString());
            Cbb_Gioitinh.Text = gt ? "Nam" : "Nữ";
            txtDiachi.Text = dtGridView_QVSV.CurrentRow.Cells[4].Value.ToString();
            txtSDT.Text = dtGridView_QVSV.CurrentRow.Cells[5].Value.ToString();
            txtEmail.Text = dtGridView_QVSV.CurrentRow.Cells[6].Value.ToString();
            string imagePath = dtGridView_QVSV.CurrentRow.Cells[7].Value.ToString();

            // Kiểm tra nếu đường dẫn ảnh hợp lệ, hiển thị lên PictureBox
            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                Ptb_AnhSv.Image = Image.FromFile(imagePath); // Hiển thị ảnh
                Ptb_AnhSv.Tag = imagePath; // Lưu đường dẫn vào Tag để sử dụng lại nếu cần
            }
            else
            {
                Ptb_AnhSv.Image = null; // Nếu không có ảnh, đặt PictureBox về null
                Ptb_AnhSv.Tag = null;
                MessageBox.Show("Không tìm thấy ảnh hoặc đường dẫn không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void dtGridView_QVSV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clickdata();
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
                Ptb_AnhSv.Tag = imagePath;

                // Hiển thị ảnh từ đường dẫn đầy đủ
                Ptb_AnhSv.Image = Image.FromFile(imagePath);
            }
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            HienthiAnh();
        }
        private void Capnhat()
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn cập nhật thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    string relativeImagePath = Ptb_AnhSv.Tag?.ToString();  // Lưu tên ảnh hoặc đường dẫn tương đối
                    // Tạo các tham số cho câu lệnh SQL
                    SqlParameter[] parameters = new SqlParameter[] {
                            new SqlParameter("@MaSV", SqlDbType.NVarChar) { Value = txtMaSV.Text },
                            new SqlParameter("@TenSV", SqlDbType.NVarChar) { Value = txtHoten.Text },
                            new SqlParameter("@NgaySinh", SqlDbType.Date) {Value = txtDateTime.Text},
                            new SqlParameter("@GioiTinh", SqlDbType.Bit) {Value = Cbb_Gioitinh.SelectedValue},
                            new SqlParameter("@DiaChi", SqlDbType.NVarChar) {Value = txtDiachi.Text},
                            new SqlParameter("@SDT", SqlDbType.NVarChar) {Value = txtSDT.Text},
                            new SqlParameter("@Email", SqlDbType.NVarChar) {Value = txtEmail.Text},
                            new SqlParameter("@anhSV", SqlDbType.NVarChar) {Value = relativeImagePath}  // Lưu tên ảnh vào cơ sở dữ liệu
                        };

                    // Câu lệnh SQL để gọi thủ tục lưu thông tin sinh viên
                    string query = "EXEC CapNhatSinhVien @MaSV, @TenSV, @NgaySinh, @GioiTinh, @DiaChi, @SDT, @Email, @anhSV";

                    // Gọi phương thức cập nhật dữ liệu
                    this.qlgd.CapNhatDuLieu(query, parameters);
                    MessageBox.Show("Đã cập nhật thành công!", "Thông báo", MessageBoxButtons.OK);
                    loadData();
                    ResetTxt();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật thông tin sinh viên: " + ex.Message);
                }
            }
        }
        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            Capnhat();
        }
        private void Xoa()
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // Tạo các tham số cho câu lệnh SQL
                    SqlParameter[] parameters = new SqlParameter[] {
                            new SqlParameter("@MaSV", SqlDbType.NVarChar) { Value = txtMaSV.Text },                      
                    };

                    // Câu lệnh SQL để gọi thủ tục lưu thông tin sinh viên
                    string query = "EXEC XoaSinhVien @MaSV";

                    // Gọi phương thức cập nhật dữ liệu
                    this.qlgd.CapNhatDuLieu(query, parameters);
                    MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK);
                    loadData();
                    ResetTxt();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa thông tin sinh viên: " + ex.Message);
                }
            }
        }
        private void btn_xoa_Click(object sender, EventArgs e)
        {
            Xoa();
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
            for (int i = 1; i < dtGridView_QVSV.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dtGridView_QVSV.Columns[i - 1].HeaderText;
            }

            // Ghi dữ liệu từ DataGridView vào Excel
            for (int i = 0; i < dtGridView_QVSV.Rows.Count; i++)
            {
                for (int j = 0; j < dtGridView_QVSV.Columns.Count; j++)
                {
                    worksheet.Cells[i + 2, j + 1] = dtGridView_QVSV.Rows[i].Cells[j]?.Value?.ToString() ?? "";
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
        private void btn_excel_Click(object sender, EventArgs e)
        {
            XuatExcel();
        }
    }
}
