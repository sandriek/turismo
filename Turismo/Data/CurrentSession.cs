using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turismo.Components;
using Turismo.Objects;
using Windows.Devices.Geolocation;

namespace Turismo.Data
{
    public class CurrentSession
    {

        public List<Location> FollowedRoute;
        public Route CurrentRoute;

        public Language CurrentLanguage { get; set; }

        public CurrentSession()
        {

        }

        public List<Location> GetToFollowRoute()
        {
            List<Location> ToFollow = new List<Location>();

            if (CurrentRoute != null && FollowedRoute.Any())
            {
               ToFollow = CurrentRoute.LocationList.Where(current => !FollowedRoute.Any(followed => followed.id == current.id)).ToList();
            }

            return ToFollow;
        }

        public void SwitchLanguage(string newLang)
        {
            switch(newLang)
            {
                case "NL": CurrentLanguage = Language.NL; break;
                case "EN": CurrentLanguage = Language.EN; break;
            }
        }
    }
}
