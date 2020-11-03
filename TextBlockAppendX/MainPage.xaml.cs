using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace TextBlockAppendX
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            Stock = 18;
        }
        public int Stock { get; set; }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var applicationView = ApplicationView.GetForCurrentView();
            var viewModePreference = ViewModePreferences.CreateDefault(ApplicationViewMode.CompactOverlay);
            viewModePreference.CustomSize = new Size(200, 200);
            applicationView.SetPreferredMinSize(new Size(200, 200));

            await applicationView.TryEnterViewModeAsync(ApplicationViewMode.CompactOverlay, viewModePreference);
            Window.Current.CoreWindow.SizeChanged += CoreWindow_SizeChanged;
        }

        private void CoreWindow_SizeChanged(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.WindowSizeChangedEventArgs args)
        {
            var applicationView = ApplicationView.GetForCurrentView();
            if (applicationView.ViewMode == ApplicationViewMode.CompactOverlay)
            {

                var size = new Size(200, 200);

                ApplicationView.GetForCurrentView().TryResizeView(size);
            }
        }
    }

    public class StringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            return value.ToString() + "X";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
