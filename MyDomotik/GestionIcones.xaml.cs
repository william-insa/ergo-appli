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
        private Vue pageAccueil;
       private Image image;

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
            this.pageAccueil = MainPage.Configuration.arbre.Racine;
            // création de la grille d'affichage des icones
            this.g = this.pageAccueil.Grille;
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
            this.nom = image.Name.Replace("é", ".");
        }

        //événement qui gère le click sur un bouton
        //affiche l'icone double clickée sur le bouton
        private void choixPositionIcone(object sender, RoutedEventArgs e)
        {
            if (choixPosition) // si l'utilisateur est en train d'ajouter une nouvelle icone
            {

            // mémorise le bouton et le nom de fichier de l'image sélectionnée
            this.b = sender as Button;
            //this.nom = image.Name.Replace("é", ".");

            // mémorise l'index de l'icone à créer (ou changer de nom)
            this.indexNouvelleIcone = (int)b.Tag;
            // iconeClick : icone correspondant au bouton cliqué
            this.icone = g.pageGrille()[this.indexNouvelleIcone];

                if (this.icone.EstVide()) // click sur icone vide : l'icone peut être ajoutée
                {
                    //test
                    message.Text = "Ajout de l'icone à cet emplacement vide";
                    messageBox.Visibility = Visibility.Visible;//fin test

                    /*// mémorise une nouvelle icone dans la grille temporaire
                    //g.pageGrille()[this.indexNouvelleIcone] = new Icone("", nom, 64, new Navigation(new Vue("")));
                    this.icone = new Icone("", nom, 64, new Navigation(new Vue("")));

                    // affiche la boite de dialogue permettant à l'utilisateur d'entrer le nom de l'icone
                    message.Text = "Veuillez attribuer un nom à l'icone.";
                    nomIcone.Visibility = Visibility.Visible;
                    Valider.Visibility = Visibility.Visible;*/

                }
                else // click sur icone existante : l'icone ne peut pas être ajoutée
                {
                    // Message
                    message.Text = "Il y a déjà une icône sur cet emplacement. Veuillez choisir un emplacement libre.";
                    messageBox.Visibility = Visibility.Visible;
                }
            }
        }

        // évenement qui gère la validation de saisie du nom de l'icone
        private void Validation(object sender, RoutedEventArgs e)
        {
            if (this.choixPosition) // création d'une nouvelle icone
            {
                // efface message
                message.Text = "";
                messageBox.Visibility = Visibility.Collapsed;
                nomIcone.Visibility = Visibility.Collapsed;
                Valider.Visibility = Visibility.Collapsed;
                // attribution du nom à l'icone mémorisée et ajout de la nouvelle icone à la configuration
                icone.NomIcone = nomIcone.Text;
                ajouterIcone();
            }
            else // Changement du nom de l'icone : mémorisation dans la configuration
            {
                MainPage.Configuration.arbre.Racine.Grille.setNomIcone(indexNouvelleIcone, g.NumGrille, nomIcone.Text);
                this.Frame.Navigate(typeof(GestionIcones));
            }
        }
            
<<<<<<< HEAD
=======
        // ajout de l'icone (attribut de classe) dans la grille de la page d'accueil
>>>>>>> origin/master
       private void ajouterIcone(){

            //création de la page associée à l'icone
           MainPage.Configuration.ajouterIcone(this.pageAccueil, this.icone, g.NumGrille);
            // MainPage.Configuration.ajouterPiece(icone, indexNouvelleIcone, this.g.NumGrille); 
            this.choixPosition = false;
            this.Frame.Navigate(typeof(GestionIcones));
     
        }

        // évenement qui gère le click sur un bouton (en dehors du cas où l'utilisateur ajoute une icone)
        // affiche un menu de deux boutons : supprimer l'icone ou modifier le nom de l'icone
       private void Menu(object sender, RoutedEventArgs e)
       {
           if (!this.choixPosition)
           {
               this.b = sender as Button;

               Options.Visibility = Visibility.Visible;
               Supprimer.IsEnabled = true;
               ChangerNom.IsEnabled = true;
           }
       } 

        private void enleverIcone(object sender, RoutedEventArgs e)
        {
            if (!choixPosition)
            {
                Options.Visibility = Visibility.Collapsed;
                Supprimer.IsEnabled = false;
                ChangerNom.IsEnabled = false;

                // icone : icone correspondant au bouton cliqué
                this.indexNouvelleIcone = (int)b.Tag;
                this.icone = g.pageGrille()[this.indexNouvelleIcone];

                if (!(icone.EstVide()))
                {
                    // retire l'icone de la grille et la remplace par une icone vide
                     g.pageGrille()[this.indexNouvelleIcone] = Icone.IconeVide();
                     MainPage.Configuration.arbre.Racine.Grille.removeIcone(this.indexNouvelleIcone, this.g.NumGrille);
                     this.Frame.Navigate(typeof(GestionIcones));
                }
            }
           

        }
        private void changerNomIcone(object sender, RoutedEventArgs e)
        {
            if (!choixPosition)
            {
                Options.Visibility = Visibility.Collapsed;
                Supprimer.IsEnabled = false;
                ChangerNom.IsEnabled = false;

                messageBox.Visibility = Visibility.Visible;
                message.Text = "Changement du nom de l'icone";

                // mémorise l'index de l'icone à créer (ou changer de nom)
                this.indexNouvelleIcone = (int)b.Tag;
                // iconeClick : icone correspondant au bouton cliqué
                this.icone = g.pageGrille()[this.indexNouvelleIcone];
                if (!this.icone.EstVide()) // click sur icone existante : on peut changer son nom
                {
                    // Message
                    message.Text = "Veuillez attribuer un nom à l'icone.";
                    nomIcone.Visibility = Visibility.Visible;
                    Valider.Visibility = Visibility.Visible;
                }
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
