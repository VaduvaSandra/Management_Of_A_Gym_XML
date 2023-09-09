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
using System.Xml.Serialization;

namespace GymXML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register frm = new Register();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void btnConectare_Click(object sender, EventArgs e)
        {
            // Declaram serializerul aici
            XmlSerializer serializer = new XmlSerializer(typeof(Users), new XmlRootAttribute("Users"));

            // Încărcăm datele din fișierul XML într-un obiect Users
            Users users;
            if (File.Exists(@"C:\Users\vaduv\Desktop\Facultate\Facultate an 4\TTTvMM\GymXML\GymXML\userData.xml"))
            {
                using (FileStream fileStream = new FileStream(@"C:\Users\vaduv\Desktop\Facultate\Facultate an 4\TTTvMM\GymXML\GymXML\userData.xml", FileMode.Open))
                {
                    users = (Users)serializer.Deserialize(fileStream);
                }

                // Verificăm dacă utilizatorul și parola se află în lista de utilizatori din fișierul XML
                User user = users.UserList.Find(u => u.Nume == TxtUsername.Text && u.Parola == txtPassword.Text);
                if (user != null)
                {
                    // Dacă utilizatorul există, trecem la fereastra următoare
                    this.Hide();
                    Main frm = new Main();
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    // Dacă utilizatorul nu există, afișăm un mesaj de eroare
                    MessageBox.Show("Utilizator sau parolă incorecte. Te rog încearcă din nou.");
                }
            }
            else
            {
                // Dacă fișierul nu există, afișăm un mesaj de eroare
                MessageBox.Show("Nu există utilizatori înregistrati. Te rog creează un cont.");
            }
        }
    }
}
