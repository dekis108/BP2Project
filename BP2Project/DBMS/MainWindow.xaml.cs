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
using DBMS.ViewModel.DataGridClasses;

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

            TestScript testScript = new TestScript();
            //testScript.Run();

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
            children.ShowDialog();
            LoadZaposleni();
        }

        private void tabProstor_Clicked(object sender, MouseButtonEventArgs e)
        {
            LoadProstor();
        }

        private void LoadProstor()
        {
            mainWindowViewModel.LoadProstor(GridProstor);
        }

        private void hardverChildButton_Click(object sender, RoutedEventArgs e)
        {
            HardverChildren child = new HardverChildren();
            child.ShowDialog();
            LoadHardver();
        }

        private void tabHardver_Clicked(object sender, MouseButtonEventArgs e)
        {
            LoadHardver();
        }

        private void LoadHardver()
        {
            mainWindowViewModel.LoadHardver(GridHardver);
        }

        private void tabTim_Clicked(object sender, MouseButtonEventArgs e)
        {
            LoadTim();
        }

        private void LoadTim()
        {
            mainWindowViewModel.LoadTim(GridTim);
        }

        private void tabProjekat_Clicked(object sender, MouseButtonEventArgs e)
        {
            LoadProjekat();
        }

        private void LoadProjekat()
        {
            mainWindowViewModel.LoadProjekat(GridProjekat);
        }

        private void tabTimRadiNaProjektu_Clicked(object sender, MouseButtonEventArgs e)
        {
            LoadTimRadiNaProjektu();
        }

        private void LoadTimRadiNaProjektu()
        {
            mainWindowViewModel.LoadTimRadiNaProjektu(GridRadiNa);
        }

        private void zaposleniDelete_Click(object sender, RoutedEventArgs e)
        {
            mainWindowViewModel.ZaposleniDelete(GridZaposleni);
        }

        private void tabMapTimRadiNaProjektu_Clicked(object sender, MouseButtonEventArgs e)
        {
            LoadMap();
        }

        private void LoadMap()
        {
            mainWindowViewModel.LoadMap(GridMap);
        }

        private void prostorDelete_Click(object sender, RoutedEventArgs e)
        {
            mainWindowViewModel.ProstorDelete(GridProstor);
        }

        private void HardverDelete_Click(object sender, RoutedEventArgs e)
        {
            mainWindowViewModel.HardverDelete(GridHardver);
        }

        private void TimDelete_Click(object sender, RoutedEventArgs e)
        {
            mainWindowViewModel.TimDelete(GridTim);
        }

        private void ProjDelete_Click(object sender, RoutedEventArgs e)
        {
            mainWindowViewModel.ProjekatDelete(GridProjekat);
        }

        private void zaposleniCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateZaposleni createZaposleni = new CreateZaposleni();
            createZaposleni.ShowDialog();
            LoadZaposleni();
        }

        private void zaposleniEdit_Click(object sender, RoutedEventArgs e)
        {
            if (GridZaposleni.SelectedItem == null) return;

            EditZaposleni editZaposleni = new EditZaposleni((ZaposleniViewModel)GridZaposleni.SelectedItem);
            editZaposleni.ShowDialog();
            LoadZaposleni();
        }

        private void procedura1BTN_Click(object sender, RoutedEventArgs e)
        {
            mainWindowViewModel.IncrementOZ();
        }

        private void procedura2BTN_Click(object sender, RoutedEventArgs e)
        {
            mainWindowViewModel.AssignRoomsProcedure();
        }

        private void func1BTN_Click(object sender, RoutedEventArgs e)
        {
            mainWindowViewModel.CalcAvg();
        }

        private void prostorCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateProstorija createProstorija = new CreateProstorija();
            createProstorija.ShowDialog();
            LoadProstor();
        }

        private void TimCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateTim x = new CreateTim();
            x.ShowDialog();
            LoadTim();
        }

        private void TimEdit_Click(object sender, RoutedEventArgs e)
        {
            if (GridTim.SelectedItem == null) return;
            EditTim x = new EditTim((TimViewModel)GridTim.SelectedItem);
            x.ShowDialog();
            LoadTim();
        }

        private void prostorEdit_Click(object sender, RoutedEventArgs e)
        {
            if (GridProstor.SelectedItem == null) return;
            EditProstorija x = new EditProstorija((PoslovniProstorViewModel)GridProstor.SelectedItem);
            x.ShowDialog();
            LoadProstor();
        }

        private void func2BTN_Click(object sender, RoutedEventArgs e)
        {
            mainWindowViewModel.Count();
        }
    }
}
