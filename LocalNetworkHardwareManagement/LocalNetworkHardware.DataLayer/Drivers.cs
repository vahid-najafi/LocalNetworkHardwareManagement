//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LocalNetworkHardware.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Drivers
    {
        public int DriverId { get; set; }
        public int SystemId { get; set; }
        public string DiskName { get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public double AvailableSpace { get; set; }
        public double TotalSpace { get; set; }
    
        public virtual Systems Systems { get; set; }
    }
}
