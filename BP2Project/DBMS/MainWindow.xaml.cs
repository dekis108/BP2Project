using System;
using System.Collections.Generic;
using System.Linq;
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
using DatabaseModel;
using DatabaseModel.Model;

namespace DBMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Zaposleni> DataZaposleni;

        public MainWindow()
        {
            InitializeComponent();

            DataZaposleni = new List<Zaposleni>();
            GridZaposleni.ItemsSource = DataZaposleni;

            LoadZaposleni();
        }

        private void LoadZaposleni()
        {
            using (var db = new ProjectModelContainer())
            {
                DataZaposleni = db.Zaposleni.ToList();
                GridZaposleni.ItemsSource = DataZaposleni;
            }
        }

        private void tabZaposleni_Clicked(object sender, MouseButtonEventArgs e)
        {
            LoadZaposleni();
        }
    }
}
