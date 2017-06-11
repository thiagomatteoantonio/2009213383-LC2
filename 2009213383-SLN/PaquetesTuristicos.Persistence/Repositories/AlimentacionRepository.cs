using PaquetesTuristicos.Entities;
using PaquetesTuristicos.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Persistence.Repositories
{
   public class AlimentacionRepository : Repository<Alimentacion>, IAlimentacionRepository
    {
        public AlimentacionRepository(PaqueteTuristicoDbContext context) : base(context)
        {
        }



    }
}
