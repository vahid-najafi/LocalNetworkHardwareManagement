using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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
        private bool _recordChanges;


        public ManageSystemInformations(UnitOfWork unitOfWork, bool recordChanges)
        {
            _uof = unitOfWork;
            _recordChanges = recordChanges;
        }

        #region Static Convert Messages

        public static GlobalSystemModel ConverMessageToGlobalSystemModel(string message, out ActivitiesViewModel[] activities)
        {
            GlobalSystemModel systemModel = new GlobalSystemModel();

            //get global info
            systemModel.System = ConvertMessageToSystems(message);

            //get CPU
            systemModel.CPU = ConvertMessageToCPU(message);

            //get GPUs
            systemModel.GPUs = ConvertMessageToGPUArray(message);

            systemModel.OperatingSystems = ConvertMessageTOperatingSystemsList(message);

            systemModel.Drivers = ConvertMessageToDriversList(message);

            systemModel.RAM = ConvertMessageToRAM(message);

            systemModel.NetworkAdapters = ConvertMessageToNetworkAdaptersList(message);

            systemModel.SoundCards = ConvertMessageToSoundCardsList(message);

            systemModel.Printers = ConvertMessageToPrintersList(message);

            activities = ConvertMessageToActivities(message);

            return systemModel;
        }

        public static ShortSystemModel ConvertMessageToShortSystemModel(string message)
        {
            //Getting System Information
            int systemFrom = message.IndexOf("<system>") + "<system>".Length;
            int systemTo = message.LastIndexOf("</system>");
            string systemInfo = message.Substring(systemFrom, systemTo - systemFrom);

            //Getting Name
            int nameFrom = systemInfo.IndexOf("<Name>") + "<Name>".Length;
            int nameTo = systemInfo.LastIndexOf("<CPU>");
            string name = systemInfo.Substring(nameFrom, nameTo - nameFrom);

            //Getting CPU
            int cpuFrom = systemInfo.IndexOf("<CPU>") + "<CPU>".Length;
            string cpu = systemInfo
                .Substring(cpuFrom, systemInfo.Length - cpuFrom);

            return new ShortSystemModel()
            {
                SystemName = name,
                Cpu = cpu
            };
        }

        #endregion


        #region Database Methods

        public async Task<string> UpdateOwnedSystem()
        {
            GlobalSystemModel systemModel = await HardwareInformationHelper.GetGlobalSystemModel();

            string finalMessage = "";


            return await Task.Run(() =>
            {
                finalMessage = CheckGlobalModel(systemModel, true);


                return finalMessage;
            });
        }

        public async Task AddOrUpdateSystem(GlobalSystemModel systemModel)
        {
            int systemId = _uof.SystemsRepository.CheckSystemExists(systemModel.System.UniqMotherBoardId);

            if (systemId == -1)
            {
                //Add New System
                _uof.SystemsRepository.Insert(systemModel.System);
                _uof.Save();
            }
            else
            {
                systemModel.System.SystemId = systemId;
            }

            string finalMessage = CheckGlobalModel(systemModel, false);
        }

        public string GetSystemActvities()
        {
            string finalMessage = "";

            IEnumerable<Activities> activities = _uof.ActivitiesRepository.GetRecentActivities();

            foreach (Activities activity in activities)
            {
                finalMessage += $"<Description>{activity.Description}<Date>{activity.EventDate.ToShamsi()}<split>";
            }

            if (finalMessage.EndsWith("<split>"))
                finalMessage.Substring(0, finalMessage.Length - 7);

            return $"<activties>{finalMessage}</activties>";
        }

        public List<ActivitiesViewModel> GetSystemActivitiesToShow()
        {
            List<ActivitiesViewModel> activitiesList = new List<ActivitiesViewModel>();

            IEnumerable<Activities> activities = _uof.ActivitiesRepository.GetRecentActivities();

            foreach (Activities activity in activities)
            {
                activitiesList.Add(new ActivitiesViewModel()
                {
                    Description = activity.Description,
                    ShamsiDate = activity.EventDate.ToShamsi()
                });
            }

            return activitiesList;
        }

        #endregion

        //TODO: Has One
        #region Checks

        public string CheckGlobalModel(GlobalSystemModel systemModel, bool isOwned)
        {
            int systemId = 0;
            string finalMessage = "";


            //Checking Global System And Getting SystemId For Other Entities
            if (isOwned)
            {
                systemId = CheckOwnedSystem(systemModel.System, out string resultMessage);
                finalMessage += resultMessage;
            }
            else
            {
                systemId = systemModel.System.SystemId;
            }


            //Checking CPU
            finalMessage += CheckCPU(systemModel.CPU, systemId);


            //TODO: Delete Drivers That Exists In Database But Not In System Model
            //Checking Drivers
            finalMessage += CheckDrivers(systemModel.Drivers, systemId);

            //_uof.Save();

            //Checking GPUs
            finalMessage += CheckGPU(systemModel.GPUs, systemId);


            //Checking Operating System
            finalMessage += CheckOperatingSystems(systemModel.OperatingSystems, systemId);


            //Checking Network Adapters
            finalMessage += CheckNetworkAdapters(systemModel.NetworkAdapters, systemId);


            //Checking RAM
            finalMessage += CheckRAM(systemModel.RAM, systemId);


            //Checking Sound Cards
            finalMessage += CheckSoundCards(systemModel.SoundCards, systemId);


            //Checking CDROMs
            finalMessage += CheckCdRoms(systemModel.CDROMs, systemId);



            //Checking Printers
            //For some reasons i decided to not insert printers now
            //7 days later: i don't remember those reasons so i just do it
            finalMessage += CheckPrinters(systemModel.Printers, systemId);

            _uof.Save();
            return finalMessage;

        }

        public int CheckOwnedSystem(Systems model, out string resultMessage)
        {
            resultMessage = "";

            //Checking System
            if (_uof.SystemsRepository.IsThisSystemExists(out Systems system))
            {
                model.SystemId = system.SystemId;

                //Check if system has any changes
                if (HardwareInformationHelper
                    .CheckGlobalSystemChanges(system, model, out resultMessage))
                {
                    string msg = "اطلاعات سیستم بروزرسانی شد.";
                    _uof.SystemsRepository.Update(model);

                    if (_recordChanges)
                        _uof.ActivitiesRepository.Insert(new Activities() { Description = msg, EventDate = DateTime.Now });

                    _uof.Save();
                    resultMessage += $" {msg}<newLine>";
                }
            }
            else
            {
                string msg = "اطلاعات سیستم ثبت شد.";
                _uof.SystemsRepository.Insert(model);
                if (_recordChanges)
                    _uof.ActivitiesRepository.Insert(new Activities() { Description = msg, EventDate = DateTime.Now });
                _uof.Save();
                resultMessage += $"{msg}<newLine>";
            }

            return model.SystemId;
        }

        public string CheckCPU(CPUs model, int systemId)
        {
            string finalMessage = "";
            model.SystemId = systemId;

            if (_uof.CpuRepository.IsSystemCpuExists(systemId, out CPUs cpu))
            {
                //if it exists check the different and update
                if (HardwareInformationHelper
                    .CheckSystemCpuChanges(cpu, model, out string resultMessage))
                {
                    string msg = "اطلاعات پردازنده بروزرسانی شد.";
                    model.CpuId = cpu.CpuId;
                    _uof.CpuRepository.Update(model);
                    if (_recordChanges)
                        _uof.ActivitiesRepository.Insert(new Activities() { Description = msg, EventDate = DateTime.Now });
                    finalMessage += resultMessage;
                    finalMessage += $"{msg}<newLine>";
                }
            }
            else
            {
                string msg = "اطلاعات پردازنده ثبت شد.";
                _uof.CpuRepository.Insert(model);
                if (_recordChanges)
                    _uof.ActivitiesRepository.Insert(new Activities() { Description = msg, EventDate = DateTime.Now });
                finalMessage += $"{msg}<newLine>";
            }

            return finalMessage;
        }

        //TODO: Has One
        public string CheckDrivers(IEnumerable<Drivers> modelList, int systemId)
        {
            string finalMessage = "";

            foreach (Drivers driver in modelList)
            {
                driver.SystemId = systemId;

                //Check if disk is external
                if (driver.Type.ToLower().Equals("removable"))
                {
                    //TODO: Do The Thing For Removable Drivers
                    continue;
                }
                //Checking if the disk is fixed
                else if ((driver.Type.ToLower().Equals("fixed")))
                {
                    //If disk already saved in database
                    if (_uof.DriverRepository.IsDriverExists(systemId, driver.Address,
                        out Drivers existingDriver))
                    {
                        //Check for driver changes
                        //resultMessage: changes that recognized
                        if (HardwareInformationHelper
                            .CheckDriverChanges(existingDriver, driver, out string resultMessage))
                        {
                            //adding detected changes to return message
                            if (!string.IsNullOrEmpty(resultMessage))
                                finalMessage += resultMessage;

                            driver.DriverId = existingDriver.DriverId;
                            _uof.DriverRepository.Update(driver);

                            //Save Activities
                            if ((_recordChanges) && (!string.IsNullOrEmpty(resultMessage)))
                            {
                                string[] actArray = resultMessage.Split(new string[] { "<newLine>" },
                                    StringSplitOptions.RemoveEmptyEntries);

                                foreach (string activity in actArray)
                                {
                                    _uof.ActivitiesRepository.Insert(new Activities()
                                    {
                                        Description = activity,
                                        EventDate = DateTime.Now
                                    });
                                }
                            }
                        }
                    }
                    else
                    {
                        _uof.DriverRepository.Insert(driver);
                        if (_recordChanges)
                        {
                            _uof.ActivitiesRepository.Insert(new Activities()
                            {
                                Description = $"درایو {driver.Address} ثبت شد.",
                                EventDate = DateTime.Now
                            });
                        }
                    }
                }

            }

            finalMessage += "درایور های سیستم چک و بروزرسانی شد.<newLine>";

            return finalMessage;
        }

        public string CheckGPU(IEnumerable<GPUs> modelList, int systemId)
        {
            string finalMessage = "";

            IEnumerable<GPUs> gpuList = _uof.GpuRepository.GetSystemExistingGPUs(systemId);
            IEnumerable<GPUs> compareList = gpuList.Join(modelList,
                sg => sg.Name, gl => gl.Name, (fromGpuList, fromSystemModelGPUs) => new GPUs()
                {
                    Name = fromGpuList.Name
                }).ToList();

            foreach (GPUs gpu in gpuList)
            {
                if (compareList.All(c => c.Name != gpu.Name))
                {
                    string msg = "گرافیک کارت قدیمی شناسایی و حذف شد.";
                    _uof.GpuRepository.Delete(gpu);

                    if (_recordChanges)
                        _uof.ActivitiesRepository.Insert(new Activities() { Description = msg, EventDate = DateTime.Now });

                    finalMessage += $"{msg}<newLine>";
                }
            }

            foreach (GPUs gpu in modelList)
            {
                gpu.SystemId = systemId;

                if (compareList.All(c => c.Name != gpu.Name))
                {
                    string msg = "گرافیک کارت جدید شناسایی شد.";
                    _uof.GpuRepository.Insert(gpu);

                    if (_recordChanges)
                        _uof.ActivitiesRepository.Insert(new Activities() { Description = msg, EventDate = DateTime.Now });

                    finalMessage += $"{msg}<newLine>";
                }
            }

            return finalMessage;
        }

        public string CheckOperatingSystems(IEnumerable<OpratingSystems> modelList, int systemId)
        {
            string finalMessage = "";

            IEnumerable<OpratingSystems> existingOsList = _uof.OprativeSystemRepository.GetAllSystemOs(systemId);

            //o As OuterKeySelector And i As InnerKeySelector
            IEnumerable<OpratingSystems> osCompareList = existingOsList.Join(modelList,
            o => new { o.Name, o.Architecture }, i => new { i.Name, i.Architecture },
            (fromDatabase, fromSystemModel) => new OpratingSystems()
            {
                Name = fromDatabase.Name,
                Architecture = fromDatabase.Architecture
            }).ToList();

            //Deleting extra records from Database
            foreach (OpratingSystems opratingSystem in existingOsList)
            {
                if (osCompareList.All(c => (c.Name != opratingSystem.Name) && (c.Architecture != opratingSystem.Architecture)))
                    _uof.OprativeSystemRepository.Delete(opratingSystem);
            }


            //Checking New Operating Systems
            foreach (OpratingSystems os in modelList)
            {
                os.SystemId = systemId;
                //Check if this os exists in database
                OpratingSystems similarOs = existingOsList
                    .FirstOrDefault(s =>
                        s.SystemId == systemId && s.Name == os.Name && s.Architecture == os.Architecture);

                //If it exists check version and update otherwise insert it
                if (similarOs != null)
                {
                    os.OsId = similarOs.OsId;
                    if (!similarOs.Version.Equals(os.Version))
                    {
                        string msg = "سیستم عامل بروزرسانی شده است.";
                        _uof.OprativeSystemRepository.Update(os);

                        if (_recordChanges)
                            _uof.ActivitiesRepository.Insert(new Activities() { Description = msg, EventDate = DateTime.Now });

                        finalMessage += $"{msg}<newLine>";
                    }
                }
                else
                {
                    string msg = "سیستم عامل جدید ثبت شد.";
                    _uof.OprativeSystemRepository.Insert(os);

                    if (_recordChanges)
                        _uof.ActivitiesRepository.Insert(new Activities() { Description = msg, EventDate = DateTime.Now });

                    finalMessage += $"{msg}<newLine>";
                }
            }

            return finalMessage;
        }

        public string CheckNetworkAdapters(IEnumerable<NetworkAdapters> modelList, int systemId)
        {
            string finalMessage = "";

            IEnumerable<NetworkAdapters> databaseAdaptersList = _uof.NetworkAdaptersRepository
                .GetSystemExistingAdapters(systemId);

            IEnumerable<NetworkAdapters> adaptersCompareList = databaseAdaptersList.Join(
                modelList,
                o => o.Name, i => i.Name, (fromDatabase, fromModel) => new NetworkAdapters()
                {
                    Name = fromDatabase.Name
                }).ToList();

            //Checking extra records on database
            foreach (NetworkAdapters adapter in databaseAdaptersList)
            {
                if (adaptersCompareList.All(n => n.Name != adapter.Name))
                {
                    string msg = "کارت شبک قدیمی شناسایی و حذف شد.";
                    _uof.NetworkAdaptersRepository.Delete(adapter);

                    if (_recordChanges)
                        _uof.ActivitiesRepository.Insert(new Activities() { Description = msg, EventDate = DateTime.Now });

                    finalMessage += $"{msg}<newLine>";
                }
            }

            //Checking for new network adapters
            foreach (NetworkAdapters adapter in modelList)
            {
                adapter.SystemId = systemId;

                if (adaptersCompareList.All(n => n.Name != adapter.Name))
                {
                    string msg = "کارت شبکه جدید اضافه شد.";
                    _uof.NetworkAdaptersRepository.Insert(adapter);

                    if (_recordChanges)
                        _uof.ActivitiesRepository.Insert(new Activities() { Description = msg, EventDate = DateTime.Now });

                    finalMessage += $"{msg}<newLine>";
                }
            }

            return finalMessage;
        }

        public string CheckRAM(RAMs model, int systemId)
        {
            string finalMessage = "";

            model.SystemId = systemId;
            //Checking RAM
            if (_uof.RamRepository.IsRamExists(systemId, out RAMs existingRAM))
            {
                model.RamId = existingRAM.RamId;

                if (model.Memory != existingRAM.Memory)
                {
                    string msg = "رم جدید سیستم شناسایی و ثبت شد.";
                    _uof.RamRepository.Update(model);

                    if (_recordChanges)
                        _uof.ActivitiesRepository.Insert(new Activities() { Description = msg, EventDate = DateTime.Now });

                    finalMessage += $"{msg}<newLine>";
                }
            }
            else
            {
                string msg = "رم سیستم ثبت شد.";
                _uof.RamRepository.Insert(model);

                if (_recordChanges)
                    _uof.ActivitiesRepository.Insert(new Activities() { Description = msg, EventDate = DateTime.Now });

                finalMessage += $"{msg}<newLine>";
            }

            return finalMessage;
        }

        public string CheckSoundCards(IEnumerable<SoundCards> modelList, int systemId)
        {
            string finalMessage = "";

            IEnumerable<SoundCards> databaseSoundCardList =
                _uof.SoundCardRepository.GettAllSystemSoundCards(systemId);

            IEnumerable<SoundCards> soundCardsCompareList = databaseSoundCardList.Join(modelList,
                o => o.Name, i => i.Name, (fromDatabase, fromModel) => new SoundCards()
                {
                    Name = fromDatabase.Name
                }).ToList();

            //Checking for extra records in database
            foreach (SoundCards soundCard in databaseSoundCardList)
            {
                if (soundCardsCompareList.All(s => s.Name != soundCard.Name))
                {
                    string msg = "کارت صدای قدیمی شناسایی و حذف شد.";
                    _uof.SoundCardRepository.Delete(soundCard);

                    if (_recordChanges)
                        _uof.ActivitiesRepository.Insert(new Activities() { Description = msg, EventDate = DateTime.Now });

                    finalMessage += $"{msg}<newLine>";
                }
            }

            //Checking for new sound cards
            foreach (SoundCards soundCard in modelList)
            {
                soundCard.SystemId = systemId;
                if (soundCardsCompareList.All(s => s.Name != soundCard.Name))
                {
                    string msg = "کارت صدای جدید ثبت شد.";
                    _uof.SoundCardRepository.Insert(soundCard);

                    if (_recordChanges)
                        _uof.ActivitiesRepository.Insert(new Activities() { Description = msg, EventDate = DateTime.Now });

                    finalMessage += $"{msg}<newLine>";
                }
            }

            return finalMessage;
        }

        public string CheckCdRoms(IEnumerable<CdROMs> modelList, int systemId)
        {
            string finalMessage = "";

            IEnumerable<CdROMs> databaseCdRomsList = _uof.CdromRepository.GetAllSystemCdRoms(systemId);

            IEnumerable<CdROMs> cdRomsCompareList = databaseCdRomsList.Join(modelList,
                o => new { o.Description, o.MediaType }, i => new { i.Description, i.MediaType },
                (fromDatabase, fromModel) => new CdROMs()
                {
                    Description = fromDatabase.Description,
                    MediaType = fromDatabase.MediaType
                }).ToList();

            //Checking for extra records in database
            foreach (CdROMs cdRom in databaseCdRomsList)
            {
                if (cdRomsCompareList.All(c =>
                    c.Description != cdRom.Description && c.MediaType != cdRom.MediaType))
                {
                    string msg = "سی دی رام قدیمی شناسایی و حذف شد.";
                    _uof.CdromRepository.Delete(cdRom);

                    if (_recordChanges)
                        _uof.ActivitiesRepository.Insert(new Activities() { Description = msg, EventDate = DateTime.Now });

                    finalMessage += $"{msg}<newLine>";
                }
            }

            //Checking for new sound cards
            foreach (CdROMs cdRom in modelList)
            {
                cdRom.SystemId = systemId;
                if (cdRomsCompareList.All(c =>
                    c.Description != cdRom.Description && c.MediaType != cdRom.MediaType))
                {
                    string msg = "سی دی رام جدید ثبت شد.";
                    _uof.CdromRepository.Insert(cdRom);

                    if (_recordChanges)
                        _uof.ActivitiesRepository.Insert(new Activities() { Description = msg, EventDate = DateTime.Now });

                    finalMessage += $"{msg}<newLine>";
                }
            }

            return finalMessage;
        }

        public string CheckPrinters(IEnumerable<Printers> modelList, int systemId)
        {
            string finalMessage = "";

            IEnumerable<Printers> databasePrintersList = 
                _uof.PrinterRepository.GetAllSystemPrinters(systemId);

            IEnumerable<Printers> printersCompareList = databasePrintersList.Join(modelList,
                o => o.Name, i => i.Name, (fromDatabase, fromModel) => new Printers()
                {
                    Name = fromDatabase.Name
                }).ToList();

            //Checking for extra records in database
            foreach (Printers printer in databasePrintersList)
            {
                if (printersCompareList.All(s => s.Name != printer.Name))
                {
                    string msg = "پرینتر قدیمی شناسایی و حذف شد.";
                    _uof.PrinterRepository.Delete(printer);

                    if (_recordChanges)
                        _uof.ActivitiesRepository.Insert(new Activities() { Description = msg, EventDate = DateTime.Now });

                    finalMessage += $"{msg}<newLine>";
                }
            }

            //Checking for new printers
            foreach (Printers printer in modelList)
            {
                printer.SystemId = systemId;
                if (printersCompareList.All(s => s.Name != printer.Name))
                {
                    string msg = "پرینتر جدید ثبت شد.";
                    _uof.PrinterRepository.Insert(printer);

                    if (_recordChanges)
                        _uof.ActivitiesRepository.Insert(new Activities() { Description = msg, EventDate = DateTime.Now });

                    finalMessage += $"{msg}<newLine>";
                }
            }

            return finalMessage;
        }

        #endregion

        #region Covert Message To Class

        public static ActivitiesViewModel[] ConvertMessageToActivities(string message)
        {
            List<ActivitiesViewModel> activitiesList = new List<ActivitiesViewModel>();

            int actFrom = message.IndexOf("<activties>") + "<activties>".Length;
            int actTo = message.LastIndexOf("</activties>");
            string actInfo = message.Substring(actFrom, actTo - actFrom);

            if (string.IsNullOrEmpty(actInfo))
                return activitiesList.ToArray();

            string[] actArray = actInfo
                .Split(new string[] { "<split>" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string activity in actArray)
            {
                //Description
                int desFrom = activity.IndexOf("<Description>") + "<Description>".Length;
                int desTo = activity.LastIndexOf("<Date>");
                string description = activity.Substring(desFrom, desTo - desFrom);

                //Date
                int dateFrom = activity.IndexOf("<Date>") + "<Date>".Length;
                string eventDate = activity.Substring(dateFrom, activity.Length - dateFrom);

                activitiesList.Add(new ActivitiesViewModel()
                {
                    Description = description,
                    ShamsiDate = eventDate
                });
            }

            return activitiesList.ToArray();
        }

        public static Systems ConvertMessageToSystems(string message)
        {
            int globalFrom = message.IndexOf("<global>") + "<global>".Length;
            int globalTo = message.LastIndexOf("</global>");
            string globalInfo = message.Substring(globalFrom, globalTo - globalFrom);

            //get Uniq Motherboaerd ID
            int uniqFrom = globalInfo.IndexOf("<UniqMotherBoardId>") + "<UniqMotherBoardId>".Length;
            int uniqTo = globalInfo.LastIndexOf("<Name>");
            string uniqMotherboardId = globalInfo.Substring(uniqFrom, uniqTo - uniqFrom);

            //get Name
            int systemNameFrom = globalInfo.IndexOf("<Name>") + "<Name>".Length;
            string systemName = globalInfo
                .Substring(systemNameFrom, globalInfo.Length - systemNameFrom);


            return new Systems
            {
                Name = systemName,
                UniqMotherBoardId = uniqMotherboardId
            };
        }

        public static CPUs ConvertMessageToCPU(string message)
        {
            int cpuFrom = message.IndexOf("<cpu>") + "<cpu>".Length;
            int cpuTo = message.LastIndexOf("</cpu>");
            string cpuInfo = message.Substring(cpuFrom, cpuTo - cpuFrom);

            //get Name
            int nameFrom = cpuInfo.IndexOf("<Name>") + "<Name>".Length;
            int nameTo = cpuInfo.LastIndexOf("<Cores>");
            string name = cpuInfo.Substring(nameFrom, nameTo - nameFrom);

            //get Cores
            int coresFrom = cpuInfo.IndexOf("<Cores>") + "<Cores>".Length;
            int cores = int.Parse(cpuInfo.Substring(coresFrom, cpuInfo.Length - coresFrom));

            return new CPUs()
            {
                Name = name,
                Cores = cores
            };
        }

        public static List<GPUs> ConvertMessageToGPUArray(string message)
        {
            List<GPUs> result = new List<GPUs>();

            int gpuFrom = message.IndexOf("<gpu>") + "<gpu>".Length;
            int gpuTo = message.LastIndexOf("</gpu>");
            string gpuInfo = message.Substring(gpuFrom, gpuTo - gpuFrom);

            string[] gpuArray = gpuInfo
                .Split(new string[] { "<split>" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string gpu in gpuArray)
            {
                //Name
                int nameFrom = gpu.IndexOf("<Name>") + "<Name>".Length;
                int nameTo = gpu.LastIndexOf("<AdapterRAM>");
                string name = gpu.Substring(nameFrom, nameTo - nameFrom);

                //Adapter RAM
                int ramFrom = gpu.IndexOf("<AdapterRAM>") + "<AdapterRAM>".Length;
                double adapterRAM = double.Parse(gpu.Substring(ramFrom, gpu.Length - ramFrom));

                result.Add(new GPUs()
                {
                    Name = name,
                    AdapterRAM = adapterRAM
                });
            }

            return result;
        }

        public static List<OpratingSystems> ConvertMessageTOperatingSystemsList(string message)
        {
            List<OpratingSystems> result = new List<OpratingSystems>();

            int osFrom = message.IndexOf("<operatingSystems>") + "<operatingSystems>".Length;
            int osTo = message.LastIndexOf("</operatingSystems>");
            string osInfo = message.Substring(osFrom, osTo - osFrom);

            string[] osArray = osInfo
                .Split(new string[] { "<split>" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string os in osArray)
            {
                //Name
                int nameFrom = os.IndexOf("<Name>") + "<Name>".Length;
                int nameTo = os.LastIndexOf("<Architecture>");
                string name = os.Substring(nameFrom, nameTo - nameFrom);

                //Architecture
                int arcFrom = os.IndexOf("<Architecture>") + "<Architecture>".Length;
                int arcTo = os.LastIndexOf("<Version>");
                string architecture = os.Substring(arcFrom, arcTo - arcFrom);

                //Version
                int versionFrom = os.IndexOf("<Version>") + "<Version>".Length;
                string version = os.Substring(versionFrom, os.Length - versionFrom);

                result.Add(new OpratingSystems()
                {
                    Name = name,
                    Architecture = architecture,
                    Version = version
                });
            }

            return result;
        }

        public static RAMs ConvertMessageToRAM(string message)
        {
            int ramFrom = message.IndexOf("<ram>") + "<ram>".Length;
            int ramTo = message.LastIndexOf("</ram>");
            string ramInfo = message.Substring(ramFrom, ramTo - ramFrom);

            double memory = double.Parse(ramInfo.Replace("<Memory>", ""));

            return new RAMs()
            {
                Memory = memory
            };
        }

        public static List<Drivers> ConvertMessageToDriversList(string message)
        {
            List<Drivers> result = new List<Drivers>();

            int driverFrom = message.IndexOf("<drivers>") + "<drivers>".Length;
            int driverTo = message.LastIndexOf("</drivers>");
            string driversInfo = message.Substring(driverFrom, driverTo - driverFrom);

            string[] driversArray = driversInfo
                .Split(new string[] { "<split>" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string drive in driversArray)
            {
                //Disk Name
                int nameFrom = drive.IndexOf("<DiskName>") + "<DiskName>".Length;
                int nameTo = drive.LastIndexOf("<Address>");
                string name = drive.Substring(nameFrom, nameTo - nameFrom);

                //Address
                int addressFrom = drive.IndexOf("<Address>") + "<Address>".Length;
                int addressTo = drive.LastIndexOf("<Type>");
                string address = drive.Substring(addressFrom, addressTo - addressFrom);


                //Type
                int typeFrom = drive.IndexOf("<Type>") + "<Type>".Length;
                int typeTo = drive.LastIndexOf("<AvailableSpace>");
                string type = drive.Substring(typeFrom, typeTo - typeFrom);


                //Available Space
                int aSpaceFrom = drive.IndexOf("<AvailableSpace>") + "<AvailableSpace>".Length;
                int aSpaceTo = drive.LastIndexOf("<TotalSpace>");
                double availableSpace = double.Parse(drive.Substring(aSpaceFrom, aSpaceTo - aSpaceFrom));


                //Total Space
                int tSpaceFrom = drive.IndexOf("<TotalSpace>") + "<TotalSpace>".Length;
                double totalSpace = double.Parse(drive.Substring(tSpaceFrom, drive.Length - tSpaceFrom));


                result.Add(new Drivers()
                {
                    DiskName = name,
                    Address = address,
                    Type = type,
                    AvailableSpace = availableSpace,
                    TotalSpace = totalSpace
                });
            }

            return result;
        }

        public static List<NetworkAdapters> ConvertMessageToNetworkAdaptersList(string message)
        {
            List<NetworkAdapters> result = new List<NetworkAdapters>();

            int netFrom = message.IndexOf("<networkAdapters>") + "<networkAdapters>".Length;
            int netTo = message.LastIndexOf("</networkAdapters>");
            string networkAdaptersInfo = message.Substring(netFrom, netTo - netFrom);

            string[] networkAdaptersArray = networkAdaptersInfo
                .Split(new string[] { "<split>" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string networkAdapter in networkAdaptersArray)
            {
                result.Add(new NetworkAdapters()
                {
                    Name = networkAdapter.Replace("<Name>", "")
                });
            }


            return result;
        }

        public static List<SoundCards> ConvertMessageToSoundCardsList(string message)
        {
            List<SoundCards> result = new List<SoundCards>();

            int soundFrom = message.IndexOf("<soundCards>") + "<soundCards>".Length;
            int soundTo = message.LastIndexOf("</soundCards>");
            string soundCardsInfo = message.Substring(soundFrom, soundTo - soundFrom);

            string[] soundCardsArray = soundCardsInfo
                .Split(new string[] { "<split>" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string soundCard in soundCardsArray)
            {
                result.Add(new SoundCards()
                {
                    Name = soundCard.Replace("<Name>", "")
                });
            }

            return result;
        }

        public static List<Printers> ConvertMessageToPrintersList(string message)
        {
            List<Printers> result = new List<Printers>();

            int printersFrom = message.IndexOf("<printers>") + "<printers>".Length;
            int printersTo = message.LastIndexOf("</printers>");
            string printersInfo = message.Substring(printersFrom, printersTo - printersFrom);

            string[] printersArray = printersInfo
                .Split(new string[] { "<split>" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string printer in printersArray)
            {
                //Name
                int nameFrom = printer.IndexOf("<Name>") + "<Name>".Length;
                int nameTo = printer.LastIndexOf("<IsLocal>");
                string name = printer.Substring(nameFrom, nameTo - nameFrom);

                //IsLocal
                int localFrom = printer.IndexOf("<IsLocal>") + "<IsLocal>".Length;
                int localTo = printer.LastIndexOf("<IsNetwork>");
                bool isLocal = bool.Parse(printer.Substring(localFrom, localTo - localFrom));

                //IsNetwork
                int networkFrom = printer.IndexOf("<IsNetwork>") + "<IsNetwork>".Length;
                bool isNetwork = bool.Parse(printer.Substring(networkFrom, printer.Length - networkFrom));

                result.Add(new Printers()
                {
                    Name = name,
                    IsLocal = isLocal,
                    IsNetwork = isNetwork
                });
            }

            return result;
        }

        #endregion
    }
}
