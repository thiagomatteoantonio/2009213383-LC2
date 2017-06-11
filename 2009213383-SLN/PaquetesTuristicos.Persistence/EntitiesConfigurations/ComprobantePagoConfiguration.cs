using PaquetesTuristicos.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Persistence.EntitiesConfigurations
{
   public class ComprobantePagoConfiguration : EntityTypeConfiguration<ComprobantePago>
    {
        public ComprobantePagoConfiguration()
        {
            //Table Configurations
            ToTable("ComprobantesPago");

            HasKey(c => c.Id);

            //Relations Configurations 
            
        }
    }
}
