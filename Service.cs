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
    
    public partial class Service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Service()
        {
            this.GeneralAid = new HashSet<GeneralAid>();
        }
    
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GeneralAid> GeneralAid { get; set; }
    }
}
