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
using System.Xml.Serialization;

namespace GymXML
{
    public partial class Echipament : Form
    {
        List<Echipamente> listaEchipamente = new List<Echipamente>();
        public Echipament()
        {
            InitializeComponent();
            listaEchipamente = new List<Echipamente>();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtNume.Clear();
            txtDescriere.Clear();
            cmbGrupa.Text = "";
        }

        private void btnVezi_Click(object sender, EventArgs e)
        {
            VeziEchipament ve = new VeziEchipament();
            ve.Show();
        }
        private void SalveazaEchipamenteInXml(List<Echipament> listaEchipamente)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Echipament>));
            using (TextWriter writer = new StreamWriter(@"C:\Users\vaduv\Desktop\Facultate\Facultate an 4\TTTvMM\GymXML\GymXML\echipamente.xml"))
            {
                serializer.Serialize(writer, listaEchipamente);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidareDate())
            {
                Echipamente echipament = new Echipamente(txtNume.Text, txtDescriere.Text, cmbGrupa.SelectedItem.ToString());
                listaEchipamente.Add(echipament);
                if (SalveazaEchipamenteInXml(@"C:\Users\vaduv\Desktop\Facultate\Facultate an 4\TTTvMM\GymXML\GymXML\echipamente.xml", listaEchipamente))
                {
                    MessageBox.Show("Datele au fost salvate cu succes!", "Salvare reusita", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("A aparut o eroare la salvarea datelor!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool ValidareDate()
        {
            if (string.IsNullOrWhiteSpace(txtNume.Text))
            {
                MessageBox.Show("Introduceti un nume de echipament valid!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtDescriere.Text))
            {
                MessageBox.Show("Introduceti o descriere valida pentru echipament!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbGrupa.SelectedIndex == -1)
            {
                MessageBox.Show("Selectati o grupa pentru echipament!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private bool SalveazaEchipamenteInXml(string numeFisier, List<Echipamente> lista)
        {
            try
            {
                XmlDocument document = new XmlDocument();

                // Dacă fișierul există deja, încarcă toate echipamentele din fișierul XML în documentul XML
                if (File.Exists(numeFisier))
                {
                    document.Load(numeFisier);
                }
                else
                {
                    // Dacă fișierul nu există, creează un nod radacina pentru documentul XML
                    XmlElement radacina = document.CreateElement("Echipamente");
                    document.AppendChild(radacina);
                }

                // Creează un nou nod pentru noul obiect Echipamente
                XmlElement echipamentElement = document.CreateElement("Echipament");

                // Creează noduri pentru proprietățile obiectului Echipamente și adaugă-le la nodul Echipament
                XmlElement numeElement = document.CreateElement("Nume");
                numeElement.InnerText = txtNume.Text;
                echipamentElement.AppendChild(numeElement);

                XmlElement descriereElement = document.CreateElement("Descriere");
                descriereElement.InnerText = txtDescriere.Text;
                echipamentElement.AppendChild(descriereElement);

                XmlElement grupaElement = document.CreateElement("Grupa");
                grupaElement.InnerText = cmbGrupa.SelectedItem.ToString();
                echipamentElement.AppendChild(grupaElement);

                // Adaugă nodul Echipament la documentul XML
                document.DocumentElement.AppendChild(echipamentElement);

                // Scrie documentul XML în fișierul XML
                using (XmlTextWriter writer = new XmlTextWriter(numeFisier, Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    document.Save(writer);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"A aparut o eroare la salvarea datelor: {ex.Message}");
                return false;
            }
        }
    }
}
