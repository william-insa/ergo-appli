using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace MyDomotik
{
    class Room
    {
        // Nom de la pièce
        private string roomName;
        // Chemin de l'icone
        private string icone;
        // Appareils de la pièces 
        //public Hashtable devices;

        public Room(string name)
        {
            this.roomName = name;
            this.icone = "Assets/default_icon.png";
            //this.devices = new Hashtable();
        }

        public Room(string name, string iconPath)
        {
            this.roomName = name;
            this.icone = iconPath;
           // this.devices = new Hashtable();
        }
        public void setRoomName(string name)
        {
            this.roomName = name;
        }

        public string getRoomName()
        {
            return this.roomName;
        }

        public void setIcone(string icone)
        {
            this.icone = icone;
        }

        public string getIcone()
        {
            return this.icone;
        }

        /** boolean addDevice : ajoute un appareil de nom "name" à la pièce. 
         * Retourne vrai si l'appareil a été ajouté, faux sinon.
         **/
       /* public bool addDevice(string name)
        {
            if (!this.devices.ContainsKey(name))
            {
                Device device = new Device(name);
                this.devices.Add(name , device);
                return true;
            }
            return false;
        }

        /** boolean removeDevice : enlève l'appareil de nom "name" s'il existe et retourne vrai. 
        * Retourne faux sinon.
        **/
      /*  public bool removeDevice(string name)
        {
            if (!this.devices.ContainsKey(name))
            {
                this.devices.Remove(name);
                return true;
            }
            return false;
        }*/
    }
}
