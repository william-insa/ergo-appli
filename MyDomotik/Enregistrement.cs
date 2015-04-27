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
        string config; // configuration à enregistrer
        string fileName = "config.xml";
            
            // System.IO.File.WriteAllLines(@"C:\Users\Public\TestFolder\WriteLines.txt", lines);

        public Enregistrement(Configuration c)
        {
            config = c.toStringXML();
            creerFichierEnr(config);
        }


        private void creerFichierEnr(string conf){
            
            /*
             * 
            // Use Combine again to add the file name to the path.
            pathString = System.IO.Path.Combine(@".\", fileName);

            // Verify the path that you have constructed.
            Console.WriteLine("Path to my file: {0}\n", pathString);

            // Check that the file doesn't already exist. If it doesn't exist, create
            // the file and write integers 0 - 99 to it.
            // DANGER: System.IO.File.Create will overwrite the file if it already exists.
            // This could happen even with random file names, although it is unlikely.
            if (!System.IO.File.Exists(pathString))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(pathString))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", fileName);
                return;
            }
       */
             
        }
            





    }
}
