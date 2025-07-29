using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_GiangDay
{
    public partial class FormMain : Form
    {
        private bool isDragging = false; // Trạng thái kéo form
        private Point lastCursor; // Vị trí con trỏ chuột
        private Point lastForm; // Vị trí của form khi bắt đầu kéo
        private Point currentCursor; // Vị trí chuột hiện tại
        private bool menuExpand = false;
        private bool isFullScreen = false;
        private string _username;
        private string _taikhoanid;
        public FormMain(string mataikhoan, string tendangnhap)
        {
            InitializeComponent();
            Pn_tcc.MouseDown += FormMain_MouseDown;
            Pn_tcc.MouseMove += FormMain_MouseMove;
            Pn_tcc.MouseUp += FormMain_MouseUp;
            _username = tendangnhap;
            _taikhoanid = mataikhoan;
        }
        private void FormMain_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false; // Dừng kéo
        }
        private void FormMain_MouseMove(object sender, MouseEventArgs e)
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
        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true; // Bắt đầu kéo
                lastCursor = Cursor.Position; // Lưu vị trí của con trỏ chuột trong không gian màn hình
                lastForm = this.Location; // Lưu vị trí hiện tại của form
            }
        }
        private void Out()
        {
            Application.Exit();
        }
        private void ptb_thoat_Click(object sender, EventArgs e)
        {
            Out();
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F11)
            {
                ToggleFullScreen();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void ToggleFullScreen()
        {
            if (isFullScreen)
            {
                // Thoát toàn màn hình
                WindowState = FormWindowState.Normal;
                isFullScreen = false;
            }
            else
            {
                WindowState = FormWindowState.Maximized; // Phủ toàn bộ màn hình
                isFullScreen = true;
            }
        }
        private void Minus()
        {
            WindowState = FormWindowState.Minimized;
        }
        private void ptb_minus_Click(object sender, EventArgs e)
        {
            Minus();
        }
        private void MenuTransition_QL_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                Flop_QL.Height += 20;
                if (Flop_QL.Height >= 230)
                {
                    MenuTransition_QL.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                Flop_QL.Height -= 20; 
                if (Flop_QL.Height <= 50) 
                {
                    MenuTransition_QL.Stop();
                    menuExpand = false;
                }
            }
        }
        private void btn_Quanly_Click(object sender, EventArgs e)
        {
            quanly.Visible = true;
            quanlysinhvien.Visible = false;
            quanlygiangvien.Visible = false;
            quanlylophoc.Visible = false;
            quanlymonhoc.Visible = false;
            chuongtrinhhoc.Visible = false;
            thongbaosinhvien.Visible = false;
            thongbaogiangvien.Visible = false;

            Quanly ql = quanly as Quanly;
            if (ql != null)
            {
                ql.RefreshData();
            }
            MenuTransition_QL.Start();
        }
        private void MenuTransition_TB_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                Flop_TB.Height += 20; 
                if (Flop_TB.Height >= 150) 
                {
                    MenuTransition_TB.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                Flop_TB.Height -= 20; 
                if (Flop_TB.Height <= 60)
                {
                    MenuTransition_TB.Stop();
                    menuExpand = false;
                }
            }
        }
        private void btn_thongbao_Click(object sender, EventArgs e)
        {
            MenuTransition_TB.Start();
        }

        private void ptb_add_Click(object sender, EventArgs e)
        {
            FormLoginInformation formLoginInformation = new FormLoginInformation(_taikhoanid, _username);
            formLoginInformation.Show();
            this.Hide();
        }

        private void btn_qlsv_Click(object sender, EventArgs e)
        {
            quanly.Visible = false;
            quanlysinhvien.Visible = true;
            quanlygiangvien.Visible = false;
            quanlylophoc.Visible = false;
            quanlymonhoc.Visible = false;
            chuongtrinhhoc.Visible = false;
            thongbaosinhvien.Visible = false;
            thongbaogiangvien.Visible = false;

            Quanlysinhvien ql = quanlysinhvien as Quanlysinhvien;
            if (ql != null)
            {
                ql.Refresh();
            }
        }

        private void btn_qlgv_Click(object sender, EventArgs e)
        {
            quanly.Visible = false;
            quanlysinhvien.Visible = false;
            quanlygiangvien.Visible = true;
            quanlylophoc.Visible = false;
            quanlymonhoc.Visible = false;
            chuongtrinhhoc.Visible = false;
            thongbaosinhvien.Visible = false;
            thongbaogiangvien.Visible = false;

            Quanlygiangvien ql = quanlygiangvien as Quanlygiangvien;
            if (ql != null)
            {
                ql.Refresh();
            }
        }

        private void btn_qlmh_Click(object sender, EventArgs e)
        {
            quanly.Visible = false;
            quanlysinhvien.Visible = false;
            quanlygiangvien.Visible = false;
            quanlylophoc.Visible = false;
            quanlymonhoc.Visible = true;
            chuongtrinhhoc.Visible = false;
            thongbaosinhvien.Visible = false;
            thongbaogiangvien.Visible = false;

            Quanlymonhoc ql = quanlymonhoc as Quanlymonhoc;
            if (ql != null)
            {
                ql.Refresh();
            }
        }

        private void btn_qllh_Click(object sender, EventArgs e)
        {
            quanly.Visible = false;
            quanlysinhvien.Visible = false;
            quanlygiangvien.Visible = false;
            quanlylophoc.Visible = true;
            quanlymonhoc.Visible = false;
            chuongtrinhhoc.Visible = false;
            thongbaosinhvien.Visible = false;
            thongbaogiangvien.Visible = false;

            Quanlylophoc ql = quanlylophoc as Quanlylophoc;
            if (ql != null)
            {
                ql.Refresh();
            }
        }

        private void btn_cth_Click(object sender, EventArgs e)
        {
            quanly.Visible = false;
            quanlysinhvien.Visible = false;
            quanlygiangvien.Visible = false;
            quanlylophoc.Visible = false;
            quanlymonhoc.Visible = false;
            chuongtrinhhoc.Visible = true;
            thongbaosinhvien.Visible = false;
            thongbaogiangvien.Visible = false;

            Chuongtrinhhoc ql = chuongtrinhhoc as Chuongtrinhhoc;
            if (ql != null)
            {
                ql.Refresh();
            }
        }

        private void btn_tbsv_Click(object sender, EventArgs e)
        {
            quanly.Visible = false;
            quanlysinhvien.Visible = false;
            quanlygiangvien.Visible = false;
            quanlylophoc.Visible = false;
            quanlymonhoc.Visible = false;
            chuongtrinhhoc.Visible = false;
            thongbaosinhvien.Visible = true;
            thongbaogiangvien.Visible = false;

            Thongbaosinhvien ql = thongbaosinhvien as Thongbaosinhvien;
            if (ql != null)
            {
                ql.Refresh();
            }
        }

        private void btn_tbgv_Click(object sender, EventArgs e)
        {
            quanly.Visible = false;
            quanlysinhvien.Visible = false;
            quanlygiangvien.Visible = false;
            quanlylophoc.Visible = false;
            quanlymonhoc.Visible = false;
            chuongtrinhhoc.Visible = false;
            thongbaosinhvien.Visible = false;
            thongbaogiangvien.Visible = true;

            Thongbaogiangvien ql = thongbaogiangvien as Thongbaogiangvien;
            if (ql != null)
            {
                ql.Refresh();
            }
        }
    }
}
