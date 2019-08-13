using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalNetworkHardware.DataLayer.Services.Classes
{
    public class SoundCardRepository: GenericRepository<SoundCards>, ISoundCardRepository
    {
        public SoundCardRepository(LocalNetworkHardwareManagement_DBEntities context)
        :base(context)
        {
            
        }
    }
}
