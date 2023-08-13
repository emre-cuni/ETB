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
        public FormDetails(string _name,string _surname, string _email, string _birthday, string _phone, string _addres, string creditCard,string _photoPath , bool _gender)
        {
            InitializeComponent();
        }

        StringBuilder name = new StringBuilder();
        StringBuilder surname = new StringBuilder();
        StringBuilder email = new StringBuilder();
        StringBuilder birthday = new StringBuilder();
        StringBuilder phone = new StringBuilder();
        StringBuilder address = new StringBuilder();
        StringBuilder creditCard = new StringBuilder();
        StringBuilder photoPath = new StringBuilder();
        bool gender;

        private void FormDetails_Load(object sender, EventArgs e)
        {

        }

        private void FormDetails_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ex.message: " + ex.Message + " stacktrace: " + ex.StackTrace, "Form Details Exit Error");
            }
        }
    }
}
