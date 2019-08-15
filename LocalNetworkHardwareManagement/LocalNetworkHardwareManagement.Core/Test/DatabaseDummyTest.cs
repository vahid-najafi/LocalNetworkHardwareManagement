using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalNetworkHardware.DataLayer;
using LocalNetworkHardware.DataLayer.Context;

namespace LocalNetworkHardwareManagement.Core.Test
{
    public class DatabaseDummyTest
    {
        private UnitOfWork _uof;

        public DatabaseDummyTest(UnitOfWork unitOfWork)
        {
            _uof = unitOfWork;
        }

        public async Task InsertTestRecords()
        {
            await Task.Run(() =>
            {
                int systemId = InsertSystem();
                InsertCPU(systemId);

                _uof.Save();
            });

        }

        public int InsertSystem()
        {
            Systems system = new Systems()
            {
                UniqMotherBoardId = "QCCXKG25C81001042",
                Name = "VahidTest",
                IsOwned = true
            };
            _uof.SystemsRepository.Insert(system);
            _uof.Save();
            return system.SystemId;
        }

        public void InsertCPU(int systemId)
        {
            _uof.CpuRepository.Insert(new CPUs()
            {
                Cores = 3,
                Name = "Intel core i7",
                SystemId = systemId
            });
        }
    }
}
