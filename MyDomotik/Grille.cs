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
        private int nbCases;
        // nombre d'icones
        private int nbIcones;
        // liste des icones contenues dans la grille
        private List<Icone> icones;

        public Grille(Format format)
        {
            this.format = format;
            this.nbCases = format.getNbColonnes() * format.getNbLignes();
            this.icones = new List<Icone>;
            this.nbIcones = 0;
        }

        public Format getFormat()
        {
            return this.format;
        }

        public List<Icone> getIcones()
        {
            return this.icones;
        }

        public void setFormat(int nbCol, int nbLignes)
        {
            this.format.setNbColonnes(nbCol);
            this.format.setNbLignes(nbLignes);
        }

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
    }
}
