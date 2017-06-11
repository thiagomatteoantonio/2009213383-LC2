using PaquetesTuristicos.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Persistence.EntitiesConfigurations
{
    class PersonaConfiguration : EntityTypeConfiguration<Persona>
    {
        public PersonaConfiguration()
        {
            ToTable("Persona");
            HasKey(c => c.Id);

            Map<Cliente>(m => m.Requires("Discriminator").HasValue("Cliente"));
            Map<Empleado>(m => m.Requires("Discriminator").HasValue("Empleado"));
          
        }

    }
}
