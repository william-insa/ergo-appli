﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Drawing;
using System.IO;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;


namespace MyDomotik
{
    class Icone
    {
        private String nomIcone;
        private Image image;
        private BitmapImage source;


        private int taille;
        private String chaineSource;

        private Action action;
        private Navigation navigation;
        

       
        
        // source du fichier créé par rapport à la taille de l'icone
        public void SourceImage(String nomFichier)
        {

            this.chaineSource = @"ms-apx:/Assets/ICONS_MDTOUCH/size_" + this.taille + "x" + this.taille + "/" + nomFichier; // spécifie le dossier adéquat en fonction de la taille de l'image
            Uri imageUri = new Uri(this.chaineSource, UriKind.Absolute);
            this.Source = new BitmapImage(imageUri);
              
        }

        // constructeur d'icone associée à une action
        public Icone(String nom, String nomFichier, int taille, Action action)
        { 
            this.taille = taille;

            // création de la source
            this.SourceImage(nomFichier);

            // création de l'image à partir de la source
            this.image = new Image();
            this.image.Source = this.source;
            
            this.nomIcone = nom;
            
            this.action = action;
            this.navigation = null;
        }

        // constructeur d'icone associée à une navigation (icone menant à une nouvelle page)
        public Icone(String nom, String nomFichier, int taille, Navigation navigation)
        {
            this.taille = taille;

            // création de la source
            this.SourceImage(nomFichier);

            // création de l'image à partir de la source
            this.image = new Image();
            this.image.Source = this.source;
           
            this.nomIcone = nom;
           
            this.navigation = navigation;
            this.action = null;
        }

        //getters et setters image, nom, action, navigation

        public BitmapImage Source
        {
            get { return source; }
            set { source = value; }
        }
         internal Image Image
        {
            get { return image; }
            set { image = value; }
        }

         public String NomIcone
         {
             get { return nomIcone; }
             set { nomIcone = value; }
         }

         public int Taille
         {
             get { return taille; }
             set { taille = value; }
         }


         public String ChaineSource
         {
             get { return chaineSource; }
             set { chaineSource = value; }
         }
       
         

        public Action Action
        {
            get { return action; }
            set { action = value; }
        }

        internal Navigation Navigation
        {
            get { return navigation; }
            set { navigation = value; }
        }


        // méthode d'affichage d'une icone
        public void afficherIcone()
        {

        }
    }
}
