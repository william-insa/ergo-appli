using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace MyDomotik
{
    class Enregistrement
    {
        private string config = ""; // configuration à enregistrer
        private string fileName = "config.xml";

        // System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", lines);

        public Enregistrement(Configuration c)
        {
            config = c.toStringXML();
            creerFichierEnr();
        }

        public Enregistrement()
        {

        }


        private void creerFichierEnr()
        {

            /*
            System.IO.Stream stream = new System.IO.MemoryStream();

            using (Stream fs = File.OpenWrite(path))

            using (StreamWriter file = new StreamWriter(stream))
            {
                file.Write(config);
            }
            */

            /*
            string fileeName = "test.txt";
            string textToAdd = "Example text in file";

            using (StreamWriter writer = new StreamWriter(fileeName)
            {
                writer.Write(textToAdd);
            }
            */


        }
    }
}
