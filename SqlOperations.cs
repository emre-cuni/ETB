using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace etb
{
    internal class SqlOperations
    {
        private string connString = "Server=.;Database=etbCustomer;User Id=Cuni;Password=123456;";
        SqlConnection conn = null;
        SqlCommand cmd;
        public DataSet dataSet = new DataSet();
        SqlDataAdapter sqlDataAdapter;


        public bool SqlConn(string connString) // veritabanı bağlantısını açan metot
        {
            try
            {
                conn = new SqlConnection(connectionString: connString);
                conn.Open();
                return true; // bağlantı başarıyla açılırsa true değerini döndürür
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace + " Olay Zamanı: " + DateTime.Now, "SQL Bağlantı Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false; // bir hata oluşursa false değerini döndürür
            }
        }

    }
}
