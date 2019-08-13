using System;
using System.Collections.Generic;
using System.IO;
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
                CPU = GetSystemCPU().Result,
                Drivers = GetSystemDrives().Result,
                GPUs = GetSystemGPU().Result,
                OperatingSystems = GetOperativeSystems().Result,
                NetworkAdapters = GetSystemNetworkIntefaces().Result,
                RAM = GetSystemRAM().Result,
                SoundCards = GetSystemSoundCards().Result,
                CDROMs = GetConnectedCDROMs().Result,
                Printers = GetConnectedPrinters().Result
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

        public static async Task<IEnumerable<Drivers>> GetSystemDrives()
        {
            return await Task.Run(() =>
            {
                DriveInfo[] allDrives = DriveInfo.GetDrives();

                List<Drivers> result = new List<Drivers>();

                foreach (DriveInfo drive in allDrives)
                {
                    if (drive.IsReady == false)
                        continue;

                    string name = "Local Disk";

                    if (!string.IsNullOrEmpty(drive.VolumeLabel))
                        name = drive.VolumeLabel;

                    if (drive.DriveType == DriveType.Removable)
                        name = "External Disk";

                    if (drive.DriveType == DriveType.CDRom)
                        name = "CD-ROM Drive";

                    result .Add(new Drivers()
                    {
                        Address = drive.Name.ToUpper().Trim(),
                        AvailableSpace = drive.TotalFreeSpace,
                        DiskName = name,
                        TotalSpace = drive.TotalSize,
                        Type = drive.DriveType.ToString()
                    });
                }

                return result;
            });
        }

        public static async Task<IEnumerable<GPUs>> GetSystemGPU()
        {
            return await Task.Run(() =>
            {
                ManagementObjectSearcher myVideoObject =
                    new ManagementObjectSearcher("select * from Win32_VideoController");

                List<GPUs> result = new List<GPUs>();

                foreach (ManagementObject obj in myVideoObject.Get())
                {
                    result.Add(new GPUs()
                    {
                        Name = obj["Name"].ToString(),
                        AdapterRAM = Convert.ToDouble(obj["AdapterRAM"]),
                    });
                }

                return result;
            });
        }

        public static async Task<IEnumerable<OpratingSystems>> GetOperativeSystems()
        {

            return await Task.Run(() =>
            {
                ManagementObjectSearcher myOperativeSystemObject =
                    new ManagementObjectSearcher("select * from Win32_OperatingSystem");

                List<OpratingSystems> result = new List<OpratingSystems>();

                foreach (ManagementObject obj in myOperativeSystemObject.Get())
                {
                    result.Add(new OpratingSystems()
                    {
                        Name = obj["Caption"].ToString(),
                        Architecture = obj["OSArchitecture"].ToString(),
                        Version = obj["Version"].ToString()
                    });
                }

                return result;

            });
        }

        public static async Task<IEnumerable<NetworkAdapters>> GetSystemNetworkIntefaces()
        {
            return await Task.Run(() => {
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher(@"SELECT * FROM Win32_NetworkAdapter WHERE Manufacturer != 'Microsoft' AND NOT PNPDeviceID LIKE 'ROOT\\%'");

                List<NetworkAdapters> result = new List<NetworkAdapters>();

                foreach (ManagementObject obj in searcher.Get())
                {
                    result.Add(new NetworkAdapters()
                    {
                        Name = obj["Name"].ToString()
                    });
                }

                return result;
            });
        }

        public static async Task<RAMs> GetSystemRAM()
        {
            return await Task.Run(() => new RAMs()
            {
                Memory = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory
            });
        }

        public static async Task<IEnumerable<SoundCards>> GetSystemSoundCards()
        {
            return await Task.Run(() =>
            {
                ManagementObjectSearcher myAudioObject =
                    new ManagementObjectSearcher("select * from Win32_SoundDevice");

                List<SoundCards> result = new List<SoundCards>();

                foreach (ManagementObject obj in myAudioObject.Get())
                {
                    result.Add(new SoundCards()
                    {
                        Name = obj["Name"].ToString()
                    });
                }

                return result;
            });
        }

        public static async Task<IEnumerable<CdROMs>> GetConnectedCDROMs()
        {
            return await Task.Run(() =>
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_CDROMDrive");

                List<CdROMs> result = new List<CdROMs>();

                foreach (ManagementBaseObject obj in searcher.Get())
                {
                    result.Add(new CdROMs()
                    {
                        Description = obj["Description"].ToString(),
                        Address = obj["Drive"].ToString(),
                        MediaType = obj["MediaType"].ToString()
                    });
                }

                return result;
            });
        }

        public static async Task<IEnumerable<Printers>> GetConnectedPrinters()
        {
            return await Task.Run(() =>
            {
                ManagementObjectSearcher myPrinterObject =
                    new ManagementObjectSearcher("select * from Win32_Printer");

                List<Printers> result = new List<Printers>();

                foreach (ManagementObject obj in myPrinterObject.Get())
                {
                    result.Add(new Printers()
                    {
                        Name = obj["Name"].ToString(),
                        IsLocal = (bool)obj["Local"],
                        IsNetwork = (bool)obj["Network"]

                    });
                }

                return result;
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
