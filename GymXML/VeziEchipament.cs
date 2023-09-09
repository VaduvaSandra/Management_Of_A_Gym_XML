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
    public partial class VeziEchipament : Form
    {
        public VeziEchipament()
        {
            InitializeComponent();
        }

        private DataTable CitesteEchipamenteDinXml(string numeFisier)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Nume");
            dt.Columns.Add("Descriere");
            dt.Columns.Add("Grupa");

            try
            {
                if (File.Exists(numeFisier))
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(numeFisier);

                    XmlNodeList echipamente = document.GetElementsByTagName("Echipament");

                    foreach (XmlNode echipament in echipamente)
                    {
                        string nume = echipament.SelectSingleNode("Nume").InnerText;
                        string descriere = echipament.SelectSingleNode("Descriere").InnerText;
                        string grupa = echipament.SelectSingleNode("Grupa").InnerText;

                        DataRow row = dt.NewRow();
                        row["Nume"] = nume;
                        row["Descriere"] = descriere;
                        row["Grupa"] = grupa;
                        dt.Rows.Add(row);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"A aparut o eroare la citirea datelor: {ex.Message}");
            }

            return dt;
        }

        private void VeziEchipament_Load(object sender, EventArgs e)
        {
            DataTable dt = CitesteEchipamenteDinXml(@"C:\Users\vaduv\Desktop\Facultate\Facultate an 4\TTTvMM\GymXML\GymXML\echipamente.xml");
            DGV.DataSource = dt;
            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

         
         
    }
}
