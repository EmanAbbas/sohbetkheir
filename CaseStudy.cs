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
    
    public partial class CaseStudy
    {
        public int CaseID { get; set; }
        public string VillageName { get; set; }
        public string ReporterName { get; set; }
        public string ReporterPhone { get; set; }
        public Nullable<int> FamilyClass { get; set; }
        public string PartnerName { get; set; }
        public string PartnerNID { get; set; }
        public string Address { get; set; }
        public Nullable<int> Breadwinner { get; set; }
        public string Job { get; set; }
        public Nullable<int> EducationState { get; set; }
        public Nullable<int> ChildrenNo { get; set; }
        public Nullable<int> ChildrenInEducationNo { get; set; }
        public Nullable<int> TravelledOrMarriedChildrenNo { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Target { get; set; }
        public string ReviewerOpinion { get; set; }
        public string VolunteerID { get; set; }
        public Nullable<int> WaterFees { get; set; }
        public Nullable<int> ElectricityFees { get; set; }
        public Nullable<int> InstallmentsFees { get; set; }
        public Nullable<int> DrugsFees { get; set; }
        public Nullable<int> RentFees { get; set; }
        public Nullable<int> OtherFees { get; set; }
        public Nullable<int> MonthlySalary { get; set; }
        public Nullable<int> DailySalary { get; set; }
        public Nullable<int> InsuranceIncome { get; set; }
        public Nullable<int> SocitiesIncome { get; set; }
        public Nullable<int> MaashIncome { get; set; }
        public Nullable<int> OtherIncome { get; set; }
        public string LandsOwned { get; set; }
        public string AnimalsOwned { get; set; }
        public string BirdsOwned { get; set; }
        public string OtherOwned { get; set; }
        public string DevicesOwned { get; set; }
        public Nullable<int> RoomsNo { get; set; }
        public Nullable<int> HouseType { get; set; }
        public Nullable<int> WallsType { get; set; }
        public Nullable<int> RoofType { get; set; }
        public string Floor { get; set; }
        public Nullable<bool> HasWaterLine { get; set; }
        public Nullable<bool> HasElectLine { get; set; }
        public Nullable<bool> HasSarfLine { get; set; }
        public string OtherLines { get; set; }
        public string Comments { get; set; }
        public Nullable<int> PoorID { get; set; }
        public Nullable<System.DateTime> ResearchDate { get; set; }
        public string ReviewerName { get; set; }
        public Nullable<bool> IsDeserved { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Poor Poor { get; set; }
    }
}