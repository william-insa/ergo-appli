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
using System.Windows;
using Windows.UI;
using Windows.UI.Xaml.Media.Imaging;


namespace MyDomotik
{
    public sealed partial class MainPage : Page
    {
        // Numéro de page de la grille : modifié lors d'une interaction avec la barre de navigation
        private Affichage affichage;
        private Arbre arbre;
        private Theme theme;
        private Grille grille;

        public MainPage()
        {
            Configuration configuration = new Configuration();
            InitializeComponent();

            // Initialisation
            this.theme = configuration.theme;
            this.grille = configuration.arbre.PageCourante.Grille;
            this.affichage = new Affichage(this.grille, this.theme);
            this.arbre = configuration.arbre;          
            
            // affichage de l'heure
            this.displayTime(); 
            
            // affichage de la grille

            this.affichage.afficheGrille(cadre);
        
            // affichage des couleurs
            this.affichage.afficheCouleur(barreMenu, cadre, accueil, precedent, suivant);

        }


        // affichage de l'heure : TO DO
        public void displayTime()
        {
            TimeBox.Text = DateTime.Now.ToString();
        }
     
       
        // accès au mode configuration
        private void adminSelect(object sender, DoubleTappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminPage));
        }

        // accès à la page précédente de la grille
        private void PagePrecedente(object sender, RoutedEventArgs e)
        {
            if (!theme.ModeDefilement && this.grille.pagePrecedente())
            {
                this.affichage.afficheGrille(cadre);
            }

        }

        // accès à la page suivante de la grille
        private void PageSuivante(object sender, RoutedEventArgs e)
        {
            if (this.theme.ModeDefilement && this.grille.pageSuivante())
            {
                this.affichage.afficheGrille(cadre);
            }
      
        }

        // accès à la page d'accueil : TO DO
        private void PageAccueil(object sender, RoutedEventArgs e)
        {
            this.arbre.retourAccueil();
        }

    }
}
