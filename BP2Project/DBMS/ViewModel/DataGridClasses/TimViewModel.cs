using DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.ViewModel.DataGridClasses
{
    public class TimViewModel
    {   
        public string ST { get; set; }
        public string PR { get; set; }

        public virtual string VodjaTima { get; set; }

        public virtual string Nadredjeni { get; set; }

        public TimViewModel(Tim og)
        {
            ST = og.ST;
            PR = og.PR;
            VodjaTima = og.VodjaTima?.Id;
            Nadredjeni = og.Nadredjeni?.ST;
        }
    }
}
