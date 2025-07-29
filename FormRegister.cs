using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_GiangDay
{
	public partial class FormRegister : Form
	{
		private SQL_QLGiangDay qlgd;
        private bool isDragging = false; // Trạng thái kéo form
        private Point lastCursor; // Vị trí con trỏ chuột
        private Point lastForm; // Vị trí của form khi bắt đầu kéo
        private Point currentCursor; // Vị trí chuột hiện tại
        public FormRegister()
		{
			InitializeComponent();
			qlgd = new SQL_QLGiangDay();
			txt_Pass.PasswordChar = '*';
            this.MouseMove += FormRegister_MouseMove;
            this.MouseUp += FormRegister_MouseUp;
            this.MouseDown += FormRegister_MouseDown;
		}

        private void FormRegister_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true; // Bắt đầu kéo
                lastCursor = Cursor.Position; // Lưu vị trí của con trỏ chuột trong không gian màn hình
                lastForm = this.Location; // Lưu vị trí hiện tại của form
            }
        }

        private void FormRegister_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false; // Dừng kéo
        }

        private void FormRegister_MouseMove(object sender, MouseEventArgs e)
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

        private void SignIn()
		{
			FormLogin formLogin = new FormLogin();
			formLogin.Show();
			this.Hide();
		}
		private void Btn_SignIn_Click(object sender, EventArgs e)
		{
			SignIn();
		}
		private void Exit()
		{
			if (MessageBox.Show("Are you Exit?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Application.Exit();
			}
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
		private bool ValidateInput()
		{
			if (string.IsNullOrWhiteSpace(txt_Pass.Text) || string.IsNullOrWhiteSpace(txt_User.Text))
			{
				MessageBox.Show("Please enter complete information!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}
		private void Reset()
		{
			txt_IDAccount.Clear();
			txt_User.Clear();
			txt_Pass.Clear();
			txt_IDAccount.Focus();
		}
		private void Insert_Account()
		{
			SqlParameter[] parameters = new SqlParameter[] {
				new SqlParameter("@ID", SqlDbType.NVarChar) { Value = txt_IDAccount.Text },
				new SqlParameter("@Username", SqlDbType.NVarChar) { Value = txt_User.Text },
				new SqlParameter("@Password", SqlDbType.NVarChar) {Value = txt_Pass.Text}
			};
			string query = "EXEC ThemTaiKhoan @ID, @Username, @Password";
			this.qlgd.CapNhatDuLieu(query, parameters);
			MessageBox.Show("Account created successfully!", "Notification", MessageBoxButtons.OK);
			this.Reset();	
		}
		private void Btn_SignupNew_Click(object sender, EventArgs e)
		{
			if (!ValidateInput())
			{
				this.Reset();
				return;
			}
			Kiemtrakitu();	
			if (MessageBox.Show("Are you sure you want to create this account?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Insert_Account();
			}	
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

		private void Lb_Exit_Click(object sender, EventArgs e)
		{
			Exit();
		}
		private void CheckInt_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!"012".Contains(e.KeyChar) && !Char.IsControl(e.KeyChar))
			{
				e.Handled = true;
			}	
		}
		private void Kiemtrakitu()
		{
			if (txt_User.Text.Length < 6 && txt_Pass.Text.Length < 6)
			{
				MessageBox.Show("Username and Password length must be six characters or more!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				if (txt_Pass.Text.Length < 6 && txt_User.Text.Length > 6)
				{
					MessageBox.Show("Username length must be six characters or more!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				else if (txt_Pass.Text.Length > 6 && txt_User.Text.Length < 6)
				{
					MessageBox.Show("Password length must be six characters or more!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		private void Checkkitumk()
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
			Checkkitumk();
		}

		private void FormRegister_Load(object sender, EventArgs e)
		{
			txt_IDAccount.KeyDown += Txt_IDAccount_KeyDown;
			txt_User.KeyDown += Txt_User_KeyDown;
			txt_Pass.KeyDown += Txt_Pass_KeyDown;
			Btn_SignupNew.KeyDown += Btn_SignupNew_KeyDown;
		}

		private void Btn_SignupNew_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				txt_IDAccount.Focus();
				e.Handled = true;
			}
		}

		private void Txt_Pass_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				Btn_SignupNew.Focus();
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

		private void Txt_IDAccount_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Down)
			{
				txt_User.Focus();
				e.Handled = true;
			}
		}

		private void Llb_chatGpt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			this.Lienket();
		}
	}
}
