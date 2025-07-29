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
    public partial class FormSplash : Form
    {
        public FormSplash()
        {
            InitializeComponent();
        }

        private void FormSplash_Load(object sender, EventArgs e)
        {
            timer_Splash.Start();
        }
        private int startpoint = 0;
        private void timer_Splash_Tick(object sender, EventArgs e)
        {
            startpoint += 1;
            Pg_load.Start();
            if (startpoint > 40)
            {
                FormLogin login = new FormLogin();
                Pg_load.Stop();
                timer_Splash.Stop();
                this.Hide();
                login.Show();
            }
        }
    }
}
