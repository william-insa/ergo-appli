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
            this.pageCourante = v;
        }

        // méthodes
        public void ajouterArbre(Arbre element)
        {
            Fils.Add(element);
        }

        public void modifPageCourante(Vue v){
           PageCourante = v;
        }

       /* public List<string> cheminPageCourante()
        {
            
        }*/


        internal void retourAccueil()
        {
            throw new NotImplementedException();
        }

        public Arbre arbreVue(Vue v) // retourne l'arbre associé à la Vue v dans l'arbre global arbreConfig de la Configuration
        {               
            if(a.Noeux.Nom == v.Nom) {
                return a;
            }
            else if (a.Fils != null)
            {
                foreach (Arbre arbre in a.Fils)
                {
                    Arbre aTemp = arbre.arbreVue(v);
                    if (aTemp != null)
                        return aTemp;
                }
            }
            return null;
        }
    }
}
