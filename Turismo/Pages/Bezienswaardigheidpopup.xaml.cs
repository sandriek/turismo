using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Turismo.Components;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Turismo.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Bezienswaardigheidpopup : Page
    {
        string text;
        public Site currentSite;
        string naam = "Kasteel";
        //string naam mag weg
        string link;

        public Bezienswaardigheidpopup()
        {
            this.InitializeComponent();
            FindText();
        }

        public void FindText()
        {
            //link = "Pages/Text/" + currentSite.name + ".txt";
            //Dit is de goede, hier onder is hardcoded om te testen
            link = "Pages/Text/" + naam + ".txt";
            if (File.Exists(link))
            {
                string[] route = File.ReadAllLines(link);
                foreach (string s in route)
                {
                    text += s + Environment.NewLine;
                    Debug.WriteLine(text);
                }
                FileText.Text = text;
            }
        }
    }
}
