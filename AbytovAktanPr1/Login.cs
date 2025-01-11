using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbytovAktanPr1
{
    public partial class Login : Form
    {
        private string[,] users = { { "admin", "12345" } };

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            if (IsAuthorized(username, password))
            {
                employees main = new employees();
                main.ShowDialog();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsAuthorized(string username, string password)
        {
            for (int i = 0; i < users.GetLength(0); i++)
            {
                if (users[i, 0] == username && users[i, 1] == password)
                    return true;
            }
            return false;
        }
    }
}
