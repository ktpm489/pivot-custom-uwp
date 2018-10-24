using Tch.Uwp.TabControlSpike.ViewModel;
using Windows.UI.Xaml.Controls;

namespace Tch.Uwp.TabControlSpike
{
  public sealed partial class MainPage : Page
  {
    public MainPage(MainViewModel viewModel)
    {
      this.InitializeComponent();
      ViewModel = viewModel;
    }
        //https://blog.hompus.nl/2015/09/04/responsive-pivot-headers-in-universal-windows-platform-apps/

        public MainViewModel ViewModel { get; }
  }
}
