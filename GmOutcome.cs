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
    
    public partial class GmOutcome
    {
        public int ID { get; set; }
        public Nullable<int> OutcomeSource { get; set; }
        public Nullable<int> OutcomeValue { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string VolunteerID { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
