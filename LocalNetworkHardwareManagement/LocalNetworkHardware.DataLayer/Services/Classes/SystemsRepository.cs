using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNetworkHardware.DataLayer.Services.Classes
{
    public class SystemsRepository: GenericRepository<Systems>, ISystemsRepository
    {
        public SystemsRepository(LocalNetworkHardwareManagement_DBEntities context)
        : base(context)
        {
            
        }

        public bool IsThisSystemExists(out Systems system)
        {
            system = _db.Systems.AsNoTracking().FirstOrDefault(s => s.IsOwned);

            return (system != null);
        }
    }
}
