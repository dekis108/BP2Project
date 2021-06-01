using DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.ViewModel.DataGridClasses
{
    public class TimRadiNaProjektuViewModel
    {
        public string Id { get; set; }

        public virtual string Projekat { get; set; }
        public decimal OZ { get; set; }
   
        public TimRadiNaProjektuViewModel(TimRadiNaProjektu og)
        {
            Id = og.Id;
            Projekat = og.Projekat.SP;
            OZ = og.OZ;
        }
    }
}
