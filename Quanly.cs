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
    public partial class Quanly : UserControl
    {
        private SQL_QLGiangDay qlgd;
        public Quanly()
        {
            InitializeComponent();
            qlgd = new SQL_QLGiangDay();
            displayTE();
            displayAE();
            displayIE();
        }
        public void RefreshData()
        {
            if (InvokeRequired)
            {
                Invoke((MethodInvoker)RefreshData);
                return;
            }

            displayTE();
            displayAE();
            displayIE();
        }

        public void displayTE()
        {
            if (qlgd.getSqlConnect().State != ConnectionState.Open)
            {
                try
                {
                    qlgd.getSqlConnect().Open();

                    string selectData = "SELECT (\r\n\tSELECT COUNT(*)\r\n\tFROM SinhVien\r\n) + (\r\n\tSELECT COUNT(*)\r\n\tFROM GiangVien\r\n)\r\n";

                    using (SqlCommand cmd = new SqlCommand(selectData, qlgd.getSqlConnect()))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            dashboard_TE.Text = count.ToString();
                        }
                        reader.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex, "Error Message"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    qlgd.getSqlConnect().Close();
                }
            }
        }

        public void displayAE()
        {
            if (qlgd.getSqlConnect().State != ConnectionState.Open)
            {
                try
                {
                    qlgd.getSqlConnect().Open();

                    string selectData = "SELECT COUNT(*) FROM SinhVien";

                    using (SqlCommand cmd = new SqlCommand(selectData, qlgd.getSqlConnect()))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            dashboard_AE.Text = count.ToString();
                        }
                        reader.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex, "Error Message"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    qlgd.getSqlConnect().Close();
                }
            }
        }

        public void displayIE()
        {
            if (qlgd.getSqlConnect().State != ConnectionState.Open)
            {
                try
                {
                    qlgd.getSqlConnect().Open();

                    string selectData = "SELECT COUNT(*)\r\n\tFROM GiangVien";

                    using (SqlCommand cmd = new SqlCommand(selectData, qlgd.getSqlConnect()))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            int count = Convert.ToInt32(reader[0]);
                            dashboard_IE.Text = count.ToString();
                        }
                        reader.Close();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex, "Error Message"
                        , MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    qlgd.getSqlConnect().Close();
                }
            }
        }
    }
}
