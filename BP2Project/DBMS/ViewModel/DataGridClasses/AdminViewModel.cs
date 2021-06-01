using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBMS.ViewModel.DataGridClasses
{
    public class AdminViewModel
    {
        public string Id { get; set; }
        public string NPR { get; set; }

        public AdminViewModel(string Id, string NPR)
        {
            this.Id = Id;
            this.NPR = NPR;
        }
    }
}
