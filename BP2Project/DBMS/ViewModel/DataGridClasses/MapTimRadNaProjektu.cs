using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.ViewModel.DataGridClasses
{
    public class MapTimRadNaProjektu
    {
        public string TimRadiNaProjektu;
        public string Tim;

        public MapTimRadNaProjektu(string radiNa, string tim)
        {
            TimRadiNaProjektu = radiNa;
            Tim = tim;
        }
    }
}
