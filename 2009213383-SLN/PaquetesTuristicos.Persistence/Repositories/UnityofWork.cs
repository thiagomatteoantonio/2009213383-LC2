using PaquetesTuristicos.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Persistence.Repositories
{
    public class UnityofWork : IUnityofWork
    {
        private readonly PaqueteTuristicoDbContext _Context;


        public IClienteRepository Cliente { get; private set; }

        public IAlimentacionRepository Alimentacion { get; private set; }

        public IEmpleadoRepository Empleado { get; private set; }

        public IComprobantePagoRepository ComprobantePago { get; private set; }

        public IHospedajeRepository Hospedaje { get; private set; }

        public IPaqueteRepository Paquete { get; private set; }

        public ITransporteRepository Transporte { get; private set; }

        public IVentaPaqueteRepository VentaPaquete { get; private set; }


        public UnityofWork()
        {

        }

        public UnityofWork(PaqueteTuristicoDbContext context)
        {
            _Context = new PaqueteTuristicoDbContext();

            Alimentacion = new AlimentacionRepository(_Context);
            Cliente = new ClienteRepository(_Context);
            ComprobantePago = new ComprobantePagoRepository(_Context);
            Empleado = new EmpleadoRepository(_Context);
            Hospedaje = new HospedajeRepository(_Context);         
            Paquete = new PaqueteRepository(_Context);
            Transporte = new TransporteRepository(_Context);
            VentaPaquete = new VentaPaqueteRepository(_Context);        

        }

        public void Dispose()
        {
            _Context.Dispose();
        }

       

        //metodo que cambia el estado de una entidad en el entityframework para que luego se cambie en la base de datos
        public void StateModified(object Entity)
        {
            _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }

        public int SaveChanges()
        {
            return _Context.SaveChanges();

        }


        //metodo que guarda los cambios. lleva los cambios en memoria hacia la base de datos.

    }
}
