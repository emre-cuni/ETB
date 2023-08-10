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

        public void SqlGetCustomer(string command)
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter(new SqlCommand(command, conn));
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet);
                sqlDataAdapter.Dispose();
                sqlDataAdapter = null;
            }
            catch (Exception ex)
            {
                sqlDataAdapter.Dispose();
                sqlDataAdapter = null;
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now, "SQL Get Customer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
