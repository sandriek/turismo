using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turismo.ViewModel.Components;

namespace Turismo.ViewModel.Objects
{
    class Route
    {
        string Name { get; set; }
        private List<Location> LocationList;
        Description _Description { get; set; }
        Category _Category { get; set; }
    }
}
