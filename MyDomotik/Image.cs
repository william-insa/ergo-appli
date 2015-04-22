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

        // constructeur d'image
        public Image(String nomFichier, int taille)
        {
            this.taille = taille;
            string path = "Assets\ICONS_MDTOUCH\size_"+taille+"x"+taille; // path spécifie le dossier adéquat en fonction de la taille de l'image
            this.source = Path.Combine(path, nomFichier);
        }
    }
}
