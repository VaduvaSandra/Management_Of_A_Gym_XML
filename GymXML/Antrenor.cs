using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace GymXML
{
   public  class Antrenor
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Categorie { get; set; }
        public string Perioada { get; set; }

        public Antrenor()
        {
            Nume = "";
            Prenume = "";
            Categorie = "";
            Perioada = "";
        }
    }
}
