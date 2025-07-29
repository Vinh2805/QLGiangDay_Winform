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
    public partial class FormSplash_AfterLogin : Form
    {
        private string _username;
        private string _taikhoanid;
        public FormSplash_AfterLogin(string mataikhoan, string tendangnhap)
        {
            InitializeComponent();
            _username = tendangnhap;
            _taikhoanid = mataikhoan;
        }
        protected async override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible)
            {
                labelProgress.Text = "Updating installation...";
                progressBar.Value = 5;
                await Task.Delay(1000);
                labelProgress.Text = "Loading avatars...";
                progressBar.Value = 25;
                await Task.Delay(1000);
                labelProgress.Text = "Fetching teaching data...";
                progressBar.Value = 50;
                await Task.Delay(1000);
                labelProgress.Text = "Initializing scene...";
                progressBar.Value = 75;
                await Task.Delay(1000);
                labelProgress.Text = "Success!";
                progressBar.Value = 100;
                await Task.Delay(1000);
                DialogResult = DialogResult.OK;
                FormMain formMain = new FormMain(_taikhoanid, _username);
                formMain.Show();
                this.Hide();
            }
        }
    }
}
