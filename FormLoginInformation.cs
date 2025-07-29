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
    public partial class FormLoginInformation : Form
    {
        private string _username;
        private string _taikhoanid;
        private SQL_QLGiangDay qlgd;
        private bool isDragging = false; // Trạng thái kéo form
        private Point lastCursor; // Vị trí con trỏ chuột
        private Point lastForm; // Vị trí của form khi bắt đầu kéo
        private Point currentCursor; // Vị trí chuột hiện tại
        public FormLoginInformation(string matakhoan, string tendangnhap)
        {
            InitializeComponent();
            qlgd = new SQL_QLGiangDay();
            _username = tendangnhap;
            _taikhoanid = matakhoan;
            Pn_tcc.MouseDown += Pn_tcc_MouseDown;
            Pn_tcc.MouseUp += Pn_tcc_MouseUp;
            Pn_tcc.MouseMove += Pn_tcc_MouseMove;
        }

        private void Pn_tcc_MouseMove(object sender, MouseEventArgs e)
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

        private void Pn_tcc_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void Pn_tcc_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true; // Bắt đầu kéo
                lastCursor = Cursor.Position; // Lưu vị trí của con trỏ chuột trong không gian màn hình
                lastForm = this.Location; // Lưu vị trí hiện tại của form
            }
        }
        private void Logout()
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất khỏi thiết bị này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Bạn đã đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK);
                FormLogin formLogin = new FormLogin();
                formLogin.Show();
                this.Close();
            }
        }
        private void btnlogout_Click(object sender, EventArgs e)
        {
            Logout();
        }
        private void UpdateTK()
        {
            FormUpdateLogin formUpdateLogin = new FormUpdateLogin(_taikhoanid, _username);
            formUpdateLogin.Show();
            this.Close();
        }
        private void btnUpdatetk_Click(object sender, EventArgs e)
        {
            UpdateTK();
        }
        private void FormLoginInformation_Load(object sender, EventArgs e)
        {
            // Thiết lập các TextBox chỉ đọc
            txtMatk.ReadOnly = true;
            txtTendn.ReadOnly = true;
            txtMatk.Text = _taikhoanid;
            txtTendn.Text = _username;
        }
        private void ptb_add_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain(_taikhoanid, _username);
            formMain.Show();
            this.Close();
        }
        private void XoaTK()
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa tài khoản này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    SqlParameter[] parameters = new SqlParameter[] {
                            new SqlParameter("@TaikhoanID", SqlDbType.NVarChar) { Value = txtMatk.Text },
                            new SqlParameter("@Username", SqlDbType.NVarChar) { Value = txtTendn.Text }
                    };

                    string query = "EXEC XoaTaiKhoan @TaikhoanID, @Username";

                    this.qlgd.CapNhatDuLieu(query, parameters);
                    MessageBox.Show("Đã xóa thành công!", "Thông báo", MessageBoxButtons.OK);
                    FormLogin formLogin = new FormLogin();
                    formLogin.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa thông tin tài khoản: " + ex.Message);
                }
            }
        }
        private void btnXoatk_Click(object sender, EventArgs e)
        {
            XoaTK();
        }
        private void Minus()
        {
            WindowState = FormWindowState.Minimized;
        }
        private void ptb_minus_Click(object sender, EventArgs e)
        {
            Minus();
        }
        private void ptb_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
