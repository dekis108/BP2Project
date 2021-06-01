using DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DBMS.ViewModel.DataGridClasses
{
    public class MobilniPickerViewModel
    {
        public List<MobilniCreateViewModel> DataMobilni { get; private set; }

        List<MobilniCreateViewModel> listaMobilni;

        public MobilniPickerViewModel(List<MobilniCreateViewModel> outList)
        {
            listaMobilni = outList;
        }
        public void LoadMobilni(DataGrid grid)
        {
            using (var db = new ProjectModelContainer())
            {
                var list = db.Hardveri.Where(x => x is Mobilni);

                DataMobilni = new List<MobilniCreateViewModel>();
                foreach (Mobilni item in list)
                {
                    if (item.Dispecer != null) continue;

                   

                    DataMobilni.Add(new MobilniCreateViewModel(item));
                }

                foreach(var item in listaMobilni)
                {
                    foreach(var mob in DataMobilni)
                    {
                        if (mob.SH == item.SH)
                        {
                            mob.Selected = true;
                        }
                    }
                }


                grid.ItemsSource = DataMobilni;
            }
        }

        internal void GetSelection()
        {
            var list = DataMobilni.Where(x => x.Selected).ToList();
            foreach(var x in list)
            {
                listaMobilni.Add(x);
            }
        }

    }
}
