using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
//﻿using InstanceFactory.MessageBoxSample.UI.Popups;
using System.Threading.Tasks;
using System.Windows;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// Pour en savoir plus sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyDomotik
{
    public sealed partial class GestionIcones : Page
    {
       public Image image;

       //private static Grille g = new Grille(Format.MOYEN); 
      // private Affichage affich = new Affichage(g, new Theme());
       private Icone icone;

       public Button b ;
       private int indexNouvelleIcone;

       public String nom;
       private Grille g;
       private Affichage affich;
       private Boolean choixPosition = false;

       private List<Button> listeBoutons;

        public GestionIcones()
        {
            this.InitializeComponent();
            afficherPage();
        }

        public void afficherPage()
        {
            // création de la grille d'affichage des icones
            this.g = MainPage.Configuration.arbre.Racine.Grille;
            this.affich = new Affichage(this.g, MainPage.Configuration.theme);
            this.affich.creerGrille(cadre);

            // création et affichage de la liste des boutons et des Icones associées
            this.listeBoutons = this.affich.afficheGrille(cadre);
            this.attribueHandler();
        }

        public void exitAdmin(object sender, RoutedEventArgs e)
        {
            // il faut mémoriser la grille dans config avant de quitter
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
            // Message 
            messageBox.Visibility = Visibility.Visible;
            message.Text = "Veuillez cliquer sur l'endroit où vous souhaitez inserer l'icone";

            this.choixPosition = true;

            // mémorise l'image cliquée
            this.image = sender as Image;         
        }

        //événement qui gère le click sur un bouton
        //affiche l'icone double clickée sur le bouton
        private void choixPositionIcone(object sender, RoutedEventArgs e)
        {
            if (choixPosition == true) // si l'utilisateur est en train d'ajouter une nouvelle icone
            {
            // mémorise le bouton et le nom de fichier de l'image sélectionnée
            b = sender as Button;
            nom = image.Name.Replace("é", ".");

            // mémorise l'index de l'icone à créer (ou changer de nom)
            this.indexNouvelleIcone = (int)b.Tag;
            // iconeClick : icone correspondant au bouton cliqué
            Icone iconeClick = g.pageGrille()[this.indexNouvelleIcone];

                if (iconeClick.EstVide()) // click sur icone vide : l'icone peut être ajoutée
                {
                    // mémorise une nouvelle icone dans la grille temporaire
                    g.pageGrille()[this.indexNouvelleIcone] = new Icone("", nom, 64, new Navigation(new Vue("")));

                    // Message
                    message.Text = "Veuillez attribuer un nom à l'icone.";
                    nomIcone.Visibility = Visibility.Visible;
                    Valider.Visibility = Visibility.Visible;

                }
                else // click sur icone existante : l'icone ne peut pas être ajoutée
                {
                    // Message
                    message.Text = "Il y a déjà une icône sur cet emplacement. Veuillez choisir un emplacement libre.";
                    messageBox.Visibility = Visibility.Visible;
                }
            }
        }

        private void Validation(object sender, RoutedEventArgs e)
        {
            if (this.choixPosition)
            {
                // efface message
                message.Text = "";
                messageBox.Visibility = Visibility.Collapsed;
                nomIcone.Visibility = Visibility.Collapsed;
                Valider.Visibility = Visibility.Collapsed;
                // attribution du nom à l'icone mémorisée et ajout de la nouvelle icone à la configuration
                icone.NomIcone = message.Text;
                ajouterIcone();
            }
            else // Changement du nom de l'icone : mémorisation dans la configuration
            {
                MainPage.Configuration.arbre.Racine.Grille.setNomIcone(indexNouvelleIcone, g.NumGrille, message.Text);
                this.Frame.Navigate(typeof(GestionIcones));
            }
        }
            
       private void ajouterIcone(){

            //création de la page associée à l'icone
            MainPage.Configuration.arbre.Racine.Grille.addIcone(this.icone, indexNouvelleIcone, this.g.NumGrille);
            // MainPage.Configuration.ajouterPiece(icone, indexNouvelleIcone, this.g.NumGrille); 
            this.choixPosition = false;
            this.Frame.Navigate(typeof(GestionIcones));
     
        }

       private void Menu(object sender, RoutedEventArgs e)
       {
           if (!this.choixPosition)
           {
               Options.Visibility = Visibility.Visible;
               Supprimer.IsEnabled = true;
               ChangerNom.IsEnabled = true;
           }
       } 

        private void enleverIcone(object sender, RoutedEventArgs e)
        {
            Options.Visibility = Visibility.Collapsed;
            Supprimer.IsEnabled = false;
            ChangerNom.IsEnabled = false;

            if (!this.choixPosition)
            {
             Button boutonClick = sender as Button;
                
            // icone : icone correspondant au bouton cliqué
            int indexClick = (int)boutonClick.Tag;
            Icone icone = g.pageGrille()[indexClick];

            if (!(icone.EstVide()))
            {
                messageBox.Visibility = Visibility.Visible;
                message.Text = "Enlever icone : ok";
                
                // retire l'icone de la grille et la remplace par une icone vide
                g.pageGrille()[indexClick] = Icone.IconeVide();
                MainPage.Configuration.arbre.Racine.Grille.removeIcone(indexClick, this.g.NumGrille);
                this.Frame.Navigate(typeof(GestionIcones));
            }
            else
            {
                messageBox.Visibility = Visibility.Visible;
                message.Text = "Enlever icone : pas ok. Bah ya pas d'icone ici hein !";
            }
             
            }
        }
        private void changerNomIcone(object sender, RoutedEventArgs e)
        {
            Options.Visibility = Visibility.Collapsed;
           Supprimer.IsEnabled = false;
           ChangerNom.IsEnabled = false;

            messageBox.Visibility = Visibility.Visible;
            message.Text = "Changement du nom de l'icone";
            
            // mémorise le bouton et le nom de fichier de l'image sélectionnée
            b = sender as Button;
            nom = image.Name.Replace("é", ".");

            // mémorise l'index de l'icone à créer (ou changer de nom)
            this.indexNouvelleIcone = (int)b.Tag;
            // iconeClick : icone correspondant au bouton cliqué
            Icone iconeClick = g.pageGrille()[this.indexNouvelleIcone];
            if (!iconeClick.EstVide()) // click sur icone existante : on peut changer son nom
            {
                // Message
                message.Text = "Veuillez attribuer un nom à l'icone.";
                nomIcone.Visibility = Visibility.Visible;
                Valider.Visibility = Visibility.Visible;
            }
        }

        private void attribueHandler()
        {
            foreach (Button bouton in this.listeBoutons)
            {
                if ((int)bouton.Tag >= 0)
                {
                bouton.Click += Menu;
                bouton.Click += choixPositionIcone;
                }
            }
        }

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

    }
}
