using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDomotik
{
    class Format
    {
        private int nbColonnes;
        private int nbLignes;
        
        // constructeur format
        public Format(int nbColonnes, int nbLignes)
        {
            if (!(nbColonnes <= 0 || nbLignes <= 0))
            {
                this.nbColonnes = nbColonnes;
                this.nbLignes = nbLignes;
            }
            
        }

        // getters and setters nbColonnes, nbLignes
        public int getNbColonnes()
        {
            return this.nbColonnes;
        }

        public int getNbLignes()
        {
            return this.nbLignes;
        }

        public void setNbColonnes(int nb)
        {
            this.nbColonnes = nb;        
        }

        public void setNbLignes(int nb)
        {
            this.nbLignes = nb;
        }
        
    }
}
