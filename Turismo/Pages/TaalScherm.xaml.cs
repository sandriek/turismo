﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Turismo.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TaalScherm : Page
    {
        public TaalScherm()
        {
            this.InitializeComponent();
        }

        private void TaalGeselecteerd(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(KaartScherm));
        }

        private void NLFlag_Click(object sender, RoutedEventArgs e)
        {
            Data.AppGlobal.Instance._CurrentSession.SwitchLanguage("NL");
        }

        private void ENFlag_Click(object sender, RoutedEventArgs e)
        {
            Data.AppGlobal.Instance._CurrentSession.SwitchLanguage("EN");
        }
    }
}
