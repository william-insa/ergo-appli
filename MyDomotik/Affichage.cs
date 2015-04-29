using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;

namespace MyDomotik
{
    class Affichage
    {
        private Grille grille;
        private Theme theme;

        // getters et setters
        internal Grille Grille
        {
            get { return grille; }
            set { grille = value; }
        }

        internal Theme Theme
        {
            get { return theme; }
            set { theme = value; }
        }
         // constructeur
        public Affichage(Grille grille, Theme theme)
        {
            this.grille = grille;
            this.theme = theme;
        }
      
        // constructeur de bouton correspondant au format de la grille
        public Button formatBouton(Brush couleur, Grid grid)
        {
            Button bouton = new Button();

            bouton.SetValue(Button.BackgroundProperty, couleur);

            double hauteur = grid.Height / this.grille.NbLignes;
            double largeur = grid.Width / this.grille.NbColonnes;

            bouton.SetValue(Button.WidthProperty, largeur);
            bouton.SetValue(Button.HeightProperty, hauteur);

            return bouton;

        }

        // Affiche les couleurs de la grille, la barre de menu et ses boutons en fonction du thème de couleurs passé en paramètre
        public void afficheCouleur(Rectangle barreMenu, Grid cadre, Button accueil, Button precedent, Button suivant)
        {
            Brush grille = new SolidColorBrush(theme.Couleur.CouleurGrille);
            Brush barre = new SolidColorBrush(theme.Couleur.CouleurBarre);
            Brush boutons = new SolidColorBrush(theme.Couleur.CouleurBoutons);

            barreMenu.Fill = barre;
            cadre.Background = grille;
            accueil.Background = boutons;
            precedent.Background = boutons;
            suivant.Background = boutons;
        }



        // Affiche la grille avec le bon format et les icones correspondant au numéro de Page de la grille numGrille : TO DO
        public void afficheGrille(Grid cadre)
        {
            //couleur boutons
            Brush boutonActif = new SolidColorBrush(Colors.Red);
            Brush boutonVide = new SolidColorBrush(Colors.White);

            // icones : tableau contenant les icones à afficher
            //Icone[] icones = this.grille.pageGrille(this.numGrille);

            // tableau d'icones test
            Icone icone1 = new Icone("icone1", "bathroom_0.png", 64, (Action)null);
            Icone icone2 = new Icone("icone2", "bedroom_0.png", 64, (Action)null);
            Icone icone3 = new Icone("icone3", "battery_0.png", 64, (Action)null);
            Icone icone4 = new Icone("icone4", "bathroom_0.png", 64, (Action)null);

            Icone[] icones = new Icone[6] { icone1, null, icone2, null, icone3, icone4 };

            // création de la grid
            for (int j = 0; j < grille.NbColonnes; j++)
            {
                cadre.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < grille.NbLignes; i++)
            {
                cadre.RowDefinitions.Add(new RowDefinition());
            }

            // ajout des boutons et de leurs icones dans la grille
            int cpt = 0;
            for (int j = 0; j < grille.NbColonnes; j++)
            {
                for (int i = 0; i < grille.NbLignes; i++)
                {
                    Button bouton = this.formatBouton(boutonVide, cadre);
                    bouton.SetValue(Grid.ColumnProperty, j);
                    bouton.SetValue(Grid.RowProperty, i);

                    cadre.Children.Add(bouton);

                    if (cpt < icones.Length)
                    {
                        if (icones[cpt] != null)
                        {
                            afficherIcone(icones[cpt], bouton);
                            bouton.SetValue(Button.BackgroundProperty, boutonActif);
                        }
                    }

                    cpt++;
                }
            }
        }

        // affiche l'icone dans la grille grid à la colonne "colonne" et a la ligne "ligne"
        public void afficherIcone(Icone icone, Button bouton)
        {
            // creation de l'image 
            Image image = new Image();
            BitmapImage SourceBi = new BitmapImage();
            SourceBi.UriSource = icone.Uri;
            image.Source = SourceBi;

            bouton.Content = image;

            // empeche l'icone de depasser du contour du bouton

            double hauteur = bouton.Height;
            double largeur = bouton.Width;
            
            image.SetValue(Image.HeightProperty, 0.5 * hauteur);
            image.SetValue(Image.WidthProperty, 0.5 * hauteur);
        }  

    }
}
