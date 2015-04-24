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
        //private Navigation navigation;

        // constructeur d'icone associée à une action
        public Icone(Image image, String nom, Action action)
        {
            this.image = image;
            this.nom = nom;
            this.action = action;
        }

        // constructeur d'icone associée à une navigation (icone menant à une nouvelle page)
       /* public Icone(Image image, String nom, Navigation navigation)
        {
            this.image = image;
            this.nom = nom;
            this.navigation = navigation;
        }*/

        //getters et setters image, nom, action, navigation
        public Image getImage()
        {
            return this.image;
        }

        public void setImage(Image image)
        {
            this.image = image;
        }

        public String getNom()
        {
            return this.nom;
        }

        public void setNom(String nom)
        {
            this.nom = nom;
        }

        public Action getAction()
        {
            return this.action;
        }

        public void setAction(Action action)
        {
            this.action = action;
        }

       /* public Navigation getNavigation()
        {
            return this.navigation;
        }

        public void setNavigation(Navigation navigation)
        {
            this.navigation = navigation;
        }*/

        // méthode d'affichage d'une icone
        public void afficherIcone()
        {

        }
    }
}
