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

        internal void ZaposleniDelete(DataGrid grid)
        {
            Zaposleni item = (Zaposleni)grid.SelectedItem;
            //if (DeleteFromData(grid))
            if (grid.SelectedItem != null)
            {
                using (var db = new ProjectModelContainer())
                {
                    db.Zaposleni.Attach(item);

                    //skloni ga da nije sef timu
                    var teams = db.Timovi.Where(x => x.VodjaTima.Id == item.Id).ToList(); //vraca jedan svakako
                    foreach(Tim team in teams)
                    {
                        if (team != null)
                        {
                            team.VodjaTima = null;
                        }
                    }


                    db.Zaposleni.Remove(item);
                    db.SaveChanges();
                }
                LoadZaposleni(grid);
            }
        }

        private bool DeleteFromData(DataGrid grid)
        {
            if (grid.SelectedItem != null)
            {
                grid.Items.Remove(grid.SelectedItem);
                return true;
            }
            return false;
        }
    }
}
