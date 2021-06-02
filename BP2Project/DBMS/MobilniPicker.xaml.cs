using DBMS.ViewModel.DataGridClasses;
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
    /// Interaction logic for MobilniPicker.xaml
    /// </summary>
    public partial class MobilniPicker : Window
    {
        MobilniPickerViewModel mobilniPickerViewModel;

        List<MobilniCreateViewModel> listaMobilni;

        public MobilniPicker(List<MobilniCreateViewModel> outList)
        {
            InitializeComponent();
            listaMobilni = outList;
            mobilniPickerViewModel = new MobilniPickerViewModel(listaMobilni);
            mobilniPickerViewModel.LoadMobilni(dataGridMobilni);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
