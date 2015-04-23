using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDomotik
{
    class Grille
    {
        // format de la grille
        private Format format;
        // nombre de cases par grille
        private int nbCasesGrille;
        
     

        // hashmap associant une icone à une case de la grille représentée par son index
        private Dictionary<int,Icone> icones;

        /*// nombre d'icones
        private int nbIcones;

         // liste des icones contenues dans la grille
        private List<Icone> icones;*/

        public Grille(Format format)
        {
            this.format = format;
            this.nbCasesGrille = format.getNbColonnes() * format.getNbLignes();
            this.icones = new Dictionary<int,Icone>();
            //this.nbIcones = 0;
        }

        public Format getFormat()
        {
            return this.format;
        }

        /*public List<Icone> getIcones()
        {
            return this.icones;
        }*/

        public Icone getIcone(int index)
        {
            return this.icones[index];
        }

        public void setFormat(int nbCol, int nbLignes)
        {
            this.format.setNbColonnes(nbCol);
            this.format.setNbLignes(nbLignes);
        }

        /*
        // Insère l'Icone icone à la position index dans la liste des icones
        public void addIcone(Icone icone, int index)
        {
            this.icones.Insert(index,icone);
            this.nbIcones++;
        }

        // Enlève l'Icone icone de la liste des icones si celle-ci existe.
        public void removeIcone(Icone icone)
        {
            this.icones.Remove(icone);
        }

        // Enlève l'icone situé à l'index indiqué de la liste des icones
        public void removeIcone(int index)
        {
            this.icones.RemoveAt(index);
        }
        */

        // Insère l'Icone icone à la case index 
        public void addIcone(Icone icone, int index)
        {
            this.icones.Add(index, icone);
            //this.nbIcones++;
        }

        // Enlève l'Icone à la case index.
        public void removeIcone(int index)
        {
            this.icones.Remove(index);
        }

     // calcule le nombre de pages nécessaires pour afficher la grille
        public int nbPagesGrille()
        {
            //calcul de l'index maximal contenu dans la hashmap
            int nbCases = 0;
            foreach (int key in icones.Keys)
            {
                if (key > nbCases) nbCases = key;
            }

            // calcul du nombre de pages
            int nbPages = nbCases / this.nbCasesGrille;
            if (nbCases % (this.nbCasesGrille) != 0) nbPages += 1 ;

            return nbPages;
        }

        // pageGrille(numPage) retourne un tableau contenant les icones de la page numPage dans l'ordre
        public Icone[] pageGrille(int numPage)
        {
            Icone[] pageGrille = new Icone[this.nbCasesGrille];

            //vérification : la page demandée existe-t-elle ?
            if (numPage <= this.nbPagesGrille())
            {
                // index min et max de la page numPage
                int indexMin = numPage*this.nbCasesGrille;
                int indexMax = indexMin + this.nbCasesGrille;

                foreach (int key in icones.Keys)
                {
                    if (key >= indexMin && key <= indexMax)
                    {
                        pageGrille[key] = this.icones[key];
                    }
                }
            }

            return pageGrille;
        }


    }
}
