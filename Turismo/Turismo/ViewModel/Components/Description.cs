using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turismo.ViewModel.Components
{
    interface Description
    {
        string Description { get; set; }
        List<string> AudioList { get; set; }
    }
}
