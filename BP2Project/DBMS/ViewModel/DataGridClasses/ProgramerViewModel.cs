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
        public ProgramerViewModel(string id, int? O_PROD, string ClanTima_ST) 
        {
            Id = id;
            this.O_PROD = O_PROD;
            this.ClanTima_ST = ClanTima_ST;
        }
    }
}
