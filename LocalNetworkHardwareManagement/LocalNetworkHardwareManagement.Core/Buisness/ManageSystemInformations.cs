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

            return await Task.Run(() =>
            {
                if (_uof.SystemsRepository.IsThisSystemExists())
                {
                    _uof.SystemsRepository.Update(systemModel.System);
                    _uof.Save();
                }
                else
                {
                    _uof.SystemsRepository.Insert(systemModel.System);
                    _uof.Save();
                }


                return systemModel.System.SystemId;
            });
        }
    }
}
