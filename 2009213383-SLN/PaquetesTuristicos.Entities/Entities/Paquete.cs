using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Entities
{
    public class Paquete
    {
        public int Id { get; set; }

        public List<VentaPaquete> VentaPaquetes { get; set; }
        public List<ServicioTuristico> ServiciosTurisctico { get; set; }

        public Paquete()
        {   
            VentaPaquetes = new List<VentaPaquete>();
            ServiciosTurisctico = new List<ServicioTuristico>();

        }


    }
}
