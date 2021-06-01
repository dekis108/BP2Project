using DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.ViewModel.DataGridClasses
{
    public class ProjekatViewModel
    {
        public string SP { get; set; }
        public DateTime DD { get; set; }
        public DateTime? DP { get; set; }
        public DateTime? RI { get; set; }
        public int? KI { get; set; }
        public string SZ { get; set; }

        public virtual string TimRadiNaProjektu { get; set; }

        public ProjekatViewModel(Projekat og)
        {
            SP = og.SP;
            DD = og.DD;
            DP = og.DP;
            RI = og.RI;
            KI = og.KI;
            SZ = og.SZ;
            TimRadiNaProjektu = og.TimRadiNaProjektus?.Id;
        }
    }
}
