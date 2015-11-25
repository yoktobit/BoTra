using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml;
using System.Xml.Serialization;

namespace BoTra
{
    [Serializable]
    public class BodyList
    {

        public List<BodyEntry> Liste { get; set; }

        public BodyList()
        {
            Liste = new List<BodyEntry>();
            goodBrush = new SolidColorBrush(Colors.DarkSeaGreen);
            badBrush = new SolidColorBrush(Colors.OrangeRed);
            normalBrush = new SolidColorBrush(Colors.Transparent);
        }

        [NonSerialized]
        [XmlIgnore]
        public SolidColorBrush goodBrush;
        [NonSerialized]
        [XmlIgnore]
        public SolidColorBrush badBrush;
        [NonSerialized]
        [XmlIgnore]
        public SolidColorBrush normalBrush;


        [NonSerialized]
        public double bizepsLockerMin;
        [NonSerialized]
        public double bizepsLockerMax;
        [NonSerialized]
        public double bizepsAngespanntMin;
        [NonSerialized]
        public double bizepsAngespanntMax;
        [NonSerialized]
        public double halsMin;
        [NonSerialized]
        public double halsMax;
        [NonSerialized]
        public double schulternMin;
        [NonSerialized]
        public double schulternMax;
        [NonSerialized]
        public double brustMin;
        [NonSerialized]
        public double brustMax;
        [NonSerialized]
        public double bauchMin;
        [NonSerialized]
        public double bauchMax;
        [NonSerialized]
        public double oberschenkelMin;
        [NonSerialized]
        public double oberschenkelMax;
        [NonSerialized]
        public double wadeMin;
        [NonSerialized]
        public double wadeMax;
        [NonSerialized]
        public double bonusMin;
        [NonSerialized]
        public double bonusMax;
        [NonSerialized]
        public double gewichtMin;
        [NonSerialized]
        public double gewichtMax;

        public void Refresh()
        {
            if (Liste.Count == 0) return;
            bizepsLockerMin = Liste.Min(x => x.BizepsLocker);
            bizepsLockerMax = Liste.Max(x => x.BizepsLocker);
            bizepsAngespanntMin = Liste.Min(x => x.BizepsAngespannt);
            bizepsAngespanntMax = Liste.Max(x => x.BizepsAngespannt);
            halsMin = Liste.Min(x => x.Hals);
            halsMax = Liste.Max(x => x.Hals);
            schulternMin = Liste.Min(x => x.Schultern);
            schulternMax = Liste.Max(x => x.Schultern);
            brustMin = Liste.Min(x => x.Brust);
            brustMax = Liste.Max(x => x.Brust);
            bauchMin = Liste.Min(x => x.Bauch);
            bauchMax = Liste.Max(x => x.Bauch);
            oberschenkelMin = Liste.Min(x => x.Oberschenkel);
            oberschenkelMax = Liste.Max(x => x.Oberschenkel);
            wadeMin = Liste.Min(x => x.Wade);
            wadeMax = Liste.Max(x => x.Wade);
            bonusMin = Liste.Min(x => x.Bonus);
            bonusMax = Liste.Max(x => x.Bonus);
            gewichtMin = Liste.Min(x => x.Gewicht);
            gewichtMax = Liste.Max(x => x.Gewicht);

            foreach (BodyEntry be in Liste)
            {
                be.OnPropertyChanged("");
            }
        }
    }
}
