using DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DBMS.ViewModel.DataGridClasses
{
    public class MobilniCreateViewModel : MobilniViewModel
    {
        public bool Selected { get; set; }

        public MobilniCreateViewModel(Mobilni og) : base(og)
        {
            Selected = false;
        }
    }
}
