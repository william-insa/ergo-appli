using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace MyDomotik
{
    class Image
    {
        private int taille;
        private String source;

        //getters and setters
        public int Taille
        {
            get { return taille; }
            set { taille = value; }
        }
        public String Source
        {
            get { return source; }
            set { source = value; }
        }

        // constructeur d'image
        public Image(String nomFichier, int taille)
        {
            this.taille = taille;
            string path = "Assets\\ICONS_MDTOUCH\\size_"+taille+"x"+taille; // path spécifie le dossier adéquat en fonction de la taille de l'image
            this.source = Path.Combine(path, nomFichier);
        }
    }
}
