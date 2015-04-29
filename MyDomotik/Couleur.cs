﻿using System;
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
        private Color couleurBoutonActif;
        private Color couleurBoutonVide;

      

        Brush boutonActif = new SolidColorBrush(Colors.Red);
        Brush boutonVide = new SolidColorBrush(Colors.White);

        private readonly Color[] listeCouleurs = new Color[]
   {Colors.Blue, Colors.Violet, Colors.Lime, Colors.Red, Colors.White,
    Colors.Red , Colors.Yellow, Colors.White, Colors.Yellow, Colors.White
   }; 
        
        public Color CouleurBoutonVide
        {
            get { return couleurBoutonVide; }
            set { couleurBoutonVide = value; }
        }
        public Color CouleurBoutonActif
        {
            get { return couleurBoutonActif; }
            set { couleurBoutonActif = value; }
        }
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

        public Color CouleurBoutons
        {
            get { return couleurBoutons; }
            set { couleurBoutons = value; }
        }

        public Color[] ListeCouleurs
        {
            get { return listeCouleurs; }
        }

        // constructeurs
        public Couleur(int i)  // créé la couleur avec le i-ème thème de la liste de couleurs
        {
            if(i < listeCouleurs.Length)
            {
                CouleurGrille = ListeCouleurs[5 * i];
                CouleurBarre = ListeCouleurs[5 * i + 1];
                CouleurBoutons = ListeCouleurs[5 * i + 2];
                CouleurBoutonActif = ListeCouleurs[5 * i + 3];
                CouleurBoutonActif = ListeCouleurs[5 * i + 4];
            }
            else
            {
                CouleurGrille = ListeCouleurs[0];
                CouleurBarre = ListeCouleurs[1];
                CouleurBoutons = ListeCouleurs[2];
                CouleurBoutonActif = ListeCouleurs[3];
                CouleurBoutonActif = ListeCouleurs[4];
            }
            
        }
        public Couleur()  // créé la couleur avec le i-ème thème de la liste de couleurs
        {
            CouleurGrille = ListeCouleurs[0];
            CouleurBarre = ListeCouleurs[1];
            CouleurBoutons = ListeCouleurs[2];
            CouleurBoutonActif = ListeCouleurs[3];
            CouleurBoutonActif = ListeCouleurs[4];
        }
    }
}
