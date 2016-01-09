using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turismo.Data.Objects;
using Turismo.Objects;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Turismo.Components
{
    public class Route
    {
        public string Name;
        public List<Location> LocationList;
        public Category.category Category;
        public List<Site> SiteList;
        public string previewImage;

        public MultipleLanguageString Beschrijving;
        public int Afstand;

        public Route(string name, MultipleLanguageString beschrijving, int afstand, Category.category category)
        {
            Name = name;
            Beschrijving = beschrijving;
            Afstand = afstand;
            Category = category;
            LocationList = new List<Location>();
            SiteList = new List<Site>();
            FillLocationList();
            previewImage = "Pictures/" + SiteList.ElementAt(1).Name + ".jpg";
        }

        private void FillLocationList()
        {
            double NorthLatitude = 0.0, WesternLongitude = 0.0;
            string filename = "Assets/Routes/" + Name + ".txt";
            if (File.Exists(filename))
            {
                string[] route = File.ReadAllLines(filename);
                foreach (string s in route)
                {
                    string[] delen = s.Split(',');

                    try
                    {
                        NorthLatitude = Convert.ToDouble(delen[0]);
                    }
                    catch (FormatException e)
                    {
                        Debug.WriteLine(e.Message);
                    }



                    try
                    {
                        WesternLongitude = Convert.ToDouble(delen[1]);
                    }
                    catch (FormatException e)
                    {
                        Debug.WriteLine(e.Message);
                    }

                    string NameSite = delen[2];
                      
                    BasicGeoposition Position = new BasicGeoposition();
                    Position.Latitude = NorthLatitude;
                    Position.Longitude = WesternLongitude;

                    if (delen[2] != " ")
                    {
                        SiteList.Add(new Site(Convert.ToInt32(delen[3]),NameSite, Position));
                    }
                    Location RP = new RoutePoint(NameSite, Position);
                    LocationList.Add(RP);
                    
                }
            }
            else
            {
                Debug.WriteLine("De gewenste route is niet gevonden.");
            }
        }


        public override string ToString()
        {
            return "" + Name + System.Environment.NewLine + Beschrijving.Text + System.Environment.NewLine + Afstand + "meter." + System.Environment.NewLine + Category;
        }
    }
}
