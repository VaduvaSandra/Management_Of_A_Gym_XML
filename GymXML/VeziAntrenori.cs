using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GymXML
{
    public partial class VeziAntrenori : Form
    {
        public VeziAntrenori()
        {
            InitializeComponent();
        }
        

        private void VeziAntrenori_Load(object sender, EventArgs e)
        {
             AntrenoriList antrenoriList = new AntrenoriList();
            antrenoriList.IncarcaDateDinXML();

            foreach (Antrenor antrenor in antrenoriList.GetAntrenoriList())
            {
                ListViewItem item = new ListViewItem(new string[] { antrenor.Nume, antrenor.Prenume, antrenor.Categorie, antrenor.Perioada });
                listView1.Items.Add(item);
            }
        }
    }
}
