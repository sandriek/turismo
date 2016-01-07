using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turismo.Data;
using Turismo.Data.Objects;

namespace Turismo.ViewModels
{
    public abstract class ViewModel<T> where T : ViewModel<T>, new()
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = Activator.CreateInstance<T>();
                }
                return _instance;
            }
        }

        public MultipleLanguageString KaartKnopLabel { get; }
        public MultipleLanguageString TaalKnopLabel { get; }
        public MultipleLanguageString RouteKnopLabel { get; }
        public MultipleLanguageString InfoKnopLabel { get; }
        public MultipleLanguageString PopupLabel { get; }

        public ViewModel()
        {
            KaartKnopLabel = new MultipleLanguageString("Naar kaart", "To map");
            TaalKnopLabel = new MultipleLanguageString("Taal selecteren", "Select language");
            RouteKnopLabel = new MultipleLanguageString("Route selecteren", "Select route");
            InfoKnopLabel = new MultipleLanguageString("Info weergeven", "Show info");
            PopupLabel = new MultipleLanguageString("Bezienswaardigheid popup", "Sights popup");           
        }        
    }
}
