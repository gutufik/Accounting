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
    
    public partial class Device
    {
        public Device()
        {
            this.Transfer = new HashSet<Transfer>();
        }
    
        public int DeviceID { get; set; }
        public string DeviceName { get; set; }
        public string Model { get; set; }
        public Nullable<System.DateTime> PurchaseDate { get; set; }
        public Nullable<int> Room { get; set; }
        public Nullable<int> SubdivID { get; set; }
    
        public virtual Subdivision Subdivision { get; set; }
        public virtual ICollection<Transfer> Transfer { get; set; }
    }
}