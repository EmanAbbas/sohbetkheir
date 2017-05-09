using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Gam3iaWeb.Models
{

    public class CaseStudyViewModel
    {
        Gam3iaEntities context = new Gam3iaEntities();
        [Key]
        public int CaseID { get; set; }
        [Display(Name = "اسم القريه")]
        public string VillageName { get; set; }
        [Display(Name = "اسم الدليل ")]
        public string ReporterName { get; set; }
        [Display(Name = "تليفون الدليل")]
        public string ReporterPhone { get; set; }
        [Display(Name = "تصنيف الأسرة")]
        public IEnumerable<SelectListItem> FamilyClasses
        {
            set
            {

            }
            get
            {
               return  Enum.GetValues(typeof(FamilyClassEnum))
                .Cast<FamilyClassEnum>()
                .Select(p => new SelectListItem()
                {
                    Text = p.ToString(),
                    Value = ((int)p).ToString()
                })
                .ToList();
                
            }
        }
                
          
        [Display(Name = "تصنيف الأسرة")]
        public string FamilyClass { get ; set; }
       
        [Display(Name = "الاسم رباعي  ")]
        public string PoorName { get; set; }
       
        [Display(Name = "رقم البطاقه ")]
        public string PoorNID { get; set; }
        [Display(Name = "اسم الزوج / الزوجة ")]
        public string PartnerName { get; set; }
        [Display(Name = "رقم بطاقة الزوج /الزوجة ")]
        public string PartnerNID { get; set; }
        [Required(ErrorMessage = "يجب إدخال العنوان")]
        [Display(Name = "العنوان ")]
        public string Address { get; set; }
        [Display(Name = "عائل الأسرة")]
        public IEnumerable<SelectListItem> Breadwinners
        {
            set { }
            get
            {
                return Enum.GetValues(typeof(BreadwinnerEnum))
                                                .Cast<BreadwinnerEnum>()
                                                .Select(p => new SelectListItem()
                                                {
                                                    Text = p.ToString(),
                                                    Value = ((int)p).ToString()
                                                })
                                               .ToList();
            }
        }
        [Display(Name = "عائل الأسرة")]
        public string Breadwinner { get; set; }
        [Display(Name = "الوظيفة ")]
        public string Job { get; set; }
        //Html.DropDownListFor(m => m.CityId, Model.cities)
        [Display(Name = "الحاله التعليميه ")]

        public IEnumerable<SelectListItem> EducationStates {
            set { }
            get {
                return Enum.GetValues(typeof(EducationStateEnum))
                                .Cast<EducationStateEnum>()
                                .Select(p => new SelectListItem()
                                {
                                    Text = p.ToString(),
                                    Value = ((int)p).ToString()
                                })
                               .ToList();
            }  }

        [Display(Name = "الحاله التعليميه ")]
        public string EducationState { get; set; }
        [Display(Name = "عدد الأبناء ")]
        public Nullable<int> ChildrenNo { get; set; }
        [Display(Name = "عدد الأبناء في التعليم ")]
        public Nullable<int> ChildrenInEducationNo { get; set; }
        [Display(Name = "عدد الأبناء المتزوجين أو المسافرين ")]
        public Nullable<int> TravelledOrMarriedChildrenNo { get; set; }
        [Required]
        [Display(Name = "التليفون 1 ")]
        public string Telephone1 { get; set; }
        [Display(Name = "التليفون 2 ")]
        public string Telephone2 { get; set; }
        [Display(Name = "المطلوب ")]
        public string Target { get; set; }
        [Display(Name = "رأي الباحث ")]
        public string ReviewerOpinion { get; set; }
        [Display(Name = "المتطوع ")]
        public string VolunteerName { get; set; }
       
        [Display(Name = "أدخل بواسطة المتطوع ")]
        public string VolunteerID { get; set; }
        [Display(Name = "اختر اسم المحتاج   ")]

        List<SelectListItem> Poors { get; set; }
        [Display(Name = "اختر اسم المحتاج ")]
        public int PoorID { get; set; }

        [Display(Name = "مياه ")]

        public Nullable<int> WaterFees { get; set; }
        [Display(Name = "كهرباء ")]
        public Nullable<int> ElectricityFees { get; set; }
        [Display(Name = "أقساط ")]
        public Nullable<int> InstallmentsFees { get; set; }
        [Display(Name = "علاج ")]
        public Nullable<int> DrugsFees { get; set; }
        [Display(Name = "إيجار ")]
        public Nullable<int> RentFees { get; set; }
        [Display(Name = "مصروفات أخري ")]
        public Nullable<int> OtherFees { get; set; }
        [Display(Name = "راتب شهري ")]
        public Nullable<int> MonthlySalary { get; set; }
        [Display(Name = "يوميه ")]
        public Nullable<int> DailySalary { get; set; }
        [Display(Name = "تأمينات ")]
        public Nullable<int> InsuranceIncome { get; set; }
        [Display(Name = "جمعيات ")]
        public Nullable<int> SocitiesIncome { get; set; }
        [Display(Name = "معاش ")]
        public Nullable<int> MaashIncome { get; set; }
        [Display(Name = "دخل آخر ")]
        public Nullable<int> OtherIncome { get; set; }
        [Display(Name = "أراضي  ")]
        public string LandsOwned { get; set; }
        [Display(Name = "أغنام / ماشيه ")]
        public string AnimalsOwned { get; set; }
        [Display(Name = "طيور ")]
        public string BirdsOwned { get; set; }
        [Display(Name = "ممتلكات أخري ")]
        public string OtherOwned { get; set; }
        [Display(Name = "أجهزة ")]
        public string DevicesOwned { get; set; }
        [Display(Name = "عدد الغرف ")]
        public Nullable<int> RoomsNo { get; set; }
        [Display(Name = "نوع المسكن ")]
        public IEnumerable<SelectListItem> HouseTypes {
            set { }
            get
            {
                return Enum.GetValues(typeof(HouseTypeEnum))
                                               .Cast<HouseTypeEnum>()
                                               .Select(p => new SelectListItem()
                                               {
                                                   Text = p.ToString(),
                                                   Value = ((int)p).ToString()
                                               })
                                              .ToList();
            }
        }
        [Display(Name = "نوع المسكن ")]
        public string HouseType { get; set; }
        [Display(Name = "نوع الحوائط ")]
        public IEnumerable<SelectListItem> WallTypes
        {
            set { }
            get
            {
                return Enum.GetValues(typeof(WallTypeEnum))
                                .Cast<WallTypeEnum>()
                                .Select(p => new SelectListItem()
                                {
                                    Text = p.ToString(),
                                    Value = ((int)p).ToString()
                                })
                               .ToList();
            }
        }
        [Display(Name = "نوع الحوائط ")]
        public string WallsType { get; set; }
        [Display(Name = "نوع السقف ")]
        public IEnumerable<SelectListItem> RoofTypes { set { }
        get
            {
                return Enum.GetValues(typeof(RoofTypeEnum))
                                .Cast<RoofTypeEnum>()
                                .Select(p => new SelectListItem()
                                {
                                    Text = p.ToString(),
                                    Value = ((int)p).ToString()
                                })
                               .ToList();
            }
        }
        [Display(Name = "نوع السقف ")]
        public string RoofType { get; set; }
        [Display(Name = "الأرضيه ")]
        public string Floor { get; set; }
        [Display(Name = "عداد مياه ")]
        public bool HasWaterLine { get; set; }
        [Display(Name = "عداد كهرباء ")]
        public bool HasElectLine { get; set; }
        [Display(Name = "صرف صحي ")]
        public bool HasSarfLine { get; set; }
        [Display(Name = "أخرى ")]
        public string OtherLines { get; set; }
        [Display(Name = "تعليقات أخري عن الحاله ")]
        public string Comments { get; set; }
        [Display(Name = "تاريخ البحث ")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ResearchDate { get; set; }
        [Display(Name = "اسم الباحث ")]
        public string ReviewerName { get; set; }
        //public int MyProperty { get; set; }
        [Display(Name = "مستحق؟ ")]
        
        public bool IsDeserved { get; set; }
        [Display(Name = "مستحق؟ ")]

        public string IsDeservedS {
            get
            {
                if (IsDeserved == true) return "نعم";
                else return "لا";
            }
        }


        public static implicit operator CaseStudyViewModel(CaseStudy caseStudy)
        {
            Gam3iaEntities db = new Gam3iaEntities();

            CaseStudy study = (from ss in db.CaseStudy.Include("AspNetUsers")
                               where ss.CaseID == caseStudy.CaseID
                               select ss).FirstOrDefault();
            Poor poor = (from p in db.Poor where p.ID == caseStudy.PoorID select p).FirstOrDefault();

            return new CaseStudyViewModel
            {
                CaseID = study.CaseID,
                VillageName = study.VillageName,
                Address = study.Address,
                Breadwinners = Enum.GetValues(typeof(BreadwinnerEnum))
                                .Cast<BreadwinnerEnum>()
                                .Select(p => new SelectListItem()
                                {
                                    Text = p.ToString(),
                                    Value = ((int)p).ToString()
                                })
                               .ToList(),
                Breadwinner = Enum.GetName(typeof(BreadwinnerEnum), study.Breadwinner.Value),
                ReporterName = study.ReporterName,
                ReporterPhone = study.ReporterPhone,
                PoorName = poor.PoorName,
                PoorNID = poor.PoorNID,
                PartnerNID = study.PartnerNID,
                PartnerName = study.PartnerName,
                ResearchDate = study.ResearchDate,
                ReviewerName = study.ReviewerName,
                Telephone1 = study.Telephone1,
                Telephone2 = study.Telephone2,
                EducationState = Enum.GetName(typeof(EducationStateEnum), study.EducationState.Value),
                EducationStates = Enum.GetValues(typeof(EducationStateEnum))
                                .Cast<EducationStateEnum>()
                                .Select(p => new SelectListItem()
                                {
                                    Text = p.ToString(),
                                    Value = ((int)p).ToString()
                                })
                               .ToList(),
                ChildrenNo = study.ChildrenNo,
                ChildrenInEducationNo = study.ChildrenInEducationNo,
                TravelledOrMarriedChildrenNo = study.TravelledOrMarriedChildrenNo ?? 0,
                FamilyClass = Enum.GetName(typeof(FamilyClassEnum), study.FamilyClass.Value),
                //FamilyClasses = Enum.GetValues(typeof(FamilyClassEnum))
                //                .Cast<FamilyClassEnum>()
                //                .Select(p => new SelectListItem()
                //                {
                //                    Text = p.ToString(),
                //                    Value = ((int)p).ToString()
                //                })
                //               .ToList(),

                Job = study.Job,
                Target = study.Target,
                ReviewerOpinion = study.ReviewerOpinion,
                VolunteerName = study.AspNetUsers.UserName,
                VolunteerID = study.AspNetUsers.Id,
                AnimalsOwned = study.AnimalsOwned ?? "-",
                BirdsOwned = study.BirdsOwned ?? "-",
                LandsOwned = study.LandsOwned ?? "-",
                OtherOwned = study.OtherOwned ?? "-",
                WaterFees = study.WaterFees ?? -1,
                ElectricityFees = study.ElectricityFees ?? -1,
                InstallmentsFees = study.InstallmentsFees ?? -1,
                RentFees = study.RentFees ?? -1,
                DrugsFees = study.DrugsFees ?? -1,
                OtherFees = study.OtherFees ?? -1,
                DevicesOwned = study.DevicesOwned ?? "-",
                MonthlySalary = study.MonthlySalary ?? -1,
                DailySalary = study.DailySalary ?? -1,
                MaashIncome = study.MaashIncome ?? -1,
                SocitiesIncome = study.SocitiesIncome ?? -1,
                OtherIncome = study.OtherIncome ?? -1,
                HasElectLine = study.HasElectLine ?? false,
                HasSarfLine = study.HasSarfLine ?? false,
                HasWaterLine = study.HasWaterLine ?? false,
                OtherLines = study.OtherLines ?? "-",
                Floor = study.Floor,
                HouseType = (Enum.GetName(typeof(HouseTypeEnum), study.HouseType.Value)) ?? "-",
                HouseTypes = (Enum.GetValues(typeof(HouseTypeEnum))
                                .Cast<HouseTypeEnum>()
                                .Select(p => new SelectListItem()
                                {
                                    Text = p.ToString(),
                                    Value = ((int)p).ToString()
                                })
                               .ToList()),
                WallsType = (Enum.GetName(typeof(WallTypeEnum), study.WallsType.Value)) ?? "-",
                WallTypes = Enum.GetValues(typeof(WallTypeEnum))
                                .Cast<WallTypeEnum>()
                                .Select(p => new SelectListItem()
                                {
                                    Text = p.ToString(),
                                    Value = ((int)p).ToString()
                                })
                               .ToList(),
                RoofType = (Enum.GetName(typeof(RoofTypeEnum), study.RoofType.Value)) ?? "-",
                RoofTypes = Enum.GetValues(typeof(RoofTypeEnum))
                                .Cast<RoofTypeEnum>()
                                .Select(p => new SelectListItem()
                                {
                                    Text = p.ToString(),
                                    Value = ((int)p).ToString()
                                })
                               .ToList(),
                RoomsNo = study.RoomsNo ?? -1,
                InsuranceIncome = study.InsuranceIncome ?? -1,
                PoorID = study.PoorID.Value,
                Comments = study.Comments ?? "-",
                IsDeserved = study.IsDeserved ?? false


            };
        }

        public static implicit operator CaseStudy(CaseStudyViewModel vm)
        {
            Gam3iaEntities db = new Gam3iaEntities();
            //Poor poor = (from p in db.Poor where p.ID == vm.PoorID select p).FirstOrDefault();
            //if (usr == null)
            //{

            //}
            CaseStudy study = (from ss in db.CaseStudy.Include("AspNetUsers")
                               where ss.CaseID == vm.CaseID
                               select ss).FirstOrDefault();
            return new CaseStudy
            {
                CaseID = vm.CaseID,
                VillageName = vm.VillageName,
                Address = vm.Address,
                ReviewerName=vm.ReviewerName,
                ResearchDate=vm.ResearchDate,
                Breadwinner = (int?)ParseEnum<BreadwinnerEnum>(vm.Breadwinner),
                //Enum.Parse(typeof(EducationStateEnum), vm.Breadwinner,true),
                ReporterName = vm.ReporterName,
                ReporterPhone = vm.ReporterPhone,
                //PoorName = poor.PoorName,
                //PoorNID = poor.PoorNID,
                PoorID = vm.PoorID,
                PartnerNID = vm.PartnerNID,
                PartnerName = vm.PartnerName,
                Telephone1 = vm.Telephone1,
                Telephone2 = vm.Telephone2,
                EducationState = vm.EducationState!=null?(int?)ParseEnum<EducationStateEnum>(vm.EducationState):0,

                ChildrenNo = vm.ChildrenNo,
                ChildrenInEducationNo = vm.ChildrenInEducationNo,
                TravelledOrMarriedChildrenNo = vm.TravelledOrMarriedChildrenNo,
                FamilyClass = vm.FamilyClass!=null?(int?)ParseEnum<FamilyClassEnum>(vm.FamilyClass):0,

                Job = vm.Job,
                Target = vm.Target,
                ReviewerOpinion = vm.ReviewerOpinion,
                VolunteerID = vm.VolunteerID,
                AnimalsOwned = vm.AnimalsOwned,
                BirdsOwned = vm.BirdsOwned,
                LandsOwned = vm.LandsOwned,
                OtherOwned = vm.OtherOwned,
                WaterFees = vm.WaterFees,
                ElectricityFees = vm.ElectricityFees,
                InstallmentsFees = vm.InstallmentsFees,
                RentFees = vm.RentFees,
                DrugsFees = vm.DrugsFees,
                OtherFees = vm.OtherFees,
                DevicesOwned = vm.DevicesOwned,
                MonthlySalary = vm.MonthlySalary,
                DailySalary = vm.DailySalary,
                MaashIncome = vm.MaashIncome,
                SocitiesIncome = vm.SocitiesIncome,
                OtherIncome = vm.OtherIncome,
                HasElectLine = vm.HasElectLine,
                HasSarfLine = vm.HasSarfLine,
                HasWaterLine = vm.HasWaterLine,
                OtherLines = vm.OtherLines,
                Floor = vm.Floor,
                HouseType = vm.HouseType!=null?(int)ParseEnum<HouseTypeEnum>(vm.HouseType):0,

                WallsType = vm.WallsType!=null?(int?)ParseEnum<WallTypeEnum>(vm.WallsType):0,

                RoofType = vm.RoofType!=null?(int?)ParseEnum<RoofTypeEnum>(vm.RoofType):0,
                
                RoomsNo = vm.RoomsNo,
                InsuranceIncome = vm.InsuranceIncome,

                Comments = vm.Comments,
                IsDeserved=vm.IsDeserved
               

            };
        }
        public static T ParseEnum<T>(string value)
        {
            //if (value != null)
               
            return (T)Enum.Parse(typeof(T), value, true);
            //else
            //    return (T)Enum.Parse(typeof(T), , true);

        }

    }

}