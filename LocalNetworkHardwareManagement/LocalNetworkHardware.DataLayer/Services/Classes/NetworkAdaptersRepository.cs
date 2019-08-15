using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNetworkHardware.DataLayer.Services.Classes
{
    public class NetworkAdaptersRepository : GenericRepository<NetworkAdapters>, INetworkAdaptersRepository
    {
        public NetworkAdaptersRepository(LocalNetworkHardwareManagement_DBEntities context)
        : base(context)
        {

        }

        public IEnumerable<NetworkAdapters> GetSystemExistingAdapters(int systemId)
        {
            return _db.NetworkAdapters.Where(n => n.SystemId == systemId).ToList();
        }

        public bool IsNetworkAdapterExists(int systemId, string name)
        {
            return _db.NetworkAdapters.AsNoTracking()
                .Any(na => na.SystemId == systemId && na.Name == name);
        }
    }
}
