using DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.ViewModel.DataGridClasses
{
    public class ProgramerViewModel
    {
        public string Id { get; set; }
        public int? O_PROD { get; set; }
        public string ClanTima_ST { get; set; }
        public ProgramerViewModel(Programer og) 
        {
            Id = og.Id;
            this.O_PROD = og.O_PROD;
            this.ClanTima_ST = og.ClanTima?.ST;
        }
    }
}
