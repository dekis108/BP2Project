using DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.ViewModel.DataGridClasses
{
    public class MobilniViewModel
    {
        public string SH { get; set; }

        public decimal MDIM { get; set; }

        public string OS { get; set; }

        public string Dispecer_Id { get; set; }

        public MobilniViewModel(Mobilni og)
        {
            SH = og.SH;
            MDIM = og.MDIM;
            OS = og.OS;
            Dispecer_Id = og.Dispecer.Id;
        }
    }
}
