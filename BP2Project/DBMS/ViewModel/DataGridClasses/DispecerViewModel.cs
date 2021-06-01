using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.ViewModel.DataGridClasses
{
    public class DispecerViewModel
    {
        public string Id { get; set; }

        public DispecerViewModel(string Id)
        {
            this.Id = Id;
        }
    }
}
