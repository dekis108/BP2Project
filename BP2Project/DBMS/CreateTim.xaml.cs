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
    /// Interaction logic for CreateTim.xaml
    /// </summary>
    public partial class CreateTim : Window
    {
        public CreateTim()
        {
            InitializeComponent();

            txtBoxPR.Text = "R&D";
            txtBoxST.Text = "T10";
            txtNadredjen.Text = "T1";
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new ProjectModelContainer())
                {
                    Tim tim = new Tim
                    {
                        ST = txtBoxST.Text,
                        PR = txtBoxPR.Text,
                        Nadredjeni = db.Timovi.Find(txtNadredjen.Text)
                    };

                    db.Timovi.Add(tim);
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
