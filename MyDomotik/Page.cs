using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDomotik
{
    class Page
    {
        private String nom;
        private Grille grille;

        // constructeur à partir du nom et du format de la grille
        public Page(String nom, Format formatGrille)
        {
            this.nom = nom;
            this.grille = new Grille(formatGrille);
        }

        // constructeur à partir du nom et du "format par défaut"
        public Page(String nom)
        {
            this.nom = nom;
            this.grille = new Grille(Format.MOYEN);
        }

        // Getters et setters
        public void setNom(String nom)
        {
            this.nom = nom;
        }

        public void setFormatGrille(Format format)
        {
            this.grille.setFormat(format);
        }

        public String getNom()
        {
            return this.nom;
        }

        public 
    }
}
