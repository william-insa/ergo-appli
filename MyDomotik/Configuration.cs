using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDomotik
{
    class Configuration
    {
        public Theme theme;
        public Arbre arbre;

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
            get { return Theme; }
            set { Theme = value; }
        }

        public static Arbre Arbre
        {
            get { return Arbre; }
            set { Arbre = value; }
        }

        //constructeur
        public Configuration()
        {
            this.mainPage = new Vue("Pièces de la Maison");
            this.actions = new List<Action>();
            this.equipements = new List<Equipement>();
            this.pieces = new List<Piece>();
            this.modalites = new List<Modalite>();

            this.theme = new Theme();
            this.arbre = new Arbre(this.mainPage);
        }

        public string toStringXML()
        {  // retourne la configuration sous forme de balisage XML (plus simple pour sauvegarder dans un fichier)
            string configXML = "";

            // à compléter (William)

            return configXML;

        }

        // ajouter une icone à la grille de la page
        public void ajouterIcone(Vue page, Icone icone, int index)
        {
            page.ajouterIcone(icone, index);
        }

        // enlever l'icone à l'index index
        public void enleverIcone(Vue page, int index)
        {
            page.enleverIcone(index);
        }

        // retourne l'icone située à l'index demandé
        public Icone getIcone(Vue page, int index)
        {
            return page.getIcone(index);
        }

       /* public void ajouterPiece(Vue page, Icone icone, int index, Piece piece)
        {
            // ajoute une page (associée à la piece) à l'arbre
            Arbre a = Arbre.arbreVue(page);
            a.Fils.Add(new Arbre(page));

            // ajoute une icone (associee à la pièce) à la grille de la mainPage + à la liste Configuration.pieces
            mainPage.ajouterIcone(icone, index);
            Pieces.Add(piece);
        }*/

        public void ajouterEquipement(Vue page, Piece piece, Equipement equipmt, int index)
        {
            /*   à finir
                    // ajoute une page à l'arbre
                    Arbre a = Arbre.arbreVue(page);
                    a.Fils.Add(new Arbre(page));

                    // ajoute une icone (associee à l'equipement) a la grille de la page de la piece + à la liste Configuration.equipements
                    mainPage.ajouterIcone(icone, index);
                    Pieces.Add(piece);
             */
        }
    }

}
