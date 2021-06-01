using DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.ViewModel.DataGridClasses
{
    public class RacunarViewModel
    {
        public string SH { get; set; }
        public string VM { get; set; }

        public string PoslovniProstor_SP { get; set; }

        public RacunarViewModel(Racunar og)
        {
            SH = og.SH;
            VM = og.VM;
            PoslovniProstor_SP = og.PoslovniProstor?.SP;
        }
    }
}
