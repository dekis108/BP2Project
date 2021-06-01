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

        public List<PoslovniProstor> DataProstor { get; private set; }

        public List<Hardver> DataHardver { get; private set; }

        public List<Tim> DataTim { get; private set; }

        public List<Projekat> DataProjekat { get; private set; }

        public List<TimRadiNaProjektu> DataTimRadiNaProjektu { get; private set; }

        public MainWindowViewModel() {}



        internal void LoadZaposleni(DataGrid gridZaposleni)
        {
            using (var db = new ProjectModelContainer())
            {
                DataZaposleni = db.Zaposleni.ToList();
                gridZaposleni.ItemsSource = DataZaposleni;
            }
        }

        internal void LoadProstor(DataGrid grid)
        {
            using (var db = new ProjectModelContainer())
            {
                DataProstor = db.PoslovniProstori.ToList();
                grid.ItemsSource = DataProstor;
            }
        }

        internal void LoadHardver(DataGrid grid)
        {
            using (var db = new ProjectModelContainer())
            {
                DataHardver = db.Hardveri.ToList();
                grid.ItemsSource = DataHardver;
            }
        }

        internal void LoadTim(DataGrid grid)
        {
            using (var db = new ProjectModelContainer())
            {
                DataTim = db.Timovi.ToList();
                grid.ItemsSource = DataTim;
            }
        }

        internal void LoadProjekat(DataGrid grid)
        {
            using (var db = new ProjectModelContainer())
            {
                DataProjekat = db.Projekti.ToList();
                grid.ItemsSource = DataProjekat;
            }
        }

        internal void LoadTimRadiNaProjektu(DataGrid grid)
        {
            using (var db = new ProjectModelContainer())
            {
                DataTimRadiNaProjektu = db.TimRadiNaProjektu.ToList();
                grid.ItemsSource = DataTimRadiNaProjektu;
            }
        }
    }
}
