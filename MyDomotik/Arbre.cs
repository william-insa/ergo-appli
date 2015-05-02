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
        private List<Arbre> fils;
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
            set
            { pageCourante = value; }
        }

        // constructeur
        public Arbre(Vue v)
        {
            Racine = v;
            Fils = null;
            pageCourante = v;
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

        public List<Vue> cheminPageCour()   //la liste de vues est classée par ordre "décroissant", çad la pageCourante est en premier et la mainPage en dernier. On remonte l'arborescence en parcourant la liste de l'indice 0 à cheminPageCourante.Lenght-1
        {
            List<Vue> list = new List<Vue>();
            Arbre aTemp = this;

            do{
                list.Add(aTemp.PageCourante);
                aTemp = arbreVuePere(list.ElementAt<Vue>(list.Count));
            } while(aTemp != null);

            return list;   
        }

        public Arbre arbreVuePere(Vue v)
        {
            if (this.Fils != null)
            {
                foreach (Arbre a in this.Fils)
                {
                    if (a.Racine.Nom == v.Nom)
                        return this;
                }
            }
            else
            {
                foreach (Arbre a in this.Fils)
                {
                    Arbre aTemp = a.arbreVuePere(v);
                    if (aTemp != null)
                        return aTemp;
                }
            }
            return null;
        }

        public Arbre arbreVue(Vue v) // retourne le sous-arbre associé à la Vue v dans l'arbre courant
        {
            Arbre aTemp = arbreVuePere(v);
            if(aTemp.Racine.Nom == null){
                if (v.Nom != Configuration.mainPage.Nom)
                {
                    return this;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                foreach (Arbre a in Fils)
                {
                    if (a.Racine.Nom == v.Nom)
                        return a;
               }
            }
            return null;
        }

        public void retourAccueil()
        {
           // throw new NotImplementedException();

            // pageCourante = Racine;
        }
    }
}
