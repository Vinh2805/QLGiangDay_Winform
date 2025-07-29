using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace QL_GiangDay
{
	public partial class FormLogin : Form
	{
		private SQL_QLGiangDay qlgd;
        private bool isDragging = false; // Trạng thái kéo form
        private Point lastCursor; // Vị trí con trỏ chuột
        private Point lastForm; // Vị trí của form khi bắt đầu kéo
        private Point currentCursor; // Vị trí chuột hiện tại

        public FormLogin()
		{
			InitializeComponent();
			qlgd = new SQL_QLGiangDay();
			txt_Pass.PasswordChar = '*';
            this.MouseDown += FormLogin_MouseDown;
            this.MouseMove += FormLogin_MouseMove;
            this.MouseUp += FormLogin_MouseUp;
		}

        private void FormLogin_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false; // Dừng kéo
        }

        private void FormLogin_MouseMove(object sender, MouseEventArgs e)
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

        private void FormLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true; // Bắt đầu kéo
                lastCursor = Cursor.Position; // Lưu vị trí của con trỏ chuột trong không gian màn hình
                lastForm = this.Location; // Lưu vị trí hiện tại của form
            }
        }

        private void Exit()
		{
			if (MessageBox.Show("Are you Exit?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Application.Exit();
			}	
		}
		private void Lb_Exit_Click(object sender, EventArgs e)
		{
			Exit();
		}
		private void Lienket()
		{
			string Url = "https://chatgpt.com";
			try
			{
				Process.Start(Url);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Không thể mở URL. Lỗi: {ex.Message}");
			}
		}
		private void Llb_chatGpt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Lienket();
		}
		private bool ValidateInput()
		{
			if (string.IsNullOrWhiteSpace(txt_User.Text) || string.IsNullOrWhiteSpace(txt_Pass.Text))
			{
				MessageBox.Show("Please enter complete information!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}
		private void Reset()
		{
			txt_User.Clear();
			txt_Pass.Clear();
			txt_User.Focus();
		}
		private void Input()
		{
			string username = txt_User.Text.Trim();
			string password = txt_Pass.Text.Trim();

			string query = "SELECT TaiKhoanID, TenDangNhap, MatKhau FROM TaiKhoan WHERE TenDangNhap = @username AND MatKhau = @password";

			SqlParameter[] parameters = {
				new SqlParameter("@username", SqlDbType.NVarChar) { Value = username },
				new SqlParameter("@password", SqlDbType.NVarChar) { Value = password }
			};

			DataTable users = qlgd.DocBang(query, parameters);

			bool isAuthenticated = false;

			if (users.Rows.Count > 0)
			{
				isAuthenticated = true;
                string userId = users.Rows[0]["TaiKhoanID"].ToString();
                string userName = users.Rows[0]["TenDangNhap"].ToString();

                FormSplash_AfterLogin form1 = new FormSplash_AfterLogin(userId, userName);
                form1.Show();
                FormLoginInformation form2 = new FormLoginInformation(userId, userName);
            }

            if (isAuthenticated)
			{
				this.Hide();
			}
			else
			{
				MessageBox.Show("Username or password is incorrect!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Reset();
			}
		}  
        private void Btn_Login_Click(object sender, EventArgs e)
		{
			if (!ValidateInput())
			{
				return;
			}
			else
			{
				Input();
			}
			
		}
		private void FormLogin_Load(object sender, EventArgs e)
		{
			txt_User.KeyDown += Txt_User_KeyDown;
			txt_Pass.KeyDown += Txt_Pass_KeyDown;
			Btn_Login.KeyDown += Btn_Login_KeyDown;
		}
		private void Btn_Login_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				txt_User.Focus();
				e.Handled = true;
			}
		}
		private void Txt_Pass_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				Btn_Login.Focus();
				e.Handled = true;
			}
		}
		private void Txt_User_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				txt_Pass.Focus();
				e.Handled = true;
			}
		}
		private void SignUp()
		{
			FormRegister formRegister = new FormRegister();
			formRegister.Show();
			this.Hide();
		}
		private void Btn_SignUp_Click(object sender, EventArgs e)
		{
			SignUp();
		}
		private void ThuNho()
		{
			Lb_Thunho.Click += (s, e) =>
			{
				this.WindowState = FormWindowState.Minimized;
			};
		}
		private void Lb_Thunho_Click(object sender, EventArgs e)
		{
			ThuNho();
		}
		private void CheckPass()
		{
			if (Cb_Check.Checked)
			{
				txt_Pass.PasswordChar = '\0';
			}	
			else
			{
				txt_Pass.PasswordChar = '*';
			}	
		}
		private void Cb_Check_CheckedChanged(object sender, EventArgs e)
		{
			CheckPass();
		}
	}
}
