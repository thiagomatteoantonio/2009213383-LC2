using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Entities
{
    public class Cliente : Persona 
    {
        public int NroCuenta { get; set; }


        //relaciones
        public List<VentaPaquete> VentaPaquetes { get; set; }
       
        public Cliente()
        {
            VentaPaquetes = new List<VentaPaquete>();
        }
    }
}
