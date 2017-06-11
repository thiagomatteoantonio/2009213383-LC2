using PaquetesTuristicos.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Persistence.EntitiesConfigurations
{
    public class ServicioTuristicoConfiguration : EntityTypeConfiguration<ServicioTuristico>
    {
        public ServicioTuristicoConfiguration()
        {
            //Table Configurations
            ToTable("ServicioTuristicos");
            HasKey(c => c.Id);

            Map<Alimentacion>(m => m.Requires("Discriminator").HasValue("Alimentacion"));
            Map<Transporte>(m => m.Requires("Discriminator").HasValue("Transporte"));
            Map<Hospedaje>(m => m.Requires("Discriminator").HasValue("Hospedaje"));


        }
    }
}
