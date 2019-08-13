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

        public async Task<string> CheckThisSystem()
        {
            GlobalSystemModel systemModel = await HardwareInformationHelper.GetAll();
            int systemId = 0;
            string finalMessage = "";


            return await Task.Run(() =>
            {
                //Checking System
                if (_uof.SystemsRepository.IsThisSystemExists(out Systems system))
                {
                    systemModel.System.SystemId = system.SystemId;
                    //TODO: Check The Difference
                    _uof.SystemsRepository.Update(systemModel.System);
                    _uof.Save();
                    finalMessage += "اطلاعات سیستم بروزرسانی شد.\n";
                }
                else
                {
                    _uof.SystemsRepository.Insert(systemModel.System);
                    _uof.Save();
                    finalMessage += "اطلاعات سیستم ثبت شد.\n";
                }

                //Getting SystemId For Other Entities
                systemId = systemModel.System.SystemId;

                //Modifing CPU Foreign Key
                systemModel.CPU.SystemId = systemId;

                //Checking CPU
                if (_uof.CpuRepository.IsSystemCpuExists(systemId, out CPUs cpu))
                {
                    //if it exists check the different and update
                    systemModel.CPU.CpuId = cpu.CpuId;
                    //TODO: Check Difference
                    _uof.CpuRepository.Update(systemModel.CPU);
                    finalMessage += "اطلاعات پردازنده بروزرسانی شد.\n";
                }
                else
                {
                    _uof.CpuRepository.Insert(systemModel.CPU);
                    finalMessage += "اطلاعات پردازنده ثبت شد.\n";
                }


                //Checking Drivers
                foreach (Drivers driver in systemModel.Drivers)
                {
                    
                }
                
                _uof.Save();
                return finalMessage;
            });
        }
    }
}
