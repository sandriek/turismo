using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turismo.Data;
using Turismo.Data.Objects;

namespace Turismo.ViewModels
{
    public class KaartSchermViewModel : Singleton<KaartSchermViewModel>
    {
        public MultipleLanguageString TaalKnopLabel { get; }
        public MultipleLanguageString RouteKnopLabel { get; }

        public KaartSchermViewModel()
        {
            TaalKnopLabel = new MultipleLanguageString("Taal selecteren", "Select language");
            RouteKnopLabel = new MultipleLanguageString("Route selecteren", "Select route");
            CurrentSession.LanguageChanged += CurrentSession_LanguageChanged;
        }

        private void CurrentSession_LanguageChanged(object sender, EventArgs e)
        {
            TaalKnopLabel.SetText();
            RouteKnopLabel.SetText();
        }
    }
}
