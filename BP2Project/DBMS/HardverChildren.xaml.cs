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
    /// Interaction logic for HardverChildren.xaml
    /// </summary>
    public partial class HardverChildren : Window
    {
        HardverChildrenViewModel hardverChildrenViewModel;  

        public HardverChildren()
        {
            InitializeComponent();
            hardverChildrenViewModel = new HardverChildrenViewModel();

            LoadRacunar();
        }

        private void tabRacunar_Clicked(object sender, MouseButtonEventArgs e)
        {
            LoadRacunar();
        }

        private void LoadRacunar()
        {
            hardverChildrenViewModel.LoadRacunar(GridRacunar);
        }

        private void tabMobilni_Clicked(object sender, MouseButtonEventArgs e)
        {
            LoadMobilni();
        }

        private void LoadMobilni()
        {
            hardverChildrenViewModel.LoadMobilni(GridMobilni);
        }
    }
}
