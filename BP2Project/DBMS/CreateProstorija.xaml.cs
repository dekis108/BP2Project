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
    /// Interaction logic for CreateProstorija.xaml
    /// </summary>
    public partial class CreateProstorija : Window
    {
        public CreateProstorija()
        {
            InitializeComponent();

            txtBRM.Text = "15";
            txtBoxDIM.Text = "50";
            txtBoxSp.Text = "PP10";
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new ProjectModelContainer())
                {
                    PoslovniProstor pp = new PoslovniProstor
                    {
                        SP = txtBoxSp.Text,
                        BRM = Int32.Parse(txtBRM.Text),
                        DIM = decimal.Parse(txtBoxDIM.Text),
                    };

                    db.PoslovniProstori.Add(pp);
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
