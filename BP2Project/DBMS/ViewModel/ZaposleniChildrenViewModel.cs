using DatabaseModel;
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
        public List<Programer> DataProgramer { get; private set; }

        public List<Dispecer> DataDispecer { get; private set; }
        public List<Admin> DataAdmin { get; private set; }

        public List<Menadzer> DataMenadzer { get; private set; }

        public ZaposleniChildrenViewModel()
        {
            DataAdmin = new List<Admin>();
            DataDispecer = new List<Dispecer>();
            DataProgramer = new List<Programer>();
            DataMenadzer = new List<Menadzer>();
        }

        internal void LoadProgramer(DataGrid grid)
        {
            using (var db = new ProjectModelContainer())
            {
                var list = db.Zaposleni.Where(x => x is Programer).ToList();

                DataProgramer.Clear();
                foreach( var programer in list)
                {
                    DataProgramer.Add((Programer)programer);
                }

                grid.ItemsSource = DataProgramer;
            }
        }
    }
}
