using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATTC
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClientsForm clientsForm = new ClientsForm();
            clientsForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ContactsForm cForm = new ContactsForm();
            cForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TariffsForm tForm = new TariffsForm();
            tForm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
