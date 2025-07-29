using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_GiangDay
{
	internal class SQL_QLGiangDay
	{
		private SqlConnection sqlConnect = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Code\\C#\\C# - Winform\\QL_GiangDay\\Quanlygiangday.mdf\";Integrated Security=True");
		public SqlConnection getSqlConnect()
		{
			return sqlConnect;
		}
		public void KetNoiCSDL()
		{
			if (sqlConnect.State != ConnectionState.Open)
				sqlConnect.Open();
		}
		public void DongKetNoiCSDL()
		{
			if (sqlConnect.State != ConnectionState.Closed)
				sqlConnect.Close();
		}
		public DataTable DocBang(string sql, SqlParameter[] parameters = null)
		{
			DataTable dtBang = new DataTable();
			KetNoiCSDL();
			using (SqlCommand cmd = new SqlCommand(sql, sqlConnect))
			{
				if (parameters != null)
				{
					cmd.Parameters.AddRange(parameters);
				}

				using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
				{
					adapter.Fill(dtBang);
				}
			}
			DongKetNoiCSDL();
			return dtBang;
		}
		public void CapNhatDuLieu(string sql, SqlParameter[] parameters = null)
		{
			using (SqlCommand sqlcommand = new SqlCommand(sql, sqlConnect))
			{
				if (parameters != null)
				{
					sqlcommand.Parameters.AddRange(parameters);
				}
				KetNoiCSDL();
				sqlcommand.ExecuteNonQuery();
				DongKetNoiCSDL();
			}
		}
        public int CapNhatDuLieuVaTraVeSoDong(string query, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Code\\C#\\C# - Winform\\QL_GiangDay\\Quanlygiangday.mdf\";Integrated Security=True"))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }

                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public object ThucThiScalar(string query, SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"D:\\Code\\C#\\C# - Winform\\QL_GiangDay\\Quanlygiangday.mdf\";Integrated Security=True"))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                conn.Open();
                return cmd.ExecuteScalar();
            }
        }

    }
}
