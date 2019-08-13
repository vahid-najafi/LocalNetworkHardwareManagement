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




        private ICdromRepository _cdromRepository;
        public ICdromRepository CdromRepository
        {
            get
            {
                if (_cdromRepository == null)
                    _cdromRepository = new CdromRepository(db);
                return _cdromRepository;
            }
        }




        private IDriverRepository _driverRepository;
        public IDriverRepository DriverRepository
        {
            get
            {
                if (_driverRepository == null)
                    _driverRepository = new DriverRepository(db);
                return _driverRepository;
            }
        }




        private IGpuRepository _gpuRepository;
        public IGpuRepository GpuRepository
        {
            get
            {
                if (_gpuRepository == null)
                    _gpuRepository = new GpuRepository(db);
                return _gpuRepository;
            }
        }



        private INetworkAdaptersRepository _networkAdaptersRepository;
        public INetworkAdaptersRepository NetworkAdaptersRepository
        {
            get
            {
                if (_networkAdaptersRepository == null)
                    _networkAdaptersRepository = new NetworkAdaptersRepository(db);
                return _networkAdaptersRepository;
            }
        }




        private IOprativeSystemRepository _oprativeSystemRepository;
        public IOprativeSystemRepository OprativeSystemRepository
        {
            get
            {
                if (_oprativeSystemRepository == null)
                    _oprativeSystemRepository = new OprativeSystemRepository(db);
                return _oprativeSystemRepository;
            }
        }



        private IPrinterRepository _printerRepository;
        public IPrinterRepository PrinterRepository
        {
            get
            {
                if (_printerRepository == null)
                    _printerRepository = new PrinterRepository(db);
                return _printerRepository;
            }
        }




        private IRamRepository _ramRepository;
        public IRamRepository RamRepository
        {
            get
            {
                if (_ramRepository == null)
                    _ramRepository = new RamRepository(db);
                return _ramRepository;
            }
        }



        private ISoundCardRepository _soundCardRepository;
        public ISoundCardRepository SoundCardRepository
        {
            get
            {
                if (_soundCardRepository == null)
                    _soundCardRepository = new SoundCardRepository(db);
                return _soundCardRepository;
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
