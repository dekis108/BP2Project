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

            txtBoxProstorija.Text = "PP1";

            dateDZAP.SelectedDate = DateTime.Now;

            txtBoxProgramerOcena.Text = "1";

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
            labelProgramerOcena.Visibility = Visibility.Hidden;
            txtBoxProgramerOcena.Visibility = Visibility.Hidden;

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
                labelProgramerOcena.Visibility = Visibility.Visible;
                txtBoxProgramerOcena.Visibility = Visibility.Visible;

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
            //TODO dodaj poslovni prostor na ovaj window
            if (comboTip.SelectedItem is TypeEnum.Admin)
            {
                try
                {
                    Admin admin = new Admin
                    {
                        Id = txtBoxId.Text,
                        PLAT = Int32.Parse(txtBoxPlata.Text),
                        D_ZAP = dateDZAP.SelectedDate,
                        NPR = comboAdminNPR.SelectedItem.ToString(),
                    };

                    using (var db = new ProjectModelContainer())
                    {
                        admin.PoslovniProstor = db.PoslovniProstori.Find(txtBoxProstorija.Text);

                        db.Zaposleni.Add(admin);
                        db.SaveChanges();
                    }

                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (comboTip.SelectedItem is TypeEnum.Dispecer)
            {
                try
                {
                    Dispecer disp = new Dispecer
                    {
                        Id = txtBoxId.Text,
                        PLAT = Int32.Parse(txtBoxPlata.Text),
                        D_ZAP = dateDZAP.SelectedDate,
                    };

                    using (var db = new ProjectModelContainer())
                    {
                        var listaMobilnih = db.Hardveri.ToList();
                        var list = listaMobilnih.Where(x => listaMobilni.Where(y => y.SH == x.SH).Any()).ToList();
                        foreach (Mobilni mobilni in list)
                        {
                            disp.Mobilni.Add(mobilni);
                        }

                        disp.PoslovniProstor = db.PoslovniProstori.Find(txtBoxProstorija.Text);

                        db.Zaposleni.Add(disp);
                        db.SaveChanges();
                    }
                    this.Close();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (comboTip.SelectedItem is TypeEnum.Programer)
            {
                try
                {
                    Programer prog = new Programer
                    {
                        Id = txtBoxId.Text,
                        PLAT = Int32.Parse(txtBoxPlata.Text),
                        D_ZAP = dateDZAP.SelectedDate,
                        O_PROD = Int32.Parse(txtBoxProgramerOcena.Text),
                    };

                    using (var db = new ProjectModelContainer())
                    {
                        prog.PoslovniProstor = db.PoslovniProstori.Find(txtBoxProstorija.Text);

                        prog.ClanTima = db.Timovi.Find(txtBoxProgramerTim.Text);
                        if (checkBoxProgramer?.IsChecked == true && prog.ClanTima.VodjaTima == null)
                        {
                            prog.ClanTima.VodjaTima = prog;
                        }

                        db.Zaposleni.Add(prog);
                        db.SaveChanges();
                    }
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else if (comboTip.SelectedItem is TypeEnum.Menadzer)
            {
                try
                {
                    Menadzer men = new Menadzer
                    {
                        Id = txtBoxId.Text,
                        PLAT = Int32.Parse(txtBoxPlata.Text),
                        D_ZAP = dateDZAP.SelectedDate,
                    };

                    using (var db = new ProjectModelContainer())
                    {
                        men.PoslovniProstor = db.PoslovniProstori.Find(txtBoxProstorija.Text);

                        var ids = txtBoxMenadzer.Text.Split(',');

                        foreach (string id in ids)
                        {
                            men.TimRadiNaProjektus.Add(db.TimRadiNaProjektu.Find(id));
                        }

                        

                        db.Zaposleni.Add(men);
                        db.SaveChanges();
                    }
                    this.Close();
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
    }
}
