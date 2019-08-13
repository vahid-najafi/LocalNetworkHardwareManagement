using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNetworkHardware.DataLayer.Services
{
    public interface ISystemsRepository: IGenericRepository<Systems>
    {
        bool IsThisSystemExists(out Systems system);
    }
}
