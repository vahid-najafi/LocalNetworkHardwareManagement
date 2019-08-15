using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNetworkHardware.DataLayer.Services
{
    public interface IOprativeSystemRepository: IGenericRepository<OpratingSystems>
    {
        bool IsOperatingSystemExists(OpratingSystems os, out OpratingSystems existingOS);

        IEnumerable<OpratingSystems> GetAllSystemOs(int systemId);
    }
}
