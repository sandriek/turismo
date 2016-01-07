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

        protected override void CurrentSession_LanguageChanged(object sender, EventArgs e)
        {
            base.CurrentSession_LanguageChanged(sender, e);
            Title.SetText();
        }
    }
}
