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
        private Grille grille;
        private Theme theme;
        private Arbre arbre;

        public MainPage()
        {
            Configuration configuration = new Configuration();
            // Initialisation
            this.numGrille = 0;
            this.grille = configuration.arbre.PageCourante.Grille;
            this.theme = configuration.theme;
            this.arbre = configuration.arbre;
            this.InitializeComponent();

            // affichage de l'heure
            this.displayTime(); 

            // affichage de la grille
            this.afficheGrille();
        
            // affichage des couleurs
            this.afficheCouleur(this.theme.Couleur); 

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
        private void afficheGrille()
        {
            // icones : tableau contenant les icones à afficher
            Icone[] icones = this.grille.pageGrille(this.numGrille);

            // création de la grid

            switch (grille.Format)
            {
                case Format.PETIT :
                     ColumnDefinition colDef1 = new ColumnDefinition();
                     ColumnDefinition colDef2 = new ColumnDefinition();
                     ColumnDefinition colDef3 = new ColumnDefinition();
                     ColumnDefinition colDef4 = new ColumnDefinition();
                     ColumnDefinition colDef5 = new ColumnDefinition();
                     ColumnDefinition colDef6 = new ColumnDefinition();
                     cadre.ColumnDefinitions.Add(colDef1);
                     cadre.ColumnDefinitions.Add(colDef2);
                     cadre.ColumnDefinitions.Add(colDef3);
                     cadre.ColumnDefinitions.Add(colDef4);
                     cadre.ColumnDefinitions.Add(colDef5);
                     cadre.ColumnDefinitions.Add(colDef6);

                     RowDefinition ligneDef1 = new RowDefinition();
                     RowDefinition ligneDef2 = new RowDefinition();
                     RowDefinition ligneDef3 = new RowDefinition();
                     cadre.RowDefinitions.Add(ligneDef1);
                     cadre.RowDefinitions.Add(ligneDef2);
                     cadre.RowDefinitions.Add(ligneDef3);

                    break;

                case Format.MOYEN :
                default :

                     ColumnDefinition colmoy1 = new ColumnDefinition();
                     ColumnDefinition colmoy2 = new ColumnDefinition();
                     ColumnDefinition colmoy3 = new ColumnDefinition();
                     ColumnDefinition colmoy4 = new ColumnDefinition();
                     cadre.ColumnDefinitions.Add(colmoy1);
                     cadre.ColumnDefinitions.Add(colmoy2);
                     cadre.ColumnDefinitions.Add(colmoy3);
                     cadre.ColumnDefinitions.Add(colmoy4);

                     RowDefinition lignemoy1 = new RowDefinition();
                     RowDefinition lignemoy2 = new RowDefinition();
                     cadre.RowDefinitions.Add(lignemoy1);
                     cadre.RowDefinitions.Add(lignemoy2);

                    break;

                case Format.GRAND :

                     ColumnDefinition colgd1 = new ColumnDefinition();
                     ColumnDefinition colgd2 = new ColumnDefinition();
                     ColumnDefinition colgd3 = new ColumnDefinition();
                     cadre.ColumnDefinitions.Add(colgd1);
                     cadre.ColumnDefinitions.Add(colgd2);
                     cadre.ColumnDefinitions.Add(colgd3);

                     RowDefinition lignegd1 = new RowDefinition();
                     RowDefinition lignegd2 = new RowDefinition();
                     cadre.RowDefinitions.Add(lignegd1);
                     cadre.RowDefinitions.Add(lignegd2);

                    break;
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
                if (this.numGrille > 0)
                {
                    this.numGrille--;
                    this.afficheGrille();
                }
            }

        }

        // accès à la page suivante de la grille
        private void PageSuivante(object sender, RoutedEventArgs e)
        {
            if (!theme.ModeDefilement)
            {
                if (this.numGrille < this.grille.nbPagesGrille())
                {
                numGrille++;
                this.afficheGrille();
                }
            }
            
        }

        // accès à la page d'accueil : TO DO
        private void PageAccueil(object sender, RoutedEventArgs e)
        {

        }

      


    }
}
