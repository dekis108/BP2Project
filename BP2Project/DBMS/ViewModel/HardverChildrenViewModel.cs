using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseModel.Model;
using DatabaseModel;
using System.Windows.Controls;
using DBMS.ViewModel.DataGridClasses;

namespace DBMS.ViewModel
{
    class HardverChildrenViewModel
    {
        public List<RacunarViewModel> DataRacunar { get; private set; }
        public List<Mobilni> DataMobilni { get; private set; }

        public HardverChildrenViewModel()
        {

        }

        internal void LoadRacunar(DataGrid grid)
        {
            using (var db = new ProjectModelContainer())
            {
                var list = db.Hardveri.Where(x => x is Racunar);

                DataRacunar = new List<RacunarViewModel>();
                foreach (Racunar item in list)
                {
                    DataRacunar.Add(new RacunarViewModel(item.SH, item.VM));
                }

                grid.ItemsSource = DataRacunar;
            }
        }


        internal void LoadMobilni(DataGrid grid)
        {
            using (var db = new ProjectModelContainer())
            {
                var list = db.Hardveri.Where(x => x is Mobilni).ToList();

                DataMobilni.Clear();
                foreach (var x in list)
                {
                    DataMobilni.Add((Mobilni)x);
                }

                grid.ItemsSource = DataMobilni;
            }
        }
    }
}
