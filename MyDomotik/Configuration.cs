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
            // test affichage de la grille
            Vue pageHome = new Vue("Home");
            Vue pageSuiv = new Vue("Bravo !");
            Navigation nav1 = new Navigation(pageSuiv);
            Navigation nav2 = new Navigation(pageHome);
            //fin test

            this.mainPage = pageHome;
            this.actions = new List<Action>();
            this.equipements = new List<Equipement>();
            this.pieces = new List<Piece>();
            this.modalites = new List<Modalite>();

            this.theme = new Theme();
            this.arbre = new Arbre(this.mainPage);

            //test
            Icone icone1 = new Icone("icone1", "bathroom_0.png", 64, nav1);
            Icone icone2 = new Icone("icone2", "bedroom_0.png", 64, nav2);
            Icone icone3 = new Icone("icone3", "battery_0.png", 64, (Action)null);
            Icone icone4 = new Icone("icone4", "bathroom_0.png", 64, (Action)null);
            this.ajouterIcone(pageHome, icone1, 0);
            this.ajouterIcone(pageHome, icone3, 2);
            this.ajouterIcone(pageHome, icone4, 4);
            this.ajouterIcone(pageHome, icone2, 6);
            this.ajouterIcone(pageHome, icone2, 8);
            this.ajouterIcone(pageHome, icone1, 10);
            this.ajouterIcone(pageHome, icone1, 12);
            this.ajouterIcone(pageHome, icone1, 13);
            this.ajouterIcone(pageHome, icone2, 16);
            this.ajouterIcone(pageHome, icone1, 17);
            this.ajouterIcone(pageHome, icone1, 24);
            this.ajouterIcone(pageHome, icone2, 25);

            this.ajouterIcone(pageSuiv, icone1, 1);
            this.ajouterIcone(pageSuiv, icone3, 3);
            this.ajouterIcone(pageSuiv, icone4, 4);
            this.ajouterIcone(pageSuiv, icone2, 5);
            this.ajouterIcone(pageSuiv, icone2, 6);
            this.ajouterIcone(pageSuiv, icone1, 10);
            this.ajouterIcone(pageSuiv, icone1, 11);
            this.ajouterIcone(pageSuiv, icone1, 13);
            this.ajouterIcone(pageSuiv, icone2, 16);
            this.ajouterIcone(pageSuiv, icone1, 17);
            this.ajouterIcone(pageSuiv, icone1, 24);
            this.ajouterIcone(pageSuiv, icone2, 25);
            //fin test
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
