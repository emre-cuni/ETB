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
    public partial class FormResetPassword : Form
    {
        public FormResetPassword(string _email)
        {
            InitializeComponent();
            email.Clear();  
            email.Append(_email);
        }

        StringBuilder email = new StringBuilder();
        StringBuilder password = new StringBuilder();
        StringBuilder query = new StringBuilder();
        SqlOperations sqlOperations = new SqlOperations();
        Encryption encryption = new Encryption();
        byte[] encryptedPassword;

        private void buttonResetPassword_Click(object sender, EventArgs e)
        {
            try
            {   // textbox'ların boş olup olmadığını ve text'lerinin aynı olup olmadığı kontrol edilir
                if (textBoxPassword.Text != string.Empty && textBoxRePassword.Text != string.Empty && textBoxPassword.Text == textBoxRePassword.Text)
                {
                    password.Append(textBoxPassword.Text);

                    // kullanıcın girdiği parola şifrelenir
                    encryptedPassword = encryption.Encrypt(password.ToString());
                    password.Clear();
                    password.Append(Convert.ToBase64String(encryptedPassword));

                    query.Append($"UPDATE Table_Customer SET password = '{password}' WHERE email = '{email}'");
                    if (sqlOperations.SqlConn()) // sql bağlantısı açılır
                    {
                        if (sqlOperations.ResetPassword(query.ToString())) // parola güncellenir
                            MessageBox.Show("Parola Başarıyla Sıfırlandı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("Bir Hata Oluştu.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    password.Clear();
                }
                else
                {
                    MessageBox.Show("Parolalar Aynı Değil.", "DİKKAT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace, "Reset Password Error");
            }
        }
    }
}
