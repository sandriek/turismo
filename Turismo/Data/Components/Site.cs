using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;
using Turismo.Objects;
using Windows.UI.Xaml.Controls;
using Turismo.Data.Objects;
using System.IO;
using System.Diagnostics;

namespace Turismo.Components
{
    public class Site : Location
    {
        public int id { get; set; }
        public string Name { get; }
        public BasicGeoposition Position { get; }
        public Geofence Fence { get; set; }
        public MultipleLanguageString Description { get; private set; }

        public Site(int id, string name, BasicGeoposition Position)
        {
            this.id = id;
            this.Name = name;            
            this.Position = Position;            
            SetDescription();
            AddFence();
        }

        public void AddFence()
        {
            // Replace if it already exists for this maneuver key
            var oldFence = GeofenceMonitor.Current.Geofences.Where(p => p.Id == id.ToString()).FirstOrDefault();
            if (oldFence != null)
            {
                GeofenceMonitor.Current.Geofences.Remove(oldFence);
            }

            Geocircle geocircle = new Geocircle(Position, 25);

            bool singleUse = true;

            MonitoredGeofenceStates mask = 0;

            mask |= MonitoredGeofenceStates.Entered;

            var geofence = new Geofence(id.ToString(), geocircle, mask, singleUse, TimeSpan.FromSeconds(1));
            GeofenceMonitor.Current.Geofences.Add(geofence);
            Fence = geofence;
        }

        private void SetDescription()
        {
            string nl = "";
            string en = "";

            //Debug.WriteLine($"Strings are first time set: {nl},{en}");

            nl = GetText("_nl");
            en = GetText("_en");

            //Debug.WriteLine($"Strings are second time set: {nl},{en}");

            if (string.IsNullOrEmpty(nl))
            {
                nl = "Er is over deze bezienswaardigheid geen extra informatie";
            }
            if (string.IsNullOrEmpty(en))
            {
                en = "There is no information about this sight";
            }
            //Debug.WriteLine($"Strings are third time set: {nl},{en}");
            Description = new MultipleLanguageString(nl, en);
        }

        private string GetText(string language)
        {
            string linkText = "Pages/Text/" + Name+language + ".txt";
            if (File.Exists(linkText))
            {
                string[] route = File.ReadAllLines(linkText);
                string text = "";
                foreach (string s in route)
                {
                    text += s + Environment.NewLine;
                }
                return text;
            }
            else
            {
                return string.Empty;
            }
        }        
    }
}
