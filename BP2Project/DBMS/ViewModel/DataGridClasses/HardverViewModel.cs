using DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.ViewModel.DataGridClasses
{
    public class HardverViewModel
    {
        public string SH { get; set; }
        public string CPU { get; set; }
        public int? RAM { get; set; }
        public int? HDD { get; set; }

        public HardverViewModel(Hardver og)
        {
            SH = og.SH;
            CPU = og.CPU;
            RAM = og.RAM;
            HDD = og.HDD;
        }
    }
}
