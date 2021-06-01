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
using DBMS.ViewModel;

namespace DBMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel mainWindowViewModel;

        public MainWindow()
        {
            InitializeComponent();

            mainWindowViewModel = new MainWindowViewModel();
     
            GridZaposleni.ItemsSource = mainWindowViewModel.DataZaposleni;

            LoadZaposleni();
        }

        private void LoadZaposleni()
        {
            mainWindowViewModel.LoadZaposleni(GridZaposleni);
        }

        private void tabZaposleni_Clicked(object sender, MouseButtonEventArgs e)
        {
            LoadZaposleni();
        }

        private void zaposleniChildButton_Click(object sender, RoutedEventArgs e)
        {
            ZaposleniChildren children = new ZaposleniChildren();
            children.Show();
        }

        private void tabProstor_Clicked(object sender, MouseButtonEventArgs e)
        {
            LoadProstor();
        }

        private void LoadProstor()
        {
            mainWindowViewModel.LoadProstor(GridProstor);
        }
    }
}
