using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNetworkHardware.DataLayer.Services.Classes
{
    public class RamRepository: GenericRepository<RAMs>, IRamRepository
    {

        public RamRepository(LocalNetworkHardwareManagement_DBEntities context)
        : base(context)
        {
            
        }

        public bool IsRamExists(int systemId, out RAMs existingRAM)
        {
            existingRAM = _db.RAMs.AsNoTracking()
                .FirstOrDefault(r => r.SystemId == systemId);

            return (existingRAM != null);
        }
    }
}
