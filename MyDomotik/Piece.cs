using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDomotik
{
    class Piece
    {
         
        // Nom de la pièce
        private string nom;

        // Equipements de la pièces 
        public List<Equipement> devices;

        public Piece(string name)
        {
            this.nom = name;
            this.devices = new List<Equipement>();
        
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        /** boolean addDevice : ajoute un appareil de nom "name" à la pièce. 
         * Retourne vrai si l'appareil a été ajouté, faux sinon.
         **/
        public bool addDevice(Equipement e)
        {
            if (!this.devices.Contains(e))
            {
                this.devices.Add(e);
                e.Piece = this;
                return true;
            }
            return false;
        }

        /** boolean removeDevice : enlève l'appareil de nom "name" s'il existe et retourne vrai. 
        * Retourne faux sinon.
        **/
       public bool removeDevice(Equipement e)
        {
            if (!this.devices.Contains(e))
            {
                  return false;
            }
            else
            {
                this.devices.Remove(e);
                e.Piece = null;
                return true;
            } 
        }

       public void afficheEquipement()
       {

       }
    }
}
