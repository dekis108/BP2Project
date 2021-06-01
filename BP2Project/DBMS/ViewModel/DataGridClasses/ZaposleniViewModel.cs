using DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.ViewModel.DataGridClasses
{
    public class ZaposleniViewModel
    {
        public string Id { get; set; }
        public DateTime? D_ZAP { get; set; }
        public int PLAT { get; set; }

        public virtual string PoslovniProstor { get; set; }

        public ZaposleniViewModel(Zaposleni og)
        {
            Id = og.Id;
            D_ZAP = og.D_ZAP;
            PLAT = og.PLAT;
            PoslovniProstor = og.PoslovniProstor?.SP;
        }
    }
}
