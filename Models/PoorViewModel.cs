using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Gam3iaWeb.Models
{
    public class PoorViewModel
    {
        Gam3iaEntities context = new Gam3iaEntities();
        [Key]
        public int ID { get; set; }
        [Display(Name = "رقم بطاقة الحاله")]
        public string PoorNID { get; set; }
        [Display(Name = "اسم الحاله")]
        public string PoorName { get; set; }
        [Display(Name = "تاريخ تسجيل الحاله")]
        [DataType(DataType.Date)]
        public Nullable<DateTime>RegisterDate { get; set; }
        [Display(Name = "البلد")]
        public Nullable<int> CityID { get; set; }
        [Display(Name = "البلد")]
        public string CityName { get; set; }


        public static implicit operator PoorViewModel(Poor poor)
        {
            return new PoorViewModel()
            {
                ID = poor.ID,
                PoorName = poor.PoorName,
                PoorNID = poor.PoorNID,
                RegisterDate=poor.RegisterDate,
                CityID=poor.City.ID,
                CityName=poor.City.CityName
            };

        }

        public static implicit operator Poor(PoorViewModel vm)
        {
            return new Poor()
            {
                ID = vm.ID,
                PoorName = vm.PoorName,
                PoorNID = vm.PoorNID,
                RegisterDate=vm.RegisterDate,
                CityID=vm.CityID
            };
        }

        }
}