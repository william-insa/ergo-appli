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


namespace MyDomotik
{
    public sealed partial class MainPage : Page
    {
        // Numéro de page de la grille : modifié lors d'une interaction avec la barre de navigation
        private int numGrille;
        private Theme theme; 

        public MainPage()
        {
            // Initialisation
            this.numGrille = 0;
            this.theme = Configuration.theme;
            Arbre arbre = Configuration.arbre;
            this.InitializeComponent();

            // affichage de l'heure
            this.displayTime(); 

            // affichage de la grille
            this.afficheGrille(arbre.PageCourante.Grille, this.numGrille);
        
            // affichage des couleurs
            this.afficheCouleur(theme.Couleur); 

        }

        // Affiche les couleurs de la grille, la barre de menu et ses boutons en fonction du thème de couleurs passé en paramètre
        private void afficheCouleur(Couleur couleur)
        {

            Brush grille = new SolidColorBrush(couleur.CouleurGrille);
            Brush barre = new SolidColorBrush(couleur.CouleurBarre);
            Brush boutons = new SolidColorBrush(couleur.CouleurBoutons);

            barreMenu.Fill = barre;
            cadre.Background = grille;
            accueil.Background = boutons;
            precedent.Background = boutons;
            suivant.Background = boutons;
    
        }

        // Affiche la grille avec le bon format et les icones correspondant au numéro de Page de la grille numGrille : TO DO
        private void afficheGrille(Grille grille, int numGrille)
        {
            // icones : tableau contenant les icones à afficher
            Icone[] icones = grille.pageGrille(numGrille);
            for (int i = 0; i < grille.nbCasesGrille(); i++)
            {
                Button button = new Button();
                button.Name = "bouton" + i;
            }

        }


        // affichage de l'heure : TO DO
        private void displayTime()
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
            if (!theme.ModeDefilement)
            {
                if (numGrille > 0)
                {
                    numGrille--;
                    this.afficheGrille(arbre.PageCourante.Grille, numGrille);
                }
            }

        }

        // accès à la page suivante de la grille
        private void PageSuivante(object sender, RoutedEventArgs e)
        {
            if (!theme.ModeDefilement)
            {
                if (numGrille < arbre.PageCourante.Grille.nbPagesGrille())
                {
                numGrille++;
                this.afficheGrille(arbre.PageCourante.Grille, numGrille);
                }
            }
            
        }

        // accès à la page d'accueil : TO DO
        private void PageAccueil(object sender, RoutedEventArgs e)
        {

        }

      


    }
}
