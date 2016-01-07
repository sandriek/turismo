using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turismo.Data;
using Turismo.Data.Objects;

namespace Turismo.ViewModels
{
    public class TaalSchermViewModel : ViewModel<TaalSchermViewModel>
    {

        public MultipleLanguageString Title { get; }        

        public TaalSchermViewModel()
        {
            Title = new MultipleLanguageString("Kies een taal", "Choose a language");             
        }        
    }
}
