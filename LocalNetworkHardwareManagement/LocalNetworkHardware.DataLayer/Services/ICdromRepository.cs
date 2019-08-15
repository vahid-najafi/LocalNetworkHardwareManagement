using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNetworkHardware.DataLayer.Services
{
    public interface ICdromRepository: IGenericRepository<CdROMs>
    {
        IEnumerable<CdROMs> GetAllSystemCdRoms(int systemId);
    }
}
