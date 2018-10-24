﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace Tch.Uwp.TabControlSpike.Libs
{
  public  class BrowserControls
    {
        public void Back(ref WebView web)
        {
            if (web.CanGoBack) web.GoBack();
        }

        public void Forward(ref WebView web) {
            if (web.CanGoForward) web.GoForward();  
        }

        public void Go(ref WebView web, string value, KeyRoutedEventArgs args) {
            if (args.Key == Windows.System.VirtualKey.Enter) {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    try {
                        if (value == "")
                        {
                            web.Navigate(new System.Uri("http://google.com"));
                        }
                        else if (value.StartsWith("http://") || value.StartsWith("https://"))
                        {
                            try
                            {
                                web.Navigate(new System.Uri(value));
                            }
                            catch
                            {

                            }
                        }
                        else if (value.Contains(".")) {
                            string newvalue = "http://" + value;
                            web.Navigate(new System.Uri(newvalue));
                        }
                    } catch
                    {

                    }
                }
                else {
                    CultureInfo ci = CultureInfo.CurrentCulture;
                    var url = "ms-appx-web:///WebResources/ErrorPages/" + "en-GB" + "/noInternet.html";
                    web.Navigate(new System.Uri(url));
                }
                web.Focus(Windows.UI.Xaml.FocusState.Keyboard);

            }
        }
    }
}
