using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace MyDomotik
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.displayTime();
        }

        private void displayTime()
        {
            TimeBox.Text = DateTime.Now.ToString();
        }

       

        private void adminSelect(object sender, DoubleTappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminPage));
        }


    }
}
