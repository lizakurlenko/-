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
    public partial class AddContractsForm : Form
    {
        private OleDbConnection connection;
        public AddContractsForm()
        {
            InitializeComponent();
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\student\\source\\repos\\ATC\\ATC\\ATC.accdb");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Договор (ДатаДоговора, Клиент, Тариф, НомерТелефона, АбонентскаяПлата, Баланс, Задолженость)" +
                         "VALUES (@ContractDate, @Client, @Tariff, @PhoneNumber, @SubscriptionFee, @Balance, @Debt)";

            OleDbCommand cmd = new OleDbCommand(query, connection);

            cmd.Parameters.AddWithValue("@ContractDate", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@Client", textBox1.Text);
            cmd.Parameters.AddWithValue("@Tariff", textBox2.Text);
            cmd.Parameters.AddWithValue("@PhoneNumber", textBox3.Text);
            cmd.Parameters.AddWithValue("@SubscriptionFee", textBox4.Text);
            cmd.Parameters.AddWithValue("@Balance", textBox6.Text);
            cmd.Parameters.AddWithValue("@Debt", textBox5.Text);

            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Договор успешно добавлен!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления договора: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
