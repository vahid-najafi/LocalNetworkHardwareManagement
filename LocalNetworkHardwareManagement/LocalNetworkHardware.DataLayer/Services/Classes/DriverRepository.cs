using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNetworkHardware.DataLayer.Services.Classes
{
    public class DriverRepository: GenericRepository<Drivers>, IDriverRepository
    {
        public DriverRepository(LocalNetworkHardwareManagement_DBEntities context) : base(context)
        {
            
        }

        public bool IsDriverExists(int systemId, string driverAddress, out Drivers driver)
        {
            driver = _db.Drivers.AsNoTracking()
                .FirstOrDefault(d => d.SystemId == systemId && d.Address == driverAddress);
            return (driver != null);
        }
    }
}
