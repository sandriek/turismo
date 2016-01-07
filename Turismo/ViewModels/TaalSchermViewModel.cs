using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turismo.Data;
using Turismo.Data.Objects;

namespace Turismo.ViewModels
{
    public class TaalSchermViewModel : Singleton<TaalSchermViewModel>
    {        
        public TaalSchermViewModel()
        {
            Title = new MultipleLanguageString("Kies een taal", "Choose a language");
            CurrentSession.LanguageChanged += CurrentSession_LanguageChanged;
        }

        private void CurrentSession_LanguageChanged(object sender, EventArgs e)
        {
            Title.SetText();
        }

        public MultipleLanguageString Title { get; }
    }
}
