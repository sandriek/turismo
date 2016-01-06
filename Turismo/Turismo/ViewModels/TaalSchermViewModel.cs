using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turismo.Data;
using Turismo.Data.Objects;

namespace Turismo.ViewModels
{
    public class TaalSchermViewModel
    {
        private static TaalSchermViewModel _instance;
        public static TaalSchermViewModel Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new TaalSchermViewModel();
                }
                return _instance;
            }
        }


        private TaalSchermViewModel()
        {
            Title = new MutipleLanguageString("Kies een taal", "Choose a language");
            CurrentSession.LanguageChanged += CurrentSession_LanguageChanged;
        }

        private void CurrentSession_LanguageChanged(object sender, EventArgs e)
        {
            Title.SetText();
        }

        public MutipleLanguageString Title { get; }
    }
}
