﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNetworkHardware.DataLayer.Services
{
    public interface ICpuRepository: IGenericRepository<CPUs>
    {
        bool IsSystemCpuExists(int systemId, out CPUs cpu);

    }
}
