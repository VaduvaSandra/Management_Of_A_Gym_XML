using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GymXML
{
    public class Abonamente : IEnumerable<Abonament>
    {
        private List<Abonament> abonamente = new List<Abonament>();

        public void IncarcaDateDinXML(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Abonament>));
            StreamReader reader = new StreamReader(fileName);
            List<Abonament> lista = (List<Abonament>)serializer.Deserialize(reader);
            reader.Close();

            // Elimină toate abonamentele existente din lista.
            abonamente.Clear();

            // Adaugă abonamentele din fișierul XML în lista.
            abonamente.AddRange(lista);
        }

        public void SalveazaInFisier(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Abonament>));
            FileStream fileStream = new FileStream(fileName, FileMode.Create);
            serializer.Serialize(fileStream, abonamente);
            fileStream.Close();
        }

        public void AdaugaAbonament(Abonament abonament)
        {
            abonamente.Add(abonament);
        }

        public void Add(object obj)
        {
            if (obj is Abonament abonament)
            {
                abonamente.Add(abonament);
            }
            else
            {
                throw new ArgumentException("Invalid type.");
            }
        }

        public IEnumerator<Abonament> GetEnumerator()
        {
            return abonamente.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
