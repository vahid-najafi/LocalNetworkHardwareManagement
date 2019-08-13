using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalNetworkHardware.DataLayer.Services;
using LocalNetworkHardware.DataLayer.Services.Classes;

namespace LocalNetworkHardware.DataLayer.Context
{
    public class UnitOfWork : IDisposable
    {
        LocalNetworkHardwareManagement_DBEntities db =
            new LocalNetworkHardwareManagement_DBEntities();

        private ISystemsRepository _systemsRepository;
        public ISystemsRepository SystemsRepository
        {
            get
            {
                if (_systemsRepository == null)
                    _systemsRepository = new SystemsRepository(db);
                return _systemsRepository;

            }

        }


        private ICpuRepository _cpuRepository;
        public ICpuRepository CpuRepository
        {
            get
            {
                if (_cpuRepository == null)
                    _cpuRepository = new CpuRepository(db);
                return _cpuRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
