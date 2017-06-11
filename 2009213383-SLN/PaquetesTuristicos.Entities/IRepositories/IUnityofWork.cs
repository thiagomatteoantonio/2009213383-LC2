using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Entities.IRepositories
{
    public interface IUnityofWork : IDisposable
    {
        //Cada una de las propiedades deben ser de solo lectura
            IAlimentacionRepository Alimentacion { get; }
            IClienteRepository Cliente { get; }   
            IComprobantePagoRepository ComprobantePago { get; }
            IEmpleadoRepository Empleado { get; }
            IHospedajeRepository Hospedaje { get; }        
            IPaqueteRepository Paquete { get; }        
            ITransporteRepository Transporte { get; }
            IVentaPaqueteRepository VentaPaquete { get; }

        //Método que guardará los cambios en la base de datos.
        int SaveChanges();
        void StateModified(object Entity);
    } 
}
