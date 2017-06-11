using PaquetesTuristicos.Entities;
using PaquetesTuristicos.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Persistence.Repositories
{
   public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(PaqueteTuristicoDbContext context) : base(context)
        {
        }
    }
}
