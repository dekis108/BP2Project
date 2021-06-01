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

        public RacunarViewModel(string SH, string VM)
        {
            this.SH = SH;
            this.VM = VM;
        }
    }
}
