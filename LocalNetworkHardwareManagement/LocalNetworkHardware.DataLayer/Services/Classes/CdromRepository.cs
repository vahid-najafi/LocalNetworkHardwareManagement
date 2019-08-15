using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNetworkHardware.DataLayer.Services.Classes
{
    public class CdromRepository: GenericRepository<CdROMs>, ICdromRepository
    {

        public CdromRepository(LocalNetworkHardwareManagement_DBEntities context)
        :base(context)
        {
            
        }

        public IEnumerable<CdROMs> GetAllSystemCdRoms(int systemId)
        {
            return _db.CdROMs.Where(c => c.SystemId == systemId).ToList();
        }
    }
}
