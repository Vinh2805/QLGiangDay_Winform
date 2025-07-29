
namespace QL_GiangDay
{
	partial class FormMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.Pn_tcc = new System.Windows.Forms.Panel();
            this.ptb_minus = new System.Windows.Forms.PictureBox();
            this.ptb_thoat = new System.Windows.Forms.PictureBox();
            this.Lb_title = new System.Windows.Forms.Label();
            this.Pn_Menu = new System.Windows.Forms.Panel();
            this.Pn_Main = new System.Windows.Forms.Panel();
            this.Flop_QL = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_Quanly = new System.Windows.Forms.Button();
            this.btn_qlsv = new System.Windows.Forms.Button();
            this.btn_qlgv = new System.Windows.Forms.Button();
            this.btn_qlmh = new System.Windows.Forms.Button();
            this.btn_qllh = new System.Windows.Forms.Button();
            this.Flop_TB = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_thongbao = new System.Windows.Forms.Button();
            this.btn_tbsv = new System.Windows.Forms.Button();
            this.btn_tbgv = new System.Windows.Forms.Button();
            this.Lb_Hello = new System.Windows.Forms.Label();
            this.btn_cth = new System.Windows.Forms.Button();
            this.ptb_add = new System.Windows.Forms.PictureBox();
            this.MenuTransition_QL = new System.Windows.Forms.Timer(this.components);
            this.MenuTransition_TB = new System.Windows.Forms.Timer(this.components);
            this.quanly = new QL_GiangDay.Quanly();
            this.quanlysinhvien = new QL_GiangDay.Quanlysinhvien();
            this.quanlygiangvien = new QL_GiangDay.Quanlygiangvien();
            this.quanlymonhoc = new QL_GiangDay.Quanlymonhoc();
            this.quanlylophoc = new QL_GiangDay.Quanlylophoc();
            this.chuongtrinhhoc = new QL_GiangDay.Chuongtrinhhoc();
            this.thongbaosinhvien = new QL_GiangDay.Thongbaosinhvien();
            this.thongbaogiangvien = new QL_GiangDay.Thongbaogiangvien();
            this.Pn_tcc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_minus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_thoat)).BeginInit();
            this.Pn_Menu.SuspendLayout();
            this.Flop_QL.SuspendLayout();
            this.Flop_TB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_add)).BeginInit();
            this.SuspendLayout();
            // 
            // Pn_tcc
            // 
            this.Pn_tcc.AutoSize = true;
            this.Pn_tcc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Pn_tcc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Pn_tcc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pn_tcc.Controls.Add(this.ptb_minus);
            this.Pn_tcc.Controls.Add(this.ptb_thoat);
            this.Pn_tcc.Controls.Add(this.Lb_title);
            this.Pn_tcc.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pn_tcc.Location = new System.Drawing.Point(0, 0);
            this.Pn_tcc.Margin = new System.Windows.Forms.Padding(6);
            this.Pn_tcc.Name = "Pn_tcc";
            this.Pn_tcc.Size = new System.Drawing.Size(1445, 49);
            this.Pn_tcc.TabIndex = 0;
            // 
            // ptb_minus
            // 
            this.ptb_minus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptb_minus.Image = ((System.Drawing.Image)(resources.GetObject("ptb_minus.Image")));
            this.ptb_minus.Location = new System.Drawing.Point(1351, 11);
            this.ptb_minus.Name = "ptb_minus";
            this.ptb_minus.Size = new System.Drawing.Size(32, 32);
            this.ptb_minus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_minus.TabIndex = 4;
            this.ptb_minus.TabStop = false;
            this.ptb_minus.Click += new System.EventHandler(this.ptb_minus_Click);
            // 
            // ptb_thoat
            // 
            this.ptb_thoat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptb_thoat.Image = ((System.Drawing.Image)(resources.GetObject("ptb_thoat.Image")));
            this.ptb_thoat.Location = new System.Drawing.Point(1400, 11);
            this.ptb_thoat.Name = "ptb_thoat";
            this.ptb_thoat.Size = new System.Drawing.Size(32, 32);
            this.ptb_thoat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_thoat.TabIndex = 2;
            this.ptb_thoat.TabStop = false;
            this.ptb_thoat.Click += new System.EventHandler(this.ptb_thoat_Click);
            // 
            // Lb_title
            // 
            this.Lb_title.AutoSize = true;
            this.Lb_title.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_title.ForeColor = System.Drawing.Color.White;
            this.Lb_title.Location = new System.Drawing.Point(14, 8);
            this.Lb_title.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Lb_title.Name = "Lb_title";
            this.Lb_title.Size = new System.Drawing.Size(430, 39);
            this.Lb_title.TabIndex = 1;
            this.Lb_title.Text = "Teaching Management System";
            // 
            // Pn_Menu
            // 
            this.Pn_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Pn_Menu.Controls.Add(this.Pn_Main);
            this.Pn_Menu.Controls.Add(this.Flop_QL);
            this.Pn_Menu.Controls.Add(this.Flop_TB);
            this.Pn_Menu.Controls.Add(this.Lb_Hello);
            this.Pn_Menu.Controls.Add(this.btn_cth);
            this.Pn_Menu.Controls.Add(this.ptb_add);
            this.Pn_Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.Pn_Menu.Location = new System.Drawing.Point(0, 49);
            this.Pn_Menu.Margin = new System.Windows.Forms.Padding(6);
            this.Pn_Menu.Name = "Pn_Menu";
            this.Pn_Menu.Size = new System.Drawing.Size(381, 833);
            this.Pn_Menu.TabIndex = 1;
            // 
            // Pn_Main
            // 
            this.Pn_Main.Location = new System.Drawing.Point(384, 0);
            this.Pn_Main.Margin = new System.Windows.Forms.Padding(6);
            this.Pn_Main.Name = "Pn_Main";
            this.Pn_Main.Size = new System.Drawing.Size(1061, 819);
            this.Pn_Main.TabIndex = 2;
            // 
            // Flop_QL
            // 
            this.Flop_QL.Controls.Add(this.btn_Quanly);
            this.Flop_QL.Controls.Add(this.btn_qlsv);
            this.Flop_QL.Controls.Add(this.btn_qlgv);
            this.Flop_QL.Controls.Add(this.btn_qlmh);
            this.Flop_QL.Controls.Add(this.btn_qllh);
            this.Flop_QL.Location = new System.Drawing.Point(8, 341);
            this.Flop_QL.Name = "Flop_QL";
            this.Flop_QL.Size = new System.Drawing.Size(374, 82);
            this.Flop_QL.TabIndex = 8;
            // 
            // btn_Quanly
            // 
            this.btn_Quanly.AutoSize = true;
            this.btn_Quanly.BackColor = System.Drawing.Color.Gray;
            this.btn_Quanly.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Quanly.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_Quanly.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_Quanly.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_Quanly.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Quanly.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quanly.ForeColor = System.Drawing.Color.White;
            this.btn_Quanly.Image = global::QL_GiangDay.Properties.Resources.management;
            this.btn_Quanly.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Quanly.Location = new System.Drawing.Point(6, 6);
            this.btn_Quanly.Margin = new System.Windows.Forms.Padding(6);
            this.btn_Quanly.Name = "btn_Quanly";
            this.btn_Quanly.Size = new System.Drawing.Size(361, 69);
            this.btn_Quanly.TabIndex = 2;
            this.btn_Quanly.Text = "Quản lý";
            this.btn_Quanly.UseVisualStyleBackColor = false;
            this.btn_Quanly.Click += new System.EventHandler(this.btn_Quanly_Click);
            // 
            // btn_qlsv
            // 
            this.btn_qlsv.AutoSize = true;
            this.btn_qlsv.BackColor = System.Drawing.Color.Gray;
            this.btn_qlsv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_qlsv.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_qlsv.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_qlsv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_qlsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_qlsv.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_qlsv.ForeColor = System.Drawing.Color.White;
            this.btn_qlsv.Image = global::QL_GiangDay.Properties.Resources.sinhvien1;
            this.btn_qlsv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_qlsv.Location = new System.Drawing.Point(6, 87);
            this.btn_qlsv.Margin = new System.Windows.Forms.Padding(6);
            this.btn_qlsv.Name = "btn_qlsv";
            this.btn_qlsv.Size = new System.Drawing.Size(361, 74);
            this.btn_qlsv.TabIndex = 4;
            this.btn_qlsv.Text = "Quản lý sinh viên";
            this.btn_qlsv.UseVisualStyleBackColor = false;
            this.btn_qlsv.Click += new System.EventHandler(this.btn_qlsv_Click);
            // 
            // btn_qlgv
            // 
            this.btn_qlgv.AutoSize = true;
            this.btn_qlgv.BackColor = System.Drawing.Color.Gray;
            this.btn_qlgv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_qlgv.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_qlgv.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_qlgv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_qlgv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_qlgv.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_qlgv.ForeColor = System.Drawing.Color.White;
            this.btn_qlgv.Image = global::QL_GiangDay.Properties.Resources.giangvien1;
            this.btn_qlgv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_qlgv.Location = new System.Drawing.Point(6, 173);
            this.btn_qlgv.Margin = new System.Windows.Forms.Padding(6);
            this.btn_qlgv.Name = "btn_qlgv";
            this.btn_qlgv.Size = new System.Drawing.Size(361, 74);
            this.btn_qlgv.TabIndex = 7;
            this.btn_qlgv.Text = "Quản lý giảng viên";
            this.btn_qlgv.UseVisualStyleBackColor = false;
            this.btn_qlgv.Click += new System.EventHandler(this.btn_qlgv_Click);
            // 
            // btn_qlmh
            // 
            this.btn_qlmh.AutoSize = true;
            this.btn_qlmh.BackColor = System.Drawing.Color.Gray;
            this.btn_qlmh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_qlmh.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_qlmh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_qlmh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_qlmh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_qlmh.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_qlmh.ForeColor = System.Drawing.Color.White;
            this.btn_qlmh.Image = global::QL_GiangDay.Properties.Resources.subject;
            this.btn_qlmh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_qlmh.Location = new System.Drawing.Point(6, 259);
            this.btn_qlmh.Margin = new System.Windows.Forms.Padding(6);
            this.btn_qlmh.Name = "btn_qlmh";
            this.btn_qlmh.Size = new System.Drawing.Size(361, 74);
            this.btn_qlmh.TabIndex = 5;
            this.btn_qlmh.Text = "Quản lý môn học";
            this.btn_qlmh.UseVisualStyleBackColor = false;
            this.btn_qlmh.Click += new System.EventHandler(this.btn_qlmh_Click);
            // 
            // btn_qllh
            // 
            this.btn_qllh.AutoSize = true;
            this.btn_qllh.BackColor = System.Drawing.Color.Gray;
            this.btn_qllh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_qllh.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_qllh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_qllh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_qllh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_qllh.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_qllh.ForeColor = System.Drawing.Color.White;
            this.btn_qllh.Image = global::QL_GiangDay.Properties.Resources.clr;
            this.btn_qllh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_qllh.Location = new System.Drawing.Point(6, 345);
            this.btn_qllh.Margin = new System.Windows.Forms.Padding(6);
            this.btn_qllh.Name = "btn_qllh";
            this.btn_qllh.Size = new System.Drawing.Size(361, 74);
            this.btn_qllh.TabIndex = 6;
            this.btn_qllh.Text = "Quản lý lớp học";
            this.btn_qllh.UseVisualStyleBackColor = false;
            this.btn_qllh.Click += new System.EventHandler(this.btn_qllh_Click);
            // 
            // Flop_TB
            // 
            this.Flop_TB.Controls.Add(this.btn_thongbao);
            this.Flop_TB.Controls.Add(this.btn_tbsv);
            this.Flop_TB.Controls.Add(this.btn_tbgv);
            this.Flop_TB.Location = new System.Drawing.Point(7, 555);
            this.Flop_TB.Name = "Flop_TB";
            this.Flop_TB.Size = new System.Drawing.Size(374, 86);
            this.Flop_TB.TabIndex = 7;
            // 
            // btn_thongbao
            // 
            this.btn_thongbao.BackColor = System.Drawing.Color.Gray;
            this.btn_thongbao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_thongbao.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_thongbao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_thongbao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_thongbao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_thongbao.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_thongbao.ForeColor = System.Drawing.Color.White;
            this.btn_thongbao.Image = global::QL_GiangDay.Properties.Resources.notification;
            this.btn_thongbao.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_thongbao.Location = new System.Drawing.Point(6, 6);
            this.btn_thongbao.Margin = new System.Windows.Forms.Padding(6);
            this.btn_thongbao.Name = "btn_thongbao";
            this.btn_thongbao.Size = new System.Drawing.Size(361, 70);
            this.btn_thongbao.TabIndex = 4;
            this.btn_thongbao.Text = "Thông báo";
            this.btn_thongbao.UseVisualStyleBackColor = false;
            this.btn_thongbao.Click += new System.EventHandler(this.btn_thongbao_Click);
            // 
            // btn_tbsv
            // 
            this.btn_tbsv.BackColor = System.Drawing.Color.Gray;
            this.btn_tbsv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_tbsv.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_tbsv.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_tbsv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_tbsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tbsv.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tbsv.ForeColor = System.Drawing.Color.White;
            this.btn_tbsv.Image = global::QL_GiangDay.Properties.Resources.error;
            this.btn_tbsv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_tbsv.Location = new System.Drawing.Point(6, 88);
            this.btn_tbsv.Margin = new System.Windows.Forms.Padding(6);
            this.btn_tbsv.Name = "btn_tbsv";
            this.btn_tbsv.Size = new System.Drawing.Size(361, 74);
            this.btn_tbsv.TabIndex = 9;
            this.btn_tbsv.Text = "Thông báo sinh viên";
            this.btn_tbsv.UseVisualStyleBackColor = false;
            this.btn_tbsv.Click += new System.EventHandler(this.btn_tbsv_Click);
            // 
            // btn_tbgv
            // 
            this.btn_tbgv.BackColor = System.Drawing.Color.Gray;
            this.btn_tbgv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_tbgv.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_tbgv.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_tbgv.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_tbgv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_tbgv.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_tbgv.ForeColor = System.Drawing.Color.White;
            this.btn_tbgv.Image = global::QL_GiangDay.Properties.Resources.error;
            this.btn_tbgv.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_tbgv.Location = new System.Drawing.Point(6, 174);
            this.btn_tbgv.Margin = new System.Windows.Forms.Padding(6);
            this.btn_tbgv.Name = "btn_tbgv";
            this.btn_tbgv.Size = new System.Drawing.Size(361, 75);
            this.btn_tbgv.TabIndex = 8;
            this.btn_tbgv.Text = "Thông báo giảng viên";
            this.btn_tbgv.UseVisualStyleBackColor = false;
            this.btn_tbgv.Click += new System.EventHandler(this.btn_tbgv_Click);
            // 
            // Lb_Hello
            // 
            this.Lb_Hello.AutoSize = true;
            this.Lb_Hello.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Hello.ForeColor = System.Drawing.Color.White;
            this.Lb_Hello.Location = new System.Drawing.Point(137, 256);
            this.Lb_Hello.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Lb_Hello.Name = "Lb_Hello";
            this.Lb_Hello.Size = new System.Drawing.Size(124, 33);
            this.Lb_Hello.TabIndex = 1;
            this.Lb_Hello.Text = "Xin chào!";
            // 
            // btn_cth
            // 
            this.btn_cth.AutoSize = true;
            this.btn_cth.BackColor = System.Drawing.Color.Gray;
            this.btn_cth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cth.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_cth.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_cth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.btn_cth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cth.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cth.ForeColor = System.Drawing.Color.White;
            this.btn_cth.Image = global::QL_GiangDay.Properties.Resources.liststudy;
            this.btn_cth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cth.Location = new System.Drawing.Point(14, 452);
            this.btn_cth.Margin = new System.Windows.Forms.Padding(6);
            this.btn_cth.Name = "btn_cth";
            this.btn_cth.Size = new System.Drawing.Size(361, 74);
            this.btn_cth.TabIndex = 3;
            this.btn_cth.Text = "Chương trình học";
            this.btn_cth.UseVisualStyleBackColor = false;
            this.btn_cth.Click += new System.EventHandler(this.btn_cth_Click);
            // 
            // ptb_add
            // 
            this.ptb_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptb_add.Image = global::QL_GiangDay.Properties.Resources.admin;
            this.ptb_add.Location = new System.Drawing.Point(102, 39);
            this.ptb_add.Margin = new System.Windows.Forms.Padding(6);
            this.ptb_add.Name = "ptb_add";
            this.ptb_add.Size = new System.Drawing.Size(197, 195);
            this.ptb_add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_add.TabIndex = 0;
            this.ptb_add.TabStop = false;
            this.ptb_add.Click += new System.EventHandler(this.ptb_add_Click);
            // 
            // MenuTransition_QL
            // 
            this.MenuTransition_QL.Interval = 10;
            this.MenuTransition_QL.Tick += new System.EventHandler(this.MenuTransition_QL_Tick);
            // 
            // MenuTransition_TB
            // 
            this.MenuTransition_TB.Interval = 10;
            this.MenuTransition_TB.Tick += new System.EventHandler(this.MenuTransition_TB_Tick);
            // 
            // quanly
            // 
            this.quanly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quanly.Location = new System.Drawing.Point(381, 49);
            this.quanly.Margin = new System.Windows.Forms.Padding(6);
            this.quanly.Name = "quanly";
            this.quanly.Size = new System.Drawing.Size(1064, 833);
            this.quanly.TabIndex = 9;
            // 
            // quanlysinhvien
            // 
            this.quanlysinhvien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quanlysinhvien.Location = new System.Drawing.Point(381, 49);
            this.quanlysinhvien.Name = "quanlysinhvien";
            this.quanlysinhvien.Size = new System.Drawing.Size(1064, 833);
            this.quanlysinhvien.TabIndex = 8;
            // 
            // quanlygiangvien
            // 
            this.quanlygiangvien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quanlygiangvien.Location = new System.Drawing.Point(381, 49);
            this.quanlygiangvien.Name = "quanlygiangvien";
            this.quanlygiangvien.Size = new System.Drawing.Size(1064, 833);
            this.quanlygiangvien.TabIndex = 7;
            // 
            // quanlymonhoc
            // 
            this.quanlymonhoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quanlymonhoc.Location = new System.Drawing.Point(381, 49);
            this.quanlymonhoc.Name = "quanlymonhoc";
            this.quanlymonhoc.Size = new System.Drawing.Size(1064, 833);
            this.quanlymonhoc.TabIndex = 6;
            // 
            // quanlylophoc
            // 
            this.quanlylophoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quanlylophoc.Location = new System.Drawing.Point(381, 49);
            this.quanlylophoc.Name = "quanlylophoc";
            this.quanlylophoc.Size = new System.Drawing.Size(1064, 833);
            this.quanlylophoc.TabIndex = 5;
            // 
            // chuongtrinhhoc
            // 
            this.chuongtrinhhoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chuongtrinhhoc.Location = new System.Drawing.Point(381, 49);
            this.chuongtrinhhoc.Name = "chuongtrinhhoc";
            this.chuongtrinhhoc.Size = new System.Drawing.Size(1064, 833);
            this.chuongtrinhhoc.TabIndex = 4;
            // 
            // thongbaosinhvien
            // 
            this.thongbaosinhvien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thongbaosinhvien.Location = new System.Drawing.Point(381, 49);
            this.thongbaosinhvien.Name = "thongbaosinhvien";
            this.thongbaosinhvien.Size = new System.Drawing.Size(1064, 833);
            this.thongbaosinhvien.TabIndex = 3;
            // 
            // thongbaogiangvien
            // 
            this.thongbaogiangvien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thongbaogiangvien.Location = new System.Drawing.Point(381, 49);
            this.thongbaogiangvien.Name = "thongbaogiangvien";
            this.thongbaogiangvien.Size = new System.Drawing.Size(1064, 833);
            this.thongbaogiangvien.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 882);
            this.Controls.Add(this.quanly);
            this.Controls.Add(this.quanlysinhvien);
            this.Controls.Add(this.quanlygiangvien);
            this.Controls.Add(this.quanlymonhoc);
            this.Controls.Add(this.quanlylophoc);
            this.Controls.Add(this.chuongtrinhhoc);
            this.Controls.Add(this.thongbaosinhvien);
            this.Controls.Add(this.thongbaogiangvien);
            this.Controls.Add(this.Pn_Menu);
            this.Controls.Add(this.Pn_tcc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Pn_tcc.ResumeLayout(false);
            this.Pn_tcc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_minus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_thoat)).EndInit();
            this.Pn_Menu.ResumeLayout(false);
            this.Pn_Menu.PerformLayout();
            this.Flop_QL.ResumeLayout(false);
            this.Flop_QL.PerformLayout();
            this.Flop_TB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptb_add)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel Pn_tcc;
		private System.Windows.Forms.Label Lb_title;
		private System.Windows.Forms.Panel Pn_Menu;
		private System.Windows.Forms.PictureBox ptb_add;
		private System.Windows.Forms.Label Lb_Hello;
		private System.Windows.Forms.Button btn_Quanly;
        private System.Windows.Forms.Button btn_thongbao;
        private System.Windows.Forms.Button btn_cth;
		private System.Windows.Forms.Panel Pn_Main;
        private System.Windows.Forms.PictureBox ptb_minus;
        private System.Windows.Forms.PictureBox ptb_thoat;
        private System.Windows.Forms.FlowLayoutPanel Flop_TB;
        private System.Windows.Forms.Timer MenuTransition_QL;
        private System.Windows.Forms.Timer MenuTransition_TB;
        private System.Windows.Forms.FlowLayoutPanel Flop_QL;
        private System.Windows.Forms.Button btn_qllh;
        private System.Windows.Forms.Button btn_qlmh;
        private System.Windows.Forms.Button btn_tbsv;
        private System.Windows.Forms.Button btn_tbgv;
        private System.Windows.Forms.Button btn_qlgv;
        private System.Windows.Forms.Button btn_qlsv;
        private Thongbaogiangvien thongbaogiangvien;
        private Thongbaosinhvien thongbaosinhvien;
        private Chuongtrinhhoc chuongtrinhhoc;
        private Quanlylophoc quanlylophoc;
        private Quanlymonhoc quanlymonhoc;
        private Quanlygiangvien quanlygiangvien;
        private Quanlysinhvien quanlysinhvien;
        private Quanly quanly;
    }
}