using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Entities
{
     public class Alimentacion : ServicioTuristico
    {


        //relaciones

        public CategoriaAlimentacion CategoriaAlimentacion { get; set; }
        
       

    }
}
