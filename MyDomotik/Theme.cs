﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDomotik
{
    class Theme
    {
        // champs
        private int modeDefilement;
        private int vitesseDefilement;
        private Couleur couleur;

        // propriétés
        public int ModeDefilement
        {
            get { return modeDefilement; }
            set { modeDefilement = value; }
        }

        public int VitesseDefilement
        {
            get { return vitesseDefilement; }
            set { vitesseDefilement = value; }
        }

        public Couleur Couleur
        {
            get { return couleur; }
            set { couleur = value; }
        }

        // constructeurs
        public Theme()
        {
            ModeDefilement = 0;
            VitesseDefilement = 0;
            Couleur = new Couleur();
        }

        public Theme(int modeDef, int vitesseDef, Couleur coul)
        {
        ModeDefilement = modeDef;
        VitesseDefilement = vitesseDef;
        Couleur = coul;
        }
    }
}
