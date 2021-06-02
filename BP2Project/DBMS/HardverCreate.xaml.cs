using DatabaseModel;
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
    /// Interaction logic for HardverCreate.xaml
    /// </summary>
    public partial class HardverCreate : Window
    {
        enum TypeEnum { Racunar = 0, Mobilni };

        public HardverCreate()
        {
            InitializeComponent();

            txtSH.Text = "SH10";
            txtCPU.Text = "Intel1331";
            txtRAM.Text = "13";
            txtHDD.Text = "121";

            txtVM.Text = "VirtMa";
            txtProstorija.Text = "PP1";

            txtDIM.Text = "12.71";
            txtOS.Text = "OSic";
            txtDisp.Text = "D1";

            List<TypeEnum> lista = new List<TypeEnum>()
            {
                TypeEnum.Racunar,
                TypeEnum.Mobilni,
            };

            comboType.ItemsSource = lista;
            comboType.SelectedItem = comboType.Items[0];



        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (comboType.SelectedItem is TypeEnum.Racunar)
            {
                try
                {
                    Racunar rac = new Racunar
                    {
                        SH = txtSH.Text,
                        CPU = txtCPU.Text,
                        HDD = int.Parse(txtHDD.Text),
                        RAM = int.Parse(txtRAM.Text),
                        VM = txtVM.Text,
                    };

                    using (var db = new ProjectModelContainer())
                    {
                        rac.PoslovniProstor = db.PoslovniProstori.Find(txtProstorija.Text);

                        db.Hardveri.Add(rac);
                        db.SaveChanges();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else if (comboType.SelectedItem is TypeEnum.Mobilni)
            {
                try
                {
                    Mobilni mob = new Mobilni()
                    {
                        SH = txtSH.Text,
                        CPU = txtCPU.Text,
                        HDD = int.Parse(txtHDD.Text),
                        RAM = int.Parse(txtRAM.Text),
                        MDIM = decimal.Parse(txtDIM.Text),
                        OS = txtOS.Text,
                    };

                    using (var db = new ProjectModelContainer())
                    {
                        mob.Dispecer = (Dispecer)db.Zaposleni.Find(txtDisp.Text);

                        db.Hardveri.Add(mob);
                        db.SaveChanges();

                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }


            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void comboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            txtVM.Visibility = Visibility.Hidden;
            labelVM.Visibility = Visibility.Hidden;
            txtProstorija.Visibility = Visibility.Hidden;
            labelProstorija.Visibility = Visibility.Hidden;

            txtDIM.Visibility = Visibility.Hidden;
            labelDimenzije.Visibility = Visibility.Hidden;
            txtOS.Visibility = Visibility.Hidden;
            labelOS.Visibility = Visibility.Hidden;
            txtDisp.Visibility = Visibility.Hidden;
            labelDisp.Visibility = Visibility.Hidden;


            if (comboType.SelectedItem is TypeEnum.Racunar)
            {
                txtVM.Visibility = Visibility.Visible;
                txtProstorija.Visibility = Visibility.Visible;
                labelVM.Visibility = Visibility.Visible;
                labelProstorija.Visibility = Visibility.Visible;
            }
            else if (comboType.SelectedItem is TypeEnum.Mobilni)
            {
                txtDIM.Visibility = Visibility.Visible;
                txtOS.Visibility = Visibility.Visible;
                txtDisp.Visibility = Visibility.Visible;
                labelDimenzije.Visibility = Visibility.Visible;
                labelOS.Visibility = Visibility.Visible;
                labelDisp.Visibility = Visibility.Visible;
            }
        }
    }
}
