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
 

// Pour en savoir plus sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace MyDomotik
{
    public sealed partial class GestionIcones : Page
    {
       public Image image;
       public String source;
       //public TextBlock message;
       private  Grille g;
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
            messageBox.Visibility = Visibility.Visible;
            message.Text = "Veuillez cliquer sur l'endroit où vous souhaitez inserer l'icone";
            this.choixPosition = true;
            this.image = sender as Image;        
        }

        //événement qui gère le click sur un bouton
        //affiche l'icone double clickée sur le bouton
        private void choixPositionIcone(object sender, RoutedEventArgs e)
        {
            if (this.choixPosition == true) { 
            Button boutonClick = sender as Button;
            message.Text = "vous avez clické sur une case : c'est bien.";
            messageBox.Visibility = Visibility.Visible;
            /*
            // création d'une nouvelle icone à l'index du bouton
            int indexClick = (int)boutonClick.Tag;
            Icone nouvelleIcone = new Icone(this.image);
            g.pageGrille()[indexClick] = nouvelleIcone;

            //création de la page associée à l'icone
            MainPage.Configuration.ajouterPiece(new Vue(""),nouvelleIcone,indexClick,new Piece("")); // nom à définir

            //String nom = image.Name.Replace("é", ".");
            
            affich.afficherIcone(nouvelleIcone, boutonClick);
            message.Text = " ";
            messageBox.Visibility = Visibility.Collapsed;

            this.Frame.Navigate(typeof(GestionIcones));*/

            this.choixPosition = false;
            }
            
        }

        private void enleverIcone(object sender, DoubleTappedRoutedEventArgs e)
        {
            if (!this.choixPosition)
            {
             Button boutonClick = sender as Button;
             message.Text = "double-click : il faut enlever l'icone";
             messageBox.Visibility = Visibility.Visible;
                
            // icone : icone correspondant au bouton cliqué
            int indexClick = (int)boutonClick.Tag;
            Icone icone = g.pageGrille()[indexClick];

            if (icone != null)
            {
                message.Text += ": icone enlevée";
                messageBox.Visibility = Visibility.Visible;
                /*
               // indexClick correspond au bouton cliqué
               int indexClick = (int)boutonClick.Tag;

               // retire l'icone de la grille en le rendant null
               g.pageGrille()[indexClick] = null;
               this.Frame.Navigate(typeof(GestionIcones)); */
            }
            else { message.Text += ": icone pas enlevée"; }


               
            }

            

        }

        private void attribueHandler()
        {
            foreach (Button bouton in this.listeBoutons)
            {
                bouton.DoubleTapped += enleverIcone;
                bouton.Click += choixPositionIcone;

            }
        }

       

    }
}
