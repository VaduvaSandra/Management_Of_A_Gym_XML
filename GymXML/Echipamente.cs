using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymXML
{
    public class Echipamente
    {
        public string Nume { get; set; }
        public string Descriere { get; set; }
        public string Grupa { get; set; }
        public Echipamente()
        {
            // constructor gol
        }
        public Echipamente(string nume, string descriere, string grupa)
        {
            Nume = nume;
            Descriere = descriere;
            Grupa = grupa;
        }
    }
}
