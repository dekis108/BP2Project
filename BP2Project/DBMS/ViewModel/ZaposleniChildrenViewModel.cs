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

        public List<Dispecer> DataDispecer { get; private set; }
        public List<AdminViewModel> DataAdmin { get; private set; }

        public List<Menadzer> DataMenadzer { get; private set; }

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
    }
}
