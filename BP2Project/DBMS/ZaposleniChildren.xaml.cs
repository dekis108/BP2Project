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

        }

        private void tabDispecer_Clicked(object sender, MouseButtonEventArgs e)
        {

        }

        private void tabProgramer_Clicked(object sender, MouseButtonEventArgs e)
        {
            LoadProgramer();
        }
    }
}
