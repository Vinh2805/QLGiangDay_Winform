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
    public partial class FormUpdateLogin : Form
    {
        private SQL_QLGiangDay qlgd;
        private string _username;
        private string _taikhoanid;
        private bool isDragging = false; // Trạng thái kéo form
        private Point lastCursor; // Vị trí con trỏ chuột
        private Point lastForm; // Vị trí của form khi bắt đầu kéo
        private Point currentCursor; // Vị trí chuột hiện tại
        public FormUpdateLogin(string matakhoan, string tendangnhap)
        {
            InitializeComponent();
            qlgd = new SQL_QLGiangDay();
            _username = tendangnhap;
            _taikhoanid = matakhoan;
            txtPass.PasswordChar = '*';
            txtPassOld.PasswordChar = '*';
            panel1.MouseMove += Panel1_MouseMove;
            panel1.MouseUp += Panel1_MouseUp;
            panel1.MouseDown += Panel1_MouseDown;
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true; // Bắt đầu kéo
                lastCursor = Cursor.Position; // Lưu vị trí của con trỏ chuột trong không gian màn hình
                lastForm = this.Location; // Lưu vị trí hiện tại của form
            }
        }

        private void Panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void Panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                currentCursor = Cursor.Position; // Lấy vị trí hiện tại của chuột trên toàn màn hình

                // Tính toán sự thay đổi vị trí của form
                int deltaX = currentCursor.X - lastCursor.X;
                int deltaY = currentCursor.Y - lastCursor.Y;

                // Cập nhật vị trí của form
                this.Location = new Point(lastForm.X + deltaX, lastForm.Y + deltaY);

                // Cập nhật lại vị trí của con trỏ chuột và form
                lastCursor = currentCursor;
                lastForm = this.Location;
            }
        }

        private void Huy()
        {
            FormLoginInformation formMain = new FormLoginInformation(_taikhoanid, _username);
            formMain.Show();
            this.Hide();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            Huy();
        }
        private void Luu()
        {
            try
            {
                // Lấy mật khẩu hiện tại trong cơ sở dữ liệu
                System.Data.DataTable dt = qlgd.DocBang("SELECT MatKhau FROM TaiKhoan WHERE TaiKhoanID = @ID AND TenDangNhap = @Username",
                    new SqlParameter[]
                    {
                new SqlParameter("@ID", SqlDbType.NVarChar) { Value = _taikhoanid },
                new SqlParameter("@Username", SqlDbType.NVarChar) { Value = _username }
                    });

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Tài khoản không tồn tại hoặc thông tin không chính xác.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Kiểm tra mật khẩu cũ
                string matKhauTrongDB = dt.Rows[0]["MatKhau"].ToString();
                if (txtPassOld.Text != matKhauTrongDB)
                {
                    MessageBox.Show("Mật khẩu cũ không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra mật khẩu mới có hợp lệ không
                if (string.IsNullOrWhiteSpace(txtPass.Text))
                {
                    MessageBox.Show("Mật khẩu mới không được để trống.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cập nhật mật khẩu mới
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@ID", SqlDbType.NVarChar) { Value = _taikhoanid },
            new SqlParameter("@Username", SqlDbType.NVarChar) { Value = _username },
            new SqlParameter("@Password", SqlDbType.NVarChar) { Value = txtPass.Text }
                };

                string updateQuery = "EXEC CapNhatTaiKhoan @ID, @Username, @Password";
                int rowsAffected = qlgd.CapNhatDuLieuVaTraVeSoDong(updateQuery, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Điều hướng về trang thông tin đăng nhập
                    FormLoginInformation formLoginInformation = new FormLoginInformation(_taikhoanid, _username);
                    formLoginInformation.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không có bản ghi nào được cập nhật. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đổi mật khẩu: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            Luu();
        }
        private void CheckPass()
        {
            if (cb_HienMK.Checked)
            {
                txtPassOld.PasswordChar = '\0';
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPassOld.PasswordChar = '*';
                txtPass.PasswordChar = '*';
            }
        }
        private void cb_HienMK_CheckedChanged(object sender, EventArgs e)
        {
            CheckPass();
        }
    }
}
