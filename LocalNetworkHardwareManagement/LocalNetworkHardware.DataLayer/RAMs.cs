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
    
    public partial class RAMs
    {
        public int RamId { get; set; }
        public int SystemId { get; set; }
        public double Memory { get; set; }
    
        public virtual Systems Systems { get; set; }
    }
}