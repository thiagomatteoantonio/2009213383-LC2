using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Entities
{
    public class Empleado : Persona
    {
        public int EmpSueldo { get; set; }

       

        //relaciones
        public List<VentaPaquete> VentaPaquetes { get; set; }
        public Empleado()
        {
            VentaPaquetes = new List<VentaPaquete>();
        }

    }
}
