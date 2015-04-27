﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDomotik
{
    class Configuration
    {
        public static Theme theme;
        public static Arbre arbre;

        private Vue mainPage;
        private List<Action> actions;
        private List<Equipement> equipements;
        private List<Modalite> modalites;
        private List<Piece> pieces;

        //getters et setters
        internal List<Piece> Pieces
        {
            get { return pieces; }
            set { pieces = value; }
        }
        internal List<Modalite> Modalites
        {
            get { return modalites; }
            set { modalites = value; }
        }
        
        internal List<Equipement> Equipements
        {
            get { return equipements; }
            set { equipements = value; }
        }

        internal List<Action> Actions
        {
            get { return actions; }
            set { actions = value; }
        }
       
        public static Theme Theme
        {
            get { return Configuration.theme; }
            set { Configuration.theme = value; }
        }

        public static Arbre Arbre
        {
            get { return Configuration.arbre; }
            set { Configuration.arbre = value; }
        }

        //constructeur
        public Configuration()
        {
            this.mainPage = new Vue("Pièces");
            this.actions = new List<Action>();
            this.equipements = new List<Equipement>();
            this.pieces = new List<Piece>();
            this.modalites = new List<Modalite>();

            theme = new Theme();
            arbre = new Arbre(this.mainPage);
        }

        public string toStringXML(){  // retourne la configuration sous forme de balisage XML (plus simple pour sauvegarder dans un fichier)
            string configXML = "";

            // à compléter (William)

            return configXML;

        }

        


    }
}
