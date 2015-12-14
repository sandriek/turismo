using System;
using System.Collections.Generic;
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
        private Geoposition CurrentLocation;
        private List<Location> FollowedRoute;
        private Route CurrentRoute;
        public Language.language CurrentLanguage { get; set; }

        public CurrentSession()
        {

        }

        public void SwitchLanguage()
        {

        }
    }
}
