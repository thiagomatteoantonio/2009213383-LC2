    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Entities
{
    public class Transporte : ServicioTuristico
    {
        public string DescripcionTransporte { get; set; }

        //relaciones

        public TipoTransporte TipoTransporte { get; set; }
        public CategoriaTransporte CategoriaTransporte { get; set; }
        
        

    }
}
