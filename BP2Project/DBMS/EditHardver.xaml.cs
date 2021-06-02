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
    public partial class EditHardver : Window
    {
        enum TypeEnum { Racunar = 0, Mobilni };

        HardverViewModel hardver;

        public EditHardver(HardverViewModel hvm)
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

            hardver = hvm;
            LoadHardver();
        }

        private void LoadHardver()
        {
            txtSH.IsEnabled = false;
            comboType.IsEnabled = false;

            txtSH.Text = hardver.SH;
            txtCPU.Text = hardver.CPU;
            txtRAM.Text = hardver.RAM.ToString();
            txtHDD.Text = hardver.HDD.ToString();

            using (var db = new ProjectModelContainer())
            {
                Hardver hard = db.Hardveri.Find(hardver.SH);

                if (hard is Racunar)
                {
                    comboType.SelectedItem = TypeEnum.Racunar;
                    txtVM.Text = ((Racunar)hard).VM;
                    txtProstorija.Text = ((Racunar)hard).PoslovniProstor.SP;
                }
                else if (hard is Mobilni)
                {
                    comboType.SelectedItem = TypeEnum.Mobilni;
                    txtOS.Text = ((Mobilni)hard).OS;
                    txtDIM.Text = ((Mobilni)hard).MDIM.ToString();
                    txtDisp.Text = ((Mobilni)hard).Dispecer.Id;
                }
            }
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (comboType.SelectedItem is TypeEnum.Racunar)
            {
                try
                {
                    using (var db = new ProjectModelContainer())
                    {
                        Racunar rac = (Racunar)db.Hardveri.Find(hardver.SH);

                        rac.CPU = txtCPU.Text;
                        rac.HDD = int.Parse(txtHDD.Text);
                        rac.RAM = int.Parse(txtRAM.Text);
                        rac.VM = txtVM.Text;
                        rac.PoslovniProstor = db.PoslovniProstori.Find(txtProstorija.Text);

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
                    using (var db = new ProjectModelContainer())
                    {
                        Mobilni mob = (Mobilni)db.Hardveri.Find(hardver.SH);

                        mob.CPU = txtCPU.Text;
                        mob.HDD = int.Parse(txtHDD.Text);
                        mob.RAM = int.Parse(txtRAM.Text);
                        mob.MDIM = decimal.Parse(txtDIM.Text);
                        mob.OS = txtOS.Text;
                        
                        mob.Dispecer = (Dispecer)db.Zaposleni.Find(txtDisp.Text);

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
