using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace GymXML
{
    public partial class Produse : Form
    {
        private BindingSource bindingSource = new BindingSource();
        List<Produs> listaProduse = new List<Produs>();
        public Produse()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("A apărut o eroare la încărcarea imaginii: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Nu s-a selectat nicio imagine.");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (bindingSource.DataSource == null)
            {
                bindingSource.DataSource = new List<Produs>();
            }
            // Creăm un nou produs
            Produs produs = new Produs
            {
                Nume = txtNume.Text
            };

            if (pictureBox1.Image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    pictureBox1.Image.Save(ms, ImageFormat.Jpeg);
                    produs.Imagine = ms.ToArray();
                }
            }

            // Adăugăm produsul în lista de produse
            List<Produs> products = bindingSource.DataSource as List<Produs>;
            products.Add(produs);

            // Serializăm lista de produse într-un fișier XML
            XmlSerializer serializer = new XmlSerializer(typeof(List<Produs>));
            using (FileStream fs = new FileStream(@"C:\Users\vaduv\Desktop\Facultate\Facultate an 4\TTTvMM\GymXML\GymXML\produse.xml", FileMode.Create))
            {
                serializer.Serialize(fs, products);
            }

            // Actualizăm BindingSource
            bindingSource.ResetBindings(false);
            DGV.DataSource = bindingSource;

            // Resetați TextBox-urile și PictureBox-ul
            txtNume.Text = "";
            pictureBox1.Image = null;
        }

        private void LoadData()
        {
            // Deserializăm fișierul XML într-o listă de produse
            XmlSerializer serializer = new XmlSerializer(typeof(List<Produs>));
            using (FileStream fs = new FileStream(@"C:\Users\vaduv\Desktop\Facultate\Facultate an 4\TTTvMM\GymXML\GymXML\produse.xml", FileMode.Open))
            {
                List<Produs> products = (List<Produs>)serializer.Deserialize(fs);

                // Actualizăm BindingSource cu lista de produse
                bindingSource.DataSource = products;
            }

            // Actualizăm DataGridView
            DGV.DataSource = bindingSource;
        }

        private void DGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }

        private void Produse_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnOrd_Click(object sender, EventArgs e)
        {
            List<Produs> products = bindingSource.DataSource as List<Produs>;
            if (products != null)
            {
                products.Sort((p1, p2) => p1.Nume.CompareTo(p2.Nume));
                bindingSource.ResetBindings(false);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Obțineți rândul selectat din datagridview
            DataGridViewRow selectedRow = DGV.SelectedRows[0];

            // Obțineți produsul corespunzător din bindingSource
            Produs selectedProduct = selectedRow.DataBoundItem as Produs;

            // Eliminați produsul din lista de produse
            List<Produs> products = bindingSource.DataSource as List<Produs>;
            products.Remove(selectedProduct);

            // Rescrieți fișierul XML cu lista actualizată de produse
            XmlSerializer serializer = new XmlSerializer(typeof(List<Produs>));
            using (FileStream fs = new FileStream(@"C:\Users\vaduv\Desktop\Facultate\Facultate an 4\TTTvMM\GymXML\GymXML\produse.xml", FileMode.Create))
            {
                serializer.Serialize(fs, products);
            }

            // Actualizați datagridview pentru a reflecta modificările
            bindingSource.ResetBindings(false);
        }
    }
}
