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
    
    public partial class SponsorshipResearch
    {
        public int ID { get; set; }
        public string ResearcherName { get; set; }
        public Nullable<System.DateTime> ResearchDate { get; set; }
        public string ResearchResponse { get; set; }
        public string ResearchResults { get; set; }
        public Nullable<System.DateTime> SponsorshipStartDate { get; set; }
        public string Comments { get; set; }
        public string VolunteerID { get; set; }
        public Nullable<int> PoorID { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Poor Poor { get; set; }
    }
}
