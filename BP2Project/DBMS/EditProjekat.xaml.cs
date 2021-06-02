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
    public partial class EditProjekat : Window
    {

        ProjekatViewModel pvm;
        public EditProjekat(ProjekatViewModel proj)
        {
            InitializeComponent();

            txtKI.Text = "7";
            txtOZ.Text = "0";
            txtSpec.Text = "Opis...";

            dateDD.SelectedDate = DateTime.Now.AddDays(-7);
            datePR.SelectedDate = DateTime.Now;
            dateRi.SelectedDate = DateTime.Now.AddDays(1);

            pvm = proj;
            LoadProjekat();
        }

        private void LoadProjekat()
        {
            txtSP.IsEnabled = false;
            txtNadgleda.IsEnabled = false;

            using (var db = new ProjectModelContainer())
            {
                TimRadiNaProjektu trnp = db.TimRadiNaProjektu.Find(pvm.TimRadiNaProjektu);

                txtSP.Text = pvm.SP;
                txtNadgleda.Text = pvm.TimRadiNaProjektu;
                txtKI.Text = pvm.KI.ToString();
                txtOZ.Text = trnp.OZ.ToString();
                txtSpec.Text = pvm.SZ;

                dateDD.SelectedDate = pvm.DD;
                datePR.SelectedDate = pvm.DP;
                dateRi.SelectedDate = pvm.RI;
            }
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new ProjectModelContainer())
                {
                    Projekat projekat = db.Projekti.Find(pvm.SP);

                    projekat.DD = (DateTime)dateDD.SelectedDate;
                    projekat.SZ = txtSpec.Text;
                    projekat.DP = datePR.SelectedDate;
                    projekat.KI = int.Parse(txtKI.Text);
                    projekat.RI = dateRi.SelectedDate;
                    

                    TimRadiNaProjektu timRadiNaProjektu = db.TimRadiNaProjektu.Find(pvm.TimRadiNaProjektu);

                    timRadiNaProjektu.OZ = decimal.Parse(txtOZ.Text);
                    timRadiNaProjektu.Projekat = projekat;
                
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