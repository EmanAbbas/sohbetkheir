//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gam3iaWeb
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhysicalDonation
    {
        public int ID { get; set; }
        public string DonationType { get; set; }
        public string DeviceName { get; set; }
        public string DeviceState { get; set; }
        public Nullable<bool> CanBeFixed { get; set; }
        public Nullable<int> FixFees { get; set; }
        public Nullable<System.DateTime> ReceiveDate { get; set; }
        public Nullable<bool> IsSelled { get; set; }
        public Nullable<bool> IsDelivered { get; set; }
        public Nullable<int> SellPrice { get; set; }
        public Nullable<System.DateTime> SellDate { get; set; }
        public string VolunteerID { get; set; }
        public Nullable<int> DonatorID { get; set; }
        public Nullable<int> PoorID { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Poor Poor { get; set; }
        public virtual Donator Donator { get; set; }
    }
}
