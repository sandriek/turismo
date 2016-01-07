using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Turismo.Components;
using Turismo.ViewModels;
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
        private BezienswaardigheidsPopupViewModel bpvm;
        public Bezienswaardigheidpopup()
        {
            this.InitializeComponent();
            bpvm = BezienswaardigheidsPopupViewModel.Instance;
            DataContext = bpvm;
            FindText();
            FindPicture();
        }

        public void FindText()
        {            
            string linkText = "Pages/Text/" + bpvm.CurrentSite.name+ ".txt";
            if (File.Exists(linkText))
            {
                string[] route = File.ReadAllLines(linkText);
                string text = "";
                foreach (string s in route)
                {
                    text += s + Environment.NewLine;
                }
                FileText.Text = text;
            }
            else
            {
                FileText.Text = "Er is over deze bezienswaardigheid geen extra informatie";
            }
        }


        public void FindPicture()
        {                
            BitmapImage img = ImageFromRelativePath(this, "Pictures/" + bpvm.CurrentSite.name+ ".jpg");
            //Debug.WriteLine(img.UriSource);
            FilePicture.Source = img;            
        }

        public static BitmapImage ImageFromRelativePath(FrameworkElement parent, string path)
        {
            var uri = new Uri(parent.BaseUri, path);
            BitmapImage bmp = new BitmapImage();
            bmp.UriSource = uri;
            return bmp;
        }
    }
}
