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
        private Vue racine;
        private List<Arbre> fils = null;
        private Vue pageCourante;
        
        // propriétés
        public Vue Racine
        {
            get { return racine; }
            set { racine = value; }
        }

        public List<Arbre> Fils
        {
            get { return fils; }
            set { fils = value; }
        }

        public Vue PageCourante
        {
            get { return pageCourante; }
            set { pageCourante = value; }
        }

        // constructeur
        public Arbre(Vue v)
        {
            Racine = v;
            this.pageCourante = v;
        }

        // méthodes
        public void ajouterArbre(Arbre a) // dans l'arbre COURANT, ajoute l'arbre 'a' à la liste des fils 
        {
            Fils.Add(a);
        }

        public static void ajouterVue(Vue vuePere, Vue vueFils)   //  dans l'arbre GLOBAL, ajoute la vueFils dans la liste des fils de la vuePere
        {
            Arbre aPere = Configuration.Arbre.arbreVue(vuePere);
            Arbre aFils = new Arbre(vueFils);
            aPere.ajouterArbre(aFils);
        }

        public void modifPageCourante(Vue v){
           PageCourante = v;
        }

       /* public List<string> cheminPageCourante()
        {
            
        }*/


        public Arbre arbreVue(Vue v) // retourne le sous-arbre associé à la Vue v dans l'arbre courant
        {
            if(this.Racine.Nom == v.Nom) {
                return this;
            }
            else if (this.Fils != null)
            {
                foreach (Arbre arbre in this.Fils)
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
