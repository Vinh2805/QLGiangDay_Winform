
namespace QL_GiangDay
{
    partial class FormSplash
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
            System.Windows.Forms.Label Lb_Title;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSplash));
            this.timer_Splash = new System.Windows.Forms.Timer(this.components);
            this.guna2CircleButton1 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CircleButton2 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.guna2CircleButton3 = new Guna.UI2.WinForms.Guna2CircleButton();
            this.Pg_load = new Guna.UI2.WinForms.Guna2WinProgressIndicator();
            this.ptB_ClassRoom = new System.Windows.Forms.PictureBox();
            Lb_Title = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptB_ClassRoom)).BeginInit();
            this.SuspendLayout();
            // 
            // Lb_Title
            // 
            Lb_Title.AutoSize = true;
            Lb_Title.Font = new System.Drawing.Font("Times New Roman", 20.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            Lb_Title.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            Lb_Title.Location = new System.Drawing.Point(194, 300);
            Lb_Title.Name = "Lb_Title";
            Lb_Title.Size = new System.Drawing.Size(923, 55);
            Lb_Title.TabIndex = 1;
            Lb_Title.Text = "Welcome to the Teaching Management System!";
            // 
            // timer_Splash
            // 
            this.timer_Splash.Tick += new System.EventHandler(this.timer_Splash_Tick);
            // 
            // guna2CircleButton1
            // 
            this.guna2CircleButton1.FillColor = System.Drawing.Color.White;
            this.guna2CircleButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton1.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton1.Location = new System.Drawing.Point(781, -44);
            this.guna2CircleButton1.Name = "guna2CircleButton1";
            this.guna2CircleButton1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton1.Size = new System.Drawing.Size(278, 292);
            this.guna2CircleButton1.TabIndex = 0;
            // 
            // guna2CircleButton2
            // 
            this.guna2CircleButton2.FillColor = System.Drawing.Color.White;
            this.guna2CircleButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton2.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton2.Location = new System.Drawing.Point(45, 365);
            this.guna2CircleButton2.Name = "guna2CircleButton2";
            this.guna2CircleButton2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton2.Size = new System.Drawing.Size(202, 190);
            this.guna2CircleButton2.TabIndex = 0;
            // 
            // guna2CircleButton3
            // 
            this.guna2CircleButton3.FillColor = System.Drawing.Color.White;
            this.guna2CircleButton3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2CircleButton3.ForeColor = System.Drawing.Color.White;
            this.guna2CircleButton3.Location = new System.Drawing.Point(-88, -3);
            this.guna2CircleButton3.Name = "guna2CircleButton3";
            this.guna2CircleButton3.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CircleButton3.Size = new System.Drawing.Size(202, 190);
            this.guna2CircleButton3.TabIndex = 0;
            // 
            // Pg_load
            // 
            this.Pg_load.CircleSize = 1F;
            this.Pg_load.Location = new System.Drawing.Point(404, 410);
            this.Pg_load.Name = "Pg_load";
            this.Pg_load.ProgressColor = System.Drawing.Color.GreenYellow;
            this.Pg_load.Size = new System.Drawing.Size(79, 87);
            this.Pg_load.TabIndex = 2;
            // 
            // ptB_ClassRoom
            // 
            this.ptB_ClassRoom.Image = global::QL_GiangDay.Properties.Resources.classroom;
            this.ptB_ClassRoom.Location = new System.Drawing.Point(334, 24);
            this.ptB_ClassRoom.Name = "ptB_ClassRoom";
            this.ptB_ClassRoom.Size = new System.Drawing.Size(228, 224);
            this.ptB_ClassRoom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptB_ClassRoom.TabIndex = 3;
            this.ptB_ClassRoom.TabStop = false;
            // 
            // FormSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(8)))), ((int)(((byte)(138)))));
            this.ClientSize = new System.Drawing.Size(891, 509);
            this.Controls.Add(this.ptB_ClassRoom);
            this.Controls.Add(this.Pg_load);
            this.Controls.Add(Lb_Title);
            this.Controls.Add(this.guna2CircleButton3);
            this.Controls.Add(this.guna2CircleButton2);
            this.Controls.Add(this.guna2CircleButton1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormSplash";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SplashForm";
            this.Load += new System.EventHandler(this.FormSplash_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ptB_ClassRoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer_Splash;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton1;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton2;
        private Guna.UI2.WinForms.Guna2CircleButton guna2CircleButton3;
        private Guna.UI2.WinForms.Guna2WinProgressIndicator Pg_load;
        private System.Windows.Forms.PictureBox ptB_ClassRoom;
    }
}