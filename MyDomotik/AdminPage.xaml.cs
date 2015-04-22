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

// Pour en savoir plus sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyDomotik
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class AdminPage : Page
    {
        public AdminPage()
        {
            this.InitializeComponent();
        }

        private void exitAdmin(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void menuAdmin(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminPage));
        }

        private void gestionIcones(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GestionIcones));
        }

        private void accesPageReseau(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(ReglagesReseau));
        }

        private void accesParamInterface(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ParamInterface));
        }
    }
}
