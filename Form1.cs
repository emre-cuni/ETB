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


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace, "Login Error");
            }
        }
    }
}
