using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalNetworkHardware.DataLayer;
using LocalNetworkHardware.DataLayer.Context;
using LocalNetworkHardwareManagement.Core.Helpers;
using LocalNetworkHardwareManagement.Core.Models;

namespace LocalNetworkHardwareManagement.Core.Buisness
{
    public class ManageSystemInformations
    {
        private UnitOfWork _uof;


        public ManageSystemInformations(UnitOfWork unitOfWork)
        {
            _uof = unitOfWork;
        }

        public async Task<int> CheckThisSystem()
        {
            GlobalSystemModel systemModel = await HardwareInformationHelper.GetAll();
            int systemId = 0;
            string finalMessage = "";


            return await Task.Run(() =>
            {
                //TODO: Compelete Model For Update
                if (_uof.SystemsRepository.IsThisSystemExists(out Systems system))
                {
                    systemModel.System.SystemId = system.SystemId;
                    //TODO: Check The Difference
                    _uof.SystemsRepository.Update(systemModel.System);
                    _uof.Save();
                    finalMessage += "اطلاعات سیستم بروزرسانی شد\n";
                }
                else
                {
                    _uof.SystemsRepository.Insert(systemModel.System);
                    _uof.Save();
                }

                systemId = systemModel.System.SystemId;

                //Check if cpu with this systemId exists
                if (_uof.CpuRepository.IsSystemCpuExists(systemId))
                {
                    //if it exists check the different and update
                    //TODO: Check Difference
                    _uof.CpuRepository.Update(systemModel.CPU);
                    _uof.Save();
                }
                else
                {
                    _uof.CpuRepository.Insert(systemModel.CPU);
                }
                

                return systemModel.System.SystemId;
            });
        }
    }
}
