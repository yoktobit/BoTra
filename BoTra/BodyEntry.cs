using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;

namespace BoTra
{
    [Serializable]
    public class BodyEntry : INotifyPropertyChanged
    {
        public DateTime Datum { get; set; }

        [NonSerialized]
        [XmlIgnore]
        public BodyList Parent;

        private double _gewicht;
        private double _bizepsLocker;
        private double _bizepsAngespannt;
        private double _hals;
        private double _schultern;
        private double _brust;
        private double _bauch;
        private double _wade;
        private double _oberschenkel;
        private double _bonus;

        public double Gewicht
        {
            get
            {
                return _gewicht;
            }
            set
            {
                if (_gewicht != value)
                {
                    _gewicht = value;
                    OnPropertyChanged("Gewicht");
                    OnPropertyChanged("BMI");
                    OnPropertyChanged("Punkte");
                    Parent?.Refresh();
                }
            }
        }
        public Brush GewichtBrush => Parent.gewichtMin == Gewicht ? Parent.goodBrush : (Parent.gewichtMax == Gewicht ? Parent.badBrush : Parent.normalBrush);

        public double BizepsLocker
        {
            get
            {
                return _bizepsLocker;
            }
            set
            {
                if (_bizepsLocker != value)
                {
                    _bizepsLocker = value;
                    OnPropertyChanged("BizepsLocker");
                    OnPropertyChanged("Punkte");
                    Parent?.Refresh();
                }
            }
        }
        public Brush BizepsLockerBrush => Parent.bizepsLockerMin == BizepsLocker ? Parent.badBrush : (Parent.bizepsLockerMax == BizepsLocker ? Parent.goodBrush : Parent.normalBrush);

        public double BizepsAngespannt
        {
            get { return _bizepsAngespannt; }
            set
            {
                _bizepsAngespannt = value; 
                OnPropertyChanged("BizepsAngespannt");
                OnPropertyChanged("Punkte");
                Parent?.Refresh();
            }
        }
        public Brush BizepsAngespanntBrush => Parent.bizepsAngespanntMin == BizepsAngespannt ? Parent.badBrush : (Parent.bizepsAngespanntMax == BizepsAngespannt ? Parent.goodBrush : Parent.normalBrush);

        public double Hals
        {
            get { return _hals; }
            set
            {
                _hals = value;
                OnPropertyChanged("Hals");
                OnPropertyChanged("Punkte");
                Parent?.Refresh();
            }
        }
        public Brush HalsBrush => Parent.halsMin == Hals ? Parent.badBrush : (Parent.halsMax == Hals ? Parent.goodBrush : Parent.normalBrush);

        public double Schultern
        {
            get { return _schultern; }
            set
            {
                _schultern = value;
                OnPropertyChanged("Schultern");
                OnPropertyChanged("Punkte");
                Parent?.Refresh();
            }
        }
        public Brush SchulternBrush => Parent.schulternMin == Schultern ? Parent.badBrush : (Parent.schulternMax == Schultern ? Parent.goodBrush : Parent.normalBrush);

        public double Brust
        {
            get { return _brust; }
            set
            {
                _brust = value;
                OnPropertyChanged("Brust");
                OnPropertyChanged("Punkte");
                Parent?.Refresh();
            }
        }
        public Brush BrustBrush => Parent.brustMin == Brust ? Parent.badBrush : (Parent.brustMax == Brust ? Parent.goodBrush : Parent.normalBrush);

        public double Bauch
        {
            get { return _bauch; }
            set
            {
                _bauch = value;
                OnPropertyChanged("Bauch");
                OnPropertyChanged("Punkte");
                Parent?.Refresh();
            }
        }
        public Brush BauchBrush => Parent.bauchMin == Bauch ? Parent.goodBrush : (Parent.bauchMax == Bauch ? Parent.badBrush : Parent.normalBrush);

        public double Wade
        {
            get { return _wade; }
            set
            {
                _wade = value;
                OnPropertyChanged("Wade");
                OnPropertyChanged("Punkte");
                Parent?.Refresh();
            }
        }
        public Brush WadeBrush => Parent.wadeMin == Wade ? Parent.badBrush : (Parent.wadeMax == Wade ? Parent.goodBrush : Parent.normalBrush);

        public double Oberschenkel
        {
            get { return _oberschenkel; }
            set
            {
                _oberschenkel = value;
                OnPropertyChanged("Oberschenkel");
                OnPropertyChanged("Punkte");
                Parent?.Refresh();
            }
        }
        public Brush OberschenkelBrush => Parent.oberschenkelMin == Oberschenkel ? Parent.badBrush : (Parent.oberschenkelMax == Oberschenkel ? Parent.goodBrush : Parent.normalBrush);

        public double Bonus
        {
            get { return _bonus; }
            set
            {
                _bonus = value;
                OnPropertyChanged("Bonus");
                OnPropertyChanged("Punkte");
                Parent?.Refresh();
            }
        }
        public Brush BonusBrush => Parent.bonusMin == Bonus ? Parent.badBrush : (Parent.bonusMax == Bonus ? Parent.goodBrush : Parent.normalBrush);

        public double BMI
        {
            get
            {
                return Gewicht / Math.Pow(Body.Groesse / 100.0, 2);
            }
        }
        public double Punkte
        {
            get
            {
                return (Gewicht * Body.BodyEntryFaktorStatic.Gewicht)
                    + (BizepsLocker * Body.BodyEntryFaktorStatic.BizepsLocker)
                    + (BizepsAngespannt * Body.BodyEntryFaktorStatic.BizepsAngespannt)
                    + (Hals * Body.BodyEntryFaktorStatic.Hals)
                    + (Schultern * Body.BodyEntryFaktorStatic.Schultern)
                    + (Brust * Body.BodyEntryFaktorStatic.Brust)
                    + (Bauch * Body.BodyEntryFaktorStatic.Bauch)
                    + (Oberschenkel * Body.BodyEntryFaktorStatic.Oberschenkel)
                    + (Wade * Body.BodyEntryFaktorStatic.Wade)
                    + (Bonus * Body.BodyEntryFaktorStatic.Bonus)
                    + (BMI * Body.BodyEntryFaktorStatic.BMI);
            }
        }

        public BodyEntry()
        {
            this.Datum = DateTime.Now;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }
    }
    [Serializable]
    public class BodyEntryFaktor : INotifyPropertyChanged
    {
        private bool _gewichtVisible;
        public double Gewicht { get; set; }

        public bool GewichtVisible
        {
            get { return _gewichtVisible; }
            set { _gewichtVisible = value; OnPropertyChanged("GewichtVisible");}
        }

        public double Groesse { get; set; }
        public bool GroesseVisible { get; set; }

        public double BizepsLocker { get; set; }
        public bool BizepsLockerVisible { get; set; }
        public double BizepsAngespannt { get; set; }
        public bool BizepsAngespanntVisible { get; set; }

        public double Hals { get; set; }
        public bool HalsVisible { get; set; }
        public double Schultern { get; set; }
        public bool SchulternVisible { get; set; }
        public double Brust { get; set; }
        public bool BrustVisible { get; set; }
        public double Bauch { get; set; }
        public bool BauchVisible { get; set; }

        public double Wade { get; set; }
        public bool WadeVisible { get; set; }
        public double Oberschenkel { get; set; }
        public bool OberschenkelVisible { get; set; }

        public double Bonus { get; set; }
        public bool BonusVisible { get; set; }
        public double BMI { get; set; }
        public bool BMIVisible { get; set; }

        public BodyEntryFaktor()
        {
            Groesse = 180;
            Gewicht = 1.0;
            GewichtVisible = true;
            BizepsLocker = 1.0;
            BizepsLockerVisible = true;
            BizepsAngespannt = 1.0;
            BizepsAngespanntVisible = true;
            Hals = 1.0;
            HalsVisible = false;
            Schultern = 1.0;
            SchulternVisible = true;
            Brust = 1.0;
            BrustVisible = true;
            Bauch = -1.0;
            BauchVisible = true;
            Wade = 1.0;
            WadeVisible = true;
            Oberschenkel = 1.0;
            OberschenkelVisible = true;
            Bonus = 1.0;
            BonusVisible = true;
            BMI = 0.0;
            BMIVisible = true;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string property)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
