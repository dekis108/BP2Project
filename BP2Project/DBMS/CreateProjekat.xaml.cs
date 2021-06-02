using System;
using System.Collections.Generic;
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
    /// Interaction logic for CreateProjekat.xaml
    /// </summary>
    public partial class CreateProjekat : Window
    {
        public CreateProjekat()
        {
            InitializeComponent();

            txtSP.Text = "P10";
            txtNadgleda.Text = "TRNP10";
            txtKI.Text = "7";
            txtOZ.Text = "0";
            txtSpec.Text = "Opis...";
            txtTimovi.Text = "T1,T2,";

            dateDD.SelectedDate = DateTime.Now.AddDays(-7);
            datePR.SelectedDate = DateTime.Now;
            dateRi.SelectedDate = DateTime.Now.AddDays(1);
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                using (var db = new ProjectModelContainer())
                {
                    Projekat projekat = new Projekat()
                    {
                        SP = txtSP.Text,
                        DD = (DateTime)dateDD.SelectedDate,
                        SZ = txtSpec.Text,
                        DP = datePR.SelectedDate,
                        KI = int.Parse(txtKI.Text),
                        RI = dateRi.SelectedDate,
                    };

                    TimRadiNaProjektu timRadiNaProjektu = new TimRadiNaProjektu
                    {
                        Id = txtNadgleda.Text,
                        OZ = decimal.Parse(txtOZ.Text),
                        Projekat = projekat,
                    };

                    var timIds = txtTimovi.Text.Split(',');
                    timRadiNaProjektu.Tim.Clear();
                    foreach(var id in timIds)
                    {
                        timRadiNaProjektu.Tim.Add(db.Timovi.Find(id));
                    }

                    db.TimRadiNaProjektu.Add(timRadiNaProjektu);
                    db.Projekti.Add(projekat);

                    db.SaveChanges();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
