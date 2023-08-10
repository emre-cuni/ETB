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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        SqlOperations sqlOperations = new SqlOperations();
        StringBuilder email = new StringBuilder();
        StringBuilder password = new StringBuilder();


        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxEmail.Text != string.Empty && textBoxPassword.Text != string.Empty)
                {
                    email.Append(textBoxEmail.Text.ToLower());
                    password.Append(textBoxPassword.Text);

                    if (sqlOperations.SqlConn())
                    {
                        for (int i = 0; i < sqlOperations.dataSet.Tables[0].Rows.Count; i++)
                        {
                            if (sqlOperations.dataSet.Tables[0].Rows[i]["email"] == email)
                            {
                                MessageBox.Show("kullanıcı bulundu");
                            }
                        }
                    }
                    else
                        MessageBox.Show("bağlantı kurulamadı");
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
                if (tabControl1.SelectedIndex == 0)
                    tabControl1.Size = new Size(348, 302);
                else
                    tabControl1.Size = new Size(348, 536);
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace, "Tab Change Error");
            }
        }
    }
}
