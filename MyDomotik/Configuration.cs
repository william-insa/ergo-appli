using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDomotik
{
    class Configuration
    {
        public static Theme theme;
        public static Arbre arbre;

        public static Theme Theme
        {
            get { return Configuration.theme; }
            set { Configuration.theme = value; }
        }

        public static Arbre Arbre
        {
            get { return Configuration.arbre; }
            set { Configuration.arbre = value; }
        }



    }
}
