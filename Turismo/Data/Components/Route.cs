﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turismo.Data.Objects;
using Turismo.Objects;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls;

namespace Turismo.Components
{
    public class Route
    {
        public string Name;
        public List<Location> LocationList;
        public Category.category Category;
        public List<Site> SiteList;       
        

        public Route(string name,  Category.category category)

        {
            Name = name;            
            Category = category;
            LocationList = new List<Location>();
            SiteList = new List<Site>();
            FillLocationList();
        }

        private void FillLocationList()
        {
            double NorthLatitude = 0.0, WesternLongitude = 0.0;
            string filename = "Assets/Routes/" + Name + ".txt";
            DirectoryInfo di = new DirectoryInfo("Pages/Pictures");
            FileInfo[] Images = di.GetFiles("*.jpg");
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
    }
}
