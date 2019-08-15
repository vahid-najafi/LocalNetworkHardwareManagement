using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNetworkHardware.DataLayer.Services.Classes
{
    public class OprativeSystemRepository: GenericRepository<OpratingSystems>, IOprativeSystemRepository
    {

        public OprativeSystemRepository(LocalNetworkHardwareManagement_DBEntities context)
            : base(context)
        {
            
        }

        public IEnumerable<OpratingSystems> GetAllSystemOs(int systemId)
        {
            return _db.OpratingSystems.Where(os => os.SystemId == systemId).ToList();
        }

        public bool IsOperatingSystemExists(OpratingSystems os, out OpratingSystems existingOS)
        {
            existingOS = _db.OpratingSystems.AsNoTracking()
                .FirstOrDefault(o => o.SystemId == os.SystemId && o.Name == os.Name && o.Architecture == os.Architecture);

            return (existingOS != null);
        }
    }
}
