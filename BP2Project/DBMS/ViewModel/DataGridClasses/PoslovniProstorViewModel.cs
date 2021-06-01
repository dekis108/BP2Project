using DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.ViewModel.DataGridClasses
{
    public class PoslovniProstorViewModel
    {
        public string SP { get; set; }
        public decimal DIM { get; set; }
        public int? BRM { get; set; }

        public PoslovniProstorViewModel(PoslovniProstor og)
        {
            SP = og.SP;
            DIM = og.DIM;
            BRM = og.BRM;
        }
    }
}
