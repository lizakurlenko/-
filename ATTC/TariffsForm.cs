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
    public partial class TariffsForm : Form
    {
        private OleDbConnection connection;
        private int currentClientId;

        public TariffsForm()
        {
            InitializeComponent();
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\student\\source\\repos\\ATTC\\ATC.accdb");
            LoadTariffs();
        }

        private void LoadTariffs()
        {
            connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Тарифы", connection);
            DataTable tariffsTable = new DataTable();
            adapter.Fill(tariffsTable);
            dataGridView1.DataSource = tariffsTable;
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
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentClientId != 0)
            {
                string query = "UPDATE Тарифы SET Тариф = @Tariff, АбонентскаяПлата = @Abonent WHERE Код = @ID";
                OleDbCommand cmd = new OleDbCommand(query, connection);

                cmd.Parameters.AddWithValue("@Tariff", textBox1.Text);
                cmd.Parameters.AddWithValue("@Abonent", textBox2.Text);
                cmd.Parameters.AddWithValue("@ID", currentClientId);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                LoadTariffs();
                ClearFields();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Тарифы (Тариф, АбонентскаяПлата) VALUES (@Tariff, @Abonent)";
            OleDbCommand cmd = new OleDbCommand(query, connection);

            cmd.Parameters.AddWithValue("@Tariff", textBox1.Text);
            cmd.Parameters.AddWithValue("@Abonent", textBox2.Text);


            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            LoadTariffs();
            ClearFields();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedRows[0].Index;
                int clientId = Convert.ToInt32(dataGridView1.Rows[selectedRowIndex].Cells["Код"].Value);

                string query = "DELETE FROM Тарифы WHERE Код = @ID";
                OleDbCommand cmd = new OleDbCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID", clientId);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                LoadTariffs();
                ClearFields();
            }
        }
        private void ClearFields()
        {
            textBox1.Clear();
            textBox2.Clear();
            currentClientId = 0;
        }
    }
}