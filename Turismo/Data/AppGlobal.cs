using System;
using System.Collections.Generic;
using Turismo.Components;
using Turismo.Data.Objects;
using Turismo.Library;
using Turismo.Objects;
using Turismo.ViewModels;

namespace Turismo.Data
{
    public class AppGlobal
    {
        public static AppGlobal _Instance;
        public GeoUtil _GeoUtil;
        public List<Site> SiteList;
        public List<Route> RouteList;
        public CurrentSession _CurrentSession;
        protected List<Help> HelpDescriptionList;
        public BezienswaardigheidsPopupViewModel popup;

        public static AppGlobal Instance { get { return _Instance ?? (_Instance = new AppGlobal()); } }

        public AppGlobal()
        {
            _GeoUtil = new GeoUtil();
            SiteList = new List<Site>();
            RouteList = new List<Route>();
            _CurrentSession = new CurrentSession();
            HelpDescriptionList = new List<Help>();
        }

        public void InitializeRoute()
        {
            //Nieuwe route aanmaken
            this.RouteList.Add(new Route(
                "HistorischeRoute", 
                new MultipleLanguageString("Een route langs historische gebouwen in Breda.","A route passing historical buildings found in Breda."), 
                4, 
                Category.category.Historical));
            this.RouteList.Add(new Route(
    "Route2",
    new MultipleLanguageString(" Navigatie terug naar de VVV", "Navigation back to the VVV."),
    2,
    Category.category.Historical));
        }

    }
}
