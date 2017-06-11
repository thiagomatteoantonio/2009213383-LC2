using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Entities
{
    public abstract class ServicioTuristico
    {
        public int Id { get; set; }
        public String  Fecha { get; set; }
        public DateTime Hora { get; set; }
        public string Direccion { get; set; }

        
        public List<Paquete> Paquetes { get; set; }
        public ServicioTuristico()
        {
            Paquetes = new List<Paquete>();
        }

    }
}
