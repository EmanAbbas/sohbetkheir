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
    
    public partial class Sponsor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sponsor()
        {
            this.Sponsorship = new HashSet<Sponsorship>();
            this.SponsorshipInstallment = new HashSet<SponsorshipInstallment>();
        }
    
        public int ID { get; set; }
        public string SponsorName { get; set; }
        public string SponsorPhone { get; set; }
        public string SponsorAddress { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }
        public string Job { get; set; }
        public string SponsorNID { get; set; }
        public Nullable<System.DateTime> JoinedAt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sponsorship> Sponsorship { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SponsorshipInstallment> SponsorshipInstallment { get; set; }
    }
}
