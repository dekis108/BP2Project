using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.ViewModel.DataGridClasses
{
    public class MapTimRadNaProjektu
    {
        public string TimRadiNaProjektu { get; set; }
        public string Tim { get; set; }

        public MapTimRadNaProjektu(string radiNa, string tim)
        {
            TimRadiNaProjektu = radiNa;
            Tim = tim;
        }
    }
}
