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
    public sealed partial class GestionIcones2 : Page
    {
        public GestionIcones2()
        {
            this.InitializeComponent();
         
        }

        public void exitAdmin(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        public void retourPieces(object sender, RoutedEventArgs e)
        {
            this.Frame.GoBack();
        }

/*
        // accès à la page précédente de la grille
        private void pagePrecedente(object sender, RoutedEventArgs e)
        {
            if (!MainPage.Configuration.theme.ModeDefilement && this.g.pagePrecedente())
            {
                affich.nettoieGrille(cadre);
                this.listeBoutons = affich.afficheGrille(cadre);
                this.attribueHandler();
            }

        }

        // accès à la page suivante de la grille
        private void pageSuivante(object sender, RoutedEventArgs e)
        {
            if (!MainPage.Configuration.theme.ModeDefilement && this.g.pageSuivante())
            {
                affich.nettoieGrille(cadre);
                this.listeBoutons = affich.afficheGrille(cadre);
                this.attribueHandler();
            }
        }
 */
    }
}
