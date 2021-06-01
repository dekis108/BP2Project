using DBMS.ViewModel;
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
using System.Windows.Shapes;

namespace DBMS
{
    /// <summary>
    /// Interaction logic for ZaposleniChildren.xaml
    /// </summary>
    public partial class ZaposleniChildren : Window
    {
        ZaposleniChildrenViewModel zaposleniChildrenViewModel;

        public ZaposleniChildren()
        {
            InitializeComponent();

            zaposleniChildrenViewModel = new ZaposleniChildrenViewModel();

            LoadProgramer();
        }

        private void LoadProgramer()
        {
            zaposleniChildrenViewModel.LoadProgramer(GridProgramer);
        }

        private void tabAdmin_Clicked(object sender, MouseButtonEventArgs e)
        {
            LoadAdmin();
        }

        private void LoadAdmin()
        {
            zaposleniChildrenViewModel.LoadAdmin(GridAdmin);
        }

        private void tabMenadzer_Clicked(object sender, MouseButtonEventArgs e)
        {
            LoadMenadzer();
        }

        private void LoadMenadzer()
        {
            zaposleniChildrenViewModel.LoadMenadzer(GridMenadzer);
        }

        private void tabDispecer_Clicked(object sender, MouseButtonEventArgs e)
        {
            LoadDispecer();
        }

        private void LoadDispecer()
        {
            zaposleniChildrenViewModel.LoadDispecer(GridDispecer);
        }

        private void tabProgramer_Clicked(object sender, MouseButtonEventArgs e)
        {
            LoadProgramer();
        }

        private void DispecerDelete_Click(object sender, RoutedEventArgs e)
        {
            zaposleniChildrenViewModel.DispecerDelete(GridDispecer);
        }

        private void ProgramerDelete_Click(object sender, RoutedEventArgs e)
        {
            zaposleniChildrenViewModel.ProgramerDelete(GridProgramer);
        }

        private void AdminDelete_Click(object sender, RoutedEventArgs e)
        {
            zaposleniChildrenViewModel.AdminDelete(GridDispecer);
        }

        private void MenadzerDelete_Click(object sender, RoutedEventArgs e)
        {
            zaposleniChildrenViewModel.MenadzerDelete(GridMenadzer);
        }

        private void tabMap_Clicked(object sender, MouseButtonEventArgs e)
        {
            LoadMap();
        }

        private void LoadMap()
        {
            zaposleniChildrenViewModel.LoadMap(GridMap);
        }

        private void MapDelete_Click(object sender, RoutedEventArgs e)
        {
            zaposleniChildrenViewModel.MapDelete(GridMap);
        }
    }
}
