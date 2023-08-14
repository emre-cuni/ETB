using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace etb
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        SqlOperations sqlOperations = new SqlOperations();
        StringBuilder email = new StringBuilder();
        StringBuilder password = new StringBuilder();
        StringBuilder query = new StringBuilder();
        StringBuilder name = new StringBuilder();
        StringBuilder surname = new StringBuilder();
        StringBuilder registerEmail = new StringBuilder();
        StringBuilder registerPassword = new StringBuilder();
        StringBuilder address = new StringBuilder();
        StringBuilder phone = new StringBuilder();
        StringBuilder creditCard = new StringBuilder();
        StringBuilder code = new StringBuilder();
        DateTime birthday;
        StringBuilder fileExtension = new StringBuilder();
        StringBuilder photoPath = new StringBuilder();
        bool photoControl;
        string temp;
        FormMain formMain;
        FormResetPassword formResetPassword;
        FormVerifyCode formVerifyCode;
        Encryption encryption = new Encryption();
        byte[] encryptedPassword;
        int verifyCode = 0;

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxEmail.Text != string.Empty && textBoxPassword.Text != string.Empty) // girilen değerlerin boş olmadığı kontrol edilir
                {
                    query.Clear();
                    email.Clear();
                    password.Clear();
                    email.Append(textBoxEmail.Text.ToLower()); // büyük küçük harf karışıklığı olmaması için mail adresinin bütün harfleri küçük harfe çevrilir
                    password.Append(textBoxPassword.Text);
                    sqlOperations.customer.Clear();

                    if (sqlOperations.SqlConn()) // sql bağlantısı açılır başarılıyla açılırsa "SqlConn" metodu true değer döndürür
                    {
                        // bütün kayıtları çekecek sorgu hazırlanır
                        query.Append("SELECT * FROM Table_Customer");
                        sqlOperations.GetEmailAndPassword(query.ToString());

                        if (sqlOperations.customer.ContainsKey(email.ToString())) // girilen email'in veritabanında kayıtlı olup olmadığı kontrol edilir
                        {
                            // kullanıcın girdiği parola şifrelenir
                            encryptedPassword = encryption.Encrypt(password.ToString());
                            if (encryptedPassword == null) // şifreleme esnasında bir hata oluşursa sona atlar
                                goto finish;
                            password.Clear();
                            password.Append(Convert.ToBase64String(encryptedPassword));

                            if (sqlOperations.customer[email.ToString()].Item1 == password.ToString()) // girilen mail ile girilen şifreli parolanın eşleşip eşleşmediği kontrol edilir
                            {
                                if (!sqlOperations.customer[email.ToString()].Item2) // giriş yapmak isteyen kullanıcının yetkisi yoksa kayıtları görüntülemesine izin verilmez
                                {
                                    MessageBox.Show("Kayıtları Görüntülemek İçin Yetkiniz Yok.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    goto finish;
                                }

                                MessageBox.Show($"Hoşgeldiniz {email}", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (email.ToString() == "admin@admin.com" && password.ToString() == "sART4lDsPTTqPB/ZRfKUdg==") // girilen parola 'admin' ise parola sıfırlama ekranına yönlendirir
                                {
                                    formResetPassword = new FormResetPassword(email.ToString());
                                    Hide();
                                    formResetPassword.ShowDialog();
                                }
                                formMain = new FormMain();
                                Hide();
                                formMain.ShowDialog();
                                Show();
                            }
                            else
                                MessageBox.Show("Bilgilerini Kontrol Ediniz", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Kullanıcı Bulunamadı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        finish:
                        sqlOperations.customer.Clear();
                    }
                    else
                        MessageBox.Show("Bağlantı Kurulamadı.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    query.Clear();
                    email.Clear();
                    password.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0) // giriş yap seçilirse tab control'ün boyutu küçültülür
                {
                    Text = "Giriş Yap";
                    tabControl1.Size = new Size(348, 302);
                }
                else // kayıt ol seçilirse tab control'ün boyutu büyültülür
                {
                    Text = "Kayıt Ol";
                    tabControl1.Size = new Size(348, 565); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace, "Tab Change Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxName.Text != string.Empty && textBoxSurname.Text != string.Empty && textBoxRegisterMail.Text != string.Empty && textBoxRegisterPassword.Text != string.Empty && textBoxAddress.Text != string.Empty && maskedTextBoxBirthDay.Text != string.Empty
                    && maskedTextBoxCreditCard.Text != string.Empty && maskedTextBoxPhone.Text != string.Empty && (radioButtonFemale.Checked || radioButtonMale.Checked) && photoControl)
                {
                    // kullanıcıdan müşteri bilgileri alınır
                    photoControl = false;
                    name.Append(textBoxName.Text);
                    surname.Append(textBoxSurname.Text);
                    registerEmail.Append(textBoxRegisterMail.Text);
                    registerPassword.Append(textBoxRegisterPassword.Text);
                    address.Append(textBoxAddress.Text);
                    birthday = DateTime.ParseExact(maskedTextBoxBirthDay.Text, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    creditCard.Append(maskedTextBoxCreditCard.Text);
                    temp = maskedTextBoxPhone.Text;
                    temp = temp.Substring(1, 3) + temp.Substring(6, 3) + temp.Substring(10);
                    phone.Append(temp);

                    // girilen mail adresinin veri tabanında kayıtlı olup olmadığı kontrol edilir var olan mail adresi kayıt edilmeye çalışılıyorsa uyarı pop-up'ı çıkar ve kayıt işlemlerinin yapılması atlanır
                    if (sqlOperations.customer.ContainsKey(registerEmail.ToString()))
                    {
                        MessageBox.Show("Bu Mail Adresi Zaten Kayıtlı.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        goto finish;
                    }

                    //  kullanıcının girdiği parola şifrelenir
                    encryptedPassword = encryption.Encrypt(registerPassword.ToString());
                    if (encryptedPassword == null) // şifreleme esnasında bir hata oluşursa sona atlar
                        goto finish;
                    registerPassword.Clear();
                    registerPassword.Append(Convert.ToBase64String(encryptedPassword));

                    // kayıt ekleme sorgusu hazırlanır
                    query.Append("INSERT INTO Table_Customer (name, surname, email, password, birthday, [authorization], gender, address, phone, creditCard, photoPath) " +
                        $"VALUES('{name}', '{surname}', '{registerEmail}' , '{registerPassword}', '{maskedTextBoxBirthDay.Text}', 0, ");
                    if (radioButtonFemale.Checked)
                        query.Append(0);
                    else
                        query.Append(1);
                    query.Append($", '{address}' , '{phone}', '{creditCard}', '{photoPath}');");

                    try
                    {
                        // kayıt için girilen mail adresine doğrulama kodu gönderilir.
                        MailMessage mailMessage = new MailMessage();
                        SmtpClient smtpClient = new SmtpClient();
                        Random random = new Random();

                        for (int i = 0; i < 6; i++) // doğrulama kodu oluşturulur
                            code.Append(random.Next(10));
                        verifyCode = int.Parse(code.ToString());

                        smtpClient.Credentials = new NetworkCredential("ecom.destek@outlook.com", "0401ecomdestek1102");
                        smtpClient.Port = 587;
                        smtpClient.Host = "smtp-mail.outlook.com";
                        smtpClient.EnableSsl = true;

                        //mail hazırlanır
                        mailMessage.To.Add(registerEmail.ToString());
                        mailMessage.From = new MailAddress("ecom.destek@outlook.com");
                        mailMessage.Subject = "ETB Doğrulama Kodu";
                        mailMessage.Body = $"Kayıt İçin Doğrulama Kodunuz: {verifyCode}\n\nİşlem Tarihi:{DateTime.Now}";
                        smtpClient.Send(mailMessage);

                        MessageBox.Show("Doğrulama Kodu Gönderildi!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception) // mail gönderilirken bir hata oluşursa sona atlar
                    {
                        MessageBox.Show("Doğrulama Kodu Gönderilemedi.","UYARI",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        goto finish;
                    }                    
                    
                    // kod başarıyla gönderildiyse doğrulama ekranı açılır
                    Hide();
                    formVerifyCode = new FormVerifyCode(verifyCode, query);
                    formVerifyCode.ShowDialog();
                    Show();                    
                }
                else
                    MessageBox.Show("Boş Alanları Doldurunuz!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                finish:;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace, "Register Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonChoosePhoto_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxName.Text != string.Empty && textBoxSurname.Text != string.Empty) // dosya adında ad ve soyad kullanılacağı için o değerlerin boş olup olmaması kontrol edilir
                {
                    openFileDialogChoosePhoto.Title = "Resim Seç";
                    openFileDialogChoosePhoto.Filter = "Jpeg Dosyaları(*.jpeg)|*.jpeg|Jpg Dosyaları(*.jpg)|*.jpg|Png Dosyaları(*.png)|*.png";
                    if (openFileDialogChoosePhoto.ShowDialog() == DialogResult.OK) // bir resim seçildiyse
                    {
                        photoPath.Clear();
                        name.Clear();
                        surname.Clear();
                        name.Append(textBoxName.Text);
                        surname.Append(textBoxSurname.Text);
                        fileExtension.Append(openFileDialogChoosePhoto.FileName.Substring(openFileDialogChoosePhoto.FileName.IndexOf("."))); // seçilen dosyanın dosya uzantısı alınır
                        photoPath.Append(Application.StartupPath + "\\photos\\" + name + "_" + surname + fileExtension);
                        var allPhotos = Directory.GetFiles(Application.StartupPath + "\\photos");
                        foreach (var photo in allPhotos)
                        {
                            if (photo == photoPath.ToString())
                            {
                                MessageBox.Show("Dosya Zaten Var.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                photoPath.Clear();
                                goto finish;
                            }
                        }
                        File.Copy(openFileDialogChoosePhoto.FileName, photoPath.ToString()); // seçilen dosya yazılımın kurulu olduğu dizine kopyalanır
                        pictureBox1.Image = Image.FromFile(photoPath.ToString());
                        photoControl = true;
                        photoPath.Clear();
                        photoPath.Append("photos\\" + name + "_" + surname + fileExtension);
                    finish:
                        name.Clear();
                        surname.Clear();
                        fileExtension.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace, "Choose Photo Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            try
            {
                // parola için karakter limiti bilgisi verilir
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(textBoxRegisterPassword, "Parola Maksimum 20 Karakter Olmalıdır!");

                query.Clear();
                if (sqlOperations.SqlConn()) // sql bağlantısı açılır başarılıyla açılırsa "SqlConn" metodu true değer döndürür
                {
                    query.Append("SELECT * FROM Table_Customer"); // bütün kayıtları çekecek sorgu hazırlanır
                    sqlOperations.GetEmailAndPassword(query.ToString()); // bütün kayıtlar çekilir (mail, parola, yetki)
                }
                else
                    MessageBox.Show("Bağlantı Kurulamadı.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                query.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace, "Login Form Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
