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
    public class ZaposleniChildrenViewModel
    {
        public List<ProgramerViewModel> DataProgramer { get; private set; }

        public List<DispecerViewModel> DataDispecer { get; private set; }
        public List<AdminViewModel> DataAdmin { get; private set; }

        public List<MenadzerViewModel> DataMenadzer { get; private set; }

        public List<MenadzerMapViewModel> DataMap { get; private set; }

        public ZaposleniChildrenViewModel()
        {
        }

        internal void LoadProgramer(DataGrid grid)
        {
            using (var db = new ProjectModelContainer())
            {
                DataProgramer = new List<ProgramerViewModel>();
                var list = db.Zaposleni.Where(x => x is Programer);

                foreach (Programer item in list)
                {
                    DataProgramer.Add(new ProgramerViewModel(item.Id, item.O_PROD, item.ClanTima.ST));
                }

                grid.ItemsSource = DataProgramer;
            }
        }

        internal void LoadAdmin(DataGrid grid)
        {
            using (var db = new ProjectModelContainer())
            {
                DataAdmin = new List<AdminViewModel>();
                var list = db.Zaposleni.Where(x => x is Admin);

                foreach (Admin item in list)
                {
                    DataAdmin.Add(new AdminViewModel(item.Id, item.NPR));
                }

                grid.ItemsSource = DataAdmin;
            }
        }

        internal void LoadMenadzer(DataGrid grid)
        {
            using (var db = new ProjectModelContainer())
            {
                DataMenadzer = new List<MenadzerViewModel>();
                var list = db.Zaposleni.Where(x => x is Menadzer);

                foreach (Menadzer item in list)
                {
                    DataMenadzer.Add(new MenadzerViewModel(item.Id));
                }

                grid.ItemsSource = DataMenadzer;
            }
        }

        internal void DispecerDelete(DataGrid grid)
        {
            DispecerViewModel itemViewModel = (DispecerViewModel)grid.SelectedItem;
            if (itemViewModel != null)
            {
                using (var db = new ProjectModelContainer())
                {
                    Zaposleni item = db.Zaposleni.Find(itemViewModel.Id);
                    //db.Zaposleni.Attach(item);

                    //skloni moblnima da ne pripadaju ovom dispeceru
                    var list = db.Hardveri.Where(x => x is Mobilni);
                    foreach(Mobilni mobilni in list)
                    {
                        if (mobilni != null && mobilni.Dispecer.Id == item.Id)
                        {
                            mobilni.Dispecer = null;
                        }
                    }

                    db.Zaposleni.Remove(item);
                    db.SaveChanges();
                }
                LoadDispecer(grid);
            }
        }

        internal void MapDelete(DataGrid grid)
        {
            MenadzerMapViewModel itemViewModel = (MenadzerMapViewModel)grid.SelectedItem;
            if (itemViewModel != null)
            {
                using (var db = new ProjectModelContainer())
                {
                    Zaposleni item = db.Zaposleni.Find(itemViewModel.Menadzer_Id);
                    if (item == null) return;
                    //db.Zaposleni.Attach(item);
                    Menadzer menadzer = (Menadzer)item;
                    TimRadiNaProjektu gerund = (TimRadiNaProjektu)db.TimRadiNaProjektu.Find(itemViewModel.TimRadiNaProjektu_Id);
                    db.TimRadiNaProjektu.Attach(gerund);
                    menadzer.TimRadiNaProjektus.Remove(gerund);




                    //db.Zaposleni.Remove(item);
                    db.SaveChanges();
                }
                LoadAdmin(grid);
            }
        }

        internal void LoadMap(DataGrid grid)
        {
            using (var db = new ProjectModelContainer())
            {
                DataMap = new List<MenadzerMapViewModel>();
                var list = db.Zaposleni.Where(x => x is Menadzer);

                foreach (Menadzer item in list)
                {
                    foreach (var projekti in item.TimRadiNaProjektus)
                    {
                        DataMap.Add(new MenadzerMapViewModel(item.Id, projekti.Id));
                    }
                }
                grid.ItemsSource = DataMap;
            }
        }

        internal void AdminDelete(DataGrid grid)
        {
            AdminViewModel itemViewModel = (AdminViewModel)grid.SelectedItem;
            if (itemViewModel != null)
            {
                using (var db = new ProjectModelContainer())
                {
                    Zaposleni item = db.Zaposleni.Find(itemViewModel.Id);
                    db.Zaposleni.Attach(item);

                    db.Zaposleni.Remove(item);
                    db.SaveChanges();
                }
                LoadAdmin(grid);
            }
        }

        internal void LoadDispecer(DataGrid grid)
        {
            using (var db = new ProjectModelContainer())
            {
                DataDispecer = new List<DispecerViewModel>();
                var list = db.Zaposleni.Where(x => x is Dispecer);

                foreach (Dispecer item in list)
                {
                    DataDispecer.Add(new DispecerViewModel(item.Id));
                }

                grid.ItemsSource = DataDispecer;
            }
        }

        internal void MenadzerDelete(DataGrid grid)
        {
            MenadzerViewModel itemViewModel = (MenadzerViewModel)grid.SelectedItem;
            if (itemViewModel != null)
            {
                using (var db = new ProjectModelContainer())
                {
                    Zaposleni item = db.Zaposleni.Find(itemViewModel.Id);
                    db.Zaposleni.Attach(item);
                    //TODO iz mape menadzer <-> gerund izbaci


                    db.Zaposleni.Remove(item);
                    db.SaveChanges();
                }
                LoadDispecer(grid);
            }
        }

        internal void ProgramerDelete(DataGrid grid)
        {
            ProgramerViewModel itemViewModel = (ProgramerViewModel)grid.SelectedItem;
            if (itemViewModel != null)
            {
                using (var db = new ProjectModelContainer())
                {
                    Zaposleni item = db.Zaposleni.Find(itemViewModel.Id);
                    //db.Zaposleni.Attach(item);

                    //skloni ga da nije sef timu
                    var teams = db.Timovi.Where(x => x.VodjaTima.Id == item.Id); //vraca jedan svakako
                    foreach (Tim team in teams)
                    {
                        if (team != null)
                        {
                            team.VodjaTima = null;
                        }
                    }


                    db.Zaposleni.Remove(item);
                    db.SaveChanges();
                }
                LoadProgramer(grid);
            }
        }
    }
}
