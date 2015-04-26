using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDomotik
{
    class Icone
    {
        private Image image;
        private String nom;
        private Action action;
        private Navigation navigation;

        // constructeur d'icone associée à une action
        public Icone(Image image, String nom, Action action)
        {
            this.image = image;
            this.nom = nom;
            this.action = action;
        }

        // constructeur d'icone associée à une navigation (icone menant à une nouvelle page)
       public Icone(Image image, String nom, Navigation navigation)
        {
            this.image = image;
            this.nom = nom;
            this.navigation = navigation;
        }

        //getters et setters image, nom, action, navigation
         internal Image Image
        {
            get { return image; }
            set { image = value; }
        }

         public String Nom
         {
             get { return nom; }
             set { nom = value; }
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
