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


                if (listaMobilni.Count == 0)
                {
                    foreach (Mobilni item in list)
                    {
                        if (item.Dispecer != null) continue;



                        listaMobilni.Add(new MobilniCreateViewModel(item));
                    }
                }

                grid.ItemsSource = listaMobilni;
            }
        }

        public static void FillFreeMobilni(List<MobilniCreateViewModel> listaM)
        {
            using (var db = new ProjectModelContainer())
            {
                var list = db.Hardveri.Where(x => x is Mobilni);

                foreach (Mobilni item in list)
                {
                    if (item.Dispecer != null || listaM.Where(x=>x.SH == item.SH).Any()) continue;



                    listaM.Add(new MobilniCreateViewModel(item));
                }

            }
        }
    }
}
