using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNetworkHardware.DataLayer.Services.Classes
{
    public class CpuRepository: GenericRepository<CPUs>, ICpuRepository
    {
        public CpuRepository(LocalNetworkHardwareManagement_DBEntities context)
        : base (context)
        {
            
        }

        public bool IsSystemCpuExists(int systemId, out CPUs cpu)
        {
            cpu = _db.CPUs.AsNoTracking().FirstOrDefault(c => c.SystemId == systemId);
            return (cpu != null);
        }
    }
}
