using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Turismo.Components;
using Turismo.Data.Objects;
using Turismo.Objects;
using Windows.Devices.Geolocation;

namespace Turismo.Data
{
    public class CurrentSession
    {
        public Geoposition CurrentLocation;
        public List<Location> FollowedRoute;

        public Route _currentRoute;

        public Route CurrentRoute
        {
            get { return _currentRoute; }
            set { _currentRoute = value; RouteIsChanged(); }
        }

        public static event EventHandler RouteChanged;
        public static void RouteIsChanged()
        {
            var handler = RouteChanged;
            if (handler != null)
            {
                //Debug.WriteLine("Language is changed");
                handler(null, new EventArgs());
            }
        }

        public void SwitchRoute(Route newRoute)
        {
            MultipleLanguageString mls = new MultipleLanguageString("Een route langs historische gebouwen in Breda.", "A route passing historical buildings found in Breda.");
            CurrentRoute = new Route("HistorischeRoute", mls, 1000);
            Debug.WriteLine("Route is changed");
        }

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
