using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDomotik
{
    class Configuration
    {
        //champs

        public Theme theme;
        public Arbre arbre;

        public static Vue mainPage;
        private List<Action> actions;
        private List<Equipement> equipements;
        private List<Modalite> modalites;
        private List<Piece> pieces;
        private ReglReseau reglagesReseau;

        //getters et setters
        public List<Piece> Pieces
        {
            get { return pieces; }
            set { pieces = value; }
        }
        public List<Modalite> Modalites
        {
            get { return modalites; }
            set { modalites = value; }
        }
        public List<Equipement> Equipements
        {
            get { return equipements; }
            set { equipements = value; }
        }
        public List<Action> Actions
        {
            get { return actions; }
            set { actions = value; }
        }
        public Theme Theme
        {
            get { return theme; }
            set { theme = value; }
        }
        public Arbre Arbre
        {
            get { return arbre; }
            set { arbre = value; }
        }
        public ReglReseau ReglagesReseau
        {
            get { return reglagesReseau; }
            set { reglagesReseau = value; }
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

            this.actions = new List<Action>();
            this.equipements = new List<Equipement>();
            this.pieces = new List<Piece>();
            this.modalites = new List<Modalite>();
            this.reglagesReseau = new ReglReseau();

            this.theme = new Theme();
            this.arbre = new Arbre(pageHome);

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

        // ajouter une icone à la grille de la page à partir de l'index et le numéro de page de la grille
        public void ajouterIcone(Vue page, Icone icone, int index, int numPage)
        {
            page.ajouterIcone(icone, index, numPage);
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

        public void ajouterPiece(Icone icone, int index, int numPage)
        {
            Piece piece = new Piece(icone.NomIcone);
            Vue pagePiece = new Vue(icone.NomIcone);

            icone.Navigation = new Navigation(pagePiece);
            icone.Action = (Action)null;

            // ajoute une page (associée à la piece) à l'arbre
            arbre.ajouterVue(arbre.Racine, pagePiece);

            // ajoute une icone (associee à la pièce) à la grille de la mainPage + à la liste Configuration.pieces
            ajouterIcone(arbre.Racine, icone, index, numPage);
            Pieces.Add(piece);

        }

        public void ajouterEquipement(Vue pagePiece, Vue pageEquip, Piece piece, Equipement equipmt, Icone icone, int index)
        {
            // ajoute une page (associée à l'équipement)  à l'arbre
            Arbre a = Arbre.arbreVue(pagePiece);  // on trouve la pièce dans l'arbre global grâce à la Vue pagePiece de la pièce dans laquelle on souhaite mettre l'équipement
            a.Fils.Add(new Arbre(pageEquip));  // on ajoute l'équipement à la liste des fils de la Vue pagePiece

            // ajoute une icone (associee à l'equipement) a la grille de la page de la piece + à la liste Configuration.equipements
            pagePiece.ajouterIcone(icone, index);  // on ajoute l'icone à la grille de la Vue de la pièce
            Equipements.Add(equipmt);  // on ajoute l'équipement à la liste globale des équipements

            // ajoute l'équipement à la liste des équipements de la pièce associée
            piece.addDevice(equipmt);
        }

        public void ajouterAction(Vue pageEquip, Vue pageAction, Equipement equipmt, Action action, Icone icone, int index)
        {
            // ajoute une icone (associee à l'action) a la grille de la page de l'equipement + + à la liste Configuration.actions
            pageEquip.ajouterIcone(icone, index);  // on ajoute l'icone à la grille de la Vue de l'équipement
            Actions.Add(action);  // on ajoute l'équipement à la liste globale des équipements

            // ajoute l'action à la liste des action de l'équipement associé
            equipmt.addAction(action);
        }
    }

}

