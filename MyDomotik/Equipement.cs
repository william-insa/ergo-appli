using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDomotik
{
    class Equipement
    {
        // Nom de l'equipement
        private string nom;
        // Pièce où se situe l'equipement
        private Piece piece;
        // Liste  d'action que l'on peut effectuer avec l'équipement
        private List<Action> action;


        public Equipement(string name) 
        {
            this.nom = name;
            this.action = new List<Action>();
            this.piece = null;
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }


        internal Piece Piece
        {
            get { return piece; }
            set { piece = value; }
        }
   

        public void addAction(Action a)
        {
            this.action.Add(a);
            a.Equipement(this);
        }

        public void afficheAction()
        {

        }
    }
}
