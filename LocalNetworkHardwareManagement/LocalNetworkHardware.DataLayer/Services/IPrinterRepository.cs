﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNetworkHardware.DataLayer.Services
{
    public interface IPrinterRepository: IGenericRepository<Printers>
    {
        IEnumerable<Printers> GetAllSystemPrinters(int systemId);
    }
}
