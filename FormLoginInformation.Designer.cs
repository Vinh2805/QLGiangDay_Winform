
namespace QL_GiangDay
{
    partial class FormLoginInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoginInformation));
            this.Pn_tcc = new System.Windows.Forms.Panel();
            this.ptb_minus = new System.Windows.Forms.PictureBox();
            this.ptb_thoat = new System.Windows.Forms.PictureBox();
            this.Lb_title = new System.Windows.Forms.Label();
            this.Pn_Menu = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Pn_Main = new System.Windows.Forms.Panel();
            this.Lb_Hello = new System.Windows.Forms.Label();
            this.ptb_add = new System.Windows.Forms.PictureBox();
            this.MenuTransition_QL = new System.Windows.Forms.Timer(this.components);
            this.MenuTransition_TB = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMatk = new System.Windows.Forms.TextBox();
            this.btnlogout = new System.Windows.Forms.Button();
            this.btnUpdatetk = new System.Windows.Forms.Button();
            this.btnXoatk = new System.Windows.Forms.Button();
            this.txtTendn = new System.Windows.Forms.TextBox();
            this.ptb_img = new System.Windows.Forms.PictureBox();
            this.Pn_tcc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_minus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_thoat)).BeginInit();
            this.Pn_Menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_add)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_img)).BeginInit();
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
            this.Pn_tcc.Size = new System.Drawing.Size(1445, 48);
            this.Pn_tcc.TabIndex = 0;
            // 
            // ptb_minus
            // 
            this.ptb_minus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptb_minus.Image = global::QL_GiangDay.Properties.Resources.minus;
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
            this.ptb_thoat.Image = global::QL_GiangDay.Properties.Resources.exit;
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
            this.Lb_title.Location = new System.Drawing.Point(14, 4);
            this.Lb_title.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Lb_title.Name = "Lb_title";
            this.Lb_title.Size = new System.Drawing.Size(430, 39);
            this.Lb_title.TabIndex = 1;
            this.Lb_title.Text = "Teaching Management System";
            // 
            // Pn_Menu
            // 
            this.Pn_Menu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.Pn_Menu.Controls.Add(this.pictureBox1);
            this.Pn_Menu.Controls.Add(this.label3);
            this.Pn_Menu.Controls.Add(this.Pn_Main);
            this.Pn_Menu.Controls.Add(this.Lb_Hello);
            this.Pn_Menu.Controls.Add(this.ptb_add);
            this.Pn_Menu.Dock = System.Windows.Forms.DockStyle.Left;
            this.Pn_Menu.Location = new System.Drawing.Point(0, 48);
            this.Pn_Menu.Margin = new System.Windows.Forms.Padding(6);
            this.Pn_Menu.Name = "Pn_Menu";
            this.Pn_Menu.Size = new System.Drawing.Size(381, 834);
            this.Pn_Menu.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox1.Image = global::QL_GiangDay.Properties.Resources.QLGD1;
            this.pictureBox1.Location = new System.Drawing.Point(32, 122);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(327, 210);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(110, 368);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 42);
            this.label3.TabIndex = 3;
            this.label3.Text = "Xin chào!";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Pn_Main
            // 
            this.Pn_Main.Location = new System.Drawing.Point(384, 0);
            this.Pn_Main.Margin = new System.Windows.Forms.Padding(6);
            this.Pn_Main.Name = "Pn_Main";
            this.Pn_Main.Size = new System.Drawing.Size(1061, 833);
            this.Pn_Main.TabIndex = 2;
            // 
            // Lb_Hello
            // 
            this.Lb_Hello.AutoSize = true;
            this.Lb_Hello.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lb_Hello.ForeColor = System.Drawing.Color.White;
            this.Lb_Hello.Location = new System.Drawing.Point(94, 686);
            this.Lb_Hello.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Lb_Hello.Name = "Lb_Hello";
            this.Lb_Hello.Size = new System.Drawing.Size(219, 33);
            this.Lb_Hello.TabIndex = 1;
            this.Lb_Hello.Text = "Quay lại trang chủ";
            this.Lb_Hello.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ptb_add
            // 
            this.ptb_add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptb_add.Image = global::QL_GiangDay.Properties.Resources.back;
            this.ptb_add.Location = new System.Drawing.Point(32, 669);
            this.ptb_add.Margin = new System.Windows.Forms.Padding(6);
            this.ptb_add.Name = "ptb_add";
            this.ptb_add.Size = new System.Drawing.Size(50, 50);
            this.ptb_add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_add.TabIndex = 0;
            this.ptb_add.TabStop = false;
            this.ptb_add.Click += new System.EventHandler(this.ptb_add_Click);
            // 
            // MenuTransition_QL
            // 
            this.MenuTransition_QL.Interval = 10;
            // 
            // MenuTransition_TB
            // 
            this.MenuTransition_TB.Interval = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(654, 404);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 42);
            this.label1.TabIndex = 3;
            this.label1.Text = "Mã tài khoản:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(626, 512);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 42);
            this.label2.TabIndex = 4;
            this.label2.Text = "Tên đăng nhập:";
            // 
            // txtMatk
            // 
            this.txtMatk.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatk.Location = new System.Drawing.Point(914, 404);
            this.txtMatk.Multiline = true;
            this.txtMatk.Name = "txtMatk";
            this.txtMatk.Size = new System.Drawing.Size(301, 42);
            this.txtMatk.TabIndex = 5;
            // 
            // btnlogout
            // 
            this.btnlogout.BackColor = System.Drawing.Color.Gray;
            this.btnlogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogout.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnlogout.Location = new System.Drawing.Point(496, 717);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(213, 58);
            this.btnlogout.TabIndex = 7;
            this.btnlogout.Text = "Đăng xuất";
            this.btnlogout.UseVisualStyleBackColor = false;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // btnUpdatetk
            // 
            this.btnUpdatetk.BackColor = System.Drawing.Color.Gray;
            this.btnUpdatetk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdatetk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatetk.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatetk.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUpdatetk.Location = new System.Drawing.Point(819, 717);
            this.btnUpdatetk.Name = "btnUpdatetk";
            this.btnUpdatetk.Size = new System.Drawing.Size(245, 58);
            this.btnUpdatetk.TabIndex = 8;
            this.btnUpdatetk.Text = "Đổi mật khẩu";
            this.btnUpdatetk.UseVisualStyleBackColor = false;
            this.btnUpdatetk.Click += new System.EventHandler(this.btnUpdatetk_Click);
            // 
            // btnXoatk
            // 
            this.btnXoatk.BackColor = System.Drawing.Color.Gray;
            this.btnXoatk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoatk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoatk.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoatk.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnXoatk.Location = new System.Drawing.Point(1154, 717);
            this.btnXoatk.Name = "btnXoatk";
            this.btnXoatk.Size = new System.Drawing.Size(245, 58);
            this.btnXoatk.TabIndex = 9;
            this.btnXoatk.Text = "Xóa tài khoản";
            this.btnXoatk.UseVisualStyleBackColor = false;
            this.btnXoatk.Click += new System.EventHandler(this.btnXoatk_Click);
            // 
            // txtTendn
            // 
            this.txtTendn.Font = new System.Drawing.Font("Times New Roman", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTendn.Location = new System.Drawing.Point(914, 512);
            this.txtTendn.Multiline = true;
            this.txtTendn.Name = "txtTendn";
            this.txtTendn.Size = new System.Drawing.Size(301, 42);
            this.txtTendn.TabIndex = 10;
            // 
            // ptb_img
            // 
            this.ptb_img.Cursor = System.Windows.Forms.Cursors.Default;
            this.ptb_img.Image = global::QL_GiangDay.Properties.Resources.admin;
            this.ptb_img.Location = new System.Drawing.Point(798, 88);
            this.ptb_img.Margin = new System.Windows.Forms.Padding(6);
            this.ptb_img.Name = "ptb_img";
            this.ptb_img.Size = new System.Drawing.Size(249, 251);
            this.ptb_img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptb_img.TabIndex = 2;
            this.ptb_img.TabStop = false;
            // 
            // FormLoginInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 882);
            this.Controls.Add(this.txtTendn);
            this.Controls.Add(this.btnXoatk);
            this.Controls.Add(this.btnUpdatetk);
            this.Controls.Add(this.btnlogout);
            this.Controls.Add(this.txtMatk);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ptb_img);
            this.Controls.Add(this.Pn_Menu);
            this.Controls.Add(this.Pn_tcc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormLoginInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.FormLoginInformation_Load);
            this.Pn_tcc.ResumeLayout(false);
            this.Pn_tcc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_minus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_thoat)).EndInit();
            this.Pn_Menu.ResumeLayout(false);
            this.Pn_Menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_add)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel Pn_tcc;
        private System.Windows.Forms.Label Lb_title;
        private System.Windows.Forms.Panel Pn_Menu;
        private System.Windows.Forms.PictureBox ptb_add;
        private System.Windows.Forms.Label Lb_Hello;
        private System.Windows.Forms.Panel Pn_Main;
        private System.Windows.Forms.PictureBox ptb_minus;
        private System.Windows.Forms.PictureBox ptb_thoat;
        private System.Windows.Forms.Timer MenuTransition_QL;
        private System.Windows.Forms.Timer MenuTransition_TB;
        private System.Windows.Forms.PictureBox ptb_img;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMatk;
        private System.Windows.Forms.Button btnlogout;
        private System.Windows.Forms.Button btnUpdatetk;
        private System.Windows.Forms.Button btnXoatk;
        private System.Windows.Forms.TextBox txtTendn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}