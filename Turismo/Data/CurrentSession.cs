using System;
using System.Collections.Generic;
using Turismo.Components;
using Turismo.Objects;
using Windows.Devices.Geolocation;

namespace Turismo.Data
{
    public class CurrentSession
    {
        private Geoposition CurrentLocation;
        private List<Location> FollowedRoute;
        private Route CurrentRoute;

        private Language _currentLanguage;

        public Language CurrentLanguage
        {
            get { return _currentLanguage; }
            set { _currentLanguage = value; LanguagedIsChanged();  }
        }
        
        public CurrentSession()
        {

        }

        public void SwitchLanguage(string newLang)
        {
            switch(newLang)
            {
                case "NL": CurrentLanguage = Language.NL; break;
                case "EN": CurrentLanguage = Language.EN; break;
            }
        }


        public static event EventHandler LanguageChanged;
        public static void LanguagedIsChanged()
        {
            var handler = LanguageChanged;
            if(handler != null)
            {
                //Debug.WriteLine("Language is changed");
                handler(null, new EventArgs());
            }
        }
    }
}
