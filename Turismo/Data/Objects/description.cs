using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turismo.Objects
{
    public interface Description
    {
       string _Description { get; set;}
       List<string> AudioList { get; set;}
    }
}
