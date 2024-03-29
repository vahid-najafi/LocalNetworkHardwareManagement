﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNetworkHardware.DataLayer.Services
{
    public interface IRamRepository: IGenericRepository<RAMs>
    {
        bool IsRamExists(int systemId, out RAMs existingRAM);
    }
}
