using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.ViewModel.DataGridClasses
{
    public class MenadzerMapViewModel
    {
        public string Menadzer_Id { get; set; }
        public string TimRadiNaProjektu_Id { get; set; }

        public MenadzerMapViewModel(string mId, string tId)
        {
            Menadzer_Id = mId;
            TimRadiNaProjektu_Id = tId;
        }
    }
}
