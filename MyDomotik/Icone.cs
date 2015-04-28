using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;








namespace MyDomotik
{
    class Icone
    {
        private String nomIcone;
        private Image image;

        private int taille;
        private String source;
       
        private Action action;
        private Navigation navigation;
        

       
        
        // source du fichier créé par rapport à la taille de l'icone
        public void SourceImage(String nomFichier)
        {

            this.source = "Assets\\ICONS_MDTOUCH\\size_"+this.taille+"x"+this.taille+"\\"+nomFichier; // spécifie le dossier adéquat en fonction de la taille de l'image
            
        }

        // constructeur d'icone associée à une action
        public Icone(String nom, String nomFichier, int taille, Action action)
        {
            this.taille = taille;
            this.SourceImage(nomFichier);
            this.image = Image.FromFile(this.source);
            this.nomIcone = nom;
            this.action = action;
            this.navigation = null;
        }

        // constructeur d'icone associée à une navigation (icone menant à une nouvelle page)
        public Icone(String nom, String nomFichier, int taille, Navigation navigation)
        {
            this.taille = taille;
            this.SourceImage(nomFichier);
            this.image = Image.FromFile(this.source);
            this.nomIcone = nom;
            this.navigation = navigation;
            this.action = null;
        }

        //getters et setters image, nom, action, navigation
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
         
        public String Source
        {
            get { return source; }
            set { source = value; }
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
