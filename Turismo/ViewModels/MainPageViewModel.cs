using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turismo.Data;
using Turismo.Data.Objects;

namespace Turismo.ViewModels
{
    public class MainPageViewModel : Singleton<MainPageViewModel>
    {
        public MultipleLanguageString TaalKnopLabel { get; }
        public MultipleLanguageString RouteKnopLabel { get; }
        public MultipleLanguageString KaartKnopLabel { get; }

        public MainPageViewModel()
        {
            TaalKnopLabel = new MultipleLanguageString("Taal selecteren", "Select language");
            RouteKnopLabel = new MultipleLanguageString("Route selecteren", "Select route");
            KaartKnopLabel = new MultipleLanguageString("Naar kaart", "To map");
            CurrentSession.LanguageChanged += CurrentSession_LanguageChanged;
        }

        private void CurrentSession_LanguageChanged(object sender, EventArgs e)
        {           
            TaalKnopLabel.SetText();
            RouteKnopLabel.SetText();
            KaartKnopLabel.SetText();
        }
    }
}
