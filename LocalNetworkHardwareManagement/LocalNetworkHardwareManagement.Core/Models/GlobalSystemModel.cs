using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LocalNetworkHardware.DataLayer;

namespace LocalNetworkHardwareManagement.Core.Models
{
    public class GlobalSystemModel
    {
        public Systems  System { get; set; }

        public CPUs CPU { get; set; }

        public RAMs RAM { get; set; }

        public IEnumerable<GPUs> GPUs { get; set; }

        public IEnumerable<Drivers> Drivers { get; set; }

        public IEnumerable<NetworkAdapters> NetworkAdapters { get; set; }

        public IEnumerable<OpratingSystems> OperatingSystems { get; set; }

        public IEnumerable<SoundCards> SoundCards { get; set; }

        public IEnumerable<CdROMs> CDROMs { get; set; }

        public IEnumerable<Printers> Printers { get; set; }
    }
}
