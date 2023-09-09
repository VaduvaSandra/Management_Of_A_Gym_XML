using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GymXML
{
   public  class Membru
    {
        [XmlElement("Nume")]
        public string Nume { get; set; }

        [XmlElement("Prenume")]
        public string Prenume { get; set; }

        [XmlElement("Telefon")]
        public string Telefon { get; set; }

        [XmlElement("Tip")]
        public string Tip { get; set; }

        [XmlElement("Valabilitate")]
        public string Valabilitate { get; set; }

        [XmlElement("DataInscriere")]
        public DateTime DataInscriere { get; set; }
    }
}
