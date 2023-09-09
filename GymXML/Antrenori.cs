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
using System.Xml;

namespace GymXML
{
    public partial class Antrenori : Form
    {
        public Antrenori()
        {
            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtNume.Clear();
            txtPrenume.Clear();
            cmbCategorie.Text = "";
            cmbPerioada.Text = "";
        }

        private void btnAntrenori_Click(object sender, EventArgs e)
        {
            VeziAntrenori va = new VeziAntrenori();
            va.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Creăm o instanță a clasei XmlDocument
            XmlDocument doc = new XmlDocument();

            // Verificăm dacă fișierul Antrenor.xml există deja
            if (File.Exists(@"C:\Users\vaduv\Desktop\Facultate\Facultate an 4\TTTvMM\GymXML\GymXML\antrenor.xml"))
            {
                // Încărcăm fișierul existent în instanța XmlDocument
                doc.Load(@"C:\Users\vaduv\Desktop\Facultate\Facultate an 4\TTTvMM\GymXML\GymXML\antrenor.xml");
            }

            // Creăm un nod "Antrenor" și adăugăm valorile introduse în interfață
            XmlNode antrenorNode = doc.CreateElement("Antrenor");

            XmlNode numeNode = doc.CreateElement("Nume");
            numeNode.InnerText = txtNume.Text;
            antrenorNode.AppendChild(numeNode);

            XmlNode prenumeNode = doc.CreateElement("Prenume");
            prenumeNode.InnerText = txtPrenume.Text;
            antrenorNode.AppendChild(prenumeNode);

            XmlNode categorieNode = doc.CreateElement("Categorie");
            categorieNode.InnerText = cmbCategorie.SelectedItem.ToString();
            antrenorNode.AppendChild(categorieNode);

            XmlNode perioadaNode = doc.CreateElement("Perioada");
            perioadaNode.InnerText = cmbPerioada.SelectedItem.ToString();
            antrenorNode.AppendChild(perioadaNode);

            // Adăugăm nodul "Antrenor" la nodul radacina "Antrenori" și salvăm fișierul
            doc.DocumentElement.AppendChild(antrenorNode);
            doc.Save(@"C:\Users\vaduv\Desktop\Facultate\Facultate an 4\TTTvMM\GymXML\GymXML\antrenor.xml");

            // Afisam un mesaj de confirmare
            MessageBox.Show("Datele au fost salvate cu succes în fișierul Antrenor.xml.");
        }
    }
}
