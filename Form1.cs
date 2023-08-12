using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
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
        DateTime birthday;
        StringBuilder fileExtension = new StringBuilder();
        StringBuilder photoPath = new StringBuilder();
        bool photoControl, gender;
        string temp;


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxEmail.Text != string.Empty && textBoxPassword.Text != string.Empty) // girilen değerlerin boş olmadığı kontrol edilir
                {
                    email.Append(textBoxEmail.Text.ToLower());
                    password.Append(textBoxPassword.Text);

                    if (sqlOperations.SqlConn()) // sql bağlantısı açılır başarılıyla açılırsa "SqlConn" metodu true değer döndürür
                    {
                        query.Append("SELECT * FROM Table_Customer");
                        sqlOperations.GetEmailAndPassword(query.ToString());

                        if (sqlOperations.customer.ContainsKey(email.ToString())) // girilen email'in veritabanında kayıtlı olup olmadığı kontrol edilir
                        {
                            if (sqlOperations.customer[email.ToString()] == password.ToString()) // girilen mail ile girilen parolanın eşleşip eşleşmediği kontrol edilir
                            {
                                MessageBox.Show($"Hoşgeldiniz {email}", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else
                                MessageBox.Show("Bilgilerini Kontrol Ediniz", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Kullanıcı Bulunamadı.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        sqlOperations.customer.Clear();

                    }
                    else
                        MessageBox.Show("Bağlantı Kurulamadı.", "DİKKAT", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    query.Clear();
                    email.Clear();
                    password.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace, "Login Error");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0) // giriş yap seçilirse tab control'ün boyutu küçültülür
                    tabControl1.Size = new Size(348, 302);
                else // kayıt ol seçilirse tab control'ün boyutu büyültülür
                    tabControl1.Size = new Size(348, 565);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace, "Tab Change Error");
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxName.Text != string.Empty && textBoxSurname.Text != string.Empty && textBoxRegisterMail.Text != string.Empty && textBoxRegisterPassword.Text != string.Empty && textBoxAddress.Text != string.Empty && maskedTextBoxBirthDay.Text != string.Empty
                    && maskedTextBoxCreditCard.Text != string.Empty && maskedTextBoxPhone.Text != string.Empty && (radioButtonFemale.Checked || radioButtonMale.Checked))
                {
                    name.Append(textBoxName.Text);
                    surname.Append(textBoxSurname.Text);
                    registerEmail.Append(textBoxRegisterMail.Text);
                    registerPassword.Append(textBoxRegisterPassword.Text);
                    address.Append(textBoxAddress.Text);
                    birthday = DateTime.ParseExact(maskedTextBoxBirthDay.Text,"dd.MM.yyyy", CultureInfo.InvariantCulture);
                    creditCard.Append(maskedTextBoxCreditCard.Text);
                    temp = maskedTextBoxPhone.Text;
                    temp = temp.Substring(1, 3) + temp.Substring(6, 3) + temp.Substring(10);
                    phone.Append(temp);

                    query.Append("INSERT INTO Table_Customer (name, surname, email, password, birthday, [authorization], gender, address, phone, creditCard, photoPath) " +
                        $"VALUES('{name}', '{surname}', '{registerEmail}' , '{registerPassword}', '{maskedTextBoxBirthDay.Text}', 0, ");
                    if (radioButtonFemale.Checked)
                        query.Append(0);
                    else
                        query.Append(1);
                    query.Append($", '{address}' , '{phone}', '{creditCard}', '{photoPath}');");

                    if (sqlOperations.SqlConn())
                    {
                        if (sqlOperations.WriteCustomer(query.ToString()))
                            MessageBox.Show("Kayıt Başarıyla Eklendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show("İşlem Sırasında Bir Hata Oluştu.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace, "Register Error");
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
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace, "Choose Photo Error");
            }
        }



        //private void FormLogin_Load(object sender, EventArgs e)
        //{

        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string photoPath;
        //        sqlOperations.SqlConn();
        //        sqlOperations.SqlGetCustomer("Select * From Table_Customer");
        //        for (int i = 0; i < sqlOperations.dataSet.Tables[0].Rows.Count; i++)
        //        {
        //            photoPath = sqlOperations.dataSet.Tables[0].Rows[i]["photoPath"].ToString();
        //            pictureBox1.Image = Image.FromFile(Application.StartupPath + "\\" + photoPath);
        //            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace, "Tab Change Error");
        //    }
        //}
    }
}
