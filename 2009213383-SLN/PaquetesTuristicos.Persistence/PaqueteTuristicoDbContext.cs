using PaquetesTuristicos.Entities;
using PaquetesTuristicos.Persistence.EntitiesConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Persistence
{
    public class PaqueteTuristicoDbContext  : DbContext 
    {

        public DbSet<ComprobantePago> ComprobantesPago { get; set; }
        public DbSet<Persona> Empleados { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }     
        public DbSet<ServicioTuristico> ServiciosTuristicos { get; set; }    
        public DbSet<VentaPaquete> VentaPaquetes{ get; set; }

        public PaqueteTuristicoDbContext()
			:base("PaqueteTuristico")
		{

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonaConfiguration());

            modelBuilder.Configurations.Add(new ComprobantePagoConfiguration());
            modelBuilder.Configurations.Add(new PaqueteConfiguration());
            modelBuilder.Configurations.Add(new ServicioTuristicoConfiguration()); 
            
            modelBuilder.Configurations.Add(new VentaPaqueteConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<PaquetesTuristicos.Entities.Cliente> Personas { get; set; }

        public System.Data.Entity.DbSet<PaquetesTuristicos.Entities.Alimentacion> ServicioTuristicoes { get; set; }
    }
}
