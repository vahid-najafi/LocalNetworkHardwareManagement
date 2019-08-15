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


        public ManageSystemInformations(UnitOfWork unitOfWork)
        {
            _uof = unitOfWork;
        }

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
                //TODO: Do The Thing You Want to do for other systems
                systemId = -1;
            }


            //Checking CPU
            finalMessage += CheckCPU(systemModel.CPU, systemId);


            //TODO: Delete Drivers That Exists In Database But Not In System Model
            //Checking Drivers
            finalMessage += CheckDrivers(systemModel.Drivers, systemId);


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
                    _uof.SystemsRepository.Update(model);
                    _uof.Save();
                    resultMessage += " اطلاعات سیستم بروزرسانی شد.<newLine>";
                }
            }
            else
            {
                _uof.SystemsRepository.Insert(model);
                _uof.Save();
                resultMessage += "اطلاعات سیستم ثبت شد.<newLine>";
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
                    model.CpuId = cpu.CpuId;
                    _uof.CpuRepository.Update(model);
                    finalMessage += resultMessage;
                    finalMessage += "اطلاعات پردازنده بروزرسانی شد.<newLine>";
                }
            }
            else
            {
                _uof.CpuRepository.Insert(model);
                finalMessage += "اطلاعات پردازنده ثبت شد.<newLine>";
            }

            return finalMessage;
        }

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
                        if (HardwareInformationHelper
                            .CheckDriverChanges(existingDriver, driver, out string resultMessage))
                        {
                            driver.DriverId = existingDriver.DriverId;
                            _uof.DriverRepository.Update(driver);
                        }
                    }
                    else
                    {
                        _uof.DriverRepository.Insert(driver);
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
                    _uof.GpuRepository.Delete(gpu);
                    finalMessage += "گرافیک کارت قدیمی شناسایی و حذف شد.<newLine>";
                }
            }

            foreach (GPUs gpu in modelList)
            {
                gpu.SystemId = systemId;

                if (compareList.All(c => c.Name != gpu.Name))
                {
                    _uof.GpuRepository.Insert(gpu);
                    finalMessage += "گرافیک کارت جدید شناسایی شد.<newLine>";
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
                        _uof.OprativeSystemRepository.Update(os);
                        finalMessage += "سیستم عامل بروزرسانی شده است.<newLine>";
                    }
                }
                else
                {
                    _uof.OprativeSystemRepository.Insert(os);
                    finalMessage += "سیستم عامل جدید شناسایی شد.<newLine>";
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
                    _uof.NetworkAdaptersRepository.Delete(adapter);
                    finalMessage += "کارت شبک قدیمی شناسایی و حذف شد.<newLine>";
                }
            }

            //Checking for new network adapters
            foreach (NetworkAdapters adapter in modelList)
            {
                adapter.SystemId = systemId;

                if (adaptersCompareList.All(n => n.Name != adapter.Name))
                {
                    _uof.NetworkAdaptersRepository.Insert(adapter);
                    finalMessage += "کارت شبکه جدید اضافه شد.<newLine>";
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
                    _uof.RamRepository.Update(model);
                    finalMessage += "رم جدید سیستم شناسایی و ثبت شد.<newLine>";
                }
            }
            else
            {
                _uof.RamRepository.Insert(model);
                finalMessage += "رم سیستم ثبت شد.<newLine>";
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
                    _uof.SoundCardRepository.Delete(soundCard);
                    finalMessage += "کارت صدای قدیمی شناسایی و حذف شد.<newLine>";
                }
            }

            //Checking for new sound cards
            foreach (SoundCards soundCard in modelList)
            {
                soundCard.SystemId = systemId;
                if (soundCardsCompareList.All(s => s.Name != soundCard.Name))
                {
                    _uof.SoundCardRepository.Insert(soundCard);
                    finalMessage += "کارت صدای جدید ثبت شد.<newLine>";
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
                    _uof.CdromRepository.Delete(cdRom);
                    finalMessage += "سی دی رام قدیمی شناسایی و حذف شد.<newLine>";
                }
            }

            //Checking for new sound cards
            foreach (CdROMs cdRom in modelList)
            {
                cdRom.SystemId = systemId;
                if (cdRomsCompareList.All(c =>
                    c.Description != cdRom.Description && c.MediaType != cdRom.MediaType))
                {
                    _uof.CdromRepository.Insert(cdRom);
                    finalMessage += "سی دی رام جدید ثبت شد.<newLine>";
                }
            }

            return finalMessage;
        }
    }
}
