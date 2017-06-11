using PaquetesTuristicos.Entities;
using PaquetesTuristicos.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaquetesTuristicos.Persistence.Repositories
{
   public class VentaPaqueteRepository : Repository<VentaPaquete>, IVentaPaqueteRepository
    {
        public VentaPaqueteRepository(PaqueteTuristicoDbContext context) : base(context)
        {

        }

        IEnumerable<VentaPaquete> IVentaPaqueteRepository.GetComprobantePago()
        {
            throw new NotImplementedException();
        }
    }
}
