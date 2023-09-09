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

namespace GymXML
{
    public partial class AdaugaAbonament : Form
    {
        public AdaugaAbonament()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Creează un obiect Abonament cu datele introduse de utilizator.
            Abonament abonament = new Abonament
            {
                Nume = txtNume.Text,
                TipAbonament = cmbTip.SelectedItem.ToString(),
                Valabilitate = cmbValabilitate.SelectedItem.ToString(),
                Pret = cmbPret.SelectedItem.ToString()
            };

            // Initializează un obiect Abonamente și încarcă datele din fișierul XML.
            Abonamente abonamente = new Abonamente();
            abonamente.IncarcaDateDinXML(@"C:\Users\vaduv\Desktop\Facultate\Facultate an 4\TTTvMM\GymXML\GymXML\Abonamente.xml");

            // Adaugă noul abonament în obiectul Abonamente.
            abonamente.AdaugaAbonament(abonament);

            // Salvează lista actualizată în fișierul XML.
            abonamente.SalveazaInFisier(@"C:\Users\vaduv\Desktop\Facultate\Facultate an 4\TTTvMM\GymXML\GymXML\Abonamente.xml");

            // Curăță ListView-ul și adaugă din nou toate abonamentele.
            listView1.Items.Clear();
            foreach (Abonament a in abonamente)
            {
                ListViewItem item = new ListViewItem(new string[] { a.Nume, a.TipAbonament, a.Valabilitate, a.Pret });
                listView1.Items.Add(item);
            }
        }

        private void AdaugaAbonament_Load(object sender, EventArgs e)
        {
            // Initializează un obiect Abonamente și încarcă datele din fișierul XML.
            Abonamente abonamente = new Abonamente();
            abonamente.IncarcaDateDinXML(@"C:\Users\vaduv\Desktop\Facultate\Facultate an 4\TTTvMM\GymXML\GymXML\Abonamente.xml");

            // Afiseaza toate abonamentele in Listview.
            foreach (Abonament a in abonamente)
            {
                ListViewItem item = new ListViewItem(new string[] { a.Nume, a.TipAbonament, a.Valabilitate, a.Pret });
                listView1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtNume.Clear();
            cmbPret.Text = "";
            cmbTip.Text = "";
            cmbValabilitate.Text = "";
        }
    }
}
