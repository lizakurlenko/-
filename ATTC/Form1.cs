using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATTC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtLogin.Text;
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Поля не должны быть пустыми!");
                return;
            }

            if (AuthenticateUser(username, password))
            {
                MessageBox.Show("Логин успешен!");

                MenuForm menu = new MenuForm();
                menu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }

        }

        private bool AuthenticateUser(string username, string password)
        {
            string[] lines = File.ReadAllLines("users.txt");

            foreach (var line in lines)
            {
                var parts = line.Split(':');
                if (parts.Length == 2)
                {
                    var fileUsername = parts[0];
                    var filePassword = parts[1];

                    if (fileUsername == username && filePassword == password)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
