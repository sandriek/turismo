using System;
using System.Collections.Generic;
using System.Linq;
using Turismo.Components;
using Turismo.Objects;
using Windows.Devices.Geolocation;

namespace Turismo.Data
{
    public class CurrentSession
    {
        public Geoposition CurrentLocation;
        public List<Location> FollowedRoute;
        public Route CurrentRoute;

        public Language _currentLanguage;

        public Language CurrentLanguage
        {
            get { return _currentLanguage; }
            set { _currentLanguage = value; LanguagedIsChanged();  }
        }
        
        public CurrentSession()
        {
            FollowedRoute = new List<Location>();
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

        public List<Location> GetToFollowRoute()
        {
            List<Location> ToFollow = new List<Location>();

            if (CurrentRoute != null && FollowedRoute.Any())
            {
                ToFollow = CurrentRoute.LocationList.Except(FollowedRoute).ToList();
            }

            return ToFollow;
        }
    }
}
