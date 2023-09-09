using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GymXML
{
    [XmlRoot("Membri")]
    public class Membri
    {
        [XmlElement("Membru")]
        public List<Membru> MembriList { get; set; } = new List<Membru>();

        public void AdaugaMembru(Membru membru)
        {
            MembriList.Add(membru);
        }
    }
}
