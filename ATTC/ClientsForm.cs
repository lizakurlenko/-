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
    public partial class ClientsForm : Form
    {
        private OleDbConnection connection;
        private int currentClientId;

        public ClientsForm()
        {
            InitializeComponent();
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Student\\source\\repos\\ATTC\\ATC.accdb");
            LoadClients();
        }

        private void LoadClients()
        {
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Клиенты", connection);
            DataTable clientsTable = new DataTable();
            adapter.Fill(clientsTable);
            dataGridView1.DataSource = clientsTable;
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
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                currentClientId = Convert.ToInt32(row.Cells[0].Value);
                textBox1.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentClientId != 0)
            {
                string query = "UPDATE Клиенты SET ФИО = @Name, Адрес = @Address, Паспорт = @Passport WHERE Код = @ID";
                OleDbCommand cmd = new OleDbCommand(query, connection);

                cmd.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd.Parameters.AddWithValue("@Address", textBox2.Text);
                cmd.Parameters.AddWithValue("@Passport", textBox3.Text);
                cmd.Parameters.AddWithValue("@ID", currentClientId);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                LoadClients();
                ClearFields();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Клиенты (ФИО, Адрес, Паспорт) VALUES (@Name, @Address, @Passport)";
            OleDbCommand cmd = new OleDbCommand(query, connection);

            cmd.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd.Parameters.AddWithValue("@Address", textBox2.Text);
            cmd.Parameters.AddWithValue("@Passport", textBox3.Text);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            LoadClients();
            ClearFields();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int clientId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["Код"].Value);

                string query = "DELETE FROM Клиенты WHERE Код = @ID";
                OleDbCommand cmd = new OleDbCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID", clientId);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                LoadClients();
                ClearFields();
            }

        }

        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            currentClientId = 0;
        }
    }
}

