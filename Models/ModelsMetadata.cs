using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Gam3iaWeb.Models
{
   
        public class LoanMetadata
        {
        [Display(Name = "كود القرض")]
        public int ID;
       
        [Display(Name = "البلد/العنوان")]
        public string Address;
        [Display(Name = "التليفون1")]
        public string Telephone1;
        [Display(Name = "التليفون2")]
        public string Telephone2;
        [Display(Name = "التليفون3")]
        public string Telephone3;
        [Display(Name = "التليفون4")]
        public string Telephone4;
        [Display(Name = "ملاحظات")]
        public string Notes;
        [Display(Name = "نوع العمل")]

        public Nullable<int> WorkType;
        //void set(string val) {

        //    WorkType = (int)ParseEnum<WorkTypeEnum>(val);
        //} }

        [Display(Name = "عنوان العمل")]

        public string WorkAddress { get; set; }
        [Display(Name = "تليفون العمل")]
        public string WorkPhone { get; set; }
        //[Display(Name = "الرق القومي للمقترض")]
        [Required (ErrorMessage = "لابد من إدخال قيمة القرض")]
        [Display(Name = "قيمة القرض")]
        public Nullable<int> LoanValue { get; set; }
        [Display(Name = "سبب القرض")]
        public string LoanReason { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "تاريخ الطلب yyyy/mm/dd")]
        public Nullable<System.DateTime> RequestDate { get; set; }
        [Display(Name = "تم استيفاء الأوراق المطلوبه")]
        public Nullable<bool> RequiredPapersSatisfied { get; set; }
        [Display(Name = "؟هل يوجد مفردات مرتب للمقترض")]
        public Nullable<bool> HasSalaryStatement { get; set; }
        [Display(Name = "الدخل الشهري")]
        public Nullable<int> MonthlyIncome { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "تاريخ استلام القرض yyyy/mm/dd") ]
        public Nullable<System.DateTime> ReceiveDate { get; set; }
        [Display(Name = "نظام تسديد شهري؟")]
        public Nullable<bool> IsMonthlyPayment { get; set; }
        [Display(Name = "  ؟منتظم في القرض الحالي")]
        public Nullable<bool> PaymentBehavior { get; set; }
        [Display(Name = " (في حالة غير منتظم) سبب  عدم الانتظام في الدفع")]
        public Nullable<int> IrregularPaymentReason { get; set; }
        [Display(Name = "اسم الضامن")]
        public string GuarantorName { get; set; }
        [Display(Name = "عنوان الضامن")]
        public string GuarantorAddress { get; set; }
        [Display(Name = "تليفون الضامن ")]
        public string GuarantorPhone1 { get; set; }
        [Display(Name = "تليفون الضامن 2")]
        public string GuarantorPhone2 { get; set; }
        [Display(Name = "نوع عمل الضامن")]
        public Nullable<int> GuarantorWorkType { get; set; }
        [Display(Name = "عنوان عمل الضامن")]
        public string GuarantorWorkAddress { get; set; }
        [Display(Name = "تليفون عمل الضامن")]
        public string GuarantorWorkPhone { get; set; }
        [Display(Name = "الرقم القومي للضامن")]
        public string GuarantorNID { get; set; }
        [Display(Name = "هل يوجد مفردات مرتب للضامن")]
      
        public Nullable<bool> GuarantorHasSalaryStatement { get; set; }
        [Display(Name = "اسم المتطوع")]
        public string VolunteerID { get; set; }
        [Display(Name = "اسم المقترض")]
        public Nullable<int> PoorID { get; set; }
        public static T ParseEnum<T>(string value)
        {
            //if (value != null)

            return (T)Enum.Parse(typeof(T), value, true);
            //else
            //    return (T)Enum.Parse(typeof(T), , true);

        }

    }

       public class LoanInstallmentMetadata
       {
        [Display(Name = "كود القسط")]
        public int ID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "تاريخ الدفع yyyy/mm/dd")]
        public Nullable<System.DateTime> DueDate { get; set; }
        [Display(Name = "المبلغ")]
        public Nullable<int> Amount { get; set; }
        [Display(Name = "كود القرض")]
        public Nullable<int> LoanID { get; set; }
        [Display(Name = "اسم المقترض")]
        public Nullable<int> PoorID { get; set; }
        [Display(Name = "ملاحظات")]
        public string Comments { get; set; }

       // public virtual Loan Loan { get; set; }
      }

       public class StudentAidMetadata
        {

        [Display(Name = "السنة الدراسيه")]
        public string StudyYear { get; set; }
        [Display(Name = "اسم المدرسة او الجامعة او المعهد")]
        public string SchoolName { get; set; }
        [Display(Name = "المصاريف المطلوبة للسنة")]
        public Nullable<int> RequiredFeesValue { get; set; }
        [Display(Name = "نوع المصاريف")]
        public Nullable<int> RequiredFeesType { get; set; }
        [Display(Name = "مصاريف اضافية")]
        public Nullable<int> OtherFeesValue { get; set; }
        [Display(Name = "سبب المصاريف الإضافية")]
        public Nullable<int> OtherFeesType { get; set; }
        [Display(Name = "اسم المتطوع")]
        public string VolunteerID { get; set; }
        [Display(Name = "اسم الحاله /ولي الأمر")]
        public Nullable<int> PoorID { get; set; }
        [Display(Name = "عنوان المدرسه/الجامعه")]
        public string SchoolAddress { get; set; }
        [Display(Name = "ملاحظات")]
        public string Notes { get; set; }
        [Display(Name = "اسم الطالب")]
        public string StudentName { get; set; }
    }

    public class DonatorMetadata
    {
        [Required]
        [Display(Name = "اسم المتبرع")]
        public string DonatorName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "رقم  التليفون")]
        public string DonatorPhone { get; set; }
     
        [Display(Name = "العنوان")]
        public string DonatorAddress { get; set; }
     
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }
        [Display(Name = "كلمات دلاليه Tags")]
        public string Tag { get; set; }
        [Display(Name = "ملاحظات")]

        public string Notes { get; set; }
        [Display(Name = "الوظيفه")]
       public string Job { get; set; }
        [Display(Name = "الرقم القومي")]

        public string DonatorNID { get; set; }
        [Display(Name = "تاريخ الإلتحاق ")]
        public DateTime? JoinedAt { get; set; }
    }
    public class DonationMetaData
    {
        [Required]
        [Display(Name = "قيمة التبرع")]
        public Nullable<int> DonationValue { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        [Display(Name = " yyyy/mm/dd تاريخ التبرع")]
        public Nullable<System.DateTime> Date { get; set; }
        //[Required]
        [Display(Name = "اسم المتطوع")]
        public string VolunteerID { get; set; }
        [Required]
        [Display(Name = "اسم المتبرع")]
        public Nullable<int> DonatorID { get; set; }
    }
    public class AspUserMetadata
    {
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }

        [Display(Name = "التليفون")]

        public string PhoneNumber { get; set; }
        [Display(Name = "اسم المستخدم")]
        public string UserName { get; set; }
    }
    public class PhysicalDonationMetadata
    {
       
        [Display(Name = "نوع التبرع(ملابس - أخري ..)")]
        public string DonationType { get; set; }
        [Display(Name = "اسم الجهاز")]
        public string DeviceName { get; set; }
        [Display(Name = "حالة الجهاز")]
        public string  DeviceState { get; set; }
        [Display(Name = "به عيب مكن إصلاحه ؟")]
        public Nullable<bool> CanBeFixed { get; set; }
        [Display(Name = "تكاليف التصليح")]
        public Nullable<int> FixFees { get; set; }
        //[Display(Name = "مستلم التبرع")]
        //public string DonationReceiverName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = " تاريخ استلام الجمعيه للتبرع")]
        public Nullable<System.DateTime> ReceiveDate { get; set; }
        
        [Display(Name = "تم بيعه؟")]
        public Nullable<bool> IsSelled { get; set; }
        [Display(Name = "تم تسليمه")]
        public Nullable<bool> IsDelivered { get; set; }
        [Display(Name = "ثمن البيع")]
        public Nullable<int> SellPrice { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "تاريخ البيع")]
        public Nullable<System.DateTime> SellDate { get; set; }
        [Display(Name = "اسم المتطوع")]
        public string VolunteerID { get; set; }
        [Display(Name = "اسم المتبرع")]
        public Nullable<int> DonatorID { get; set; }
        [Display(Name = "اسم مستلم التبرع(في حالة تسليمه)")]
        public Nullable<int> PoorID { get; set; }

    }

    public class GeneralAidMetadata
    {
        [Display(Name = "ملاحظات")]
        public string Comment { get; set; }
        [Display(Name = "اسم الحاله")]
        public Nullable<int> PoorID { get; set; }
        [Display(Name = "اسم المساعدة")]
        public Nullable<int> ServiceID { get; set; }
        [Display(Name = "مدخل البيانات")]
        public string VolunteerID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "تاريخ الإستلام")]
        public Nullable<System.DateTime> ReceiveDate { get; set; }
        [Display(Name = " قيمة المساعدة الماديه")]
        public Nullable<int> Value { get; set; }
        [Display(Name = "كلمات دلاليه Tag")]
        public string Tag { get; set; }
    }
    
    public class ProductMetadata
    {
        [Display(Name = "اسم المنتج")]
        public string ProductName { get; set; }
        [Display(Name = "الكميه")]
        public Nullable<int> Quantity { get; set; }
        [Display(Name = "السعر الكلي")]
        public Nullable<int> TotalPrice { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "تاريخ البيع")]
        public Nullable<System.DateTime> SellDate { get; set; }
        [Display(Name = "مدخل البيانات")]
        public string VolunteerID { get; set; }
    }
    public class SponsorshipMetadata
    {
        [Display(Name = "حالة الطلب")]
        public Nullable<int> RequestCase { get; set; }
        [Display(Name = "مستلم الطلب")]
        public string RequestReceiver { get; set; }
        [Display(Name = "مسئول متابعة الطلب")]
        public string RequestFollowHolder { get; set; }
        [Display(Name = "مبلغ الكفالة")]
        public Nullable<int> Amount { get; set; }
        [Display(Name = "طريقة الدفع")]
        public Nullable<int> PaymentMethodType { get; set; }
        [Display(Name = "اسم الوسيط")]
        public string WaseetName { get; set; }
        [Display(Name = "رقم تليفون الوسيط")]
        public string WaseetPhone { get; set; }
        [Display(Name = "هل تم تغيير الكفيل")]
        public Nullable<bool> SposorChanged { get; set; }
        [Display(Name = "اسم الكفيل القديم")]
        public string OldSponsorName { get; set; }
        [Display(Name = "اسم الكفيل الجديد")]
        public string NewSponsorName { get; set; }
        [Display(Name = "سبب تغيير الكفيل")]
        public string ReasonOfChange { get; set; }
        [Display(Name = "تم وقف الكفاله؟")]
        public Nullable<bool> IsStopped { get; set; }
        [Display(Name = "تاريخ وقف الكفاله")]
        public Nullable<System.DateTime> StopDate { get; set; }
        [Display(Name = "سبب توقف الكفالة")]
        public string StopReason { get; set; }
        [Display(Name = "مدخل البيانات")]
        public string VolunteerID { get; set; }
        [Display(Name = "سبب رفض الكفالة")]
        public string RefuseReason { get; set; }
        [Display(Name = "تم رفض الطلب؟")]
        public Nullable<bool> IsRefused { get; set; }
        [Display(Name = "اسم طالب الكفالة")]
        public Nullable<int> PoorID { get; set; }
        [Display(Name = "اسم الكفيل")]
        public Nullable<int> SponsorID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "تاريخ طلب الكفالة")]
        public Nullable<System.DateTime> RequestDate { get; set; }
        [Display(Name = "الدخل")]
        
        public Nullable<int> Income { get; set; }
        [Display(Name = "مصدر الدخل")]
        public string IncomeSource { get; set; }
    }
    public class SponsorshipResearchMetadata
    {
        [Display(Name = "اسم الباحث")]
        public string ResearcherName { get; set; }
        [Display(Name = "تاريخ البحث ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ResearchDate { get; set; }
        [Display(Name = "رد الباحث")]
        public string ResearchResponse { get; set; }
        [Display(Name = "نتيجة البحث")]
        public string ResearchResults { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "تاريخ بدء الكفالة")]
        public Nullable<System.DateTime> SponsorshipStartDate { get; set; }
        [Display(Name = "ملاحظات")]
        public string Comments { get; set; }
        [Display(Name = "مدخل البيانات")]
        public string VolunteerID { get; set; }
        [Display(Name = "اسم الحالة")]
        public Nullable<int> PoorID { get; set; }
    }
    public class SponsorshipInstallmentMetadata
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "تاريخ الدفع")]
        public Nullable<System.DateTime> DueDate { get; set; }
        [Display(Name = "المبلغ")]
        public string Amount { get; set; }
        [Display(Name = "هل تم الإتصال به؟")]
        public Nullable<bool> IsCalled { get; set; }
        [Display(Name = "اسم المتصل")]
        public string CallerName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "تاريخ الاتصال")]
        public Nullable<System.DateTime> CallDate { get; set; }
        [Display(Name = "هل تم تسليمها للحاله؟")]
        public Nullable<bool> IsDeliverdToPoor { get; set; }
        [Display(Name = "تاريخ التسليم")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DeliveryDate { get; set; }
        [Display(Name = "الكفالة")]
        public Nullable<int> SposorshipID { get; set; }
        [Display(Name = "اسم الكفيل")]
        public Nullable<int> SponsorID { get; set; }
        [Display(Name = "يناير")]
        public Nullable<bool> January { get; set; }
        [Display(Name = "فبراير")]
        public Nullable<bool> February { get; set; }
        [Display(Name = "مارس")]
        public Nullable<bool> March { get; set; }
        [Display(Name = "أبريل")]
        public Nullable<bool> April { get; set; }
        [Display(Name = "مايو")]
        public Nullable<bool> May { get; set; }
        [Display(Name = "يونيو")]
        public Nullable<bool> June { get; set; }
        [Display(Name = "يوليو")]
        public Nullable<bool> July { get; set; }
        [Display(Name = "أغسطس")]
        public Nullable<bool> August { get; set; }
        [Display(Name = "سبتمبر")]
        public Nullable<bool> September { get; set; }
        [Display(Name = "أكتوبر")]
        public Nullable<bool> October { get; set; }
        [Display(Name = "نوفمبر")]
        public Nullable<bool> November { get; set; }
        [Display(Name = "ديسمبر")]
        public Nullable<bool> December { get; set; }
        [Display(Name = "السنه")]
        public string Year { get; set; }
       
    }


    public class CityMetaData
    {
        [Display(Name = "البلد")]
        public int ID { get; set; }
        [Display(Name = "اسم البلد")]
        public string CityName { get; set; }
    }
    public class SponsorMetadata
    {
        [Required]
        [Display(Name = "اسم الكفيل")]
        public string SponsorName { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "رقم  التليفون")]
        public string SponsorPhone { get; set; }

        [Display(Name = "العنوان")]
        public string SponsorAddress { get; set; }

        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }
        
        [Display(Name = "ملاحظات")]

        public string Notes { get; set; }
        [Display(Name = "الوظيفه")]
        public string Job { get; set; }
        [Display(Name = "الرقم القومي")]

        public string SponsorNID { get; set; }
        [Display(Name = "تاريخ الإلتحاق ")]
        public DateTime? JoinedAt { get; set; }
    }

    public class VolunteerMetadata
    {
        
        [Display(Name = "اسم المتطوع")]
        public string VolunteerName { get; set; }
        [Display(Name = "الوظيفه")]
        public string Job { get; set; }
        [Display(Name = "البريد الإلكتروني")]
        public string Email { get; set; }
        [Display(Name = "ملاحظات")]
        public string Notes { get; set; }
        [Display(Name = "التليفونات")]
        public string Telephone { get; set; }
    }
}
