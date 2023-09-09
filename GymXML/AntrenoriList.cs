using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GymXML
{
    public class AntrenoriList
    {
        private static string xmlFilePath = @"C:\Users\vaduv\Desktop\Facultate\Facultate an 4\TTTvMM\GymXML\GymXML\antrenor.xml";

        private List<Antrenor> antrenoriList = new List<Antrenor>();

        public void IncarcaDateDinXML(string filePath = null)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                xmlFilePath = filePath;
            }

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(xmlFilePath);

            XmlNodeList antrenoriNodes = xmlDoc.SelectNodes("//Antrenor");
            foreach (XmlNode node in antrenoriNodes)
            {
                Antrenor antrenor = new Antrenor()
                {
                    Nume = node.SelectSingleNode("Nume").InnerText,
                    Prenume = node.SelectSingleNode("Prenume").InnerText,
                    Categorie = node.SelectSingleNode("Categorie").InnerText,
                    Perioada = node.SelectSingleNode("Perioada").InnerText
                };
                antrenoriList.Add(antrenor);
            }
        }

        public List<Antrenor> GetAntrenoriList()
        {
            return antrenoriList;
        }
    }
}
