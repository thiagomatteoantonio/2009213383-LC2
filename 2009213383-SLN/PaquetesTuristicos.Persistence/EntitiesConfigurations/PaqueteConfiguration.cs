using PaquetesTuristicos.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Persistence.EntitiesConfigurations
{
   public class PaqueteConfiguration : EntityTypeConfiguration<Paquete> 
    {
        public PaqueteConfiguration()
        {
            //Table Configurations
            ToTable("Paquetes");
            HasKey(c => c.Id);


            //Relations Configurations 
            HasMany(c => c.ServiciosTurisctico)
                .WithMany(c => c.Paquetes)
            .Map(m =>
             {
                 m.ToTable("PaquetesServiciosTuristicos");
                 m.MapLeftKey("PaquetesId");
                 m.MapRightKey("Id");
             });

        }
    }
}
