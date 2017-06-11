using PaquetesTuristicos.Entities;
using PaquetesTuristicos.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Persistence.Repositories
{
   public  class TransporteRepository : Repository<Transporte>, ITransporteRepository
    {
        public TransporteRepository(PaqueteTuristicoDbContext context) : base(context)
        {
        }
    }
}
