using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDomotik
{
    class Action
    {
        // Nom de l'action
        private string nom;

        // Code associé à l'action
        private string code;

        // Equipement concerné par l'action
        private Equipement equipement;
        
        //Modalité de l'action
        private Modalite modalite;


        public Action(string name, Modalite modalite)
        {
            this.nom = name;
            this.modalite = modalite;
        }


        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }


       public Equipement Equipement
        {
            get { return equipement; }
            set { equipement = value; }
        }


        public Modalite Modalite
        {
            get { return modalite; }
            set { modalite = value; }
        }

    }
}
