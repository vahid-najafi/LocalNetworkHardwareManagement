using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using LocalNetworkHardware.DataLayer;
using LocalNetworkHardwareManagement.Core.Models;

namespace LocalNetworkHardwareManagement.Core.Helpers
{
    public static class HardwareInformationHelper
    {

        public static async Task<GlobalSystemModel> GetAll()
        {
            return await Task.Run(() => new GlobalSystemModel()
            {
                System = GetGlobalInfo().Result,
                CPU = GetSystemCPU().Result
            });
        }

        public static async Task<Systems> GetGlobalInfo()
        {
            return await Task.Run(() => new Systems()
            {
                UniqMotherBoardId = GetMotherBoardID(),
                Name = Environment.MachineName,
                IsOwned = true
            });
        }

        public static async Task<CPUs> GetSystemCPU()
        {
            return await Task.Run(() =>
            {
                ManagementObjectSearcher myProcessorObject =
                    new ManagementObjectSearcher("select * from Win32_Processor");

                List<ManagementObject> resultList = new List<ManagementObject>();

                foreach (ManagementObject obj in myProcessorObject.Get())
                {
                    resultList.Add(obj);
                }

                ManagementObject cpuObject = resultList[0];

                return new CPUs()
                {
                    Cores = int.Parse(cpuObject["NumberOfCores"].ToString()),
                    Name = cpuObject["Name"].ToString(),

                };
            });
        }

        public static string GetMotherBoardID()
        {
            string mbInfo = String.Empty;
            ManagementScope scope = new ManagementScope("\\\\" + Environment.MachineName + "\\root\\cimv2");
            scope.Connect();
            ManagementObject wmiClass = new ManagementObject(scope, new ManagementPath("Win32_BaseBoard.Tag=\"Base Board\""), new ObjectGetOptions());

            foreach (PropertyData propData in wmiClass.Properties)
            {
                if (propData.Name == "SerialNumber")
                    mbInfo = Convert.ToString(propData.Value);
                //mbInfo = String.Format("{0,-25}{1}", propData.Name, Convert.ToString(propData.Value));
            }

            return mbInfo;
        }
    }
}
