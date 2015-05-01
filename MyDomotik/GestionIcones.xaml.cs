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
﻿//using InstanceFactory.MessageBoxSample.UI.Popups;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls; 
 

// Pour en savoir plus sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyDomotik
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class GestionIcones : Page
    {

       public Image image;
       public String source;
       //public TextBlock message;
       private static Grille g = new Grille(Format.MOYEN);
       private Affichage affich = new Affichage(g, new Theme());


        public GestionIcones()
        {
            this.InitializeComponent();
        }

        public void exitAdmin(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        public void menuAdmin(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminPage));
        }

        private void goToIcones(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GestionIcones2));
        }

        //événement qui gère le double click sur une icone
        //affiche un mesage pour le choix de l'emplacement de l'icone dans la grille et récupère les informations sur l'icone
        private void choixImage(object sender, DoubleTappedRoutedEventArgs e)
        {
            messageBox.Visibility = Visibility.Visible;
            message.Text = "Veuillez clicker sur l'endroit où vous souhaitez inserer l'icone";

            image = sender as Image;
           // source = image.Source.ToString();
            
        }

        //événement qui gère le click sur un bouton
        //affiche l'icone double clickée sur le bouton
        private void choixPositionIcone(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            String nom = image.Name.Replace("é", ".");
            Icone icone = new Icone("house", nom , 64, new Navigation(new Vue("pageIcones")));
            affich.afficherIcone(icone, b);
            message.Text = " ";
            messageBox.Visibility = Visibility.Collapsed;
            
        }

      /*  private void enleverIcone(object sender, DoubleTappedRoutedEventArgs e)
        {
            Button b = sender as Button;
            String nom = image.Name.Replace("é", ".");
            Icone icone = new Icone("house", nom, 64, new Navigation(new Vue("page")));
            affich.cacherIcone(icone, b);
        }

       */

    }
}
