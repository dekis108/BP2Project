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
    public partial class EditProstorija : Window
    {
        PoslovniProstorViewModel prostor;
        public EditProstorija(PoslovniProstorViewModel pp)
        {
            InitializeComponent();

            prostor = pp;

            txtBoxSp.IsEnabled = false;

            txtBRM.Text = pp.BRM.ToString();
            txtBoxDIM.Text = pp.DIM.ToString();
            txtBoxSp.Text = pp.SP;
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new ProjectModelContainer())
                {
                    PoslovniProstor pp = db.PoslovniProstori.Find(prostor.SP);
                   
                    pp.BRM = Int32.Parse(txtBRM.Text);
                    pp.DIM = decimal.Parse(txtBoxDIM.Text);

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