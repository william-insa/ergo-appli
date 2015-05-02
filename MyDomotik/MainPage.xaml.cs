using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Windows;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


namespace MyDomotik
{
    
    public sealed partial class MainPage : Page
    {
        // Numéro de page de la grille : modifié lors d'une interaction avec la barre de navigation
        private Affichage affichage;
        private Grille grille;
        private List<Button> listeBoutons;
        private static Configuration configuration = new Configuration();

        // Initialisation
        public MainPage()
        {
            InitializeComponent();

            afficherPage();
        }

        // affichage de la page courante
        public void afficherPage()
        {
            // création de la grille d'affichage des icones
            this.grille = configuration.arbre.PageCourante.Grille;
            this.affichage = new Affichage(this.grille, configuration.theme);
            this.affichage.creerGrille(cadre);

            // création et affichage de la liste des boutons et des Icones associées
            this.listeBoutons = this.affichage.afficheGrille(cadre);
            //this.creerListeIcones();
            // attribution des evenements de navigation à chaque bouton
            this.attribueHandler();

            // affichage du nom de la page
            page_title.Text = configuration.arbre.PageCourante.Nom;

            // affichage de l'heure
            this.displayTime();

            // affichage des couleurs
            this.affichage.afficheCouleur(barreMenu, cadre, accueil, precedent, suivant);
        }


        // affichage de l'heure : TO DO
        public void displayTime()
        {
            TimeBox.Text = DateTime.Now.Hour + ":" + DateTime.Now.Minute;
        }


        // accès au mode configuration
        private void adminSelect(object sender, DoubleTappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(AdminPage));
        }

        // accès à la page précédente de la grille
        private void PagePrecedente(object sender, RoutedEventArgs e)
        {
            if (!configuration.theme.ModeDefilement && this.grille.pagePrecedente())
            {
                this.affichage.nettoieGrille(cadre);
                this.listeBoutons = this.affichage.afficheGrille(cadre);
                this.attribueHandler();
            }

        }

        // accès à la page suivante de la grille
        private void PageSuivante(object sender, RoutedEventArgs e)
        {
            if (!configuration.theme.ModeDefilement && this.grille.pageSuivante())
            {
                this.affichage.nettoieGrille(cadre);
                this.listeBoutons = this.affichage.afficheGrille(cadre);
                this.attribueHandler();
            }
        }

        // accès à la page d'accueil : TO DO
        private void PageAccueil(object sender, RoutedEventArgs e)
        {
            configuration.arbre.PageCourante = configuration.arbre.Racine;
            this.Frame.Navigate(typeof(MainPage));
        }



        // actions
        private void attribueHandler()
        {
            foreach (Button bouton in this.listeBoutons)
            {
                bouton.Click += IconeClick; // ça suffit pas !  
            }
        }

        private void IconeClick(object sender, RoutedEventArgs e)
        {
            Button boutonClick = sender as Button;
            /*// test handler
            accueil.Background = new SolidColorBrush(Colors.White);*/

            int indexClick = (int)boutonClick.Tag;
            Icone icone = grille.pageGrille()[indexClick];

            // si icone de navigation : changement de page
            if (icone.Navigation != null)
            {
                configuration.arbre.PageCourante = icone.Navigation.PageFils;
                this.affichage.nettoieGrille(cadre);
                this.Frame.Navigate(typeof(MainPage));
            }
        }
}

  
}
