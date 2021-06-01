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

        public List<HardverViewModel> DataHardver { get; private set; }

        public List<TimViewModel> DataTim { get; private set; }

        public List<ProjekatViewModel> DataProjekat { get; private set; }

        public List<TimRadiNaProjektuViewModel> DataTimRadiNaProjektu { get; private set; }

        public List<MapTimRadNaProjektu> DataMap { get; private set; }

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
                DataHardver = new List<HardverViewModel>();
                foreach (var item in db.Hardveri)
                {
                    DataHardver.Add(new HardverViewModel(item));
                }

                grid.ItemsSource = DataHardver;
            }
        }

        internal void LoadTim(DataGrid grid)
        {
            using (var db = new ProjectModelContainer())
            {
                DataTim = new List<TimViewModel>();
                foreach (var item in db.Timovi)
                {
                    DataTim.Add(new TimViewModel(item));
                }

                grid.ItemsSource = DataTim;
            }
        }

        internal void LoadProjekat(DataGrid grid)
        {
            using (var db = new ProjectModelContainer())
            {
                DataProjekat = new List<ProjekatViewModel>();
                foreach (var item in db.Projekti)
                {
                    DataProjekat.Add(new ProjekatViewModel(item));
                }

                grid.ItemsSource = DataProjekat;
            }
        }

        internal void LoadTimRadiNaProjektu(DataGrid grid)
        {
            using (var db = new ProjectModelContainer())
            {
                DataTimRadiNaProjektu = new List<TimRadiNaProjektuViewModel>();
                foreach (var item in db.TimRadiNaProjektu)
                {
                    DataTimRadiNaProjektu.Add(new TimRadiNaProjektuViewModel(item));
                }

                grid.ItemsSource = DataTimRadiNaProjektu;
            }
        }

        internal void LoadMap(DataGrid grid)
        {
            using (var db = new ProjectModelContainer())
            {
                DataMap = new List<MapTimRadNaProjektu>();

                foreach(var team in db.Timovi)
                {
                    foreach(var radiNa in team.TimRadiNaProjektu)
                    {
                        DataMap.Add(new MapTimRadNaProjektu(radiNa.Id, team.ST));
                    }
                }

                grid.ItemsSource = DataMap;
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
                    var teams = db.Timovi.Where(x => x.VodjaTima.Id == item.Id); //vraca jedan svakako
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
