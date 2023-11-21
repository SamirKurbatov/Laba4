using Laba4.UserClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text) ||
                string.IsNullOrWhiteSpace(textBoxName.Text) ||
                string.IsNullOrWhiteSpace(textBoxSubject.Text) ||
                string.IsNullOrWhiteSpace(textBoxBody.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            string smtp = "smtp.mail.ru";

            StringPair frominfo = new StringPair("sanms2@mail.ru", "Курбатов Самир Рушанович");

            string password = "mAqPkL8kvLvbcug4qJwB";

            StringPair toInfo = new StringPair(textBoxEmail.Text, textBoxName.Text);

            string subject = textBoxSubject.Text;
            string body = $"{DateTime.Now}\n" +
                $"{Dns.GetHostName()}\n" +
                $"{Dns.GetHostAddresses(Dns.GetHostName()).First()}" +
                $"{textBoxBody.Text}";

            var info = new InfoEmailSending(smtp, frominfo, password, toInfo, subject, body);

            var sendingEmail = new SendingEmail(info);

            sendingEmail.Send();
            MessageBox.Show("Письмо отправлено!");

            foreach (TextBox textBox in Controls.OfType<TextBox>())
            {
                textBox.Text = "";
            }
        }
    }
}
