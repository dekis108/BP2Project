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
        public List<MobilniViewModel> DataMobilni { get; private set; }

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
                    DataRacunar.Add(new RacunarViewModel(item));
                }

                grid.ItemsSource = DataRacunar;
            }
        }


        internal void LoadMobilni(DataGrid grid)
        {
            using (var db = new ProjectModelContainer())
            {
                var list = db.Hardveri.Where(x => x is Mobilni);

                DataMobilni = new List<MobilniViewModel>();
                foreach (Mobilni item in list)
                {
                    DataMobilni.Add(new MobilniViewModel(item));
                }

                grid.ItemsSource = DataMobilni;
            }
        }
    }
}
