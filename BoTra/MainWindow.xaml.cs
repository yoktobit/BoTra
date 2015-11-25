using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BoTra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ListeLaden();
        }

        private void ListeLaden()
        {
            body = Body.Load();
            this.DataContext = body;
            this.mnuAnsicht.DataContext = body.bodyEntryFaktor;
        }

        private Body body;

        public Body Body => body;

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            body.Save();
        }

        private void mnuSettings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow sw = new SettingsWindow();
            sw.bodyEntryFaktor = body.bodyEntryFaktor;
            sw.DataContext = body.bodyEntryFaktor;
            sw.ShowDialog();
            Body.Groesse = body.bodyEntryFaktor.Groesse;
            foreach(var item in body.bodyList.Liste)
            {
                item.OnPropertyChanged("BMI");
                item.OnPropertyChanged("Punkte");
            }
        }

        private void dataGrid_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            var newItem = new BodyEntry();
            newItem.Parent = body.bodyList;
            var be = body.bodyList.Liste.LastOrDefault<BodyEntry>();
            if (be != null)
            {
                newItem.Bauch = be.Bauch;
                newItem.BizepsAngespannt = be.BizepsAngespannt;
                newItem.BizepsLocker = be.BizepsLocker;
                newItem.Bonus = be.Bonus;
                newItem.Brust = be.Brust;
                newItem.Gewicht = be.Gewicht;
                newItem.Hals = be.Hals;
                newItem.Oberschenkel = be.Oberschenkel;
                newItem.Schultern = be.Schultern;
                newItem.Wade = be.Wade;
                e.NewItem = newItem;
            }
            else
            {
                newItem.Bauch = 0;
                newItem.BizepsAngespannt = 0;
                newItem.BizepsLocker = 0;
                newItem.Bonus = 0;
                newItem.Brust = 0;
                newItem.Gewicht = 0;
                newItem.Hals = 0;
                newItem.Oberschenkel = 0;
                newItem.Schultern = 0;
                newItem.Wade = 0;
                e.NewItem = newItem;
            }
        }
    }
}
