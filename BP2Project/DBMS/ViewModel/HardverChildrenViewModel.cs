using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseModel.Model;
using DatabaseModel;
using System.Windows.Controls;

namespace DBMS.ViewModel
{
    class HardverChildrenViewModel
    {
        public List<Racunar> DataRacunar { get; private set; }
        public List<Mobilni> DataMobilni { get; private set; }

        public HardverChildrenViewModel()
        {

        }

        internal void LoadRacunar(DataGrid grid)
        {
            using (var db = new ProjectModelContainer())
            {
                var list = db.Hardveri.Where(x => x is Racunar).ToList();

                DataRacunar.Clear();
                foreach (var x in list)
                {
                    DataRacunar.Add((Racunar)x);
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
