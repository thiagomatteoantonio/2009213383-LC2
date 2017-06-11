using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Entities
{
    public class Hospedaje : ServicioTuristico
    {
        public string  Descripcion { get; set; }


        //relaciones
        public TipoHospedaje TipoHospedaje { get; set; }

        public  CalificacionHospedaje CalificacionHospedaje { get; set; }

        public CategoriaHospedaje CategoriaHospedaje { get; set; }

        public ServicioHospedaje ServicioHospedaje { get; set; }


    }
}
