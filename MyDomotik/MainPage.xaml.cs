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
        private Arbre arbre;
        private Theme theme;
        private Grille grille;

        public MainPage()
        {
          // Initialisation
            Configuration configuration = new Configuration();
            this.arbre = configuration.arbre;
            this.theme = configuration.theme;
          
            InitializeComponent();
          
          // affichage de la grille
            Vue pageSuiv = new Vue("the big page");
            Navigation nav = new Navigation(pageSuiv);

            // test affichage de la grille
            Icone icone1 = new Icone("icone1", "bathroom_0.png", 64, nav);
            Icone icone2 = new Icone("icone2", "bedroom_0.png", 64, (Action)null);
            Icone icone3 = new Icone("icone3", "battery_0.png", 64, (Action)null);
            Icone icone4 = new Icone("icone4", "bathroom_0.png", 64, (Action)null);
            configuration.ajouterIcone(arbre.PageCourante, icone1, 0);
            configuration.ajouterIcone(arbre.PageCourante, icone3, 2);
            configuration.ajouterIcone(arbre.PageCourante, icone4, 4);
            configuration.ajouterIcone(arbre.PageCourante, icone2, 6);
            configuration.ajouterIcone(arbre.PageCourante, icone2, 8);
            configuration.ajouterIcone(arbre.PageCourante, icone1, 10);
            configuration.ajouterIcone(arbre.PageCourante, icone1, 12);
            configuration.ajouterIcone(arbre.PageCourante, icone1, 13);
            configuration.ajouterIcone(arbre.PageCourante, icone2, 16);
            configuration.ajouterIcone(arbre.PageCourante, icone1, 17);
            configuration.ajouterIcone(arbre.PageCourante, icone1, 24);
            configuration.ajouterIcone(arbre.PageCourante, icone2, 25);
            //fin test

            afficherPage();
            // premierAffichage = false;  // Erreur : premierAffichage non défini (commenté par William)

        }

        // affichage de la page courante
        public void afficherPage()
        {
            page_title.Text = this.arbre.PageCourante.Nom;
            this.grille = this.arbre.PageCourante.Grille;
            this.affichage = new Affichage(this.grille, this.theme);

            this.affichage.creerGrille(cadre);

            this.affichage.afficheGrille(cadre);

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
            if (!theme.ModeDefilement && this.grille.pagePrecedente())
            {
                this.affichage.nettoieGrille(cadre);
                this.affichage.afficheGrille(cadre);
            }

        }

        // accès à la page suivante de la grille
        private void PageSuivante(object sender, RoutedEventArgs e)
        {
            if (!this.theme.ModeDefilement && this.grille.pageSuivante())
            {
                this.affichage.nettoieGrille(cadre);
                this.affichage.afficheGrille(cadre);
            }
        }

        // accès à la page d'accueil : TO DO
        private void PageAccueil(object sender, RoutedEventArgs e)
        {
                this.arbre.PageCourante = this.arbre.Racine;
                this.Frame.Navigate(typeof(MainPage));
        }

      

        // actions
        private void attribueHandler()
        {
            Icone[] icones = grille.pageGrille();
            for(int i=0; i<icones.Length; i++)
            {
                icones[i].Bouton.Click += IconeClick;  // ça suffit pas !  
            }
        }

        private void IconeClick(object sender, RoutedEventArgs e)
        {
            Button boutonClick = sender as Button;
            // test handler
            accueil.Background = new SolidColorBrush(Colors.White);

            int indexClick = (int)boutonClick.Tag;
            Icone icone = grille.pageGrille()[indexClick];

            // si icone de navigation : changement de page
            if (icone.Navigation != null)
            {
                this.arbre.PageCourante = icone.Navigation.PageFils;
                this.Frame.Navigate(typeof(MainPage));
            }
        }

    }
}
