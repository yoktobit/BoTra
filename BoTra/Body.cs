using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BoTra
{
    [Serializable]
    public class Body
    {
        public BodyList bodyList { get; set; }
        public BodyEntryFaktor bodyEntryFaktor { get; set; }

        [NonSerialized]
        [XmlIgnore]
        public static double Groesse;

        [NonSerialized]
        [XmlIgnore]
        public static BodyEntryFaktor BodyEntryFaktorStatic;

        public Body()
        {
            bodyList = new BodyList();
            bodyEntryFaktor = new BodyEntryFaktor();
        }

        public void Save()
        {
            DirectoryInfo dir = Directory.CreateDirectory("data");
            XmlSerializer serializer = new XmlSerializer(this.GetType());
            XmlTextWriter xmlWriter = new XmlTextWriter("data/data.xml", Encoding.UTF8);
            serializer.Serialize(xmlWriter, this);
            xmlWriter.Close();
        }

        public static Body Load()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Body));
            Body b = null;
            if (File.Exists("data/data.xml"))
            {
                XmlTextReader xmlReader = new XmlTextReader("data/data.xml");
                b = (Body)serializer.Deserialize(xmlReader);
                xmlReader.Close();
            }
            else
            {
                b = new Body();
            }
            Groesse = b.bodyEntryFaktor.Groesse;
            BodyEntryFaktorStatic = b.bodyEntryFaktor;
            foreach (var b1 in b.bodyList.Liste)
            {
                b1.Parent = b.bodyList;
                b1.OnPropertyChanged("BMI");
                b1.OnPropertyChanged("Punkte");
            }
            b.bodyList.Refresh();
            return b;
        }
    }
}
