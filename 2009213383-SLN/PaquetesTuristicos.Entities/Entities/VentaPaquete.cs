using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Entities
{
    public class VentaPaquete
    {
        public int Id { get; set; }


        //relaciones
        public int Id { get; set; }
        public ComprobantePago ComprobantePago { get; set; }    

        public MedioPago MediosPago { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<Empleado> Empleados { get; set; }
        public List<Paquete> Paquetes { get; set; } 

        public VentaPaquete()
        {
            Clientes= new List<Cliente>();
            Empleados= new List<Empleado>();
            Paquetes = new List<Paquete>();

        }

    }
}
