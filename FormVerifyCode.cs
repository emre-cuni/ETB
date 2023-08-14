using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace etb
{
    public partial class FormVerifyCode : Form
    {
        public FormVerifyCode(int _verifyCode, StringBuilder _query)
        {
            InitializeComponent();
            verifyCode = _verifyCode;
            query = _query;
        }

        int verifyCode = 0, checkVerifyCode = -1;
        StringBuilder query = new StringBuilder();
        SqlOperations sqlOperations = new SqlOperations();


        private void buttonVerify_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBoxVerifyCode.Text != string.Empty) // textbox'ın boş olup olmamasını kontrol eder
                {
                    checkVerifyCode = int.Parse(textBoxVerifyCode.Text); // kullanıcın girdiği doğrulama kodu alınır
                    if (verifyCode == checkVerifyCode) // gönderilen kod ile girilen kod karşılaştırılır
                    {
                        if (sqlOperations.SqlConn()) // sql bağlantısı açılır
                        {
                            if (sqlOperations.AddOrUpdate(query.ToString())) // kayıt eklenir
                                MessageBox.Show("Kayıt Başarıyla Eklendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                                MessageBox.Show("İşlem Sırasında Bir Hata Oluştu.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                            MessageBox.Show("Bağlantı Kurulamadı.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Kodlar Eşleşmiyor!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace, "Verify Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
