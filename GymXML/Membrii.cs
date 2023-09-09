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
    public partial class Membrii : Form
    {
        public Membrii()
        {
            InitializeComponent();
        }

        private void btnNou_Click(object sender, EventArgs e)
        {
            txtNume.Clear();
            txtPrenume.Clear();
            txtTelefon.Clear();

            cmbTip.Text = "";
            cmbValabilitate.Text = "";

            dateTimePicker1.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Verificam daca este selectat un element
            if (listView1.SelectedItems.Count > 0)
            {
                //Obtinem elementul selectat
                ListViewItem item = listView1.SelectedItems[0];

                //Stergem elementul din JSON
                listView1.Items.Remove(item);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Verificam dacă este selectat un element
            if (listView1.SelectedItems.Count > 0)
            {
                // Obținem elementul selectat
                ListViewItem item = listView1.SelectedItems[0];

                // Obținem datele curente ale elementului
                string nume = item.SubItems[0].Text;
                string prenume = item.SubItems[1].Text;
                string telefon = item.SubItems[2].Text;
                string tipAbonament = item.SubItems[3].Text;
                string valabilitateAbonament = item.SubItems[4].Text;
                string dataInscrierii = item.SubItems[5].Text;

                // Actualizam datele elementului selectat
                nume = txtNume.Text;
                prenume = txtPrenume.Text;
                telefon = txtTelefon.Text;
                tipAbonament = cmbTip.Text;
                valabilitateAbonament = cmbValabilitate.Text;
                dataInscrierii = dateTimePicker1.Value.ToShortDateString();

                // Înlocuim elementul selectat cu elementul actualizat
                listView1.Items.Remove(item);
                ListViewItem newItem = new ListViewItem(new string[] { nume, prenume, telefon, tipAbonament, valabilitateAbonament, dataInscrierii });
                listView1.Items.Add(newItem);
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            //Stergem toate elementele din ListView
            listView1.Items.Clear();
        }

        private void txtTelefon_TextChanged(object sender, EventArgs e)
        {
            if (txtTelefon.TextLength < 10 || txtTelefon.TextLength > 10)
            {
                errorProvider1.SetError(txtTelefon, "Numarul de telefon trebuie sa contina exact 10 cifre.");
            }
            else
            {
                errorProvider1.SetError(txtTelefon, "");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Creăm un obiect ListViewItem și îi populăm proprietățile cu datele introduse în TextBox-uri și ComboBox-uri
            ListViewItem item = new ListViewItem(txtNume.Text);
            item.SubItems.Add(txtPrenume.Text);
            item.SubItems.Add(txtTelefon.Text);
            item.SubItems.Add(cmbTip.SelectedItem.ToString());
            item.SubItems.Add(cmbValabilitate.SelectedItem.ToString());
            item.SubItems.Add(dateTimePicker1.Value.ToShortDateString());

            // Adăugăm elementul în ListView
            listView1.Items.Add(item);

            // Goliți TextBox-urile și ComboBox-urile
            txtNume.Clear();
            txtPrenume.Clear();
            txtTelefon.Clear();
            cmbTip.Text = "";
            cmbValabilitate.Text = "";
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            Membri membri = new Membri();

            // Incarcam membrii existenti din fisierul XML
            XmlSerializer serializer = new XmlSerializer(typeof(Membri));
            using (FileStream fileStream = new FileStream(@"C:\Users\vaduv\Desktop\Facultate\Facultate an 4\TTTvMM\GymXML\GymXML\Membri.xml", FileMode.OpenOrCreate))
            {
                membri = (Membri)serializer.Deserialize(fileStream);
            }

            // Adaugam membrii noi din ListView
            foreach (ListViewItem item in listView1.Items)
            {
                Membru membru = new Membru()
                {
                    Nume = item.SubItems[0].Text,
                    Prenume = item.SubItems[1].Text,
                    Telefon = item.SubItems[2].Text,
                    Tip = item.SubItems[3].Text,
                    Valabilitate = item.SubItems[4].Text,
                    DataInscriere = DateTime.Parse(item.SubItems[5].Text)
                };
                membri.AdaugaMembru(membru);
            }

            // Salvam membrii in fisierul XML
            using (FileStream fileStream = new FileStream(@"C:\Users\vaduv\Desktop\Facultate\Facultate an 4\TTTvMM\GymXML\GymXML\Membri.xml", FileMode.Create))
            {
                serializer.Serialize(fileStream, membri);
            }
            MessageBox.Show("Datele au fost salvate cu succes!");
        }

        private void btnVezi_Click(object sender, EventArgs e)
        {
            // Stergere elemente existente din ListView
            listView1.Items.Clear();

            // Incarcare date din fisierul XML in lista de membrii
            XmlSerializer serializer = new XmlSerializer(typeof(Membri));
            Membri membri;
            using (FileStream fileStream = new FileStream(@"C:\Users\vaduv\Desktop\Facultate\Facultate an 4\TTTvMM\GymXML\GymXML\Membri.xml", FileMode.Open))
            {
                membri = (Membri)serializer.Deserialize(fileStream);
            }

            // Adaugare membri in ListView
            foreach (var membru in membri.MembriList)
            {
                ListViewItem item = new ListViewItem(membru.Nume);
                item.SubItems.Add(membru.Prenume);
                item.SubItems.Add(membru.Telefon);
                item.SubItems.Add(membru.Tip);
                item.SubItems.Add(membru.Valabilitate);
                item.SubItems.Add(membru.DataInscriere.ToShortDateString());
                listView1.Items.Add(item);
            }
        }
    }
}
