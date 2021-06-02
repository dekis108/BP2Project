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

        internal void ProstorDelete(DataGrid grid)
        {
            PoslovniProstorViewModel itemViewModel = (PoslovniProstorViewModel)grid.SelectedItem;
            if (itemViewModel != null)
            {
                using (var db = new ProjectModelContainer())
                {
                    PoslovniProstor item = db.PoslovniProstori.Find(itemViewModel.SP);
                    //db.Zaposleni.Attach(item);

                    //remove this room from zaposleni and racunari
                    var zaposleni = item.Zaposleni.ToList();
                    var racunari = item.Racunari.ToList();

                    for(int i = 0; i < zaposleni.Count; ++i)
                    {
                        zaposleni[i].PoslovniProstor = null;
                    }
                    for(int i = 0; i < racunari.Count; ++i)
                    {
                        racunari[i].PoslovniProstor = null;
                    }

                    db.PoslovniProstori.Remove(item);
                    db.SaveChanges();
                }
                LoadProstor(grid);
            }
        }

        internal void ProjekatDelete(DataGrid grid)
        {
            ProjekatViewModel itemViewModel = (ProjekatViewModel)grid.SelectedItem;
            if (itemViewModel != null)
            {
                using (var db = new ProjectModelContainer())
                {
                    Projekat item = db.Projekti.Find(itemViewModel.SP);
                    //db.Hardveri.Attach(item);

                    var temp = item.TimRadiNaProjektus;
                    temp.Tim.Clear();
                    temp.Projekat = null;
                    temp.Menadzer.Clear();
                    db.TimRadiNaProjektu.Remove(temp);
                    //item.TimRadiNaProjektus = null;


                    db.Projekti.Remove(item);
                    db.SaveChanges();
                }
                LoadProjekat(grid);
            }
        }

        internal void CalcAvg()
        {
            using (var db = new ProjectModelContainer())
            {
                var result = db.Database.ExecuteSqlCommand("FunctionCounting");
            }
        }

        internal void AssignRoomsProcedure()
        {
            using (var db = new ProjectModelContainer())
            {
                var result = db.Database.ExecuteSqlCommand("RoomCursor");            
            }
        }

        internal void IncrementOZ()
        {
            using (var db = new ProjectModelContainer())
            {
                var result = db.Database.ExecuteSqlCommand("IncrementOZ");
            }
        }

        internal void Count()
        {
            using (var db = new ProjectModelContainer())
            {
                var result = db.Database.ExecuteSqlCommand("FunctionCounting");
            }
        }

        internal void TimDelete(DataGrid grid)
        {
            TimViewModel itemViewModel = (TimViewModel)grid.SelectedItem;
            if (itemViewModel != null)
            {
                using (var db = new ProjectModelContainer())
                {
                    Tim item = db.Timovi.Find(itemViewModel.ST);
                    //db.Hardveri.Attach(item);

                    item.Programeri.Clear();
                    item.TimRadiNaProjektu.Clear();
                    item.PodredjeniTimovi.Clear();

                    db.Timovi.Remove(item);
                    db.SaveChanges();
                }
                LoadTim(grid);
            }
        }

        internal void HardverDelete(DataGrid grid)
        {
            HardverViewModel itemViewModel = (HardverViewModel)grid.SelectedItem;
            if (itemViewModel != null)
            {
                using (var db = new ProjectModelContainer())
                {
                    Hardver item = db.Hardveri.Find(itemViewModel.SH);
                    db.Hardveri.Attach(item);


                    db.Hardveri.Remove(item);
                    db.SaveChanges();
                }
                LoadHardver(grid);
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
                    if (item is Programer)
                    {
                        var teams = db.Timovi.Where(x => x.VodjaTima.Id == item.Id);
                        foreach (Tim team in teams)
                        {
                            if (team != null)
                            {
                                team.VodjaTima = null;
                            }
                        }
                    }
                    else if (item is Dispecer) //remove reference from Mobilni
                    {
                        var mobilni = ((Dispecer)item).Mobilni.ToList();
                        for(int i = 0; i < mobilni.Count; ++i)
                        {
                            mobilni[i].Dispecer = null;
                        }
                    }
                    else if (item is Menadzer) //remove from overlook
                    {
                        ((Menadzer)item).TimRadiNaProjektus.Clear();
                    }


                    db.Zaposleni.Remove(item);
                    db.SaveChanges();
                }
                LoadZaposleni(grid);
            }
        }
    }
}
