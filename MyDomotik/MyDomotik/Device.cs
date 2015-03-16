using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDomotik
{
    class Device
    {
        // Nom de l'appareil
        private string deviceName;
        // Chemin de l'icone
        private string icone;

        public Device(string name)
        {
            this.deviceName = name;
            this.icone = "assets/device_default_icone.png";
        
        }
        public void setDeviceName(string name)
        {
            this.deviceName = name;
        }

        public string getRoomName()
        {
            return this.deviceName;
        }

        public void setIcone(string icone)
        {
            this.icone = icone;
        }

        public string getIcone()
        {
            return this.icone;
        }
    }
}
