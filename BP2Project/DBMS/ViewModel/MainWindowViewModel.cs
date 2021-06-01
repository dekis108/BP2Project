using DatabaseModel;
using DBMS.ViewModel.DataGridClasses;
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
        public List<ZaposleniViewModel> DataZaposleni { get; private set;}

        public List<PoslovniProstorViewModel> DataProstor { get; private set; }

        public List<Hardver> DataHardver { get; private set; }

        public List<Tim> DataTim { get; private set; }

        public List<Projekat> DataProjekat { get; private set; }

        public List<TimRadiNaProjektu> DataTimRadiNaProjektu { get; private set; }

        public MainWindowViewModel() {}



        internal void LoadZaposleni(DataGrid gridZaposleni)
        {
            using (var db = new ProjectModelContainer())
            {
                DataZaposleni = new List<ZaposleniViewModel>();
                foreach(var zaposleni in  db.Zaposleni)
                {
                    DataZaposleni.Add(new ZaposleniViewModel(zaposleni));
                }
                    
                gridZaposleni.ItemsSource = DataZaposleni;
            }
        }

        internal void LoadProstor(DataGrid grid)
        {
            using (var db = new ProjectModelContainer())
            {
                DataProstor = new List<PoslovniProstorViewModel>();
                foreach (var item in db.PoslovniProstori)
                {
                    DataProstor.Add(new PoslovniProstorViewModel(item));
                }

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
            ZaposleniViewModel itemViewModel = (ZaposleniViewModel)grid.SelectedItem;
            if (itemViewModel != null)
            {
                using (var db = new ProjectModelContainer())
                {
                    Zaposleni item = db.Zaposleni.Find(itemViewModel.Id);
                    //db.Zaposleni.Attach(item);

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
    }
}
