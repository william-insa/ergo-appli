using System;
using Windows.UI;
//using System.Drawing;
using Windows.UI.Xaml.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDomotik
{
    class Couleur
    {
        private Color couleurGrille;
        private Color couleurBarre;
        private Color couleurBoutons;

        private readonly Color[] listeCouleurs = new Color[]
   {Colors.Blue, Colors.DarkMagenta, Colors.Green,
    Colors.Red , Colors.Yellow     , Colors.White
   };
        public Color CouleurGrille
        {
            get { return couleurGrille; }
            set { couleurGrille = value; }
        }

        public Color CouleurBarre
        {
            get { return couleurBarre; }
            set { couleurBarre = value; }
        }

        public Color CouleurIconeBarre
        {
            get { return couleurBoutons; }
            set { couleurBoutons = value; }
        }

        public Color[] ListeCouleurs
        {
            get { return listeCouleurs; }
        }

        // constructeurs
        public Couleur() //initialisation -> les couleurs par défault sont les 3 premières de la liste (càd le premier thème)
        {
            CouleurGrille = ListeCouleurs[0];
            CouleurBarre = ListeCouleurs[1];
            CouleurBoutons = ListeCouleurs[2];
        }

        public Couleur(Color coulBarre, Color coulGrille, Color coulIconeBarre)
        {
            CouleurBarre = coulBarre;
            CouleurGrille = coulGrille;
            CouleurBoutons = CoulBoutons;
        }
    }
}
