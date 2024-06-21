using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATTC
{
    public partial class ContactsForm : Form
    {
        private OleDbConnection connection;

        public ContactsForm()
        {
            InitializeComponent();
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\student\\source\\repos\\ATTC\\ATC.accdb");
            LoadContracts();
        }
        private void LoadContracts()
        {
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Договор", connection);
            DataTable contractsTable = new DataTable();
            adapter.Fill(contractsTable);
            dataGridView1.DataSource = contractsTable;
            connection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MenuForm mForm = new MenuForm();
            mForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddContractsForm addContractForm = new AddContractsForm();
            addContractForm.ShowDialog();

            // После закрытия формы добавления, обновляем данные на основной форме
            LoadContracts();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
