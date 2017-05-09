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
    
    public partial class Loan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Loan()
        {
            this.LoanInstallment = new HashSet<LoanInstallment>();
        }
    
        public int ID { get; set; }
        public string Address { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Telephone3 { get; set; }
        public string Telephone4 { get; set; }
        public Nullable<int> WorkType { get; set; }
        public string WorkAddress { get; set; }
        public string WorkPhone { get; set; }
        public Nullable<int> LoanValue { get; set; }
        public string LoanReason { get; set; }
        public Nullable<System.DateTime> RequestDate { get; set; }
        public Nullable<bool> RequiredPapersSatisfied { get; set; }
        public Nullable<bool> HasSalaryStatement { get; set; }
        public Nullable<int> MonthlyIncome { get; set; }
        public Nullable<System.DateTime> ReceiveDate { get; set; }
        public Nullable<bool> IsMonthlyPayment { get; set; }
        public Nullable<bool> PaymentBehavior { get; set; }
        public Nullable<int> IrregularPaymentReason { get; set; }
        public string GuarantorName { get; set; }
        public string GuarantorAddress { get; set; }
        public string GuarantorPhone1 { get; set; }
        public string GuarantorPhone2 { get; set; }
        public Nullable<int> GuarantorWorkType { get; set; }
        public string GuarantorWorkAddress { get; set; }
        public string GuarantorWorkPhone { get; set; }
        public string GuarantorNID { get; set; }
        public Nullable<bool> GuarantorHasSalaryStatement { get; set; }
        public string VolunteerID { get; set; }
        public Nullable<int> PoorID { get; set; }
        public Nullable<bool> HasCompleted { get; set; }
        public Nullable<bool> HasJudged { get; set; }
        public string Notes { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoanInstallment> LoanInstallment { get; set; }
        public virtual Poor Poor { get; set; }
    }
}