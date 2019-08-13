using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNetworkHardware.DataLayer.Services
{
    public interface IDriverRepository: IGenericRepository<Drivers>
    {
        bool IsDriverExists(int systemId, string driverAddress, out Drivers driver);
    }
}
