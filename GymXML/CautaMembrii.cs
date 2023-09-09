using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GymXML
{
    public partial class CautaMembrii : Form
    {

        private DataSet ds = new DataSet();
        private DataView dv = new DataView();
        public CautaMembrii()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtNume.Clear();
            cmbTip.Text = "Tip Abonament";

            // Verificarea daca obiectul ds este initializat
            if (ds != null)
            {
                // Stergerea datelor din tabelul din DataSet
                ds.Tables[0].Clear();

                // Re-incarcarea datelor din fisierul XML in DataSet
                ds.ReadXml(@"C:\Users\vaduv\Desktop\Facultate\Facultate an 4\TTTvMM\GymXML\GymXML\Abonamente.xml");

                // Crearea unui nou obiect DataView cu tabelul din DataSet
                dv = new DataView(ds.Tables[0]);

                // Setarea sursei de date a DataGridView la obiectul DataView
                DGV.DataSource = dv;
            }
        }

        private void CautaMembrii_Load(object sender, EventArgs e)
        {
            // Incarcarea datelor din fisierul XML intr-un DataSet
            ds.ReadXml(@"C:\Users\vaduv\Desktop\Facultate\Facultate an 4\TTTvMM\GymXML\GymXML\Abonamente.xml");

            // Setarea sursei de date a obiectului DataView la tabelul din DataSet
            dv.Table = ds.Tables[0];

            // Setarea sursei de date a DataGridView la obiectul DataView
            DGV.DataSource = dv;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Verificarea daca obiectul dv este initializat
            if (dv != null)
            {
                // Aplicarea filtrului pe baza numelor introduse in textbox
                string nume = txtNume.Text.Trim();
                if (!string.IsNullOrEmpty(nume))
                {
                    dv.RowFilter = string.Format("nume LIKE '%{0}%'", nume);
                }
                else
                {
                    dv.RowFilter = string.Empty;
                }
            }
        }

        private void cmbTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificarea daca obiectul dv este initializat
            if (dv != null)
            {
                // Aplicarea filtrului pe baza tipului de abonament selectat in combobox
                string tip = cmbTip.SelectedItem.ToString();
                if (!string.IsNullOrEmpty(tip))
                {
                    dv.RowFilter = string.Format("TipAbonament = '{0}'", tip);
                }
                else
                {
                    dv.RowFilter = string.Empty;
                }
            }
        }
    }
}
