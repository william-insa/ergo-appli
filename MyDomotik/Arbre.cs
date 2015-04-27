using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDomotik
{
    class Arbre
    {
        // champs
        private Vue noeux;
        private List<Arbre> fils = null;
        private Vue pageCourante;
        
        // propriétés
        internal Vue Noeux
        {
            get { return noeux; }
            set { noeux = value; }
        }

        internal List<Arbre> Fils
        {
            get { return fils; }
            set { fils = value; }
        }

        internal Vue PageCourante
        {
            get { return pageCourante; }
            set { pageCourante = value; }
        }

        // constructeur
        public Arbre(Vue v)
        {
            Noeux = v;
        }

        // méthodes
        public void ajouterArbre(Arbre element)
        {
            Fils.Add(element);
        }

        public void modifPageCourante(Vue v){
           PageCourante = v;
        }

        public List<string> cheminPageCourante()
        {

        }

    }
}
