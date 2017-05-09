using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Gam3iaWeb.Models;
using System.Web.Mvc;

namespace Gam3iaWeb
{
    [MetadataType(typeof(LoanMetadata))]
    public partial class Loan
    {
        [Display(Name = "نوع العمل")]
        public IEnumerable<SelectListItem> WorkTypes
        {
            set { }
            get
            {
                return Enum.GetValues(typeof(WorkTypeEnum))
                                               .Cast<WorkTypeEnum>()
                                               .Select(p => new SelectListItem()
                                               {
                                                   Text = p.ToString(),
                                                   Value = ((int)p).ToString()
                                               })
                                              .ToList();
            }
        }
        [Display(Name = "نوع العمل")]
        public string  WorkTypeString {
            get
            {
                return (Enum.GetName(typeof(WorkTypeEnum), this.WorkType.Value)) ?? "-";
            }
        }

        [Display(Name = "مدي الأنتظام في الدفع")]
        public IEnumerable<SelectListItem> PayRegularReason
        {
            set { }
            get
            {
                return Enum.GetValues(typeof(RegularPayEnum))
                                               .Cast<RegularPayEnum>()
                                               .Select(p => new SelectListItem()
                                               {
                                                   Text = p.ToString(),
                                                   Value = ((int)p).ToString()
                                               })
                                              .ToList();
            }
        }

        [Display(Name = "كود القرض")]
        public string LoanCode
        {
            get
            {
               
                    return "قرض باسم    " + this.PoorName+" " + "بقيمة  " + this.LoanValue;
               

            }
        }
        [Display(Name = "مدي الأنتظام في الدفع")]
        public string PayRegularReasonS
        {
            get
            {
                if (IrregularPaymentReason != null)
                    return (Enum.GetName(typeof(RegularPayEnum), this.IrregularPaymentReason.Value));
                else
                    return "-";
            }
        }
        [Display(Name = "نوع عمل الضامن")]
        public string GWorkTypeString
        {
            get
            {
                if (this.GuarantorWorkType != null)
                    return (Enum.GetName(typeof(WorkTypeEnum), this.GuarantorWorkType.Value));
                else
                    return "-";
            }
        }
        [Display(Name = "اسم المقترض")]
        public string  PoorName { get {
                return this.Poor.PoorName;

            }
        }
        [Display(Name = "هل يوجد مفردات مرتب للضامن؟")]
        public bool GuarantorHasSalaryStatementNotNull
        {
            get { return GuarantorHasSalaryStatement ?? false; }
            set { GuarantorHasSalaryStatement = value; }
        }
        [Display(Name = "نظام دفع شهري؟")]
        public bool MonthlyPaymentNotNull
        {
            get { return IsMonthlyPayment ?? false; }
            set { IsMonthlyPayment = value; }
        }
        //PaymentBehavior
        [Display(Name = "مدي انتظامه في القرض الحالي؟")]
        public bool PaymentBehaviorNotNull
        {
            get { return PaymentBehavior ?? false; }
            set { PaymentBehavior = value; }
        }

        [Display(Name = "هل تم استيفاء الأوراق المطلوبة ؟")]
        public bool RequiredPapersSatisfiedNotNull
        {
            get { return RequiredPapersSatisfied ?? false; }
            set { RequiredPapersSatisfied = value; }
        }
        [Display(Name = "هل يوجد مفردات مرتب للمقترض؟")]
        public bool HasSalaryStatementNotNull
        {
            get { return HasSalaryStatement ?? false; }
            set { HasSalaryStatement = value; }
        }

        [Display(Name = "هل تم استيفاء جميع الأقساط ؟")]
        public bool HasCompletedNotNull {
            get { return HasCompleted ?? false; }
            set { HasCompleted = value; }
        }
        [Display(Name = "تم رفع قضيه عليه؟")]
          public bool HasJudgedNotNull {
            get { return HasJudged ?? false; }
            set { HasJudged = value; }
        }
        [Display(Name = "قيمة الأقساط المتبقيه")]
        public int RemainingInstallments
        {


            get
            {
                Gam3iaEntities db = new Gam3iaEntities();
              
                int? paid_amount = (from i in db.LoanInstallment
                                   where i.LoanID == this.ID
                                   select i.Amount.Value).ToList().Sum();
                if (paid_amount != null)
                    return this.LoanValue.Value - paid_amount.Value;
                else
                    return this.LoanValue.Value;

            }
        }
    }

    [MetadataType(typeof(LoanInstallmentMetadata))]
    public partial class LoanInstallment
    {
        [Display(Name = "اسم المقترض")]
        public string PoorName
        {
            get
            {
                return this.Loan.PoorName;

            }
        }
       
        


        [Display(Name = "قيمة القرض الكليه")]
        public int LoanValue
        {


            get
            {
                Gam3iaEntities db = new Gam3iaEntities();
                Loan l = (from lo in db.Loan where lo.ID == this.LoanID select lo).FirstOrDefault();
                int loanVal = l.LoanValue.Value;
               

                return loanVal;

            }
        }

    }
   

    [MetadataType(typeof(StudentAidMetadata))]
    public partial class StudentAid
    {

        [Display(Name = "سبب المصاريف المطلوبة")]
        public IEnumerable<SelectListItem> AidTypes
        {
            set { }
            get
            {
                return Enum.GetValues(typeof(StudentAidTypeEnum))
                                               .Cast<StudentAidTypeEnum>()
                                               .Select(p => new SelectListItem()
                                               {
                                                   Text = p.ToString(),
                                                   Value = ((int)p).ToString()
                                               })
                                              .ToList();
            }
        }
        [Display(Name = "سبب المصاريف المطلوبة")]
        public string AidTypeString
        {
            get
            {
                if (this.OtherFeesType != null)
                    return (Enum.GetName(typeof(StudentAidTypeEnum), this.RequiredFeesType.Value)) ?? "-";
                else
                    return "-";

            }
        }

        [Display(Name = "سبب المصاريف الأخري")]
        public IEnumerable<SelectListItem> OtherAidTypes
        {
            set { }
            get
            {
                return Enum.GetValues(typeof(StudentOtherAidTypeEnum))
                                               .Cast<StudentOtherAidTypeEnum>()
                                               .Select(p => new SelectListItem()
                                               {
                                                   Text = p.ToString(),
                                                   Value = ((int)p).ToString()
                                               })
                                              .ToList();
            }
        }
        [Display(Name = "سبب المصاريف الأخري")]
        public string OtherAidTypeString
        {
            get
            {
                if (this.OtherFeesType != null)
                    return (Enum.GetName(typeof(StudentOtherAidTypeEnum), this.OtherFeesType.Value)) ?? "-";
                else
                    return "-";
            }
        }
        [Display(Name = "اسم الطالب")]
        public string PoorName
        {
            get
            {
                return this.Poor.PoorName;

            }
        }
        [Display(Name = "اسم المتطوع")]
        public string VolunteerName
        {
            get
            {
                return this.AspNetUsers.UserName;

            }
        }


   }
    [MetadataType(typeof(DonatorMetadata))]
    public partial class Donator
    {


    }
    [MetadataType(typeof(DonationMetaData))]

    public partial class Donation
    {
    }
    [MetadataType(typeof(AspUserMetadata))]
    public partial class AspNetUsers
    {
    }
    [MetadataType(typeof(PhysicalDonationMetadata))]
    public partial class PhysicalDonation
    {
        [Display(Name = "به عيب يمكن إصلاحه؟")]
        public bool CanBeFixedNotNull
        {
            get { return CanBeFixed ?? false; }
            set { CanBeFixed = value; }
        }
        [Display(Name = "تم بيعه؟")]
        public bool IsSelledNotNull
        {
            get { return IsSelled ?? false; }
            set { IsSelled = value; }
        }
        [Display(Name = "تم تسليمه لحاله؟")]
        public bool IsDeliveredNotNull
        {
            get { return IsDelivered ?? false; }
            set { IsDelivered = value; }
        }
    }
    [MetadataType(typeof(GeneralAidMetadata))]
    public partial class GeneralAid
    {
        [Display(Name = "البلد")]
        public string CityName
        {
            get
            {
                return this.Poor.City.CityName;

            }
        }
    }
    [MetadataType(typeof(ProductMetadata))]
    public partial class Product
    {
    }
    [MetadataType(typeof(SponsorshipMetadata))]
    public partial class Sponsorship
    {

        [Display(Name = "حالة الطلب")]
        public IEnumerable<SelectListItem> RequestStatusList
        {
            set { }
            get
            {
                return Enum.GetValues(typeof(RequestStatusEnum))
                                               .Cast<RequestStatusEnum>()
                                               .Select(p => new SelectListItem()
                                               {
                                                   Text = p.ToString(),
                                                   Value = ((int)p).ToString()
                                               })
                                              .ToList();
            }
        }
        [Display(Name = "حالة الطلب")]
        public string RequestStatusString
        {
            get
            {
                return (Enum.GetName(typeof(RequestStatusEnum), this.RequestCase.Value)) ?? "-";
            }
        }

        [Display(Name = "طريقة الدفع")]
        public IEnumerable<SelectListItem> PaymentPlans
        {
            set { }
            get
            {
                return Enum.GetValues(typeof(PaymentPlanEnum))
                                               .Cast<PaymentPlanEnum>()
                                               .Select(p => new SelectListItem()
                                               {
                                                   Text = p.ToString(),
                                                   Value = ((int)p).ToString()
                                               })
                                              .ToList();
            }
        }
        [Display(Name = "طريقة الدفع")]
        public string PaymentPlanString
        {
            get
            {
                return (Enum.GetName(typeof(PaymentPlanEnum), this.PaymentMethodType.Value)) ?? "-";
            }
        }

        [Display(Name = "تم رفض الطلب؟")]
        public bool RequestRejected
        {
            get { return IsRefused ?? false; }
            set { IsRefused = value; }
        }
        [Display(Name = "تم رفض الطلب؟")]
        public string RequestRejectedString
        {
            get
            {
                if (IsRefused == true) return "نعم";
                else return "لا";
            }
        }
        [Display(Name = "له قرض؟")]
        public string HasLoan
        {
            get
            {
                Gam3iaEntities db = new Gam3iaEntities();
                List<Loan> prev_loans = (from l in db.Loan where l.PoorID == this.PoorID && l.HasCompleted != true && l.HasJudged != true select l).ToList();
                if(prev_loans.Count>0)
                {
                    return "نعم";
                }
                else
                {
                    return "لا";
                }
            }
        }
        [Display(Name = "تم وقف الكفالة؟")]
        public bool SponsorshipStopped
        {
            get { return IsStopped ?? false; }
            set { IsStopped = value; }
        }
        [Display(Name = "تم وقف الكفالة؟")]
        public string SponsorshipStoppedString
        {
            get
            {
                if (IsStopped == true) return "نعم";
                else return "لا";
            }
        }
        [Display(Name = "تم تغيير الكفيل؟")]
        public string SponsorChangedString
        {
            get
            {
                if (SposorChanged == true) return "نعم";
                else return "لا";
            }
        }
        //SposorChanged
        [Display(Name = "تم تغيير الكفيل؟")]
        public bool SponsorChanged
        {
            get { return SposorChanged ?? false; }
            set { SposorChanged = value; }
        }

        [Display(Name = "كود الكفالة")]
        public string SposorshipCode
        {
            set { }
            get
            {
                if (this.Poor != null)
                    return "كفاله باسم    " + this.Poor.PoorName + " " + "بقيمة  " + this.Amount;
                else
                    return "لم تحدد بعد";

            }
        }
    }
    [MetadataType(typeof(SponsorshipResearchMetadata))]
    public partial class SponsorshipResearch
    {
        

    }
    [MetadataType(typeof(SponsorshipInstallmentMetadata))]
    public partial class SponsorshipInstallment
    {
        [Display(Name = "تم الإتصال به؟")]
        public string IsCalledString
        {
            get
            {
                if (IsCalled == true) return "نعم";
                else return "لا";
            }
        }
        [Display(Name = "تم تسليمها للحاله؟")]
        public string IsDeliveredString
        {
            get
            {
                if (IsDeliverdToPoor == true) return "نعم";
                else return "لا";
            }
        }
        //SposorChanged
        [Display(Name = "تم الإتصال به؟")]
        public bool IsCalledB
        {
            get { return IsCalled ?? false; }
            set { IsCalled = value; }
        }
        [Display(Name = "تم تسليمها للحاله؟")]
        public bool IsDeliveredB
        {
            get { return IsDeliverdToPoor ?? false; }
            set {IsDeliverdToPoor = value; }
        }
        //NN = not null :)
        [Display(Name = "يناير")]
          public bool JanuaryNN {
            get { return January ?? false; }
            set { January = value; }
        }
        [Display(Name = "فبراير")]
        public bool FebruaryNN {
            get { return February ?? false; }
            set { February = value; }
        }
        [Display(Name = "مارس")]
        public bool MarchNN {
            get { return March ?? false; }
            set { March = value; }
        }
        [Display(Name = "أبريل")]
        public bool AprilNN {
            get { return April ?? false; }
            set { April = value; }
        }
        [Display(Name = "مايو")]
        public bool MayNN {
            get { return May ?? false; }
            set { May = value; }
        }
        [Display(Name = "يونيو")]
        public bool JuneNN {
            get { return June ?? false; }
            set { June = value; }
        }
        [Display(Name = "يوليو")]
        public bool JulyNN {
            get { return July ?? false; }
            set { July = value; }
        }
        [Display(Name = "أغسطس")]
        public bool AugustNN {
            get { return August ?? false; }
            set { August = value; }
        }
        [Display(Name = "سبتمبر")]
        public bool SeptemberNN {
            get { return September ?? false; }
            set { September = value; }
        }
        [Display(Name = "أكتوبر")]
        public bool OctoberNN {
            get { return October ?? false; }
            set { October = value; }
        }
        [Display(Name = "نوفمبر")]
        public bool NovemberNN {
            get { return November ?? false; }
            set { November = value; }
        }
        [Display(Name = "ديسمبر")]
        public bool DecemberNN {
            get { return December ?? false; }
            set { December = value; }
        }
    }
    [MetadataType(typeof (CityMetaData))]
    public partial class City
    {
        
    }
    [MetadataType(typeof(VolunteerMetadata))]
    public partial class Volunteer
    {

    }
    [MetadataType(typeof(SponsorMetadata))]
    public partial class Sponsor
    {


    }

}
