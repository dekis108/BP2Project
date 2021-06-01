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
    /// Interaction logic for CreateZaposleni.xaml
    /// </summary>
    /// 

    public partial class CreateZaposleni : Window
    {
        enum TypeEnum { Admin = 0, Programer, Menadzer, Dispecer};
        enum NPR {Level0 = 0, Level1, Level2, Level3 };

        List<MobilniCreateViewModel> listaMobilni = new List<MobilniCreateViewModel>();

        public CreateZaposleni()
        {
            InitializeComponent();

            List<TypeEnum> typeEnums = new List<TypeEnum> {
                TypeEnum.Admin,
                TypeEnum.Programer,
                TypeEnum.Menadzer,
                TypeEnum.Dispecer,
            };

            List<NPR> nprList = new List<NPR> {
                NPR.Level0,
                NPR.Level1,
                NPR.Level2,
                NPR.Level3,
            };

            comboTip.ItemsSource = typeEnums;
            comboTip.SelectedItem = comboTip.Items[0];

            dateDZAP.SelectedDate = DateTime.Now;

            txtBoxId.Text = "ID_N";

            txtBoxPlata.Text = "10000";

            comboAdminNPR.ItemsSource = nprList;
            comboAdminNPR.SelectedItem = comboAdminNPR.Items[0];

            txtBoxProgramerTim.Text = "T1";

            txtBoxMenadzer.Text = "TRNP1";

        }

        private void comboTip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            comboAdminNPR.Visibility = Visibility.Hidden;
            labelAdminNPR.Visibility = Visibility.Hidden;

            btnDispecer.Visibility = Visibility.Hidden;
            labelDispecer.Visibility = Visibility.Hidden;

            labelProgramer.Visibility = Visibility.Hidden;
            labelProgramerCheckBox.Visibility = Visibility.Hidden;
            checkBoxProgramer.Visibility = Visibility.Hidden;
            txtBoxProgramerTim.Visibility = Visibility.Hidden;

            txtBoxMenadzer.Visibility = Visibility.Hidden;
            labelMenadzer.Visibility = Visibility.Hidden;

            if (comboTip.SelectedItem is TypeEnum.Admin)
            {
                comboAdminNPR.Visibility = Visibility.Visible;
                labelAdminNPR.Visibility = Visibility.Visible;
            }
            else if (comboTip.SelectedItem is TypeEnum.Dispecer)
            {
                btnDispecer.Visibility = Visibility.Visible;
                labelDispecer.Visibility = Visibility.Visible;
            }
            else if (comboTip.SelectedItem is TypeEnum.Programer)
            {
                labelProgramer.Visibility = Visibility.Visible;
                labelProgramerCheckBox.Visibility = Visibility.Visible;
                checkBoxProgramer.Visibility = Visibility.Visible;
                txtBoxProgramerTim.Visibility = Visibility.Visible;
            }
            else if (comboTip.SelectedItem is TypeEnum.Menadzer)
            {
                txtBoxMenadzer.Visibility = Visibility.Visible;
                labelMenadzer.Visibility = Visibility.Visible;
            }

        }

        private void btnDispecer_Click(object sender, RoutedEventArgs e)
        {
            MobilniPicker mobilniPicker = new MobilniPicker(listaMobilni);
            mobilniPicker.ShowDialog();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
