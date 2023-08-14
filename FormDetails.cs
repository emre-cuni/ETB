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
    public partial class FormDetails : Form
    {
        public FormDetails(string _name, string _surname, string _email, string _birthday, string _phone, string _address, string _creditCard, string _photoPath, bool _gender, bool _authorization)
        {
            InitializeComponent();
            name.Append(_name);
            surname.Append(_surname);
            email.Append(_email);
            birthday.Append(_birthday.Substring(0, _birthday.IndexOf(" ")));
            phone.Append(_phone);
            address.Append(_address);
            creditCard.Append(_creditCard);
            photoPath.Append(_photoPath);
            gender = _gender;
            authorization = _authorization;
        }

        StringBuilder name = new StringBuilder();
        StringBuilder surname = new StringBuilder();
        StringBuilder email = new StringBuilder();
        StringBuilder birthday = new StringBuilder();
        StringBuilder phone = new StringBuilder();
        StringBuilder address = new StringBuilder();
        StringBuilder creditCard = new StringBuilder();
        StringBuilder photoPath = new StringBuilder();
        StringBuilder query = new StringBuilder();
        bool gender, authorization, changed, first = true;
        SqlOperations sqlOperations = new SqlOperations();

        private void FormDetails_Load(object sender, EventArgs e)
        {
            try
            {
                // müşteri bilgileri ekrana bastırılır
                labelName.Text = "Adı:   " + name;
                labelSurname.Text = "Soyadı:   " + surname;
                labelEmail.Text = "E-Mail:   " + email;
                labelBirthday.Text = "Doğum Tarihi:   " + birthday;
                labelAddress.Text = "Adres:   " + address;
                labelPhone.Text = "Telefon:   " + phone;
                labelCreditCard.Text = "Kredi Kartı:   " + creditCard;
                if (gender)
                    labelGender.Text = "Cinsiyet:   Erkek";
                else
                    labelGender.Text = "Cinsiyet:   Kadın";
                if (authorization)
                    radioButtonAdmin.Checked = true;
                else
                    radioButtonCustomer.Checked = true;
                pictureBoxPhoto.Image = Image.FromFile(Application.StartupPath + "\\" + photoPath);

                // adres çok uzun olursa adresinin tamamını adres label'ının üzerine geldiğinde tooltip olarak gösterir
                ToolTip toolTip = new ToolTip();
                toolTip.SetToolTip(labelAddress, labelAddress.Text.Substring(labelAddress.Text.IndexOf(" ")));
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace, "Form Details Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!first) // form ilk açılışı değilse değişiklik değeri true'ya çevrilir
                    changed = true;
                else // formun ilk açılışıysa first değeri false yapılır bundan sonra yetki değişikliği çıkışta kaydedilmesi için sorulur
                    first = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace, "Radio Button Changed Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormDetails_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (changed)
                {
                    // yapılan değişikliğin kaydedilip kaydedilmemesini kullanıcıya sorulur
                    DialogResult dialogResult = MessageBox.Show("Değişiklikleri Kaydetmek İster Misiniz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question); 
                    if(dialogResult == DialogResult.Yes) // kullanıcı evet derse değişiklik veri tabanında güncellenir
                    {
                        // güncelleme sorgusu hazırlanır
                        query.Append("UPDATE Table_Customer SET [authorization] = ");
                        if (radioButtonAdmin.Checked)
                            query.Append($"{1} WHERE email = '{email}';");
                        else if(radioButtonCustomer.Checked)
                            query.Append($"{0} WHERE email = '{email}';");

                        if (sqlOperations.SqlConn()) // veri tabanı bağlantısı açılır
                        {
                            if (sqlOperations.AddOrUpdate(query.ToString())) // kayıt güncellenir
                            {
                                MessageBox.Show("Değişiklikler Başarıyla Kaydedildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Close(); // kayıt güncellendikten sonra form kapatılır
                            }
                            else // kayıt güncelleme sırasında bir hata olursa hata mesajı ekrana bastırılır ve formun kapanmaması için sona atlanır
                            {
                                MessageBox.Show("İşlem Sırasında Bir Hatayla Karşılaştık.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                goto finish;
                            }
                        }
                        else
                            MessageBox.Show("Bağlantı Kurulamadı.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                Close();
            finish:;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace, "Form Details Exit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
