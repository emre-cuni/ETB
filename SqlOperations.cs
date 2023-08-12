using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace etb
{
    internal class SqlOperations
    {
        private string connString = "Server=.;Database=etbCustomer;User Id=Cuni;Password=123456;";
        SqlConnection conn = null;
        SqlCommand cmd;
        public DataSet dataSet = new DataSet();
        SqlDataAdapter sqlDataAdapter;
        public Dictionary<string,string> customer = new Dictionary<string,string>();
        

        public bool SqlConn() // veritabanı bağlantısını açan metot
        {
            try
            {
                conn = new SqlConnection(connectionString: connString);
                conn.Open();
                return true; // bağlantı başarıyla açılırsa true değerini döndürür
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now, "SQL Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // bir hata oluşursa false değerini döndürür
            }
        }

        public void GetCustomer(string query)
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter(new SqlCommand(query, conn));
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                sqlDataAdapter.Dispose();
                sqlDataAdapter = null;
                conn.Close();
            }
            catch (Exception ex)
            {
                sqlDataAdapter.Dispose();
                sqlDataAdapter = null;
                conn.Close();
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now, "SQL Get Customer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GetEmailAndPassword(string query)
        {
            SqlDataReader reader = null;
            try
            {
                //sql bağlantısının olup olmadığını kontrol et
                cmd = new SqlCommand(query, conn);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                    customer.Add(reader.GetString(3), reader.GetString(4));
                    //customer.Append(reader.GetString(3) + "-" + reader.GetString(4));

                cmd.Dispose();
                cmd = null;
                reader.Close();
                reader = null;
                conn.Close();
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                cmd = null;
                reader.Close();
                conn.Close();
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now, "SQL Read Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public bool WriteCustomer(string query)
        {
            try
            {
                cmd = new SqlCommand(query,conn);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                cmd = null;
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                cmd.Dispose();
                cmd = null;
                conn.Close();
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now, "SQL Write Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
