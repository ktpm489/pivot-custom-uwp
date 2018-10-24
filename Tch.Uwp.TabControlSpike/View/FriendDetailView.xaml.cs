using System;
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
using System;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using System.Net.NetworkInformation;
using System.Globalization;
using Tch.Uwp.TabControlSpike.View;

using System;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using System.Net.NetworkInformation;
using System.Globalization;
using Windows.UI.ViewManagement;
// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Tch.Uwp.TabControlSpike.View
{
  public sealed partial class FriendDetailView : Page
  {
        Libs.BrowserControls Library = new Libs.BrowserControls();
        public FriendDetailView()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
            if (NetworkInterface.GetIsNetworkAvailable())
            {
               // if (Value.Text == "")
                //{
                    Display.Navigate(new System.Uri("http://google.com"));
                //}
            }
            else
            {
                CultureInfo ci = CultureInfo.CurrentCulture;
                if ((ci.TwoLetterISOLanguageName == "en-GB") | (ci.TwoLetterISOLanguageName == "es-ES"))
                {
                    var url = "ms-appx-web:///WebResources/ErrorPages/" + ci.TwoLetterISOLanguageName + "/noInternet.html";
                    Display.Navigate(new System.Uri(url));
                }
                else
                {
                    var url = "ms-appx-web:///WebResources/ErrorPages/" + "en-GB" + "/noInternet.html";
                    Display.Navigate(new System.Uri(url));
                }

            }
        }

        private void Value_KeyDown(object sender, KeyRoutedEventArgs e)
        {
           // Library.Go(ref Display, Value.Text, e);
        }

        private void Display_NavigationCompleted(WebView sender, WebViewNavigationCompletedEventArgs args)
        {
            if (args.IsSuccess)
            {
              //  Value.Text = args.Uri.ToString();
            }
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                var url = args.Uri.ToString();
                System.Uri source = Display.Source;
                CultureInfo ci = CultureInfo.CurrentCulture;
                if (!url.Contains("ms-appx-web://"))
                {
                    if ((ci.TwoLetterISOLanguageName == "en-GB") | (ci.TwoLetterISOLanguageName == "es-ES"))
                    {
                        var newurl = "ms-appx-web:///WebResources/ErrorPages/" + ci.TwoLetterISOLanguageName + "/noInternet.html";
                        Display.Navigate(new System.Uri(newurl));
                    }
                    else
                    {
                        var newurl = "ms-appx-web:///WebResources/ErrorPages/" + "en-GB" + "/noInternet.html";
                        Display.Navigate(new System.Uri(newurl));
                    }
                }
            }
        }
        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Library.Back(ref Display);
            appbar.IsOpen = false;
        }

        private void fowardBtn_Click(object sender, RoutedEventArgs e)
        {
            Library.Forward(ref Display);
            appbar.IsOpen = false;
        }

        private void refreshBtn_Click(object sender, RoutedEventArgs e)
        {
            Display.Refresh();
            appbar.IsOpen = false;
        }

        private void cancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Display.Stop();
            appbar.IsOpen = false;
        }

        private void settingsBtn_Click(object sender, RoutedEventArgs e)
        {
            //   this.Frame.Navigate(typeof(SettingsPage), null);
            var view = ApplicationView.GetForCurrentView();

            if (view.IsFullScreenMode)
            {
                view.ExitFullScreenMode();
               
            }
            else
            {
                try
                {
                    view.TryEnterFullScreenMode();
                   
                }
                catch
                {
                    //未成功进入全屏
                }
            }
            appbar.IsOpen = false;
        }

        private void devBtn_Click(object sender, RoutedEventArgs e)
        {
            // this.Frame.Navigate(typeof(DevelopersPage), null);
            appbar.IsOpen = false;
        }
    }
}
