using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turismo.Data.Objects;

namespace Turismo.ViewModels
{

    public class InfoSchermViewModel : ViewModel<InfoSchermViewModel>
    { 

        public MultipleLanguageString SelfLabel { get; }
        public MultipleLanguageString SiteLabel { get; }
        public MultipleLanguageString TaalSelectLabel { get; }
        public MultipleLanguageString RouteLabel { get; }
        public MultipleLanguageString PauseLabel { get; }
        public MultipleLanguageString TitleText { get; }

        public InfoSchermViewModel()
        {
            SelfLabel = new MultipleLanguageString("Je huidige positie op de kaart", "Your current position on the map");
            SiteLabel = new MultipleLanguageString("Een bezienswaardigheid", "A Sight to visit");
            TaalSelectLabel = new MultipleLanguageString("Door op deze knop te drukken kan je een andere taal selecteren", "To change the language press this button");
            RouteLabel = new MultipleLanguageString("Hier kan je een route selecteren", "Click this button to choose a route");
            PauseLabel = new MultipleLanguageString("Met deze knop pauzeer je het lopen van een route. Dit bespaart batterijspanning. \n Als de applicatie op pauze staat kan je vrij door de map scrollen", "This option will pause the map and will save battery life. \n When the app is paused, you can scroll freely through the map.");
            TitleText = new MultipleLanguageString("Legenda", "Description");
        }
    }
}
