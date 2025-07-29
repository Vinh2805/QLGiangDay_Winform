namespace QL_GiangDay
{
    partial class Quanlymonhoc
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtGridView_QVMH = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtHocKi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSotinchi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_excel = new System.Windows.Forms.Button();
            this.txtTenMh = new System.Windows.Forms.TextBox();
            this.btn_xoa = new System.Windows.Forms.Button();
            this.btn_capnhat = new System.Windows.Forms.Button();
            this.btn_them = new System.Windows.Forms.Button();
            this.txtHotenGV = new System.Windows.Forms.TextBox();
            this.txtMaGV = new System.Windows.Forms.TextBox();
            this.txtMaMH = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridView_QVMH)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtGridView_QVMH);
            this.panel1.Location = new System.Drawing.Point(31, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(994, 368);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.85714F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 42);
            this.label1.TabIndex = 5;
            this.label1.Text = "Quản lý môn học";
            // 
            // dtGridView_QVMH
            // 
            this.dtGridView_QVMH.AllowUserToAddRows = false;
            this.dtGridView_QVMH.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(11)))), ((int)(((byte)(97)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGridView_QVMH.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dtGridView_QVMH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridView_QVMH.EnableHeadersVisualStyles = false;
            this.dtGridView_QVMH.Location = new System.Drawing.Point(20, 83);
            this.dtGridView_QVMH.Margin = new System.Windows.Forms.Padding(6);
            this.dtGridView_QVMH.Name = "dtGridView_QVMH";
            this.dtGridView_QVMH.ReadOnly = true;
            this.dtGridView_QVMH.RowHeadersVisible = false;
            this.dtGridView_QVMH.RowHeadersWidth = 72;
            this.dtGridView_QVMH.Size = new System.Drawing.Size(955, 267);
            this.dtGridView_QVMH.TabIndex = 4;
            this.dtGridView_QVMH.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridView_QVMH_CellContentClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtHocKi);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtSotinchi);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btn_excel);
            this.panel2.Controls.Add(this.txtTenMh);
            this.panel2.Controls.Add(this.btn_xoa);
            this.panel2.Controls.Add(this.btn_capnhat);
            this.panel2.Controls.Add(this.btn_them);
            this.panel2.Controls.Add(this.txtHotenGV);
            this.panel2.Controls.Add(this.txtMaGV);
            this.panel2.Controls.Add(this.txtMaMH);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(31, 446);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(994, 351);
            this.panel2.TabIndex = 1;
            // 
            // txtHocKi
            // 
            this.txtHocKi.Location = new System.Drawing.Point(657, 167);
            this.txtHocKi.Name = "txtHocKi";
            this.txtHocKi.Size = new System.Drawing.Size(194, 29);
            this.txtHocKi.TabIndex = 26;
            this.txtHocKi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.check_kitu);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(463, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 27);
            this.label5.TabIndex = 25;
            this.label5.Text = "Học kì:";
            // 
            // txtSotinchi
            // 
            this.txtSotinchi.Location = new System.Drawing.Point(196, 167);
            this.txtSotinchi.Name = "txtSotinchi";
            this.txtSotinchi.Size = new System.Drawing.Size(194, 29);
            this.txtSotinchi.TabIndex = 24;
            this.txtSotinchi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.check_kitu);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 27);
            this.label4.TabIndex = 23;
            this.label4.Text = "Số tín chỉ:";
            // 
            // btn_excel
            // 
            this.btn_excel.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_excel.Location = new System.Drawing.Point(845, 295);
            this.btn_excel.Name = "btn_excel";
            this.btn_excel.Size = new System.Drawing.Size(130, 44);
            this.btn_excel.TabIndex = 22;
            this.btn_excel.Text = "Excel";
            this.btn_excel.UseVisualStyleBackColor = true;
            this.btn_excel.Click += new System.EventHandler(this.btn_excel_Click);
            // 
            // txtTenMh
            // 
            this.txtTenMh.Location = new System.Drawing.Point(196, 96);
            this.txtTenMh.Name = "txtTenMh";
            this.txtTenMh.Size = new System.Drawing.Size(194, 29);
            this.txtTenMh.TabIndex = 20;
            // 
            // btn_xoa
            // 
            this.btn_xoa.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoa.Location = new System.Drawing.Point(657, 295);
            this.btn_xoa.Name = "btn_xoa";
            this.btn_xoa.Size = new System.Drawing.Size(130, 44);
            this.btn_xoa.TabIndex = 18;
            this.btn_xoa.Text = "Xóa";
            this.btn_xoa.UseVisualStyleBackColor = true;
            this.btn_xoa.Click += new System.EventHandler(this.btn_xoa_Click);
            // 
            // btn_capnhat
            // 
            this.btn_capnhat.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_capnhat.Location = new System.Drawing.Point(455, 295);
            this.btn_capnhat.Name = "btn_capnhat";
            this.btn_capnhat.Size = new System.Drawing.Size(130, 44);
            this.btn_capnhat.TabIndex = 17;
            this.btn_capnhat.Text = "Cập nhật";
            this.btn_capnhat.UseVisualStyleBackColor = true;
            this.btn_capnhat.Click += new System.EventHandler(this.btn_capnhat_Click);
            // 
            // btn_them
            // 
            this.btn_them.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_them.Location = new System.Drawing.Point(260, 295);
            this.btn_them.Name = "btn_them";
            this.btn_them.Size = new System.Drawing.Size(130, 44);
            this.btn_them.TabIndex = 16;
            this.btn_them.Text = "Thêm";
            this.btn_them.UseVisualStyleBackColor = true;
            this.btn_them.Click += new System.EventHandler(this.btn_them_Click);
            // 
            // txtHotenGV
            // 
            this.txtHotenGV.Location = new System.Drawing.Point(657, 96);
            this.txtHotenGV.Name = "txtHotenGV";
            this.txtHotenGV.Size = new System.Drawing.Size(194, 29);
            this.txtHotenGV.TabIndex = 12;
            this.txtHotenGV.TextChanged += new System.EventHandler(this.txtHotenGV_TextChanged);
            this.txtHotenGV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.check_kituso);
            // 
            // txtMaGV
            // 
            this.txtMaGV.Location = new System.Drawing.Point(657, 30);
            this.txtMaGV.Name = "txtMaGV";
            this.txtMaGV.Size = new System.Drawing.Size(194, 29);
            this.txtMaGV.TabIndex = 11;
            this.txtMaGV.TextChanged += new System.EventHandler(this.txtMaGV_TextChanged);
            // 
            // txtMaMH
            // 
            this.txtMaMH.Location = new System.Drawing.Point(196, 30);
            this.txtMaMH.Name = "txtMaMH";
            this.txtMaMH.Size = new System.Drawing.Size(194, 29);
            this.txtMaMH.TabIndex = 8;
            this.txtMaMH.TextChanged += new System.EventHandler(this.txtMaMH_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(463, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 27);
            this.label7.TabIndex = 5;
            this.label7.Text = "Họ và tên:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(463, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(154, 27);
            this.label6.TabIndex = 4;
            this.label6.Text = "Mã giảng viên:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 27);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tên môn học:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 9.857143F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 27);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã môn học:";
            // 
            // Quanlymonhoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Quanlymonhoc";
            this.Size = new System.Drawing.Size(1066, 819);
            this.Load += new System.EventHandler(this.Quanlymonhoc_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridView_QVMH)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtGridView_QVMH;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtMaMH;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHotenGV;
        private System.Windows.Forms.TextBox txtMaGV;
        private System.Windows.Forms.Button btn_xoa;
        private System.Windows.Forms.Button btn_capnhat;
        private System.Windows.Forms.Button btn_them;
        private System.Windows.Forms.TextBox txtTenMh;
        private System.Windows.Forms.Button btn_excel;
        private System.Windows.Forms.TextBox txtHocKi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSotinchi;
        private System.Windows.Forms.Label label4;
    }
}
