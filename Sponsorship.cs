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
    
    public partial class Sponsorship
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sponsorship()
        {
            this.SponsorshipInstallment = new HashSet<SponsorshipInstallment>();
        }
    
        public int ID { get; set; }
        public Nullable<int> RequestCase { get; set; }
        public string RequestReceiver { get; set; }
        public string RequestFollowHolder { get; set; }
        public Nullable<int> Amount { get; set; }
        public Nullable<int> PaymentMethodType { get; set; }
        public string WaseetName { get; set; }
        public string WaseetPhone { get; set; }
        public Nullable<bool> SposorChanged { get; set; }
        public string OldSponsorName { get; set; }
        public string NewSponsorName { get; set; }
        public string ReasonOfChange { get; set; }
        public Nullable<bool> IsStopped { get; set; }
        public Nullable<System.DateTime> StopDate { get; set; }
        public string StopReason { get; set; }
        public string VolunteerID { get; set; }
        public string RefuseReason { get; set; }
        public Nullable<bool> IsRefused { get; set; }
        public Nullable<int> PoorID { get; set; }
        public Nullable<int> SponsorID { get; set; }
        public Nullable<System.DateTime> RequestDate { get; set; }
        public Nullable<int> Income { get; set; }
        public string IncomeSource { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Poor Poor { get; set; }
        public virtual Sponsor Sponsor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SponsorshipInstallment> SponsorshipInstallment { get; set; }
    }
}
