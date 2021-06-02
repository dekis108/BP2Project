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
    /// Interaction logic for EditZaposleni.xaml
    /// </summary>
    public partial class EditZaposleni : Window
    {
        enum TypeEnum { Admin = 0, Programer, Menadzer, Dispecer };
        enum NPR { Level0 = 0, Level1, Level2, Level3 };

        List<MobilniCreateViewModel> listaMobilni = new List<MobilniCreateViewModel>();

        ZaposleniViewModel zap;

        public EditZaposleni(ZaposleniViewModel zaposleni)
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

            zap = zaposleni;
            LoadZaposleni();

        }

        private void LoadZaposleni()
        {
            txtBoxId.IsEnabled = false;
            comboTip.IsEnabled = false;

            txtBoxProstorija.Text = zap.PoslovniProstor;
            dateDZAP.SelectedDate = zap.D_ZAP;
            txtBoxId.Text = zap.Id;
            txtBoxPlata.Text = zap.PLAT.ToString();


            using (var db = new ProjectModelContainer())
            {
                Zaposleni zaposleni = db.Zaposleni.Find(zap.Id);
                if (zaposleni == null) return;

                if (zaposleni is Programer)
                {
                    comboTip.SelectedItem = TypeEnum.Programer;
                    txtBoxProgramerOcena.Text = ((Programer)zaposleni).O_PROD.ToString();
                    txtBoxProgramerTim.Text = ((Programer)zaposleni).ClanTima.ST;
                    checkBoxProgramer.IsChecked = ((Programer)zaposleni).VodiTim != null;
                }
                else if (zaposleni is Menadzer)
                {
                    comboTip.SelectedItem = TypeEnum.Menadzer;

                    var lista = ((Menadzer)zaposleni).TimRadiNaProjektus.Select(x => x.Id);

                    txtBoxMenadzer.Text = "";
                    foreach(string st in lista)
                    {
                        txtBoxMenadzer.Text += st.Trim() + ",";
                    }
                }
                else if (zaposleni is Admin)
                {
                    comboTip.SelectedItem = TypeEnum.Admin;
                    comboAdminNPR.SelectedItem = ((Admin)zaposleni).NPR.ToString();
                }
                else if (zaposleni is Dispecer)
                {
                    comboTip.SelectedItem = TypeEnum.Dispecer;
                    var mob = ((Dispecer)zaposleni).Mobilni;
                    foreach(Mobilni m in mob)
                    {
                        var m1 = new MobilniCreateViewModel(m);
                        m1.Selected = true;
                        listaMobilni.Add(m1);
                    }
                    MobilniPickerViewModel.FillFreeMobilni(listaMobilni);
                }


            }

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

            if (comboTip.SelectedItem is TypeEnum.Admin)
            {
                try
                {
                    using (var db = new ProjectModelContainer())
                    {
                        Admin admin = (Admin)db.Zaposleni.Find(zap.Id);

                        admin.PLAT = Int32.Parse(txtBoxPlata.Text);
                        admin.D_ZAP = dateDZAP.SelectedDate;
                        admin.NPR = comboAdminNPR.SelectedItem.ToString();
                        admin.PoslovniProstor = db.PoslovniProstori.Find(txtBoxProstorija.Text);
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
                    using (var db = new ProjectModelContainer())
                    {
                        Dispecer disp = (Dispecer)db.Zaposleni.Find(zap.Id);

                        disp.PLAT = Int32.Parse(txtBoxPlata.Text);
                        disp.D_ZAP = dateDZAP.SelectedDate;
                        var mobilni = db.Hardveri.ToList();
                        var list = mobilni.Where(x => listaMobilni.Where(y => x.SH == y.SH && y.Selected).Any()).ToList();
                        disp.Mobilni.Clear();
                        foreach (Mobilni mob in list)
                        {
                            disp.Mobilni.Add(mob);
                        }

                        disp.PoslovniProstor = db.PoslovniProstori.Find(txtBoxProstorija.Text);

                        db.SaveChanges();
                    }
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (comboTip.SelectedItem is TypeEnum.Programer)
            {
                try
                {
                    using (var db = new ProjectModelContainer())
                    {
                        Programer prog =(Programer)db.Zaposleni.Find(zap.Id);
                      
                        prog.PoslovniProstor = db.PoslovniProstori.Find(txtBoxProstorija.Text);
                        prog.PLAT = Int32.Parse(txtBoxPlata.Text);
                        prog.D_ZAP = dateDZAP.SelectedDate;
                        prog.ClanTima = db.Timovi.Find(txtBoxProgramerTim.Text);
                        if (checkBoxProgramer?.IsChecked == true && prog.ClanTima.VodjaTima == null)
                        {
                            prog.ClanTima.VodjaTima = prog;
                        }

                        db.SaveChanges();
                    }
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            else if (comboTip.SelectedItem is TypeEnum.Menadzer)
            {
                try
                {
                    using (var db = new ProjectModelContainer())
                    {
                        Menadzer men = (Menadzer)db.Zaposleni.Find(zap.Id);

                        men.PoslovniProstor = db.PoslovniProstori.Find(txtBoxProstorija.Text);
                        men.PLAT = Int32.Parse(txtBoxPlata.Text);
                        men.D_ZAP = dateDZAP.SelectedDate;
                        var ids = txtBoxMenadzer.Text.Split(',');

                        men.TimRadiNaProjektus.Clear();
                        foreach (string id in ids)
                        {
                            men.TimRadiNaProjektus.Add(db.TimRadiNaProjektu.Find(id));
                        }

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
