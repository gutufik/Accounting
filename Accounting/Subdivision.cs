//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Accounting
{
    using System;
    using System.Collections.Generic;
    
    public partial class Subdivision
    {
        public Subdivision()
        {
            this.Device = new HashSet<Device>();
            this.Emloyee = new HashSet<Emloyee>();
        }
    
        public int SubdivID { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
    
        public virtual ICollection<Device> Device { get; set; }
        public virtual ICollection<Emloyee> Emloyee { get; set; }
    }
}
