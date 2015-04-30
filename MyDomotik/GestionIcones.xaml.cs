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

        private void choixImage(object sender, DoubleTappedRoutedEventArgs e)
        {
            message.Text = "Veuillez clicker sur l'endroit où vous souhaitez inserer l'icone";

            image = sender as Image;
           // source = image.Source.ToString();
            
        }

        private void choixPositionIcone(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            String nom = image.Name.Replace("é", ".");
            Icone icone = new Icone("house", nom , 64, new Navigation());
            affich.afficherIcone(icone, b);
            //message.Text = nom;
            message.Text = " ";
            
        }

        private void enleverIcone(object sender, DoubleTappedRoutedEventArgs e)
        {
           // Button b = sender as Button;
            // String nom = image.Name.Replace("é", ".");
            // Icone icone = new Icone("house", nom, 64, new Navigation());
          //  affich.enleverImageBouton(icone, b);
        }

       

    }
}
