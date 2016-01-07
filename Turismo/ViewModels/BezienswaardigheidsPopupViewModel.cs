using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turismo.Components;

namespace Turismo.ViewModels
{
    public class BezienswaardigheidsPopupViewModel
    {
        private static BezienswaardigheidsPopupViewModel _instance;
        public static BezienswaardigheidsPopupViewModel Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new BezienswaardigheidsPopupViewModel();
                }
                return _instance;
            }
        }

        private Site _currentSite;
        public Site CurrentSite
        {
            get { return _currentSite; }
            set { _currentSite = value; }
        }


        private BezienswaardigheidsPopupViewModel()
        {
            CurrentSite = new Site("Kasteel van Breda", new Windows.Devices.Geolocation.BasicGeoposition());
        }
    }
}
