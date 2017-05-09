using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Gam3iaWeb.Models
{
    public enum FamilyClassEnum { غير_متوفر = 0, أيتام = 1, مرضي = 2, فقراء = 3 };


    public enum BreadwinnerEnum
    {
        غير_متوفر = 0, الأب = 1, الأم = 2
    };
    public enum EducationStateEnum
    {
        غير_متوفر = 0, متعلم = 2, أمي = 1
    };
    public enum HouseTypeEnum
    {
        غير_متوفر = 0,
        تمليك = 1, إيجار = 2
            ,أملاك_دوله=4
    };
    public enum WallTypeEnum
    { غير_متوفر=0,
        طوب_أحمر = 1, طوب_ني = 2, بلوك_أبيض=3 
    };
    public enum RoofTypeEnum
    {
        غير_متوفر = 0,
        خرسانة = 1, خشب = 2, جريد=3, بوص=4
    };
    
        public enum WorkTypeEnum
    {
        غير_متوفر = 0,
        مؤقت = 1, ثابت = 2 
    };
    public enum StudentAidTypeEnum
    {
        غير_متوفر = 0,
        نقل = 1,
        أخري = 3, تقديم_جديد = 2
    };
    public enum StudentOtherAidTypeEnum
    {
        غير_متوفر = 0,
        ملابس = 1, أدوات = 2
            ,
        كتب = 3, شهادة = 4
            ,
        أخري = 5
    };

    public enum RegularPayEnum
    {
        [EnumMember(Value = "يتم_السداد_فى_المعاد_كل_مرة")]
        يتم_السداد_فى_المعاد_كل_مرة = 1,
        [EnumMember(Value = "لا_يتم_السداد_الا_بعد_الاتصال_به_اكتر_من_مرة")]
        لا_يتم_السداد_الا_بعد_الاتصال_به_اكتر_من_مرة = 2,
        [EnumMember(Value = " تم_السداد_عن_طريق_المحامى_بعد_رفع_قضية_عليه")]
        تم_السداد_عن_طريق_المحامى_بعد_رفع_قضية_عليه = 3,
        [EnumMember(Value = "تم_السداد_عن_طريق_فاعل_خير")]
        تم_السداد_عن_طريق_فاعل_خير = 4
        

    };

    public enum RequestStatusEnum
    {
         انتظار_كفالة = 1,
        إعادة_بحث = 2,
        تم_كفلها_بانتظام_من_الجمعيه = 3,
        تم_رفض_الطلب = 4,
             تم_إخراج_الحاله_من_الكفالة = 5


    };
    public enum PaymentPlanEnum
    {
        غير_متوفر = 0,
        شهري = 1, سنوي = 2
            ,
        ربع_سنوي = 3, نصف_سنوي = 4
            
    };
}