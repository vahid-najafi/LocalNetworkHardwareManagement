using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNetworkHardware.DataLayer.Services
{
    public interface INetworkAdaptersRepository: IGenericRepository<NetworkAdapters>
    {
        bool IsNetworkAdapterExists(int systemId, string name);

        IEnumerable<NetworkAdapters> GetSystemExistingAdapters(int systemId);
    }
}
