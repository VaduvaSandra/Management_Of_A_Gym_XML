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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            this.Hide();
            frm.ShowDialog();
            this.Close();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Creăm un obiect User și îi populăm proprietățile cu datele introduse în Textbox-uri
            User user = new User();
            user.Nume = TxtUsername.Text;
            user.Parola = txtPassword.Text;
            user.Oras = TxtOras.Text;

            // Declaram serializerul aici
            XmlSerializer serializer = new XmlSerializer(typeof(Users), new XmlRootAttribute("Users"));

            // Încărcăm datele existente din fișierul XML (dacă există) și adăugăm noul utilizator la lista existentă de utilizatori.
            // Dacă fișierul nu există, creăm o instanță nouă a clasei Users și adăugăm noul utilizator la lista sa de utilizatori.
            Users users;
            if (File.Exists(@"C:\Users\vaduv\Desktop\Facultate\Facultate an 4\TTTvMM\GymXML\GymXML\userData.xml"))
            {
                using (FileStream fileStream = new FileStream(@"C:\Users\vaduv\Desktop\Facultate\Facultate an 4\TTTvMM\GymXML\GymXML\userData.xml", FileMode.Open))
                {
                    users = (Users)serializer.Deserialize(fileStream);
                }
            }
            else
            {
                users = new Users();
                users.UserList = new List<User>();
            }

            users.UserList.Add(user);

            // Salvăm lista actualizată de utilizatori în fișierul XML.
            using (FileStream fileStream = new FileStream(@"C:\Users\vaduv\Desktop\Facultate\Facultate an 4\TTTvMM\GymXML\GymXML\userData.xml", FileMode.Create))
            {
                serializer.Serialize(fileStream, users);
            }

            // Goliți Textbox-urile și afișați un mesaj de confirmare utilizatorului că datele au fost salvate cu succes.
            TxtUsername.Text = "";
            txtPassword.Text = "";
            TxtOras.Text = "";
            MessageBox.Show("Datele au fost salvate cu succes!");

        }
        
    }
}
