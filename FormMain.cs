using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;

namespace etb
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        Panel panel;
        Label label;
        PictureBox pictureBox;
        SqlOperations sqlOperations = new SqlOperations();
        StringBuilder query = new StringBuilder();
        StringBuilder customerName = new StringBuilder();
        StringBuilder customerSurname = new StringBuilder();
        StringBuilder customerMail = new StringBuilder();
        StringBuilder customerPhone = new StringBuilder();
        StringBuilder customerPhotoPath = new StringBuilder();
        StringBuilder customerAddress = new StringBuilder();
        StringBuilder customerBirthday = new StringBuilder();
        StringBuilder customerCreditCard = new StringBuilder();
        bool gender, authorization;
        int id = 0, index = 0;
        DataSet customers;
        FormDetails details;

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                query.Append("SELECT * FROM Table_Customer");
                if (sqlOperations.SqlConn())
                {
                    sqlOperations.GetCustomer(query.ToString());
                    customers = sqlOperations.dataSet;

                    for (int i = 0; i < sqlOperations.dataSet.Tables[0].Rows.Count; i++)
                    {
                        id = int.Parse(customers.Tables[0].Rows[i]["id"].ToString());
                        customerName.Clear();
                        customerMail.Clear();
                        customerPhone.Clear();
                        customerPhotoPath.Clear();
                        customerName.Append(customers.Tables[0].Rows[i]["name"].ToString() + " " + customers.Tables[0].Rows[i]["surname"].ToString());
                        customerMail.Append(customers.Tables[0].Rows[i]["email"].ToString());
                        customerPhone.Append(customers.Tables[0].Rows[i]["phone"].ToString());
                        customerPhotoPath.Append(Application.StartupPath + "\\" + customers.Tables[0].Rows[i]["photoPath"]);

                        if (customerName.ToString() == "admin admin") // müşteriler listesinde admin görüntülenmez
                            continue;

                        // müşterinin listeleneceği panel oluşturulur
                        panel = new Panel
                        {
                            Location = new Point(5, 5), // panel'in konumu belirlenir
                            Size = new Size(362, 163), // panel'in boyutu ayarlanır
                            Tag = i, // panel'e indeks ataması yapılır
                            Name = $"panel{id}", // panel'in adı düzenlenir
                            BackColor = SystemColors.ActiveCaption // panel'in arka plan rengi ayarlanır

                        };
                        panel.Click += CustomerDetails_Click;

                        // müşterinin adının, mail adresinin, telefon numarasının tutulacağı label'lar oluşturulur
                        label = new Label
                        {
                            Name = $"labelName{id}", // label'ın adı düzenlenir
                            Location = new Point(130, 9), // label'ın konumu belirlenir
                            Text = customerName.ToString(), // label'ın metni düzenlenir
                            AutoSize = true, // label'ın boyutu ayarlanır
                            Tag = i, // label'a indeks ataması yapılır                            
                            BackColor = Color.FromArgb(128, 255, 255) // label'ın arka plan rengi ayarlanır
                        };
                        label.Click += CustomerDetails_Click;
                        panel.Controls.Add(label); // oluşturulan label panel'e eklenir

                        label = new Label
                        {
                            Name = $"labelMail{id}", // label'ın adı düzenlenir
                            Location = new Point(130, 47), // label'ın konumu belirlenir
                            AutoSize = true, // label'ın boyutu ayarlanır
                            Tag = i, // label'a indeks ataması yapılır
                            Text = customerMail.ToString(), // label'ın metni düzenlenir
                            BackColor = Color.FromArgb(128, 255, 255) // label'ın arka plan rengi ayarlanır
                        };
                        label.Click += CustomerDetails_Click;
                        panel.Controls.Add(label); // oluşturulan label panel'e eklenir

                        label = new Label
                        {
                            Name = $"labelPhone{i}", // label'ın adı düzenlenir
                            Location = new Point(130, 89), // label'ın konumu belirlenir
                            AutoSize = true, // label'ın boyutu ayarlanır
                            Tag = i, // label'a indeks ataması yapılır
                            Text = customerPhone.ToString(), // label'ın metni düzenlenir
                            BackColor = Color.FromArgb(128, 255, 255) // label'ın arka plan rengi ayarlanır
                        };
                        label.Click += CustomerDetails_Click;
                        panel.Controls.Add(label); // oluşturulan label panel'e eklenir

                        pictureBox = new PictureBox
                        {
                            Name = $"pictureBox{id}", // picturebox'ın adı düzenlenir
                            Location = new Point(4, 9), // picturebox'ın konumu belirlenir
                            Size = new Size(108, 145), // picturebox'ın boyutu ayarlanır
                            Tag = i, // picturebox'a indeks ataması yapılır
                            Image = Image.FromFile(customerPhotoPath.ToString()), //  picturebox'a fotoğraf atanır
                            SizeMode = PictureBoxSizeMode.StretchImage, // fotoğraf'ı picturebox'a sıkıştırır
                            BorderStyle = BorderStyle.Fixed3D // picturebox'a çerçeve ekler
                        };
                        pictureBox.Click += CustomerDetails_Click;
                        panel.Controls.Add(pictureBox); // oluşturulan picturebox panel'e eklenir
                        flowLayoutPanel1.Controls.Add(panel); // oluşturulan panel flowlayoutpanel'e eklenir
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace, "Form Main Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CustomerDetails_Click(object sender, EventArgs e)
        {
            try
            {
                // tıklanan kullanıcın index değeri alınır
                if (sender.GetType() == typeof(Panel))
                {
                    panel = (Panel)sender;
                    index = int.Parse(panel.Tag.ToString());
                }
                else if (sender.GetType() == typeof(PictureBox))
                {
                    pictureBox = (PictureBox)sender;
                    index = int.Parse(pictureBox.Tag.ToString());
                }
                else if (sender.GetType() == typeof(Label))
                {
                    label = (Label)sender;
                    index = int.Parse(label.Tag.ToString());
                }

                customerAddress.Clear();
                customerBirthday.Clear();
                customerCreditCard.Clear();
                customerMail.Clear();
                customerName.Clear();
                customerPhone.Clear();
                customerPhotoPath.Clear();
                customerSurname.Clear();

                // kullanıcının bütün bilgileri alınır
                customerAddress.Append(customers.Tables[0].Rows[index]["address"].ToString());
                customerBirthday.Append(customers.Tables[0].Rows[index]["birthday"].ToString());
                customerCreditCard.Append(customers.Tables[0].Rows[index]["creditCard"].ToString());
                customerMail.Append(customers.Tables[0].Rows[index]["email"].ToString());
                customerName.Append(customers.Tables[0].Rows[index]["name"].ToString());
                customerPhone.Append(customers.Tables[0].Rows[index]["phone"].ToString());
                customerPhotoPath.Append(customers.Tables[0].Rows[index]["photoPath"].ToString());
                customerSurname.Append(customers.Tables[0].Rows[index]["surname"].ToString());
                gender = Convert.ToBoolean(customers.Tables[0].Rows[index]["gender"]);
                authorization = Convert.ToBoolean(customers.Tables[0].Rows[index]["authorization"]);

                Hide(); // mevcut form gizlenir
                // detaylar formuna kullanıcının bilgileri gönderilir
                details = new FormDetails(customerName.ToString(), customerSurname.ToString(), customerMail.ToString(), customerBirthday.ToString(), customerPhone.ToString(), customerAddress.ToString(), customerCreditCard.ToString(), customerPhotoPath.ToString(), gender, authorization);
                details.ShowDialog(); // detaylar formu açılır
                Show(); // detaylar formundan çıkıldıktan sonra main form yeniden açılır
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace, "Customer Details Click Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
