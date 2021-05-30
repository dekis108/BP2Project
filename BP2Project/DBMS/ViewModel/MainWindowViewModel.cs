using DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DBMS.ViewModel
{
    public class MainWindowViewModel
    {
        public List<Zaposleni> DataZaposleni { get; private set;}

        public MainWindowViewModel()
        {
            DataZaposleni = new List<Zaposleni>();
        }



        internal void LoadZaposleni(DataGrid gridZaposleni)
        {
            using (var db = new ProjectModelContainer())
            {
                DataZaposleni = db.Zaposleni.ToList();
                gridZaposleni.ItemsSource = DataZaposleni;
            }
        }
    }
}
