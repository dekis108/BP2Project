using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.ViewModel.DataGridClasses
{
    public class MenadzerViewModel
    {
        public string Id { get; set; }

        public MenadzerViewModel(string Id)
        {
            this.Id = Id;
        }
    }
}
