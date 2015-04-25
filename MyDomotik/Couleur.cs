using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDomotik
{
    class Couleur
    {
        private string couleurGrille;
        private string couleurBarre;
        private string couleurBoutons;

        private readonly string[] listeCouleurs = new string[] {
            "#FFFFFFF", "#FFFFFFF", "#FFFFFFF",
            "#FFFFFFF", "#FFFFFFF", "#FFFFFFF"
        }; // 1 ligne par thème

        public string CouleurGrille
        {
            get { return couleurGrille; }
            set { couleurGrille = value; }
        }

        public string CouleurBarre
        {
            get { return couleurBarre; }
            set { couleurBarre = value; }
        }

        public string CouleurIconeBarre
        {
            get { return couleurBoutons; }
            set { couleurBoutons = value; }
        }

        public string[] ListeCouleurs
        {
            get { return listeCouleurs; }
        }


        public Couleur() //initialisation -> couleurs par défault sont les 3 premières de la liste
        {
            CouleurBarre = ListeCouleurs[0];
            CouleurGrille = ListeCouleurs[1];
            CouleurIconeBarre = ListeCouleurs[2];
        }

        public Couleur(string coulBarre, string coulGrille, string coulIconeBarre)
        {
            CouleurBarre = coulBarre;
            CouleurGrille = coulGrille;
            CouleurIconeBarre = coulIconeBarre;
        }

    }
}
