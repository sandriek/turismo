using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turismo.Objects;

namespace Turismo.Components
{
    public class Route
    {
        string Name;
        List<Location> LocationList;
        Description _Description;
        Category _Category;


        double NorthLatitude;
        double WesternLongitude;
        string NameSite;
        Boolean IsItASite = false;

        public Route(string name, Description description, Category category)
        {
            this.Name = name;
            this._Description = description;
            this._Category = category;
            LocationList = new List<Location>();
            FillLocationList();
        }

        private void FillLocationList()
        {
            string filename = "Assets/" + Name + ".txt";
            if (File.Exists(filename))
            {
                string[] route = File.ReadAllLines(filename);
                foreach(string s in route)
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

                    NameSite = delen[2];

                    if (delen[2] != " ")
                        IsItASite = true;
                        



                    Location RP = new RoutePoint(NameSite, _Description); //hier moeten dan nog die NB en WL komen
                    LocationList.Add(RP);
                }
            }
            else
            {
                Debug.WriteLine("Het gewenste bestand is niet gevonden.");
            }
            

        }
    }
}
