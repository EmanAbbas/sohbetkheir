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
    
    public partial class Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> TotalPrice { get; set; }
        public Nullable<System.DateTime> SellDate { get; set; }
        public string VolunteerID { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
    }
}
